using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Equal.CRUD.Domain;
using Equal.CRUD.IDao;

namespace Equal.CRUD.Dao
{
    public abstract class SelectDaoBase<T, U> : ISelectDaoBase<T, U> where T : DomainBase<U>
    {
        #region Condition

        /// <summary>
        /// 根据查询条件类生成查询Hashtable
        /// </summary>
        /// <param name="condition">查询条件类</param>
        /// <returns>Hashtable</returns>
        public virtual Hashtable CreateConditionHashtable(ICondition condition)
        {
            return new Hashtable();
        }

        #endregion

        #region OrderBy

        /// <summary>
        /// 默认排序条件集合，由继承类实现，当没有排序条件时默认使用此排序
        /// </summary>
        protected virtual NameValueCollection DefaultOrderCollection { get { return null; } }

        /// <summary>
        /// 排序属性和数据库字段映射
        /// </summary>
        protected IDictionary<string,string> _orderPropertyColumnMap = new Dictionary<string, string>();

        /// <summary>
        /// 获取排序属性
        /// </summary>
        /// <returns>返回排序属性列表</returns>
        public IList<string> GetOrderProperty()
        {
            return _orderPropertyColumnMap.Select(s => s.Key).ToList();
        }

        /// <summary>
        /// 添加排序属性到映射表
        /// </summary>
        /// <param name="propertyName">排序属性</param>
        /// <param name="columnName">数据库字段名</param>
        protected void AddOrderPropertyColumnMap(string propertyName, string columnName)
        {
            if(!_orderPropertyColumnMap.ContainsKey(propertyName))
                _orderPropertyColumnMap.Add(propertyName, columnName);
        }

        /// <summary>
        /// 移除排序映射表内指定的排序属性
        /// </summary>
        /// <param name="propertyName">排序属性</param>
        /// <returns>是否移除成功</returns>
        protected bool RemoveOrderPropertyColumnMap(string propertyName)
        {
            if (_orderPropertyColumnMap.ContainsKey(propertyName))
                return _orderPropertyColumnMap.Remove(propertyName);
            return false;
        }

        /// <summary>
        /// 生成排序SQL语句
        /// </summary>
        /// <param name="orderBy">排序集合</param>
        /// <returns>生成排序Sql语句</returns>
        protected string CreateOrderBySql(NameValueCollection orderBy)
        {
            return null;
        }

        protected void AddOrderPropertyCondition(Hashtable condtion,NameValueCollection orderColl)
        {
            
        }

        /// <summary>
        /// 清空排序字段映射表
        /// </summary>
        protected void ClearOrderColumnMap()
        {
            _orderPropertyColumnMap.Clear();
        }

        #endregion



        public IList<T> Select(ICondition condition, NameValueCollection orderByColl = null)
        {
            throw new NotImplementedException();
        }

        public IList<T> SelectAll(NameValueCollection orderByColl = null)
        {
            throw new NotImplementedException();
        }

        public IList<T> SelectAllByPage(int startRecordIndex, int pageSize, NameValueCollection orderByColl = null)
        {
            throw new NotImplementedException();
        }

        public int SelectAllCount()
        {
            throw new NotImplementedException();
        }

        public T SelectById(U id)
        {
            throw new NotImplementedException();
        }

        public IList<T> SelectByIdList(IList<U> idList)
        {
            throw new NotImplementedException();
        }

        public T SelectByIdReq(U id)
        {
            throw new NotImplementedException();
        }

        public IList<T> SelectByPage(int startRecordIndex, int pageSize, ICondition condition = null, NameValueCollection orderByColl = null)
        {
            throw new NotImplementedException();
        }

        public int SelectCount(ICondition condition = null)
        {
            throw new NotImplementedException();
        }

        public IList<T> SelectTop(int topCount, ICondition condition = null, NameValueCollection orderByColl = null)
        {
            throw new NotImplementedException();
        }

        public T SelectTop1(ICondition condition = null, NameValueCollection orderByColl = null)
        {
            throw new NotImplementedException();
        }
    }
}
