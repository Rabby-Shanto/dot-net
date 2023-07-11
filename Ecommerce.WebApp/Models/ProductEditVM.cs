using System.ComponentModel.DataAnnotations;

namespace Ecommerce.WebApp.Models
{
    public class ProductEditVM
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide name.")]
        public string ProductName { get; set; }

        [Required]
        public string price { get; set; }

        public string size { get; set; }

        public string color { get; set; }

        public string Description { get; set; }
    }
}
