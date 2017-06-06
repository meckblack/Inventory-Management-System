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
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}