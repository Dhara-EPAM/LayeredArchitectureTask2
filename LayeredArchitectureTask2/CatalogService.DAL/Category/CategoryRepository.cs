using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.DAL.Category
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CatalogDbContext _dbContext;

        public CategoryRepository(CatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<CategoryEntity> GetAllCategory()
        {
            return _dbContext.Categories.ToList();
        }

        public CategoryEntity GetCategoryById(int id)
        {
            return _dbContext.Categories.Find(id);
        }

        public void AddCategory(CategoryEntity category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
        }

        public void UpdateCategory(CategoryEntity category)
        {
            _dbContext.Categories.Update(category);
            _dbContext.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var entity = _dbContext.Categories.Find(id);
            if (entity != null)
            {
                //Delete related products
                var products = _dbContext.Products.ToList().Where(x => x.CategoryId == id);
                _dbContext.Products.RemoveRange(products);
                _dbContext.SaveChanges();

                //Delete category
                _dbContext.Categories.Remove(entity);
                _dbContext.SaveChanges();
            }

        }

    }
}
