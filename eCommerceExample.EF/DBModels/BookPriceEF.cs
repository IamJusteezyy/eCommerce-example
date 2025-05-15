using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceExample.EF.DBModels
{
    [Table("tblBookPrice")]
    public class BookPriceEF
    {
        public int BookID { get; set; }
        public int CoverTypeID { get; set; }
        public Decimal Price { get; set; }
    }
}
