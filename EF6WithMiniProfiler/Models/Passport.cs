using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EF6WithMiniProfiler.Models
{
    public class Passport
    {
        /// <summary>
        /// 自定义主键要在字段上标注[Key]表示。因为EF默认会查找对象中第一个带有Id或者是属性名+Id的组合为主键
        /// 联合主键需要对主键顺序进行标注[Column(Order =1)]，同样外键也要进行类似标注[Column(Order =2)]
        /// </summary>
        [Key]
        [Column(Order =1)]
        public int PassportNumber { get; set; }
        [Key]
        [Column(Order =2)]
        public string IssuingContry { get; set; }
        public DateTime Issued { get; set; }
        public DateTime Expires { get; set; }

    }
}