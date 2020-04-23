using ContactInfo.DataAccessLayer.Repositories;
using ContactInfo.Models;
using System;
using Unity;

namespace ContactInfo.DataAccessLayer
{
    public interface IUnitOfWork : IDisposable
    {
        IContactRepository Contacts { get; }
        void Complete();
    }

    public class UnitOfWork : IUnitOfWork
    {
        [Dependency]
        private readonly ApplicationDbContext _dbContext;

        private bool _disposed;

        public IContactRepository Contacts { get; private set; }

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            Contacts = new ContactRepository(_dbContext);
        }

        public void Complete()
        {
            _dbContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                    _dbContext.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}