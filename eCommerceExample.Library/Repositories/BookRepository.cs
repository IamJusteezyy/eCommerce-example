using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerceExample.EF.DBContext;
using eCommerceExample.EF.DBModels;
using eCommerceExample.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace eCommerceExample.Library.Repositories
{
    public class BookRepository : GenericRepository<BookEF>, IBookRepository
    {
        public BookRepository(NookBookContext context) : base(context) { }

    }
}
