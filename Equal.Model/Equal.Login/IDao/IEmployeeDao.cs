using Equal.CRUD.IDao;
using Equal.Login.Domain;

namespace Equal.Login.IDao
{
    /// <summary>
    /// 合作单位用户IDao
    /// </summary>
    public interface IEmployeeDao : IDaoBase<Employee, long>
    {
    }
}
