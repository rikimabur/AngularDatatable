using DataTablesDemo.Data;
using DataTablesDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace DataTablesDemo.Controllers.API
{
    public class CustomersApiController : ApiController
    {
        private UnitOfWork _unit = new UnitOfWork();

        public IEnumerable<Customer> Get()
        {
            try
            {
                IEnumerable<Customer> customers = _unit.Customers.Get();
                return customers;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}