using Ecommerce.Models.EntityModels;
using Ecommerce.Repositories;
using Ecommerce.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebApp.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository _categoryRepository;

        public CategoryController()
        {
            _categoryRepository = new CategoryRepository();
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


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryCreate model)
        {

            if (ModelState.IsValid)
            {
                var category = new Category()
                {
                    CategoryCode = model.CategoryCode,
                    CategoryName = model.CategoryName,

            
 
                };
                //Database operations 
                bool isSuccess = _categoryRepository.Add(category);

                if (isSuccess)
                {
                    return View();
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

            var category = _categoryRepository.GetById((int)id);

            if (category == null)
            {
                ViewBag.Error = "Sorry, no category found for this id.";
                return View();
            }

            var model = new CategoryEditVM()
            {
                CategoryCode = category.CategoryCode,
                CategoryName = category.CategoryName,

            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CategoryEditVM model)
        {
            if (ModelState.IsValid)
            {
                var category = _categoryRepository.GetById(model.Id);

                if (category == null)
                {
                    ViewBag.Error = "category not found to update!";
                    return View(model);
                }

                category.CategoryCode = model.CategoryCode;
                category.CategoryName = model.CategoryName;



                bool isSuccess = _categoryRepository.Update(category);
                if (isSuccess)
                {
                    return View();
                }
            }

            return View(model);
        }
    }
}
