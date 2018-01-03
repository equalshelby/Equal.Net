using Equal.CRUD.Domain;
using System;

namespace Equal.Login.Domain
{
    /// <summary>
    /// 用户登录
    /// </summary>
    public class LoginUser<T> : DomainBase<long> where T:class
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


        //#region

        //private T _projectId;

        ///// <summary>
        ///// 要查询的所属项目Id
        ///// </summary>
        //public T Object
        //{
        //    get
        //    {
        //        if (_projectId != null)
        //            return _projectId;
        //        return new T();
        //    }
        //    set
        //    {
        //        this.Object=
        //        _projectId = value; 
        //    }
        //}


        //static void InvokeTest(Type t, params object[] args)
        //{
        //    Type type = typeof(Class1<>);
        //    type = type.MakeGenericType(t);
        //    object o = Activator.CreateInstance(type);
        //    type.InvokeMember("Test", BindingFlags.Default | BindingFlags.InvokeMethod, null, o, args);
        //}
        //#endregion


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
