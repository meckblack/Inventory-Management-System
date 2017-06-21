using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using IMS.Models;

namespace IMS.DAL
{
    public class IMS_DB : DbContext
    {
        public IMS_DB() : base("MyIMS_DB")
        {
            Database.SetInitializer<IMS_DB>(new MyInitializer());
        }

        public DbSet<Admin> admin { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<Sale> Sale { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}