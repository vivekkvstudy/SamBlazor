using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SamBlazor.Data
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } 

        [Range(0,1000)]
        public decimal Price { get; set; }

        public string? Description { get; set; } = string.Empty;

        public string? SpecialTag { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public string? ImageUrl { get; set; } = string.Empty;
    }
}
