using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsStore.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Product product, int quantity)
        {
            CartLine line = lineCollection
                .Where(p => p.Product.ProductID == product.ProductID)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine { Product = product, Quantity = quantity });

            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Product.Price * e.Quantity);

        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        /*public List<CartLine> Lines2
        {
            get
            {
                return new List<CartLine>();    
            }
            set
            {
                lineCollection = value;
            }
            
        }*/
        public List<string> Lines2 {get;set;}

        public List<CartLine> Lines
        { 
            get
            {
                return lineCollection;
            }
            /*set
            {
                lineCollection = value.ToList();
            }*/
        }
    }

    public class Cart2
    {
        public List<string> Lines2  {get;set;}
        public List<CartLine1> Lines1{get;set;}
        public List<CartLine> Lines{get;set;}
    }

     public class CartLine1
    {        
        public int Product  { get; set; }
        public int Quantity { get; set; }
    }

    
}
