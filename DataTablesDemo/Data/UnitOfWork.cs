using DataTablesDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataTablesDemo.Data
{
    public class UnitOfWork : IDisposable
    {
        private DataContext _context = new DataContext();

        private GenericRespository<Customer> _customers = null;

        public GenericRespository<Customer> Customers
        {
            get
            {
                if (this._customers == null)
                {
                    this._customers = new RepositoryCustomers(this._context);
                }
                return this._customers;
            }
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}