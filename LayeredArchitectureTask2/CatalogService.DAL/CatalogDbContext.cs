using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogService.DAL.Category;
using CatalogService.DAL.Product;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.DAL
{
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options) { }
     
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=EPINPUNW046E\\SQLEXPRESS;Initial Catalog=CatalogServiceDB;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True");

            base.OnConfiguring(optionsBuilder);
        }

    }
}
