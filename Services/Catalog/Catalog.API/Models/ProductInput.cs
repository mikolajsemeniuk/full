using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Models
{
    public class ProductInput
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Summary { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImageFile { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}