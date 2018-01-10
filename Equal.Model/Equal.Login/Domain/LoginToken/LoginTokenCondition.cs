using System;

using Equal.CRUD.Domain;

namespace Equal.Login.Domain
{
    /// <summary>
    /// 登录令牌查询条件类
    /// </summary>
    [Serializable]
    public class LoginTokenCondition : ICondition
    {
        #region IdContain
        /// <summary>
        /// 是否根据Id包含关键字查询
        /// </summary>
        public bool ByIdContain { get; set; }

        private string _idContain;

        /// <summary>
        /// 要查询的Id包含关键字
        /// </summary>
        public string IdContain
        {
            get { return _idContain; }
            set { _idContain = value; ByIdContain = true; }
        }
        #endregion

        #region LoginType
        /// <summary>
        /// 是否根据登录用户类型查询
        /// </summary>
        public bool ByLoginType { get; set; }

        private string _loginType;

        /// <summary>
        /// 要查询的登录用户类型
        /// </summary>
        public string LoginType
        {
            get { return _loginType; }
            set { _loginType = value; ByLoginType = true; }
        }
        #endregion

        #region LoginId
        /// <summary>
        /// 是否根据登录用户Id
        /// </summary>
        public bool ByLoginId { get; set; }

        private string _loginId;

        /// <summary>
        /// 要查询的登录用户Id
        /// </summary>
        public string LoginId
        {
            get { return _loginId; }
            set { _loginId = value; ByLoginId = true; }
        }
        #endregion

        #region LoginIdContain
        /// <summary>
        /// 是否根据登录用户Id包含关键字查询
        /// </summary>
        public bool ByLoginIdContain { get; set; }

        private string _loginIdContain;

        /// <summary>
        /// 要查询的登录用户Id包含关键字
        /// </summary>
        public string LoginIdContain
        {
            get { return _loginIdContain; }
            set { _loginIdContain = value; ByLoginIdContain = true; }
        }
        #endregion

        #region CreateTimeGEQ
        /// <summary>
        /// 是否根据创建时间大于等于查询
        /// </summary>
        public bool ByCreateTimeGEQ { get; set; }

        private DateTime _createTimeGEQ;

        /// <summary>
        /// 要查询的创建时间大于等于的值
        /// </summary>
        public DateTime CreateTimeGEQ
        {
            get { return _createTimeGEQ; }
            set { _createTimeGEQ = value; ByCreateTimeGEQ = true; }
        }
        #endregion

        #region CreateTimeLSS
        /// <summary>
        /// 是否根据创建时间小于查询
        /// </summary>
        public bool ByCreateTimeLSS { get; set; }

        private DateTime _createTimeLSS;

        /// <summary>
        /// 要查询的创建时间小于的值
        /// </summary>
        public DateTime CreateTimeLSS
        {
            get { return _createTimeLSS; }
            set { _createTimeLSS = value; ByCreateTimeLSS = true; }
        }
        #endregion

        /// <summary>
        /// 是否失效
        /// </summary>
        public bool? Invalid { get; set; }
    }
}
