using Ecommerce.Models.EntityModels;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.WebApp.Models
{
    public class ProductCreate
    {
        [Required(ErrorMessage = "Please provide name.")]
        public string ProductName { get; set; }

        [Required]
        public string price { get; set; }

        public string size { get; set; }

        public string color { get; set; }

        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}

