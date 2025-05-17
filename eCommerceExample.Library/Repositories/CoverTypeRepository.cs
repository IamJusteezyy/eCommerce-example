using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerceExample.EF.DBContext;
using eCommerceExample.EF.DBModels;
using eCommerceExample.Repository.Interfaces;

namespace eCommerceExample.Library.Repositories
{
    public class CoverTypeRepository : GenericRepository<CoverTypeEF>, ICoverTypeRepository
    {
        public CoverTypeRepository(NookBookContext context) : base(context) { }
    }
}
