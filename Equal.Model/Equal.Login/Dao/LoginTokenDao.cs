using System;
using System.Collections;

using Equal.CRUD.Dao;
using Equal.CRUD.Domain;
using Equal.Login.Domain;
using Equal.Login.IDao;

using IBatisNet.DataMapper;

namespace Equal.Login.Dao
{
    /// <summary>
    /// 登录令牌Dao
    /// </summary>
    public class LoginTokenDao : DaoBase<LoginToken, long>, ILoginTokenDao
    {
        public LoginTokenDao(ISqlMapper sqlMapper) : base(sqlMapper)
        {
        }

        public override Hashtable CreateConditionHashtable(ICondition condition)
        {
            Hashtable ht = new Hashtable();

            if (condition == null || !(condition is LoginTokenCondition))
                return ht;

            LoginTokenCondition cond = (LoginTokenCondition)condition;
            if (cond.ByIdContain)
                ht.Add("Id_Contain", cond.IdContain);

            if (cond.ByLoginType)
                ht.Add("LoginType", cond.LoginType);

            if (cond.ByLoginId)
                ht.Add("LoginId", cond.LoginId);

            if (cond.ByLoginIdContain)
                ht.Add("LoginId_Contain", cond.LoginIdContain);

            if (cond.ByCreateTimeGEQ)
                ht.Add("CreateTime_GEQ", cond.CreateTimeGEQ);

            if (cond.ByCreateTimeLSS)
                ht.Add("CreateTime_LSS", cond.CreateTimeLSS);

            if (cond.Invalid.HasValue)
                ht.Add("Invalid", cond.Invalid.Value);
            return ht;
        }
    }
}
