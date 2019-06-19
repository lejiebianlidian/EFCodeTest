using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EF6WithMiniProfiler.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }

        public string  Content { get; set; }
        public int BlogId { get; set; }
        public ICollection<Comment> Comments { get; set; }
        //public virtual ICollection<Comment> Comments { get; set; }//添加virtual时为了延迟加载，提高性能





    }
}