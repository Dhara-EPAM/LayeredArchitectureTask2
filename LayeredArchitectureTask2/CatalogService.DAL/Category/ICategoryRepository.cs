using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.DAL.Category
{
    public interface ICategoryRepository
    {
        List<CategoryEntity> GetAllCategory();
        CategoryEntity GetCategoryById(int id);
        void AddCategory(CategoryEntity categoty);
        void UpdateCategory(CategoryEntity category);
        void DeleteCategory(int id);
    }
}
