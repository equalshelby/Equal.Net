namespace Equal.CRUD.Dao
{
    /// <summary>
    /// SqlMap常量
    /// </summary>
    public class SqlMapConstants
    {
        #region Select

        /// <summary>
        /// Select语句Id
        /// </summary>
        public const string SelectStatementId = "Select";

        /// <summary>
        /// SelectTop语句Id
        /// </summary>
        public const string SelectTopStatementId = "SelectTop";

        /// <summary>
        /// SelectCount语句Id
        /// </summary>
        public const string SelectCountStatementId = "SelectCount";

        /// <summary>
        /// SelectByPage语句Id
        /// </summary>
        public const string SelectByPageStatementId = "SelectByPage";


        #endregion

        #region Insert Update Delete Truncate

        /// Insert语句Id
        /// </summary>
        public const string InsertStatementId = "Insert";

        /// <summary>
        /// Update语句Id
        /// </summary>
        public const string UpdateStatementId = "Update";

        /// <summary>
        /// Delete语句Id
        /// </summary>
        public const string DeleteStatementId = "Delete";

        /// <summary>
        /// Truncate语句Id
        /// </summary>
        public const string TruncateStatementId = "Truncate";

        #endregion

        #region KeyWords

        /// <summary>
        /// SelectTop中查询记录数参数名
        /// </summary>
        public const string TopCountParam = "TopCount";

        /// <summary>
        /// OrderBy参数名
        /// </summary>
        public const string OrderByParam = "OrderBy";

        /// <summary>
        /// Id参数名
        /// </summary>
        public const string IdParam = "Id";

        /// <summary>
        /// Ids参数名
        /// </summary>
        public const string IdsParam = "Ids";

        #endregion
    }
}
