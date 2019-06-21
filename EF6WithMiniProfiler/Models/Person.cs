using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EF6WithMiniProfiler.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [InverseProperty("CreatedBy")]
        public List<Post> PostsWritten { get; set; }

        [InverseProperty("UpdatedBy")]
        public List<Post> PostsUpdated { get; set; }


    }
}