using Equal.CRUD.Domain;

namespace Equal.Login.Domain
{
    /// <summary>
    /// 普通用户
    /// RelatedDomain_用户类别
    /// RelatedDomainId_用户登录名
    /// </summary>
    public class CommonUser : RelatedDomainBase<long>
    {
        /// <summary>
        /// 中文名
        /// </summary>
        public string ChineseName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public Sex? Sex { get; set; }

        /// <summary>
        /// 所属部门
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        public UserJobTitle JobTitle { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 工作状态
        /// </summary>
        public UserWorkingState WorkingState { get; set; }
    }
}
