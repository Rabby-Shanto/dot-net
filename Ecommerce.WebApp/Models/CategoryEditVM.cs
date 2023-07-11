using Ecommerce.Models.EntityModels;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.WebApp.Models
{
    public class CategoryEditVM
    {
        [Key]
        public int Id { get; set; }

        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
