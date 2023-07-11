using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models.EntityModels
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }
        
    }
}
