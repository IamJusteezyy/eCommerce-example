using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerceExample.EF.DBContext;
using Microsoft.EntityFrameworkCore;

namespace eCommerceExample.Library.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal NookBookContext _nookBookContext;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(NookBookContext nookBookContext)
        {
            _nookBookContext = nookBookContext;
            this._dbSet = _nookBookContext.Set<TEntity>();
        }

        public Task<List<TEntity>> GetAll()
        {
            return _dbSet.ToListAsync();
        }

        public void Add(TEntity entity)
        {
            _nookBookContext.Add(entity);
        }
        public void Remove(TEntity entity)
        {
            _nookBookContext.Remove(entity);
        }
    }
}
