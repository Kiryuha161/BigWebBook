using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BigWeb.DataAccess.Data;
using BigWeb.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BigWeb.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _database;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext database)
        {
            _database = database;
            this.dbSet = _database.Set<T>();
            _database.Products.Include(u => u.CategoryName).Include(u => u.CategoryId);
            //_database.Categories = this.dbSet();
        }
        
        public void Add(T entity)
        {
            this.dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = this.dbSet;
            query = query.Where(filter);

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> query = this.dbSet;

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) 
                {
                    query = query.Include(includeProp);
                }
            }
            
            return query.ToList();
        }

        public void Remove(T entity)
        {
            this.dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            this.dbSet.RemoveRange(entities);
        }
    }
}
