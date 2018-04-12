using Castle.Facilities.IBatisNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Equal.CRUD.Domain;
using Equal.Login.Domain;
using Equal.Login.IDao;
using Equal.Utility;

namespace Equal.Login.Svc
{
    [Transactional]
    public class LoginUserSvc
    {
        private static readonly object _lock = new object();

        protected ILoginUserDao _loginUserDao;

        public LoginUserSvc(ILoginUserDao loginUserDao)
        {
            _loginUserDao = loginUserDao;
        }

        /// <summary>
        /// 校验用户名密码
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>LoginUser</returns>
        [Transaction]
        public virtual LoginUser VerifyLoginUser(string username, string password)
        {
            lock (_lock)
            {
                LoginUser user = _loginUserDao.Select(new LoginUserCondition { LoginName = username.Trim() }).FirstOrDefault();
                if (user == null)
                    throw new ValidationException("该用户名不存在。");

                if (user.LoginPassWord != password.Trim())
                    throw new ValidationException("密码有误。");

                if (user.Disabled)
                    throw new ValidationException("此用户被禁止登录。");

                return user;
            }
        }
    }
}
