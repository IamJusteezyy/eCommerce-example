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
        public string Title { get; set; }
        public string Author { get; set; }
        public Decimal Price { get; set; }
    }
}
