using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EF6WithMiniProfiler.Models
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext() : base("name=SqlConnectionString")
        {

        }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<BlogDetail> BlogDetails { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Passport> Passports { get; set; }
        public virtual DbSet<PassportStamp> PassportStamps { get; set; }
        public virtual DbSet<Person> Persons { get; set; }


    }
}