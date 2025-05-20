using eCommerceExample.Repository.Models;

namespace eCommerceExample.Features.Browse
{
    public class BrowseViewModel
    {
        public IEnumerable<Book>? BookList { get; set; }
        public string? SearchTerm { get; set; }
    }
}
