using Equal.CRUD.Domain;
using Equal.Utility;

namespace Model.Domain
{
    /// <summary>
    /// 主页信息
    /// </summary>
    public class HomePageInfo : DomainBase<long>
    {
        public HomePageInfo()
        {
            Id = SnowFlake.GetNewId();
        }

        /// <summary>
        /// 欢迎语
        /// </summary>
        public string Welcome { get; set; }

        /// <summary>
        /// 列表1名称
        /// </summary>
        public string List1Name { get; set; }

        /// <summary>
        /// 列表2名称
        /// </summary>
        public string List2Name { get; set; }

        /// <summary>
        /// 列表3名称
        /// </summary>
        public string List3Name { get; set; }

        /// <summary>
        /// 列表4名称
        /// </summary>
        public string List4Name { get; set; }

        /// <summary>
        /// 企业邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 企业地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 电话1
        /// </summary>
        public string Phone1 { get; set; }

        /// <summary>
        /// 电话2
        /// </summary>
        public string Phone2 { get; set; }

        /// <summary>
        /// 版权信息
        /// </summary>
        public string CopyrightInfo { get; set; }
    }
}

