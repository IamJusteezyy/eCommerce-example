using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceExample.EF.DBModels
{
    [Table("tlkCoverType")]
    public class CoverTypeEF
    {
        [Key]
        public int CoverTypeID { get; set; }
        public string CoverType { get; set; }
    }
}
