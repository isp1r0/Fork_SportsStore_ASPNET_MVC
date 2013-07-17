using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;
using SportsStore.WebUI.Infrastructure.Extensions;


namespace SportsStore.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
     
        private IProductRepository repository;

        #region Product

        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult Products()
        {
            return View(repository.Products);
        }

        public ViewResult EditProduct(int productId)
        {
            IEnumerable<Category>  categoryList = repository.Categories;
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);

            ProductEditViewModel viewModel = new ProductEditViewModel() {
                ProductID = product.ProductID,
                Name = product.Name,
                SelectedCategoryID = product.CategoryID,
                Price = product.Price,
                Description = product.Description,
                Categories = categoryList 
            };

            return View(viewModel);
        }

        public ViewResult CreateProduct()
        {
            IEnumerable<Category> categoryList = repository.Categories;
            return View("EditProduct", new ProductEditViewModel() { Categories = categoryList });
        }

        [HttpPost]
        public ActionResult EditProduct(ProductEditViewModel productViewModel)
        {

            if (ModelState.IsValid)
            {
                repository.SaveProduct(productViewModel.ToDomainProduct());
                TempData["message"] = string.Format("{0} has been saved", productViewModel.Name);
                return RedirectToAction("Products");
            }
            else
            {
                IEnumerable<Category> categoryList = repository.Categories;
                productViewModel.Categories = categoryList;

                // there is something wrong with the data values
                return View(productViewModel);
            }
        }

        [HttpPost]
        public ActionResult DeleteProduct(int productId)
        {
            Product prod = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (prod != null)
            {
                repository.DeleteProduct(prod);
                TempData["message"] = string.Format("{0} was deleted", prod.Name);
            }
            return RedirectToAction("Products");
        }

        #endregion

        #region Category
        public ViewResult Categories()
        {
            return View(repository.Categories);
        }

        public ViewResult CreateCategory()
        {
            return View("EditCategory", new Category());
        }

        public ViewResult EditCategory(int categoryId)
        {
            Category category = repository.Categories.FirstOrDefault(p => p.CategoryID == categoryId);
            return View(category);
        }

        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                repository.SaveCategory(category);
                TempData["message"] = string.Format("{0} has been saved", category.Name);
                return RedirectToAction("Categories");
            }
            else
            {
                // there is something wrong with the data values
                return View(category);
            }
        }

        [HttpPost]
        public ActionResult DeleteCategory(int categoryId)
        {
            Category category = repository.Categories.FirstOrDefault(p => p.CategoryID == categoryId);
            if (category != null)
            {
                repository.DeleteCategory(category);
                TempData["message"] = string.Format("{0} was deleted", category.Name);
            }
            return RedirectToAction("Categories");
        }
        #endregion

    }
}
