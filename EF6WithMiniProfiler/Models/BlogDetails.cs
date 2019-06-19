using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EF6WithMiniProfiler.Models
{
    /// <summary>
    /// 像这种没有任何类型的键属性的值对象，实体框架将这种值对象称为复杂类型，不能自动跟踪复杂类型。
    /// 博客实体跟这个博客详情实体存在关系，博客类会将详情实体当做博客对象的一部分进行跟踪BlogDetails的属性
    /// 为了能实现这个情况，需要将BlogDetails设置为复杂类型。（需要添加标注信息[ComplexType]）
    /// 同样需要在Bolg类中添加一个BlogDetails属性
    /// </summary>

    [ComplexType]
    public class BlogDetails
    {
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// 通过标识列进行自定义列名、字段数据类型、字段长度等
        /// </summary>
        [Column("BlogDescription", TypeName ="ntext"),MaxLength(250)]
        public string Description { get; set; } 


    }
}