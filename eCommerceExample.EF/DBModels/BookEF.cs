using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceExample.EF.DBModels
{
    [Table("tblBook")]
    public class BookEF
    {
        [Key]
        public int BookID { get; set; }
        public string BookTitle { get; set; }
        public Int64 ISBN { get; set; }
        public string Author { get; set; }
        public string? Publisher { get; set; }
        public DateTime? PublishedDate { get; set; }
        public int? PageCount { get; set; }
        public string? BlobURL { get; set; }
    }
}
