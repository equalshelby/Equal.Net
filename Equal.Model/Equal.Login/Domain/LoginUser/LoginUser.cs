using Equal.CRUD.Domain;

namespace Equal.Login.Domain
{
    /// <summary>
    /// 用户登录
    /// </summary>
    public class LoginUser : DomainBase<long>
    {
        /// <summary>
        /// 登录用户名
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string LoginPassWord { get; set; }

        /// <summary>
        /// 登录用户类别
        /// </summary>
        public LoginType LoginType { get; set; }


    }
}
