using Equal.Utility;

namespace Equal.Login.Domain
{
    /// <summary>
    /// 登录用户类别
    /// </summary>
    public enum LoginType
    {
        [EnumText("普通用户")]
        CommonUser = 1,

        [EnumText("合作单位用户")]
        Employee = 2
    }
}
