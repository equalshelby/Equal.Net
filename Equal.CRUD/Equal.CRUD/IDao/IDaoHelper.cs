using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equal.CRUD.IDao
{
    /// <summary>
    /// Dao帮助接口
    /// </summary>
    public interface IDaoHelper
    {
        /// <summary>
        /// 根据排序项集合和字段对照表生成排序语句
        /// </summary>
        /// <param name="coll">排序集合</param>
        /// <param name="map">排序属性和数据库字段映射</param>
        /// <returns>返回生成排序SQL语句</returns>
        string CreateOrderSql(NameValueCollection coll, IDictionary<string, string> map);
    }
}
