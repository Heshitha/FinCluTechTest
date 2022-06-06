using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using FinCluTech.Data.Entities;

namespace FinCluTech.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base("Data Source=INIVOS-LAP22\\SQLEXPRESS;Initial Catalog=FinCluTechData;Integrated Security=True")
        {

        }

        public DbSet<Customer> Costomers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
