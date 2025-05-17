using eCommerceExample.EF.DBModels;
using eCommerceExample.Library.UnitOfWork;
using eCommerceExample.Repository.Interfaces;
using eCommerceExample.Repository.IUnitOfWork;
using eCommerceExample.Repository.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceExample.Features.Browse
{
    [Route("Browse")]
    public class BrowseController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public BrowseController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Browse()
        {
            var bookEFList = await _unitOfWork.BookRepository.GetAll();
            var bookPriceEFList = await _unitOfWork.BookPriceRepository.GetAll();
            var coverTypeEFList = await _unitOfWork.CoverTypeRepository.GetAll();

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

            BrowseViewModel browseViewModel = new()
            {
                BookList = bookList,
            };
            return View(browseViewModel);
        }

        [HttpGet]
        [Route("GetBooks")]
        public async Task<JsonResult> GetBooks()
        {
            var bookEFList = await _unitOfWork.BookRepository.GetAll();
            var bookPriceEFList = await _unitOfWork.BookPriceRepository.GetAll();
            var coverTypeEFList = await _unitOfWork.CoverTypeRepository.GetAll();

            var bookList =
                from book in bookEFList
                join bookPrice in bookPriceEFList on book.BookID equals bookPrice.BookID
                join coverType in coverTypeEFList on bookPrice.CoverTypeID equals coverType.CoverTypeID
                select new Book()
                {
                    BookTitle = book.BookTitle,
                    Author = book.Author,
                    ISBN = book.ISBN,
                    PublishedDate = book.PublishedDate,
                    Publisher = book.Publisher,
                    BlobURL = book.BlobURL,
                    CoverType = coverType.CoverType,
                    Price = bookPrice.Price,
                };

            return Json(bookList);
        }
    }
}
