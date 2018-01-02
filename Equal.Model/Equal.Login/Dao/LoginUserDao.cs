using System.Collections;

using Equal.CRUD.Dao;
using Equal.CRUD.Domain;
using Equal.Login.Domain;
using Equal.Login.IDao;

using IBatisNet.DataMapper;

namespace Equal.Login.Dao
{
    /// <summary>
    /// 用户登录Dao
    /// </summary>
    public class LoginUserDao : DaoBase<LoginUser, long>, ILoginUserDao
    {
        public LoginUserDao(ISqlMapper sqlMapper) : base(sqlMapper)
        {
        }

        public override Hashtable CreateConditionHashtable(ICondition condition)
        {
            Hashtable ht = new Hashtable();

            if (condition == null || !(condition is LoginUserCondition))
                return ht;

            LoginUserCondition cond = (LoginUserCondition)condition;

            return ht;
        }
    }
}
