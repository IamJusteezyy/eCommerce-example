using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerceExample.EF.DBModels;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace eCommerceExample.Repository.Interfaces
{
    public interface ICoverTypeRepository : IGenericRepository<CoverTypeEF>
    {

    }
}
