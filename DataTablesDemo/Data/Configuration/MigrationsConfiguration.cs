using DataTablesDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DataTablesDemo.Data.Configuration
{
    class MigrationsConfiguration : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var custs = new List<Customer>
            {
                new Customer(){LastName = "Smith", FirstName = "Josh", Title = "Mr", Email="Josh@Smith.com", CompanyName="ABC Repairs"},
                new Customer(){LastName = "Anderson", FirstName = "Mike", Title = "Mr", Email="Mike@Anderson.com", CompanyName="Lucky Star Laundry"},
                new Customer(){LastName = "Jones", FirstName = "Emma", Title = "Mrs", Email="Emma@Jones.com", CompanyName="Emma's Diner"},
                new Customer(){LastName = "Williams", FirstName = "Peter", Title = "Mr", Email="Peter@Williams.com", CompanyName="Skylines Car Wash"},
                new Customer(){LastName = "Smith", FirstName = "Josh", Title = "Mr", Email="Josh@Smith.com", CompanyName="ABC Repairs"},
                new Customer(){LastName = "Anderson", FirstName = "Mike", Title = "Mr", Email="Mike@Anderson.com", CompanyName="Lucky Star Laundry"},
                new Customer(){LastName = "Jones", FirstName = "Emma", Title = "Mrs", Email="Emma@Jones.com", CompanyName="Emma's Diner"},
                new Customer(){LastName = "Williams", FirstName = "Peter", Title = "Mr", Email="Peter@Williams.com", CompanyName="Skylines Car Wash"},
                new Customer(){LastName = "Smith", FirstName = "Josh", Title = "Mr", Email="Josh@Smith.com", CompanyName="ABC Repairs"},
                new Customer(){LastName = "Anderson", FirstName = "Mike", Title = "Mr", Email="Mike@Anderson.com", CompanyName="Lucky Star Laundry"},
                new Customer(){LastName = "Jones", FirstName = "Emma", Title = "Mrs", Email="Emma@Jones.com", CompanyName="Emma's Diner"},
                new Customer(){LastName = "Williams", FirstName = "Peter", Title = "Mr", Email="Peter@Williams.com", CompanyName="Skylines Car Wash"},
                new Customer(){LastName = "Smith", FirstName = "Josh", Title = "Mr", Email="Josh@Smith.com", CompanyName="ABC Repairs"},
                new Customer(){LastName = "Anderson", FirstName = "Mike", Title = "Mr", Email="Mike@Anderson.com", CompanyName="Lucky Star Laundry"},
                new Customer(){LastName = "Jones", FirstName = "Emma", Title = "Mrs", Email="Emma@Jones.com", CompanyName="Emma's Diner"},
                new Customer(){LastName = "Williams", FirstName = "Peter", Title = "Mr", Email="Peter@Williams.com", CompanyName="Skylines Car Wash"},
                new Customer(){LastName = "Smith", FirstName = "Josh", Title = "Mr", Email="Josh@Smith.com", CompanyName="ABC Repairs"},
                new Customer(){LastName = "Anderson", FirstName = "Mike", Title = "Mr", Email="Mike@Anderson.com", CompanyName="Lucky Star Laundry"},
                new Customer(){LastName = "Jones", FirstName = "Emma", Title = "Mrs", Email="Emma@Jones.com", CompanyName="Emma's Diner"},
                new Customer(){LastName = "Williams", FirstName = "Peter", Title = "Mr", Email="Peter@Williams.com", CompanyName="Skylines Car Wash"},
                new Customer(){LastName = "Smith", FirstName = "Josh", Title = "Mr", Email="Josh@Smith.com", CompanyName="ABC Repairs"},
                new Customer(){LastName = "Anderson", FirstName = "Mike", Title = "Mr", Email="Mike@Anderson.com", CompanyName="Lucky Star Laundry"},
                new Customer(){LastName = "Jones", FirstName = "Emma", Title = "Mrs", Email="Emma@Jones.com", CompanyName="Emma's Diner"},
                new Customer(){LastName = "Williams", FirstName = "Peter", Title = "Mr", Email="Peter@Williams.com", CompanyName="Skylines Car Wash"},
            };
            custs.ForEach(c => context.Customers.Add(c));

            base.Seed(context);

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
    }
}