using System.ComponentModel.DataAnnotations;

namespace Ecommerce.WebApp.Models
{
    public class CategoryCreate
    {
        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }
    }
}
