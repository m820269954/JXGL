using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using jxgl.Models;
namespace jxgl.Data_Access_Layer
{
    public class JXGLDBContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<CS> CSs { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<TC> TCs { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
    
}