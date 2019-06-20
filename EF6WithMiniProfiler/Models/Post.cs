using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EF6WithMiniProfiler.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        /// <summary>
        ///数据插入时数据库自动生成值。创建时间、更新时间
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateCreated { get; set; }

        public string Content { get; set; }

        /// <summary>
        /// 创建索引(默认情况下索引是非唯一的)
        /// EF6.1 及更高版本仅-Entity Framework 6.1 中引入了索引属性。 如果您使用的是早期版本不适用于此部分中的信息。
        /// </summary>
        [Index]
        public int Rating { get; set; }

        /// <summary>
        /// 自定义索引名称
        /// </summary>
        //[Index("PostRatingIndex")]
        //public int Rating { get; set; }

        /// <summary>
        /// 定义唯一索引
        /// 默认情况下，索引是非唯一的但你可以使用IsUnique名为参数来指定应该唯一索引。
        /// </summary>
        //[Index(IsUnique = true)]
        //[StringLength(100)]
        //public int Rating { get; set; }


        /// <summary>
        /// 多列索引
        /// 创建多列索引时，需要在索引中指定列的顺序
        /// </summary>
        /*
        [Index("IX_BlogIdAndRating", 2)]
        public int Rating { get; set; }

        [Index("IX_BlogIdAndRating", 1)]
        public int BlogId { get; set; }
        */

        public int BlogId { get; set; }

        [ForeignKey("BlogId")]
        public Blog blog { get; set; }
        public ICollection<Comment> Comments { get; set; }
        //public virtual ICollection<Comment> Comments { get; set; }//添加virtual时为了延迟加载，提高性能

        public Person Createdby { get; set; }
        public Person Updatedby { get; set; }



    }
}