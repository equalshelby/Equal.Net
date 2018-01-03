using Equal.Utility;

namespace Equal.Login.Domain
{
    /// <summary>
    /// 性别枚举
    /// </summary>
    public enum Sex
    {
        [EnumText("男")]
        男 = 1,

        [EnumText("女")]
        女 = 2,

        [EnumText("保密")]
        保密 = 3
    }
}
