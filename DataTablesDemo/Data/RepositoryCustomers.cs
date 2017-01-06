using DataTablesDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DataTablesDemo.Data
{
    class RepositoryCustomers : GenericRespository<Customer>
    {
        public RepositoryCustomers(DbContext context)
            : base(context)
        {

        }
    }
}