using Equal.Utility;

namespace Equal.Login.Domain
{
    public enum UserWorkingState
    {
        [EnumText("在岗")]
        在岗 = 0,

        [EnumText("离岗")]
        离岗 = 1,

        [EnumText("退休")]
        退休 = 2
    }
}
