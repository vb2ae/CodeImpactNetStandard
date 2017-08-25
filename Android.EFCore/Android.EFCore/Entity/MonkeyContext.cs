using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.EntityFrameworkCore;

namespace Android.EFCore.Entity
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

        public DbSet<Monkey> Monkeys {get;set;}
    }
}