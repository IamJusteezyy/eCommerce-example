using eCommerceExample.EF.DBModels;
using eCommerceExample.Library.UnitOfWork;
using eCommerceExample.Repository.Interfaces;
using eCommerceExample.Repository.IUnitOfWork;
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
    }
}
