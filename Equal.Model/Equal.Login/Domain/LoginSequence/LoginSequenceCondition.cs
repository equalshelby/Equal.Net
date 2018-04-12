using System;

using Equal.CRUD.Domain;

namespace Equal.Login.Domain
{
    /// <summary>
    /// 登录序列查询条件类
    /// </summary>
    [Serializable]
    public class LoginSequenceCondition : ICondition
    {
        #region LoginTokenId
        /// <summary>
        /// 是否根据登录令牌Id查询
        /// </summary>
        public bool ByLoginTokenId { get; set; }

        private string _loginTokenId;

        /// <summary>
        /// 要查询的登录令牌Id
        /// </summary>
        public string LoginTokenId
        {
            get { return _loginTokenId; }
            set { _loginTokenId = value; ByLoginTokenId = true; }
        }
        #endregion

        #region LoginTokenIdContain
        /// <summary>
        /// 是否根据登录令牌Id包含关键字查询
        /// </summary>
        public bool ByLoginTokenIdContain { get; set; }

        private string _loginTokenIdContain;

        /// <summary>
        /// 要查询的登录令牌Id包含关键字
        /// </summary>
        public string LoginTokenIdContain
        {
            get { return _loginTokenIdContain; }
            set { _loginTokenIdContain = value; ByLoginTokenIdContain = true; }
        }
        #endregion

        #region LoginTimeGEQ
        /// <summary>
        /// 是否根据登录时间大于等于查询
        /// </summary>
        public bool ByLoginTimeGEQ { get; set; }

        private DateTime _loginTimeGEQ;

        /// <summary>
        /// 要查询的登录时间大于等于的值
        /// </summary>
        public DateTime LoginTimeGEQ
        {
            get { return _loginTimeGEQ; }
            set { _loginTimeGEQ = value; ByLoginTimeGEQ = true; }
        }
        #endregion

        #region LoginTimeGTR
        /// <summary>
        /// 是否根据登录时间大于查询
        /// </summary>
        public bool ByLoginTimeGTR { get; set; }

        private DateTime _loginTimeGTR;

        /// <summary>
        /// 要查询的登录时间大于的值
        /// </summary>
        public DateTime LoginTimeGTR
        {
            get { return _loginTimeGTR; }
            set { _loginTimeGTR = value; ByLoginTimeGTR = true; }
        }
        #endregion

        #region LoginTimeLEQ
        /// <summary>
        /// 是否根据登录时间小于等于查询
        /// </summary>
        public bool ByLoginTimeLEQ { get; set; }

        private DateTime _loginTimeLEQ;

        /// <summary>
        /// 要查询的登录时间小于等于的值
        /// </summary>
        public DateTime LoginTimeLEQ
        {
            get { return _loginTimeLEQ; }
            set { _loginTimeLEQ = value; ByLoginTimeLEQ = true; }
        }
        #endregion

        #region LoginTimeLSS
        /// <summary>
        /// 是否根据登录时间小于查询
        /// </summary>
        public bool ByLoginTimeLSS { get; set; }

        private DateTime _loginTimeLSS;

        /// <summary>
        /// 要查询的登录时间小于的值
        /// </summary>
        public DateTime LoginTimeLSS
        {
            get { return _loginTimeLSS; }
            set { _loginTimeLSS = value; ByLoginTimeLSS = true; }
        }
        #endregion

        #region IPContain
        /// <summary>
        /// 是否根据IP包含关键字查询
        /// </summary>
        public bool ByIPContain { get; set; }

        private string _ipContain;

        /// <summary>
        /// 要查询的IP包含关键字
        /// </summary>
        public string IPContain
        {
            get { return _ipContain; }
            set { _ipContain = value; ByIPContain = true; }
        }
        #endregion
    }
}
