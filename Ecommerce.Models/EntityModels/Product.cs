using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models.EntityModels
{
    public class Product
    {
        [Key]
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
