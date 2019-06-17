using System.ComponentModel.DataAnnotations;

namespace _7sala_test_application.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Image { get; set; }

        public Category Category { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}