using System;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Collections.Specialized;

using Equal.Login.Domain;
using Equal.Login.IDao;
using Equal.Utility;
using Equal.DDD;

namespace Equal.Login.Svc
{
    /// <summary>
    /// 登录帮助类
    /// </summary>
    public class LoginHelper
    {
        /// <summary>
        /// 登录，每次登录操作时会重新生成令牌
        /// </summary>
        /// <param name="loginType">登录人类型</param>
        /// <param name="loginId">登录人ID</param>
        /// <param name="remember">是否记住令牌</param>
        /// <param name="expireTime">令牌过期时间</param>
        public static void Login(string loginType, string loginId, bool remember, DateTime? expireTime = null)
        {
            DateTime expTime = DateTime.Now;
            if (remember)
            {
                //令牌默认过期时间为一个月，可以将当前loginType及loginId的其他令牌设为无效
                if (!expireTime.HasValue)
                    expTime = DateTime.Now.AddMonths(1);
                else
                    expTime = expireTime.Value;
            }
            //生成令牌
            LoginToken loginToken = CreateLoginToken(loginType, loginId, expTime);
            //保存登录令牌到Session
            HttpContext.Current.Session[WebLoginConstants.LoginTokenSession] = loginToken;

            //保存登录令牌到Cookies，设置Cookies不过期
            HttpContext.Current.Response.Cookies[WebLoginConstants.LoginTokenCookies].Value = loginToken.Id.ToString();
            HttpContext.Current.Response.Cookies[WebLoginConstants.LoginTokenCookies].Expires = DateTime.MaxValue;
        }

        /// <summary>
        /// 注销
        /// </summary>
        public static void Logout()
        {
            //设置Session为Cancels
            HttpContext.Current.Session.Abandon();

            //设置登录令牌无效
            if (HttpContext.Current.Request.Cookies[WebLoginConstants.LoginTokenCookies] != null)
            {
                string token = HttpContext.Current.Request.Cookies[WebLoginConstants.LoginTokenCookies].Value;
                LoginToken loginToken = IocContainer.Get<ILoginTokenDao>().SelectById(token.ToLongOrDefault());
                if (loginToken != null)
                {
                    loginToken.Invalid = true;
                    IocContainer.Get<ILoginTokenDao>().Update(loginToken);
                }
            }
        }

        /// <summary>
        /// 登录并生成令牌
        /// </summary>
        /// <param name="loginType">登录人类型</param>
        /// <param name="loginId">登录人ID</param>
        /// <param name="expireTime">令牌过期时间</param>
        public static LoginToken CreateLoginToken(string loginType, string loginId, DateTime? expireTime)
        {
            LoginToken loginToken = new LoginToken();
            loginToken.LoginType = loginType;
            loginToken.LoginId = loginId;
            loginToken.CreateTime = DateTime.Now;
            loginToken.ExpireTime = expireTime;
            loginToken.Invalid = false;
            IocContainer.Get<ILoginTokenDao>().Insert(loginToken);
            //新创建LoginToken时记录LoginSequence
            RecordLoginSequence(loginToken.Id.ToString());
            return loginToken;
        }

        /// <summary>
        /// 取当前登录用户的有效登录令牌（未失效及过期），如无返回null
        /// </summary>
        /// <returns></returns>
        public static LoginToken GetLoginToken()
        {
            LoginToken loginToken;
            if (TryGetLoginToken(out loginToken))
                return loginToken;

            return null;
        }

        /// <summary>
        /// 取登录令牌
        /// 可以为空
        /// </summary>
        /// <param name="loginTokenId">登录令牌Id</param>
        /// <returns></returns>
        public static LoginToken GetLoginToken(string loginTokenId)
        {
            if (string.IsNullOrEmpty(loginTokenId))
                return null;
            return IocContainer.Get<ILoginTokenDao>().Select111(loginTokenId.ToLongOrDefault());
        }

        /// <summary>
        /// 取登录令牌，如为空抛出异常
        /// </summary>
        /// <param name="loginTokenId">登录令牌Id</param>
        /// <returns></returns>
        public static LoginToken GetLoginTokenReq(string loginTokenId)
        {
            LoginToken loginToken = GetLoginToken(loginTokenId);
            if (loginToken == null)
                throw new LoginTokenNotFoundException("未查询到登录令牌。");
            return loginToken;
        }

        /// <summary>
        /// 恢复登录令牌
        /// 1、先从Session中恢复（LoginToken对象）
        /// 2、若Session中没有，则从Cookies中恢复（LoginToken的Id）
        /// </summary>
        /// <param name="loginToken"></param>
        /// <returns></returns>
        public static bool TryGetLoginToken(out LoginToken loginToken)
        {
            loginToken = null;
            //从Session中恢复登录令牌
            if (HttpContext.Current.Session[WebLoginConstants.LoginTokenSession] != null)
            {
                loginToken = (LoginToken)HttpContext.Current.Session[WebLoginConstants.LoginTokenSession];
                return true;
            }

            //当Session中没有令牌时，从Cookies中恢复登录令牌
            if (HttpContext.Current.Request.Cookies[WebLoginConstants.LoginTokenCookies] != null)
            {
                string loginTokenId = HttpContext.Current.Request.Cookies[WebLoginConstants.LoginTokenCookies].Value;
                loginToken = GetLoginToken(loginTokenId);

                //登录令牌为空
                if (loginToken == null)
                    return false;

                //登录令牌失效
                if (loginToken.Invalid)
                    return false;

                //登录令牌过期
                if (loginToken.ExpireTime.HasValue && loginToken.ExpireTime.Value < DateTime.Now)
                    return false;

                //当Session失效（重新启动浏览器或Session过期），但LoginToken未失效的情况下，记录一次LoginSequence
                RecordLoginSequence(loginTokenId);

                //将登录令牌保存在Session中
                HttpContext.Current.Session[WebLoginConstants.LoginTokenSession] = loginToken;
                return true;
            }
            //Session或Cookies内都没有
            return false;
        }

        /// <summary>
        /// 记录登录序列
        /// </summary>
        /// <param name="loginTokenId">登录令牌Id</param>
        public static void RecordLoginSequence(string loginTokenId)
        {
            string ip = string.Empty;
            string serverVariables = string.Empty;
            if (HttpContext.Current != null)
            {
                NameValueCollection coll = HttpContext.Current.Request.ServerVariables;
                if (coll.AllKeys.Contains("REMOTE_HOST"))
                    ip = coll["REMOTE_HOST"];
                XElement x = new XElement("ServerVariables");
                foreach (string name in coll)
                    x.Add(new XElement(name, HttpContext.Current.Request.ServerVariables[name]));
                serverVariables = x.ToString();
            }

            LoginSequence loginSequence = new LoginSequence();
            loginSequence.LoginTokenId = loginTokenId;
            loginSequence.LoginTime = DateTime.Now;
            loginSequence.IP = ip;
            loginSequence.ServerVariables = serverVariables;
            IocContainer.Get<ILoginSequenceDao>().Insert(loginSequence);
        }
    }
}
