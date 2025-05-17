using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerceExample.EF.DBModels;

namespace eCommerceExample.Repository.Models
{
    public class Book
    {
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public Int64 ISBN { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string? Publisher { get; set; }
        public string? BlobURL { get; set; }
        public string CoverType { get; set; }
        public Decimal Price { get; set; }
    }
}
