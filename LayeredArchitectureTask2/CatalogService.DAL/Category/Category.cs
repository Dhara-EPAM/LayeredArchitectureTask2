using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogService.DAL.Product;

namespace CatalogService.DAL.Category
{
    public class CategoryEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string? Image { get; set; }
        public int? ParentCategoryId { get; set; }

        public CategoryEntity? ParentCategory { get; set; }
        
    }
}
