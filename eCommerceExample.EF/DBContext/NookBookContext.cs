using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerceExample.EF.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace eCommerceExample.EF.DBContext
{
    public class NookBookContext : DbContext
    {
        public NookBookContext(DbContextOptions<NookBookContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookPriceEF>().HasNoKey();
        }

        public DbSet<BookEF> Books { get; set; }
        public DbSet<BookPriceEF> BookPrices { get; set; }
        public DbSet<CoverTypeEF> CoverTypes { get; set; }
        public DbSet<GenreEF> Genres { get; set; }
    }
}
