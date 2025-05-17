using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerceExample.EF.DBContext;
using eCommerceExample.EF.DBModels;
using eCommerceExample.Library.Repositories;
using eCommerceExample.Repository.Interfaces;
using eCommerceExample.Repository.IUnitOfWork;

namespace eCommerceExample.Library.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly NookBookContext _context;

        public IBookRepository BookRepository { get; private set; }
        public IBookPriceRepository BookPriceRepository { get; private set; }
        public ICoverTypeRepository CoverTypeRepository { get; private set; }

        public UnitOfWork(NookBookContext context, IBookRepository bookRepository, IBookPriceRepository bookPriceRepository, ICoverTypeRepository coverTypeRepository)
        {
            _context = context;
            BookRepository = new BookRepository(_context);
            BookPriceRepository = bookPriceRepository;
            CoverTypeRepository = coverTypeRepository;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
