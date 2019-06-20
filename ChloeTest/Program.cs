using Chloe.SqlServer;
using System;
using System.Collections.Generic;
using Test.Model;



namespace ChloeTest
{
    class Program
    {
        /// <summary>
        /// 操作数据库
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            #region 使用Chloe封装好的方式

            string connString = "database=test;server=.;User=sa;password=sa;";
            MsSqlContext context = new MsSqlContext(connString);

            //MsSqlContext 对象默认使用 ROWNUMBER 的分页方式，如果您的数据库是 SqlServer2012 或更高版本，可以切换使用 OFFSET FETCH 分页方式
            context.PagingMode = PagingMode.OFFSET_FETCH;

            var query = context.Query<Class>().Where(a => a.class_id == 7).FirstOrDefault();
            Console.WriteLine($"{query}");

            #endregion


            #region 重新写扩展方法调用的方式,使用的是ASP.NET CORE 配置 Service
            ////查询Class表中的所有数据
            //var list = new Test.DB.DB().FindList<Class>();

            ////循环输出查看
            //foreach (var item in list)
            //{
            //    Console.WriteLine($"{item.class_id},{item.class_name}");
            //}
            #endregion

            Console.ReadKey();
        }

        //方法的方式
        //查询
        public IEnumerable<Class> UserSearchs()
        {
            var list = new Test.DB.DB().FindList<Class>();

            return list;
        }

        //这里还没掌握好语法糖，暂时写不出
        //public Class UserSearch()
        //{
        //    var user = new Test.DB.DB().Find<Class>();
        //    return user;
        //}
    }
}
