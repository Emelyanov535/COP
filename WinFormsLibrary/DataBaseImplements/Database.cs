using DataBaseImplements.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class Database : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=FurnitureFactory1;Username=postgres;Password=postgres");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<Manager> Managers { set; get; }
    }
}
