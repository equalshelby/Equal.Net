using Equal.Utility;

namespace Equal.Login.Domain
{
    /// <summary>
    /// 用户职位
    /// </summary>
    public enum UserJobTitle
    {
        [EnumText("总经理")]
        总经理 = 1,

        [EnumText("副总经理")]
        副总经理 = 2,

        [EnumText("部门经理")]
        部门经理 = 3,

        [EnumText("部门副经理")]
        部门副经理 = 4,

        [EnumText("室经理")]
        室经理 = 5,

        [EnumText("部门成员")]
        部门成员 = 6
    }
}
