using AutoMapper;
using CatalogService.BLL.Category;
using CatalogService.BLL.Product;
using CatalogService.Website.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Website.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            var product = _productService.GetAllProduct();
            var productList = product.Select(i => new Product
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description,
                Image = i.Image,
                Price = i.Price,
                Amount= i.Amount,
                CategoryId = i.CategoryId

            }).ToList();

            return View(productList);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                var _product =
                        _mapper.Map<BLL.Product.ProductDTO>(product);

                _productService.AddProduct(_product);

                return View("Thanks");
            }
            catch
            {
                return View("Shared/Error");
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _productService.GetProductById(id);
            var _product =
                        _mapper.Map<Product>(product);
            return View(_product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                var _product =
                       _mapper.Map<BLL.Product.ProductDTO>(product);

                _productService.UpdateProduct(_product);

                return View("Thanks");
            }
            catch
            {
                return View("Shared/Error");
            }
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                _productService.DeleteProduct(id);

                return View("Thanks");
            }
            catch
            {
                return View("Shared/Error");
            }
        }
    }
}
