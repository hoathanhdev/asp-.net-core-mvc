using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EF
{
    public class EXDbContext : DbContext
    {
        public EXDbContext(DbContextOptions<EXDbContext> options) : base(options)
        {
        }

        public DbSet<User> user { get; set; }
        public DbSet<Account> account { get; set; }

        public DbSet<Student> student { get; set; }

        public DbSet<Teacher> teacher { get; set; }
        public DbSet<Course> course{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasOne<Teacher>(c => c.Teacher)
                .WithMany(t => t.Courses)
                .HasForeignKey(c => c.MaGV);
            ;

            modelBuilder.Entity<Course>()
                .HasOne<Student>(c => c.Student)
                .WithMany(t => t.Courses)
                .HasForeignKey(c => c.MaHS);
            ;
        }

       
    }
}
