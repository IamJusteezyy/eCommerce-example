using System.ComponentModel;
using eCommerceExample.EF.DBModels;
using eCommerceExample.Library.UnitOfWork;
using eCommerceExample.Repository.Interfaces;
using eCommerceExample.Repository.IUnitOfWork;
using eCommerceExample.Repository.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceExample.Features.Browse
{
    
    public class BrowseController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public BrowseController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        [Route("Browse")]
        public async Task<IActionResult> Browse()
        {
            var bookList = await GetBooks();

            BrowseViewModel browseViewModel = new()
            {
                BookList = bookList,
            };

            return View(browseViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Search(BrowseViewModel browseViewModel)
        {
            var bookList = await GetBooks(browseViewModel.SearchTerm);

            browseViewModel.BookList = bookList;

            return View("Browse", browseViewModel);
        }

        private async Task<IEnumerable<Book>> GetBooks(string? searchTerm = null)
        {
            var bookEFList = new List<BookEF>();
            var bookPriceEFList = await _unitOfWork.BookPriceRepository.GetAll();
            var coverTypeEFList = await _unitOfWork.CoverTypeRepository.GetAll();

            if (searchTerm != null)
            {
                bookEFList = await _unitOfWork.BookRepository.GetBooksBySearch(searchTerm);
            }
            else
            {
                bookEFList = await _unitOfWork.BookRepository.GetAll();
            }
            var bookList =
                from book in bookEFList
                join bookPrice in bookPriceEFList on book.BookID equals bookPrice.BookID
                join coverType in coverTypeEFList on bookPrice.CoverTypeID equals coverType.CoverTypeID
                select new Book()
                {
                    BookID = book.BookID,
                    BookTitle = book.BookTitle,
                    Author = book.Author,
                    ISBN = book.ISBN,
                    PublishedDate = book.PublishedDate,
                    Publisher = book.Publisher,
                    BlobURL = book.BlobURL,
                    CoverType = coverType.CoverType,
                    Price = bookPrice.Price,
                };

            return bookList;
        }
    }
}
