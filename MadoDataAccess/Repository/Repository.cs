using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MadoDataAccess.Data;
using MadoDataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace MadoDataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> DbSet;
        public Repository(ApplicationDbContext _db)
        {
            this._db = _db;
            this.DbSet = _db.Set<T>();
            
        }
        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            DbSet.RemoveRange(entities);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = DbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }
    }
}
