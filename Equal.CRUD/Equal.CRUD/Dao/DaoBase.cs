using System.Collections;
using System.Collections.Generic;

using Equal.CRUD.Domain;
using Equal.CRUD.IDao;
using IBatisNet.DataMapper;

namespace Equal.CRUD.Dao
{
    public abstract class DaoBase<T, U> : SelectDaoBase<T, U>, IDaoBase<T, U> where T : DomainBase<U>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sqlMapper"></param>
        protected DaoBase(ISqlMapper sqlMapper) : base(sqlMapper)
        {
        }

        #region Insert Update Delete Truncate
       
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="t">领域对象</param>
        /// <returns>领域对象Id</returns>
        public virtual U Insert(T t)
        {
            if (t == null)
                return default(U);

            _sqlMapper.Insert(GetStatementIdWithNamespace(SqlMapConstants.InsertStatementId), t);
            return t.Id;
        }

        /// <summary>
        /// 更新，根据领域对象Id更新
        /// </summary>
        /// <param name="t">领域对象</param>
        /// <returns>更新记录数</returns>
        public virtual int Update(T t)
        {
            if (t == null)
                return 0;
            return _sqlMapper.Update(GetStatementIdWithNamespace(SqlMapConstants.UpdateStatementId), t);
        }

        /// <summary>
        /// 更新，根据指定领域对象Id更新
        /// </summary>
        /// <param name="id">领域对象Id</param>
        /// <param name="t">领域对象</param>
        /// <returns>更新数量</returns>
        public virtual int Update(U id, T t)
        {
            t.Id = id;
            return Update(t);
        }

        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <param name="condition">删除条件，如为null或空则不进行删除</param>
        /// <returns>删除数量</returns>
        protected virtual int Delete(Hashtable condition)
        {
            Hashtable ht = DaoHelper.ProcessConditionHashtable(condition);
            if (ht == null || ht.Count == 0)
                return 0;
            return _sqlMapper.Delete(GetStatementIdWithNamespace(SqlMapConstants.DeleteStatementId), ht);
        }

        /// <summary>
        /// 根据查询条件类删除
        /// </summary>
        /// <param name="condition">删除条件，如为null或空则不进行删除</param>
        /// <returns>删除数量</returns>
        public virtual int Delete(ICondition condition)
        {
            return Delete(CreateConditionHashtable(condition));
        }

        /// <summary>
        /// 删除所有数据，数据量大时建议调用Truncate方法
        /// </summary>
        /// <returns>删除数量</returns>
        public virtual int DeleteAll()
        {
            return _sqlMapper.Delete(
                GetStatementIdWithNamespace(SqlMapConstants.DeleteStatementId), null);
        }

        /// <summary>
        /// 根据Id删除
        /// </summary>
        /// <param name="id">领域对象Id</param>
        /// <returns>删除数量</returns>
        public virtual int DeleteById(U id)
        {
            return Delete(new Hashtable { { SqlMapConstants.IdParam, id } });
        }

        /// <summary>
        /// 根据Id集合删除
        /// </summary>
        /// <param name="idList">领域对象Id集合，如集合为null或空则不进行删除</param>
        /// <returns></returns>
        public virtual int DeleteByIdList(IList<U> idList)
        {
            if (idList == null || idList.Count == 0)
                return 0;

            return Delete(new Hashtable { { SqlMapConstants.IdsParam, idList } });
        }

        /// <summary>
        /// 清空表
        /// </summary>
        public virtual void Truncate()
        {
            _sqlMapper.QueryForObject(GetStatementIdWithNamespace(SqlMapConstants.TruncateStatementId), null);
        }

        #endregion

    }
}
