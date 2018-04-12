using System.Collections;

using Equal.CRUD.Dao;
using Equal.CRUD.Domain;
using Equal.Login.Domain;
using Equal.Login.IDao;

using IBatisNet.DataMapper;

namespace Equal.Login.Dao
{
    /// <summary>
    /// 合作单位用户Dao
    /// </summary>
    public class EmployeeDao : DaoBase<Employee, long>, IEmployeeDao
    {
        public EmployeeDao(ISqlMapper sqlMapper) : base(sqlMapper)
        {
        }

        public override Hashtable CreateConditionHashtable(ICondition condition)
        {
            Hashtable ht = new Hashtable();

            if (condition == null || !(condition is EmployeeCondition))
                return ht;

            EmployeeCondition cond = (EmployeeCondition)condition;

            return ht;
        }
    }
}
