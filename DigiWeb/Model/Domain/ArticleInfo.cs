using Equal.CRUD.Domain;
using Equal.Utility;

namespace Model.Domain
{
    /// <summary>
    /// 文章信息
    /// </summary>
    public class ArticleInfo : DomainBase<long>
    {
        public ArticleInfo()
        {
            Id = SnowFlake.GetNewId();
        }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public string SubmitTime { get; set; }

        /// <summary>
        /// 发布者
        /// </summary>
        public string SubmitUser { get; set; }

        /// <summary>
        /// 发布内容
        /// </summary>
        public string Context { get; set; }

        /// <summary>
        /// 文章类型
        /// </summary>
        public ArticleInfoEnum Type { get; set; }

        /// <summary>
        /// 点击量
        /// </summary>
        public int ClickCount { get; set; }

    }
}
