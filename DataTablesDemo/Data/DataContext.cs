using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataTablesDemo.Models;
using DataTablesDemo.Data.Configuration;
using System.Data;
using System.Data.Entity;

namespace DataTablesDemo.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(new MigrationsConfiguration());
        }

        public DbSet<Customer> Customers { get; set; }
    }
}