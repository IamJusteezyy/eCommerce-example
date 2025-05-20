using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerceExample.EF.DBContext;
using eCommerceExample.EF.DBModels;
using eCommerceExample.Repository.Interfaces;
using eCommerceExample.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace eCommerceExample.Library.Repositories
{
    public class BookRepository : GenericRepository<BookEF>, IBookRepository
    {
        private readonly DbSet<BookEF> _bookSet;

        public BookRepository(NookBookContext context) : base(context) 
        {
            _bookSet = context.Set<BookEF>();
        }

        public async Task<List<BookEF>> GetBooksBySearch(string searchTerm)
        {
            var bookList = await _bookSet.Where(x => x.Author.Contains(searchTerm) || x.BookTitle.Contains(searchTerm)).ToListAsync();

            return bookList;
        }

    }
}
