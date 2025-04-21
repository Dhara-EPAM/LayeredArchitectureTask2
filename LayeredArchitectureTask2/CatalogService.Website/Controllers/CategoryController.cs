using AutoMapper;
using CatalogService.BLL.Category;
using CatalogService.Website.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Website.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        // GET: CategoryController
        public ActionResult Index()
        {
            var category = _categoryService.GetAllCategoty();
            var categoryList = category.Select(i => new Category
            {
                Id = i.Id,
                Name = i.Name,
                Image = i.Image,
                ParentCategoryId = i.ParentCategoryId

            }).ToList();

            return View(categoryList);
        }


        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                var _category =
                        _mapper.Map<BLL.Category.CategoryDTO>(category);

                _categoryService.AddCategory(_category);

                return View("Thanks");
            }
            catch
            {
                return View("Shared/Error");
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            var _category =
                        _mapper.Map<Category>(category);
            return View(_category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Category category)
        {
            try
            {
                var _category =
                       _mapper.Map<BLL.Category.CategoryDTO>(category);

                _categoryService.UpdateCategory(_category);

                return View("Thanks");
            }
            catch
            {
                return View("Shared/Error");
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                _categoryService.DeleteCategory(id);

                return View("Thanks");
            }
            catch
            {
                return View("Shared/Error");
            }
        }
    }
}
