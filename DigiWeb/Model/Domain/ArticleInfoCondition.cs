using System;

using Equal.CRUD.Domain;

namespace Model.Domain
{
    /// <summary>
    /// 文章信息查询条件类
    /// </summary>
    [Serializable]
    public class ArticleInfoCondition : ICondition
    {
        #region Type
        /// <summary>
        /// Type
        /// </summary>
        public bool ByType { get; set; }

        private ArticleInfoEnum _type;

        /// <summary>
        /// Type
        /// </summary>
        public ArticleInfoEnum Type
        {
            get { return _type; }
            set { _type = value; ByType = true; }
        }
        #endregion
    }
}
