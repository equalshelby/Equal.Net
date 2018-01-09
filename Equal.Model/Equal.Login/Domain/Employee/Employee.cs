using Equal.CRUD.Domain;

namespace Equal.Login.Domain
{
    /// <summary>
    /// 合作单位用户
    /// RelatedDomain_用户类别
    /// RelatedDomainId_用户登录名
    /// </summary>
    public class Employee : RelatedDomainBase<long>
    {
        /// <summary>
        /// 中文名
        /// </summary>
        public string ChineseName { get; set; }

        /// <summary>
		/// 联系电话
		/// </summary>
		public string Mobile { get; set; }

        /// <summary>
		/// 邮箱
		/// </summary>
		public string Email { get; set; }

        /// <summary>
        /// 工作状态
        /// </summary>
        public UserWorkingState WorkingState { get; set; }

    }
}
