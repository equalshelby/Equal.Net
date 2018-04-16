using System.Collections;

using Equal.CRUD.Dao;
using Equal.CRUD.Domain;

using Model.Domain;
using Model.IDao;

using IBatisNet.DataMapper;

namespace Model.Dao
{
    /// <summary>
    /// 文章信息Dao
    /// </summary>
    public class ArticleInfoDao : DaoBase<ArticleInfo, long>, IArticleInfoDao
    {
        public ArticleInfoDao(ISqlMapper sqlMapper) : base(sqlMapper)
        {
        }

        public override Hashtable CreateConditionHashtable(ICondition condition)
        {
            Hashtable ht = new Hashtable();

            if (condition == null || !(condition is ArticleInfoCondition))
                return ht;

            ArticleInfoCondition cond = (ArticleInfoCondition)condition;
            if (cond.ByType)
                ht.Add("Type", cond.Type);
            return ht;
        }
    }
}
