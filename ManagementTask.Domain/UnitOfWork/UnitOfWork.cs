using ManagementTask.DataAccess;
using ManagementTask.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementTask.Domain.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaskContext _context;
        private Dictionary<Type, object> _repositories;

        public UnitOfWork(TaskContext context)
        {
            _context = context;
            _repositories = new();
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<Type, object>();
            }

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories[type] = repositoryInstance!;
            }

            return (IRepository<TEntity>)_repositories[type];
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
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
