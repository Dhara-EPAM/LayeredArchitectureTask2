using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogService.BLL.Category;

namespace CatalogService.BLL.Product
{
    public interface IProductService
    {
        List<ProductDTO> GetAllProduct();
        ProductDTO GetProductById(int id);
        void AddProduct(ProductDTO product);
        void UpdateProduct(ProductDTO product);
        void DeleteProduct(int id);
    }
}
