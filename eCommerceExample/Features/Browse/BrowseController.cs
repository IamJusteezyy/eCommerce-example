using Microsoft.AspNetCore.Mvc;

namespace eCommerceExample.Features.Browse
{
    [Route("Browse")]
    public class BrowseController : Controller
    {
        public BrowseController() 
        {
        
        }

        public IActionResult Browse()
        {
            return View();
        }
    }
}
