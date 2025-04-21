using System.ComponentModel.DataAnnotations;

namespace CatalogService.Website.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string? Image { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
