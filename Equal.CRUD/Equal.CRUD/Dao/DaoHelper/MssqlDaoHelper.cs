﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Equal.CRUD.IDao;

namespace Equal.CRUD.Dao.DaoHelper
{
    public class MssqlDaoHelper : IDaoHelper
    {
        /// <summary>
        /// 根据排序属性集合和字段对照表生成排序语句
        /// </summary>
        /// <param name="coll">排序集合</param>
        /// <param name="map">排序属性和数据库字段映射</param>
        /// <returns></returns>
        public string CreateOrderSql(NameValueCollection coll, IDictionary<string, string> map)
        {
            if (coll == null || coll.Count == 0 || map == null || map.Count == 0)
                return string.Empty;
            StringBuilder sb = new StringBuilder();

            foreach (string s in coll)
            {
                if (map.ContainsKey(s))
                {
                    if (sb.Length > 0)
                        sb.Append(", ");
                    sb.Append(map[s]);
                    if (coll[s].ToUpper().Trim() == "DESC")
                        sb.Append(" DESC");
                }
            }
            return sb.ToString();
        }
    }
}