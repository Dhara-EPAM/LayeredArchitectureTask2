using AutoMapper;
using CatalogService.Website.Models;

namespace CatalogService.Website.AutoMapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //CAtegory
            CreateMap<BLL.Category.CategoryDTO, Category>();
            CreateMap<Category, BLL.Category.CategoryDTO>();

            //Product
            CreateMap<BLL.Product.ProductDTO, Product>();
            CreateMap<Product, BLL.Product.ProductDTO>();
        }
    }
}
