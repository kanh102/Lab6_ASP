using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
