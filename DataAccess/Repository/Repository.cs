using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _appDbContext;
        internal DbSet<T> _dbSet;

        public Repository(AppDbContext appDbContext)
        {
            _appDbContext= appDbContext;
            _dbSet = _appDbContext.Set<T>();
        }
        public void Add(T entity)
        {
            _appDbContext.Set<T>().Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = _dbSet;
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> predicate)
        {
           IQueryable<T> query = _dbSet;
            query = query.Where(predicate);
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
    }
}
