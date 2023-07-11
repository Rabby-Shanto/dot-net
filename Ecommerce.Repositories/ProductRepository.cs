using Ecommerce.Database;
using Ecommerce.Models.EntityModels;
using Ecommerce.Models.UtilityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositories
{
    public class ProductRepository
    {
        ApplicationDbContext _db;

        public ProductRepository()
        {
            _db = new ApplicationDbContext();
        }


        public bool Add(Product product)
        {
            _db.Products.Add(product);
            return _db.SaveChanges() > 0;
        }

        public bool AddRange(ICollection<Product> products)
        {
            _db.Products.AddRange(products);
            return _db.SaveChanges() > 0;
        }

        public bool Update(Product product)
        {
            _db.Products.Update(product);

            return _db.SaveChanges() > 0;
        }

        public bool UpdateRange(ICollection<Product> products)
        {
            _db.Products.UpdateRange(products);
            return _db.SaveChanges() > 0;
        }

        public bool Delete(Product product)
        {
            _db.Products.Remove(product);
            return _db.SaveChanges() > 0;
        }

        public Product GetById(int id)
        {
            return _db.Products.FirstOrDefault(c => c.Id == id);
        }

        public ICollection<Product> GetAll()
        {
            return _db.Products.ToList();
        }

        //public ICollection<Product> Search(CustomerSearchCriteria searchCriteria)
        //{
        //    var customers = _db.Customers.AsQueryable();

        //    if (!string.IsNullOrEmpty(searchCriteria.SearchText))
        //    {
        //        string searchText = searchCriteria.SearchText.ToLower();

        //        customers = customers.Where(c => c.Name.ToLower().Contains(searchText)
        //        || c.Phone.ToLower().Contains(searchText)
        //        || c.Email.ToLower().Contains(searchText));
        //    }


        //    if (searchCriteria != null && !string.IsNullOrEmpty(searchCriteria.Name))
        //    {
        //        customers = customers.Where(c => c.Name.ToLower().Contains(searchCriteria.Name.ToLower()));
        //    }

        //    if (searchCriteria != null && !string.IsNullOrEmpty(searchCriteria.Phone))
        //    {
        //        customers = customers.Where(c => c.Phone.ToLower().Contains(searchCriteria.Phone.ToLower()));
        //    }

        //    if (searchCriteria != null && !string.IsNullOrEmpty(searchCriteria.Email))
        //    {
        //        customers = customers.Where(c => c.Email.ToLower().Contains(searchCriteria.Email.ToLower()));
        //    }



        //    int skipSize = (searchCriteria.CurrentPage - 1) * searchCriteria.PageSize;

        //    return customers.Skip(skipSize).Take(searchCriteria.PageSize).ToList();



        //}
    }
}

