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
            //查询Class表中的所有数据
            var list = new Test.DB.DB().FindList<Class>();

            //循环输出查看
            foreach (var item in list)
            {
                Console.WriteLine($"{item.class_id},{item.class_name}");
            }
            
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
