using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System.Data;

namespace SportsStore.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Product> Products
        {
            get { return context.Products; }
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                context.Entry(product).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
        }

        public IQueryable<Category> Categories
        {
            get { return context.Categories; }
        }

        public void SaveCategory(Category category)
        {
            if (category.CategoryID == 0)
            {
                context.Categories.Add(category);
            }
            else
            {
                context.Entry(category).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            context.Categories.Remove(category);
            context.SaveChanges();
        }
    }
}
