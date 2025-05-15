using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerceExample.EF.DBContext;
using eCommerceExample.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eCommerceExample.Library.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly NookBookContext _context;
        internal DbSet<TEntity> _dbSet;

        public GenericRepository(NookBookContext context)
        {
            this._context = context;
            this._dbSet = _context.Set<TEntity>();
        }

        public Task<List<TEntity>> GetAll()
        {
            return _dbSet.ToListAsync();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
