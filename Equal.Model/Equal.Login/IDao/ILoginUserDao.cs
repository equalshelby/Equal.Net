using Equal.CRUD.IDao;
using Equal.Login.Domain;

namespace Equal.Login.IDao
{
    /// <summary>
    /// 用户登录IDao
    /// </summary>
    public interface ILoginUserDao : IDaoBase<LoginUser, long>
    {
    }
}
