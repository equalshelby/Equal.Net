using Equal.CRUD.Domain;

namespace Equal.Login.Domain
{
    /// <summary>
    /// 合作单位用户
    /// </summary>
    public class Employee : DomainBase<int>
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string LoginName { get; set; }

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
