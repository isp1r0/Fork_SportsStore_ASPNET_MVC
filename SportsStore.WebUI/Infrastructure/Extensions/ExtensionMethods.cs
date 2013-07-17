using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Infrastructure.Extensions
{
    public static class ExtensionMethods
    {
        public static Product ToDomainProduct(this ProductEditViewModel viewModel)
        {
            Product prod = new Product()
            {
                ProductID = viewModel.ProductID,
                Name = viewModel.Name,
                CategoryID = Convert.ToInt32( viewModel.SelectedCategoryID),
                Price = viewModel.Price,
                Description = viewModel.Description
            };
            return prod;
        }
    }
}