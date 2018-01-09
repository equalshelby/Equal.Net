using Equal.CRUD.IDao;
using Equal.Login.Domain;

namespace Equal.Login.IDao
{
    /// <summary>
    /// 普通用户IDao
    /// </summary>
    public interface ICommonUserDao : IDaoBase<CommonUser, long>
    {
    }
}
