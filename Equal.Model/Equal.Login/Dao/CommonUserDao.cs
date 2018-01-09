using System.Collections;

using Equal.CRUD.Dao;
using Equal.CRUD.Domain;
using Equal.Login.Domain;
using Equal.Login.IDao;

using IBatisNet.DataMapper;

namespace Equal.Login.Dao
{
    /// <summary>
    /// 普通用户Dao
    /// </summary>
    public class CommonUserDao : DaoBase<CommonUser, long>, ICommonUserDao
    {
        public CommonUserDao(ISqlMapper sqlMapper) : base(sqlMapper)
        {
        }

        public override Hashtable CreateConditionHashtable(ICondition condition)
        {
            Hashtable ht = new Hashtable();

            if (condition == null || !(condition is CommonUserCondition))
                return ht;

            CommonUserCondition cond = (CommonUserCondition)condition;

            return ht;
        }
    }
}
