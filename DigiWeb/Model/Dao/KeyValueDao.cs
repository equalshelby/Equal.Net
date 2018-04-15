using System.Collections;

using Equal.CRUD.Dao;
using Equal.CRUD.Domain;

using IBatisNet.DataMapper;

using Model.Domain;
using Model.IDao;

namespace Model.Dao
{
    public class KeyValueDao : DaoBase<KeyValue, long>, IKeyValueDao
    {
        public KeyValueDao(ISqlMapper sqlMapper) : base(sqlMapper)
        {
        }

        public override Hashtable CreateConditionHashtable(ICondition condition)
        {
            Hashtable ht = new Hashtable();

            if (condition == null || !(condition is KeyValueCondition))
                return ht;

            KeyValueCondition cond = (KeyValueCondition)condition;

            if (cond.ByKey)
                ht.Add("Key", cond.Key);

            if (cond.ByAdditionalData)
                ht.Add("AdditionalData", cond.AdditionalData);

            return ht;
        }
    }
}
