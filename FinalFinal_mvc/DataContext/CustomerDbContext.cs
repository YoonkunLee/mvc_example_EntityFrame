using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalFinal_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalFinal_mvc.DataContext
{
    public class CustomerDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }
    }
}
