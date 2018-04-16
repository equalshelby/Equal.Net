using System.Collections;
using Equal.CRUD.Dao;
using Equal.CRUD.Domain;

using Model.Domain;
using Model.IDao;

using IBatisNet.DataMapper;

namespace Model.Dao
{
    /// <summary>
    /// 主页信息Dao
    /// </summary>
    public class HomePageInfoDao : DaoBase<HomePageInfo, long>, IHomePageInfoDao
    {
        public HomePageInfoDao(ISqlMapper sqlMapper) : base(sqlMapper)
        {
        }

        public override Hashtable CreateConditionHashtable(ICondition condition)
        {
            Hashtable ht = new Hashtable();

            if (condition == null || !(condition is HomePageInfoCondition))
                return ht;

            HomePageInfoCondition cond = (HomePageInfoCondition)condition;

            return ht;
        }
    }
}
