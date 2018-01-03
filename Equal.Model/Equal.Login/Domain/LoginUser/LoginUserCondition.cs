using System;

using Equal.CRUD.Domain;

namespace Equal.Login.Domain
{
    /// <summary>
    /// 用户登录查询条件类
    /// </summary>
    [Serializable]
    public class LoginUserCondition : ICondition
    {
        #region LoginName
        /// <summary>
        /// 是否根据登录名查询
        /// </summary>
        public bool ByLoginName { get; set; }

        private string _loginName;

        /// <summary>
        /// 要查询的登录名
        /// </summary>
        public string LoginName
        {
            get { return _loginName; }
            set { _loginName = value; ByLoginName = true; }
        }
        #endregion
    }
}
