using Ecommerce.Models.EntityModels;
using Ecommerce.Models.UtilityModels;
using Ecommerce.Repositories;
using Ecommerce.WebApp.Models.CustomerList;
using Ecommerce.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Database;

namespace Ecommerce.WebApp.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository _productRepository;

        public ProductController()
        {
            _productRepository = new ProductRepository();
        }


        //public IActionResult Index(CustomerSearchCriteria customerSearchCriteria)
        //{
        //    var customers = _customerRepository.Search(customerSearchCriteria);

        //    ICollection<CustomerListItem> customerModels = customers.Select(c => new CustomerListItem()
        //    {
        //        Id = c.Id,
        //        Name = c.Name,
        //        Email = c.Email,
        //        Phone = c.Phone,
        //    }).ToList();

        //    var customerListModel = new CustomerListViewModel();
        //    customerListModel.CustomerList = customerModels;

        //    return View(customerListModel);
        //}

        public IActionResult Index()
        {

            var products = _productRepository.GetAll();
            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductCreate model)
        {


            if (ModelState.IsValid)
            {
                var product = new Product()
                {
                    ProductName = model.ProductName,
                    price = model.price,
                    size = model.size,
                    color = model.color,
                    CategoryID = model.CategoryId,
                    Description = model.Description
                };
                //Database operations 
                bool isSuccess = _productRepository.Add(product);

                if (isSuccess)
                {
                    return RedirectToAction("Index");
                }

            }

            return View();

        }

        public IActionResult Edit(int? id)
        
        {
            if (id == null || id <= 0)
            {
                ViewBag.Error = "Please provide valid id.";
                return View();
            }

            var product = _productRepository.GetById((int)id);

            if (product == null)
            {
                ViewBag.Error = "Sorry, no product found for this id.";
                return View();
            }

            var model = new ProductEditVM()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                price = product.price,
                size = product.size,
                color = product.color,
                CategoryID = product.CategoryID,
                Description = product.Description
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ProductEditVM model)
        {
            if (ModelState.IsValid)
            {
                var product = _productRepository.GetById(model.Id);

                if (product == null)
                {
                    ViewBag.Error = "Product not found to update!";
                    return View(model);
                }

                product.ProductName = model.ProductName;
                product.price = model.price;
                product.size = model.size;
                product.color = model.color;
                product.CategoryID = model.CategoryID;
                product.Description = model.Description;


                bool isSuccess = _productRepository.Update(product);
                if (isSuccess)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

        public IActionResult Details(int id)
        {

            Product product = _productRepository.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);

        }

        public IActionResult Delete(int id)
        {
            Product product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();

            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")][ValidateAntiForgeryToken]

        public IActionResult DeleteConfirmed(Product product)
        {
            _productRepository.Delete(product);

            return RedirectToAction("Index");
        }

    }
}

