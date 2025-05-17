using Microsoft.AspNetCore.Mvc;

namespace eCommerceExample.Features.ViewBook
{
    public class ViewBookController : Controller
    {
        public ViewBookController()
        {

        }

        [Route("ViewBook/{bookID}")]
        public IActionResult ViewBook(int bookID)
        {
            return View();
        }
    }
}
