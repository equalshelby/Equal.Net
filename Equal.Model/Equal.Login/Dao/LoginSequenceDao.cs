using System.Collections;

using Equal.CRUD.Dao;
using Equal.CRUD.Domain;
using Equal.Login.Domain;
using Equal.Login.IDao;

using IBatisNet.DataMapper;

namespace Equal.Login.Dao
{
    /// <summary>
    /// 登录序列Dao
    /// </summary>
    public class LoginSequenceDao : DaoBase<LoginSequence, long>, ILoginSequenceDao
    {
        public LoginSequenceDao(ISqlMapper sqlMapper) : base(sqlMapper)
        {
        }

        public override Hashtable CreateConditionHashtable(ICondition condition)
        {
            Hashtable ht = new Hashtable();

            if (condition == null || !(condition is LoginSequenceCondition))
                return ht;

            LoginSequenceCondition cond = (LoginSequenceCondition)condition;

            if (cond.ByLoginTokenId)
                ht.Add("LoginTokenId", cond.LoginTokenId);

            if (cond.ByLoginTokenIdContain)
                ht.Add("LoginTokenId_Contain", cond.LoginTokenIdContain);

            if (cond.ByLoginTimeGEQ)
                ht.Add("LoginTime_GEQ", cond.LoginTimeGEQ);

            if (cond.ByLoginTimeLSS)
                ht.Add("LoginTime_LSS", cond.LoginTimeLSS);

            if (cond.ByIPContain)
                ht.Add("IP_Contain", cond.IPContain);
            return ht;
        }
    }
}
