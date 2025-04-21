using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CatalogService.BLL.Product;
using CatalogService.Website.Controllers;
using CatalogService.Website.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CatalogService.Tests
{
    public class ProductTests
    {
        private Mock<IProductService> _mockProductService;
        private Mock<IMapper> _mockMapper;
        private ProductController _controller;

        [SetUp]
        public void SetUp()
        {
            _mockProductService = new Mock<IProductService>();
            _mockMapper = new Mock<IMapper>();
            _controller = new ProductController(_mockProductService.Object, _mockMapper.Object);
        }

        [Test]
        public void GEtAllProducts_ReturnsView()
        {
            var mockProducts = new List<ProductDTO>
            {
                new ProductDTO { Id = 1, Name = "Product 1", Description = "Description 1", Price = 10, Amount = 5, CategoryId = 1 },
                new ProductDTO { Id = 2, Name = "Product 2", Description = "Description 2", Price = 20, Amount = 3, CategoryId = 2 }
            };

            _mockProductService.Setup(p => p.GetAllProduct()).Returns(mockProducts);

            var result = _controller.Index() as ViewResult;
            var model = result?.Model as List<Product>;

            Assert.IsNotNull(result);
            Assert.IsNotNull(model);
            Assert.AreEqual(2, model.Count);
            Assert.AreEqual("Product 1", model[0].Name);
            Assert.AreEqual("Product 2", model[1].Name);
        }

        [Test]
        public void AddProduct_RedirectsToThanksView()
        {
            var inputProduct = new Product
            {
                Id = 1,
                Name = "Test Product",
                Description = "Test Description",
                Price = 10,
                Amount = 5,
                CategoryId = 1
            };

            var mappedProductDto = new ProductDTO
            {
                Id = 1,
                Name = "Test Product",
                Description = "Test Description",
                Price = 10,
                Amount = 5,
                CategoryId = 1
            };

            _mockMapper.Setup(m => m.Map<ProductDTO>(inputProduct)).Returns(mappedProductDto);

            var result = _controller.Create(inputProduct) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Thanks", result.ViewName);
            _mockProductService.Verify(p => p.AddProduct(It.IsAny<ProductDTO>()), Times.Once);
        }

        [Test]
        public void Edit_GetReturnsViewWithProduct()
        {
            int productId = 1;
            var mockProductDto = new ProductDTO { Id = productId, Name = "Product 1" };

            _mockProductService.Setup(p => p.GetProductById(productId)).Returns(mockProductDto);
            _mockMapper.Setup(m => m.Map<Product>(mockProductDto)).Returns(new Product { Id = productId, Name = "Product 1" });

            var result = _controller.Edit(productId) as ViewResult;
            var model = result?.Model as Product;

            Assert.IsNotNull(result);
            Assert.IsNotNull(model);
            Assert.AreEqual(productId, model.Id);
            Assert.AreEqual("Product 1", model.Name);
        }

        [Test]
        public void EditProduct_RedirectsToThanksView()
        {
            int productId = 1;
            var inputProduct = new Product
            {
                Id = productId,
                Name = "Updated Product",
                Description = "Updated Description",
                Price = 15,
                Amount = 4,
                CategoryId = 2
            };

            var mappedProductDto = new ProductDTO
            {
                Id = productId,
                Name = "Updated Product",
                Description = "Updated Description",
                Price = 15,
                Amount = 4,
                CategoryId = 2
            };

            _mockMapper.Setup(m => m.Map<ProductDTO>(inputProduct)).Returns(mappedProductDto);

            var result = _controller.Edit(productId, inputProduct) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Thanks", result.ViewName);
            _mockProductService.Verify(p => p.UpdateProduct(It.IsAny<ProductDTO>()), Times.Once);
        }

        [Test]
        public void DeleteProduct_RedirectsToThanksView()
        {
            int productId = 1;

            var result = _controller.Delete(productId) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Thanks", result.ViewName);
            _mockProductService.Verify(p => p.DeleteProduct(productId), Times.Once);
        }

        [TearDown]
        public void Cleanup()
        {
            _controller.Dispose();
        }
    }
}
