using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogService.DAL.Category;

namespace CatalogService.BLL.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        //Constructor
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<CategoryDTO> GetAllCategoty()
        {
            var categories = _categoryRepository.GetAllCategory();
            return categories.Select(c => new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name,
                Image = c.Image,
                ParentCategoryId = c.ParentCategoryId
            }).ToList();
        }

        public CategoryDTO GetCategoryById(int id)
        {
            CategoryDTO cat = new CategoryDTO();
            var category = _categoryRepository.GetCategoryById(id);
           return cat = new CategoryDTO
           {
                Id = category.Id,
                Name = category.Name,
                Image = category.Image,
               ParentCategoryId = category.ParentCategoryId
           };
        }

        public void AddCategory(CategoryDTO categoryDto)
        {
            var category = new CategoryEntity
            {
                Name = categoryDto.Name,
                Image = categoryDto.Image,
                ParentCategoryId = categoryDto.ParentCategoryId
            };

            _categoryRepository.AddCategory(category);
        }

        public void UpdateCategory(CategoryDTO categoryDto)
        {
            var category = new CategoryEntity
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name,
                Image = categoryDto.Image,
                ParentCategoryId = categoryDto.ParentCategoryId
            };

            _categoryRepository.UpdateCategory(category);
        }

        public void DeleteCategory(int id)
        {
            _categoryRepository.DeleteCategory(id);
        }


    }
}
