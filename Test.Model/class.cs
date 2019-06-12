using System.ComponentModel;
using Chloe.Annotations;


namespace Test.Model
{
    /// <summary>
    /// 这个是数据库映射的表实体类
    /// </summary>
    [Table("Class")]
    public class Class
    {
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Id")]
        public int class_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Name")]
        public string class_name { get; set; }
    }
}
