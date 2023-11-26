using Microsoft.EntityFrameworkCore;
using ShelterApi.Contracts;
// using TravelApi.Data;
using System.Linq.Expressions;
using ShelterApi.Models;

namespace ShelterApi.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ShelterApiContext RepositoryContext { get; set; }

        public RepositoryBase(ShelterApiContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>()
                .AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>()
                .Where(expression)
                .AsNoTracking();
        }
    }
}