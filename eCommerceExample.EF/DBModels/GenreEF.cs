using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceExample.EF.DBModels
{
    [Table("tlkGenre")]
    public class GenreEF
    {
        [Key]
        public int GenreID { get; set; }
        public string GenreLongName { get; set; }
        public string GenreShortName { get; set; }
    }
}
