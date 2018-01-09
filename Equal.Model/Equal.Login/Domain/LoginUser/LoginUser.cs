using Equal.CRUD.Domain;
using System;

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

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// 权限
        /// </summary>
        public string PermissionData { get; set; }

        /// <summary>
        /// 下次登录需修改密码
        /// </summary>
        public bool ChangePasswordNextTime { get; set; }

        /// <summary>
        /// 禁止修改密码
        /// </summary>
        public bool DisableChangePassword { get; set; }

    }
}
