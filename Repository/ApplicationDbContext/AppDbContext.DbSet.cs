using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ApplicationDbContext
{
    public sealed partial class AppDbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Career> Careers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseLesson> CourseLessons { get; set; }
        public DbSet<CourseModule> CourseModules { get; set; }
        public DbSet<Checkpoint> Checkpoints { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Roadmap> Roadmaps { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
