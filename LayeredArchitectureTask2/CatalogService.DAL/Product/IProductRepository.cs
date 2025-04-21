using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogService.DAL.Category;

namespace CatalogService.DAL.Product
{
    public interface IProductRepository
    {
        List<ProductEntity> GetAllProduct();
        ProductEntity GetProductById(int id);
        void AddProduct(ProductEntity product);
        void UpdateProduct(ProductEntity product);
        void DeleteProduct(int id);
    }
}
