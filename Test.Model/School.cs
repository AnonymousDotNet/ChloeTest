using System.ComponentModel;

namespace Test.Model
{
    /// <summary>
    /// 这个是数据库映射的表实体类
    /// </summary>
    public class School
    {
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("唯一ID")]
        public int garde_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("不知道是啥字段意义")]
        public string garde { get; set; }
    }
}
