using Chloe;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Test.DB
{
    /// <summary>
    /// 这部分是执行SQL操作的类，比如增删改查等等
    /// </summary>
    public class DB
    {
        /// <summary>
        /// 这部分是配置数据库的信息
        /// </summary>
        /// <returns></returns>
        private IDbContext NewDB()
        {
            //数据库地址等信息
            var sqlserver_conn_str = "database=test;server=.;User=sa;password=sa;";//用的本地数据库地址
            return new Chloe.SqlServer.MsSqlContext(sqlserver_conn_str);
        }
        #region 基础操作方法，这里不明白一定要写这个，因为直接引用了Chloe的Nuget了可以直接使用他们的封装的方法了为什么还写这些扩展方法？不解
        /// <summary>
        /// 新增,如果一个实体存在自增列，会自动将自增列设置到相应的属性上
        /// </summary>
        /// <param name="entity">实体</param>
        public T Insert<T>(T entity) where T : class, new()
        {
            using (var db = NewDB())
            {
                return db.Insert(entity);
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体</param>
        public int Update<T>(T entity) where T : class, new()
        {
            using (var db = NewDB())
            {
                return db.Update(entity);
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="expWhere"></param>
        public int Delete<T>(Expression<Func<T, bool>> expWhere) where T : class, new()
        {
            using (var db = NewDB())
            {
                return db.Delete<T>(expWhere);
            }
        }
        /// <summary>
        /// 获取一个实体
        /// </summary>
        /// <param name="expWhere">查询条件</param>
        /// <returns></returns>
        public T Find<T>(Expression<Func<T, bool>> expWhere) where T : class, new()
        {
            using (var db = NewDB())
            {
                IQuery<T> q = db.Query<T>();
                var entity = q.Where(expWhere).FirstOrDefault();
                return entity;
            }
        }
        /// <summary>
        /// 单表查询
        /// </summary>
        /// <param name="expWhere">查询条件,可空</param>
        /// <param name="expOrder">排序字段,可空</param>
        /// <param name="isAsc">是否升序，expOrder不为空时有效</param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(Expression<Func<T, bool>> expWhere = null, Expression<Func<T, object>> expOrder = null, bool isAsc = false) where T : class, new()
        {
            using (var db = NewDB())
            {
                IQuery<T> q = db.Query<T>();
                if (expWhere != null)
                {
                    q = q.Where(expWhere);
                }
                if (expOrder != null)
                {
                    if (isAsc)
                    {
                        q = q.OrderBy(expOrder);
                    }
                    else
                    {
                        q = q.OrderByDesc(expOrder);
                    }
                }
                var list = q.ToList();
                return list;
            }
        }
        /// <summary>
        /// 根据sql语句查询
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public IEnumerable<T> DtoQuery<T>(string strSql, params DbParam[] parameters) where T : class, new()
        {
            using (IDbContext db = NewDB())
            {
                return db.SqlQuery<T>(strSql, parameters);
            }
        }
        #endregion

        //--------------------- 
        //作者：数据的流
        //来源：CSDN
        //原文：https://blog.csdn.net/shujudeliu/article/details/82257129 
        //版权声明：本文为博主原创文章，转载请附上博文链接！

    }
}
