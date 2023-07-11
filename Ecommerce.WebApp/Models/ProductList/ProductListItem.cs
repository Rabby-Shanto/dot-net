using Ecommerce.Models.EntityModels;

namespace Ecommerce.WebApp.Models.ProductList
{
    public class ProductListItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string price { get; set; }

        public string size { get; set; }

        public string color { get; set; }

        public string Description { get; set; }

        public int CategoryID { get; set; }

        public Category? Category { get; set; }
    }
}
