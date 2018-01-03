using Equal.CRUD.Domain;

namespace Equal.Login.Domain
{
    /// <summary>
    /// 普通用户
    /// </summary>
    public class CommonUser : DomainBase<int>
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
        /// 移动员工编号
        /// </summary>
        public string EmployeeNumber { get; set; }

        /// <summary>
        /// 工作状态
        /// </summary>
        public UserWorkingState WorkingState { get; set; }
    }
}
