using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerceExample.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace eCommerceExample.Repository.IUnitOfWork
{
    public interface IUnitOfWork
    {
        IBookRepository BookRepository { get; }
        void Save();
    }
}
