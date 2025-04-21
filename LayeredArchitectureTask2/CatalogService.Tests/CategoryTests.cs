using AutoMapper;
using CatalogService.BLL.Category;
using CatalogService.Website.Controllers;
using CatalogService.Website.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CatalogService.Tests
{
    public class CategoryTests
    {
        private Mock<ICategoryService> _mockCategoryService;
        private Mock<IMapper> _mockMapper;
        private CategoryController _controller;

        [SetUp]
        public void Setup()
        {
            _mockCategoryService = new Mock<ICategoryService>();
            _mockMapper = new Mock<IMapper>();
            _controller = new CategoryController(_mockCategoryService.Object, _mockMapper.Object);
        }

        [Test]
        public void GEtAllCategories_ReturnsView()
        {
            var categories = new List<CategoryDTO>
            {
                new CategoryDTO { Id = 1, Name = "Electronics", Image = "electronics.png", ParentCategoryId = null },
                new CategoryDTO { Id = 2, Name = "Clothes", Image = "clothes.png", ParentCategoryId = 1 }
            };
            _mockCategoryService.Setup(s => s.GetAllCategoty()).Returns(categories);

            var result = _controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            var model = result.Model as List<Category>;
            Assert.IsNotNull(model);
            Assert.AreEqual(2, model.Count);
            Assert.AreEqual("Electronics", model.First().Name);
        }

        [Test]
        public void AddCategory_RedirectsToThanks()
        {
            var category = new Category { Id = 1, Name = "Electronics", Image = "electronics.png", ParentCategoryId = null };
            var categoryDto = new CategoryDTO { Id = 1, Name = "Electronics", Image = "electronics.png", ParentCategoryId = null };

            _mockMapper.Setup(m => m.Map<CategoryDTO>(category)).Returns(categoryDto);

            var result = _controller.Create(category) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Thanks", result.ViewName);
            _mockCategoryService.Verify(s => s.AddCategory(It.IsAny<CategoryDTO>()), Times.Once);
        }

        
        [Test]
        public void EditCategory_GetById_ReturnsView()
        {
            var categoryDto = new CategoryDTO { Id = 1, Name = "Electronics", Image = "electronics.png" };
            var category = new Category { Id = 1, Name = "Electronics", Image = "electronics.png" };

            _mockCategoryService.Setup(s => s.GetCategoryById(1)).Returns(categoryDto);
            _mockMapper.Setup(m => m.Map<Category>(categoryDto)).Returns(category);

            var result = _controller.Edit(1) as ViewResult;

            Assert.IsNotNull(result);
            var model = result.Model as Category;
            Assert.IsNotNull(model);
            Assert.AreEqual("Electronics", model.Name);
        }

        [Test]
        public void EditCategory_RedirectsToThanks()
        {
            var category = new Category { Id = 1, Name = "Electronics", Image = "electronics.png" };
            var categoryDto = new CategoryDTO { Id = 1, Name = "Electronics", Image = "electronics.png" };

            _mockMapper.Setup(m => m.Map<CategoryDTO>(category)).Returns(categoryDto);

            var result = _controller.Edit(1, category) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Thanks", result.ViewName);
            _mockCategoryService.Verify(s => s.UpdateCategory(It.IsAny<CategoryDTO>()), Times.Once);
        }

        [Test]
        public void DeleteCategory_RedirectsToThanks()
        {
            var result = _controller.Delete(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Thanks", result.ViewName);
            _mockCategoryService.Verify(s => s.DeleteCategory(1), Times.Once);
        }

        [TearDown]
        public void Cleanup()
        {
            _controller.Dispose();
        }
    }
}