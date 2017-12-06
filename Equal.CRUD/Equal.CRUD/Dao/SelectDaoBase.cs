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

        /// <summary>
        /// 具体数据库的DaoHelper
        /// 通过属性注入，修饰符只能为public，不能为protected
        /// </summary>
        public IDaoHelper DaoHelper { get; set; }

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
        protected IDictionary<string, string> _orderPropertyColumnMap = new Dictionary<string, string>();

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
            if (!_orderPropertyColumnMap.ContainsKey(propertyName))
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
        protected string CreateOrderSql(NameValueCollection orderBy)
        {
            return DaoHelper.CreateOrderSql(orderBy, _orderPropertyColumnMap);
        }

        protected void AddOrderPropertyCondition(Hashtable condtion, NameValueCollection orderColl)
        {
            string orderSql = DaoHelper.CreateOrderSql(orderColl, _orderPropertyColumnMap);
            if (string.IsNullOrEmpty(orderSql))
                orderSql = DaoHelper.CreateOrderSql(DefaultOrderCollection, _orderPropertyColumnMap);

            if (string.IsNullOrEmpty(orderSql))
                return;
            if (condtion == null)
                condtion = new Hashtable();

            if (condtion.ContainsKey(SqlMapConstants.OrderByParam))
                throw new DaoException("Dao查询条件Hashtable中不能定义键名为" + SqlMapConstants.OrderByParam + "，与查询条件键字冲突。");

            condtion.Add(SqlMapConstants.OrderByParam, orderSql);

        }

        /// <summary>
        /// 清空排序字段映射表
        /// </summary>
        protected void ClearOrderColumnMap()
        {
            _orderPropertyColumnMap.Clear();
        }

        #endregion

        #region Select

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="condition">查询条件，禁止传递空Condition查询</param>
        /// <param name="orderByColl">排序条件</param>
        /// <returns></returns>
        public IList<T> Select(ICondition condition, NameValueCollection orderByColl = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <param name="orderByColl">排序条件</param>
        /// <returns>查询结果</returns>
        public IList<T> SelectAll(NameValueCollection orderByColl = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据条件查询顶部指定数量的数据
        /// </summary>
        /// <param name="topCount">查询数量</param>
        /// <param name="condition">查询条件，如为null或未设置查询条件则查询所有</param>
        /// <param name="orderByColl">排序条件</param>
        /// <returns>查询结果</returns>
        public IList<T> SelectTop(int topCount, ICondition condition = null, NameValueCollection orderByColl = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据条件查询顶部第一条记录
        /// </summary>
        /// <param name="condition">查询条件，如为null或未设置查询条件则查询所有</param>
        /// <param name="orderByColl">排序条件</param>
        /// <returns>查询结果</returns>
        public T SelectTop1(ICondition condition = null, NameValueCollection orderByColl = null)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region SelectById

        /// <summary>
        /// 根据领域对象Id集合查询，如集合为null或空则不进行查询。
        /// </summary>
        /// <param name="idList">领域对象Id集合</param>
        /// <returns>查询结果</returns>
        public IList<T> SelectByIdList(IList<U> idList)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据领域对象Id查询，如无数据抛出异常。
        /// </summary>
        /// <param name="id">领域对象Id</param>
        /// <returns>查询结果</returns>
        public T SelectByIdReq(U id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据领域对象Id查询
        /// </summary>
        /// <param name="id">领域对象Id</param>
        /// <returns>查询结果</returns>
        public T SelectById(U id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region SelectCount

        /// <summary>
        /// 根据条件类查询数量
        /// </summary>
        /// <param name="condition">查询条件，如为null或空则查询所有</param>
        /// <returns>返回数量结果</returns>
        public int SelectCount(ICondition condition = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 查询所有数据数量
        /// </summary>
        /// <returns>返回数量结果</returns>
        public int SelectAllCount()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region SelectByPage

        /// <summary>
        /// 根据条件分页查询
        /// </summary>
        /// <param name="startRecordIndex">当前页数据记录的起始索引，从1开始</param>
        /// <param name="pageSize">每页显示的记录数</param>
        /// <param name="condition">查询条件，如为null或未设置查询条件则查询所</param>
        /// <param name="orderByColl">排序条件</param>
        /// <returns>查询结果</returns>
        public IList<T> SelectByPage(int startRecordIndex, int pageSize, ICondition condition = null, NameValueCollection orderByColl = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 分页查询所有数据
        /// </summary>
        /// <param name="startRecordIndex">当前页数据记录的起始索引，从1开始</param>
        /// <param name="pageSize">每页显示的记录数</param>
        /// <param name="orderByColl">排序条件</param>
        /// <returns>查询结果</returns>
        public IList<T> SelectAllByPage(int startRecordIndex, int pageSize, NameValueCollection orderByColl = null)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
