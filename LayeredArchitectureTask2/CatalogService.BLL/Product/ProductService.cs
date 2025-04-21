using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogService.BLL.Category;
using CatalogService.DAL.Category;
using CatalogService.DAL.Product;

namespace CatalogService.BLL.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        //Constructor
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<ProductDTO> GetAllProduct()
        {
            var categories = _productRepository.GetAllProduct();
            return categories.Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description =p.Description,
                Image = p.Image,
                Price = p.Price,
                Amount = p.Amount,
                CategoryId = p.CategoryId
            }).ToList();
        }
        public ProductDTO GetProductById(int id)
        {
            var product = _productRepository.GetProductById(id);
            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Image = product.Image,
                Price = product.Price,
                Amount = product.Amount,
                CategoryId = product.CategoryId
            };
        }
        public void AddProduct(ProductDTO productDto)
        {
            var product = new ProductEntity
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Image = productDto.Image,
                Price = productDto.Price,
                Amount = productDto.Amount,
                CategoryId = productDto.CategoryId
            };

            _productRepository.AddProduct(product);
        }

        public void UpdateProduct(ProductDTO productDto)
        {
            var product = new ProductEntity
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Description = productDto.Description,
                Image = productDto.Image,
                Price = productDto.Price,
                Amount = productDto.Amount,
                CategoryId = productDto.CategoryId
            };

            _productRepository.UpdateProduct(product);
        }

        public void DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);
        }

    }
}
