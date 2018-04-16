using Equal.CRUD.IDao;

using Model.Domain;

namespace Model.IDao
{
    /// <summary>
    /// 文章信息IDao
    /// </summary>
    public interface IArticleInfoDao : IDaoBase<ArticleInfo, long>
    {
    }
}
