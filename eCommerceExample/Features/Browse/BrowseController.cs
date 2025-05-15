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
            List<BookEF> bookList = await _unitOfWork.BookRepository.GetAll();

            return View();
        }

        [HttpGet]
        [Route("GetBooks")]
        public JsonResult GetBooks()
        {
            Book data = new()
            {
                Title = "Test Book",
                Author = "Test, Author",
                Price = 19.99m
            };
            List<Book> bookList = new()
            {
                data
            };
            return Json(bookList);
        }
    }
}
