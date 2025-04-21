using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogService.DAL.Category;

namespace CatalogService.DAL.Product
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }

        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
    }
}
