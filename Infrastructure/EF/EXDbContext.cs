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

    }
}
