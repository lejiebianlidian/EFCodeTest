using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF6WithMiniProfiler.Models
{
    /// <summary>
    /// 自定义生成到数据库的表名称
    /// </summary>
    [Table("InternalBlogs")]
    public class Blog
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [MaxLength(50, ErrorMessage = "BloggerName must be 50 characters or less"), MinLength(4)]
        public string BloggerName { get; set; }

        /// <summary>
        /// 不映射到数据库中的字段需要设置标识[NotMapped]
        /// </summary>
        [NotMapped]
        public string BlogCode
        {
            get
            {
                return Title.Substring(0, 1) + ":" + BloggerName.Substring(0, 1);
            }
        }

        /// <summary>
        /// 数据插入时数据库自动生成值。
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateCreated { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateUpdate { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public BlogDetail  blogDetail { get; set; }


    }
}