using Equal.CRUD.IDao;
using Equal.Login.Domain;

namespace Equal.Login.IDao
{
    /// <summary>
    /// 登录令牌IDao
    /// </summary>
    public interface ILoginTokenDao : IDaoBase<LoginToken, long>
    {
    }
}
