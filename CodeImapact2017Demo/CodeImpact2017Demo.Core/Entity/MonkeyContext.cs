using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CodeImpact2017Demo.Entity
{
    public class MonkeyContext : DbContext
    {
        private string DatabasePath { get; set; }

        public MonkeyContext(string databasePath)
        {
            DatabasePath = databasePath;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
            optionsBuilder.UseSqlite($"Filename={DatabasePath}");
        }

        public DbSet<Monkey> Monkeys { get; set; }
    }
}
