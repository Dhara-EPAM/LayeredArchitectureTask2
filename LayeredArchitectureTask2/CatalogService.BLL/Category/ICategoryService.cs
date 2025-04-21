using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogService.DAL.Category;

namespace CatalogService.BLL.Category
{
    public interface ICategoryService
    {
        List<CategoryDTO> GetAllCategoty();
        CategoryDTO GetCategoryById(int id);
        void AddCategory(CategoryDTO categoty);
        void UpdateCategory(CategoryDTO category);
        void DeleteCategory(int id);
    }
}
