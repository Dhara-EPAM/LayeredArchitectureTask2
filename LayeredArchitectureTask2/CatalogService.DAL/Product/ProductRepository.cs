using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogService.DAL.Category;

namespace CatalogService.DAL.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatalogDbContext _dbContext;

        public ProductRepository(CatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ProductEntity> GetAllProduct()
        {
            return _dbContext.Products.ToList();
        }
        public ProductEntity GetProductById(int id)
        {
            return _dbContext.Products.Find(id);
        }

        public void AddProduct(ProductEntity product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }

        public void UpdateProduct(ProductEntity product)
        {
            _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var entity = _dbContext.Products.Find(id);
            if (entity != null)
            {
                _dbContext.Products.Remove(entity);
                _dbContext.SaveChanges();
            }
        }
    }
}
