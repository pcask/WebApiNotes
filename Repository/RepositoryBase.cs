using Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly RepositoryContext _repositoryContext;

        protected RepositoryBase(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public void Create(T entity) => _repositoryContext.Set<T>().Add(entity);
        public void Delete(T entity) => _repositoryContext.Set<T>().Remove(entity);
        public void Update(T entity) => _repositoryContext.Set<T>().Update(entity);

        public IQueryable<T> FindAll(bool trackChanges) =>
            trackChanges ?
            _repositoryContext.Set<T>() :
            _repositoryContext.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> filter, bool trackChanges) =>
            trackChanges ?
            _repositoryContext.Set<T>().Where(filter) :
            _repositoryContext.Set<T>().Where(filter).AsNoTracking();
    }
}
