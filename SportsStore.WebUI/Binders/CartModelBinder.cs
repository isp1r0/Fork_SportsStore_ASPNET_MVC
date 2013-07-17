using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Binders
{
    public class CartModelBinder :  DefaultModelBinder //IModelBinder
    {
        private const string sessionKey = "Cart";

        //public override object BindModel(ControllerContext controllerContext,ModelBindingContext bindingContext)
        public object BindModel_2(ControllerContext controllerContext,ModelBindingContext bindingContext)
        {

            // get the Cart from the session
            Cart cart = (Cart)controllerContext.HttpContext.Session[sessionKey];
            // create the Cart if there wasn't one in the session data
            if (cart == null)
            {
                cart = new Cart();                
                controllerContext.HttpContext.Session[sessionKey] = cart;
            }            

            // return the cart
            return cart;
        }

        protected override void OnModelUpdated(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            base.OnModelUpdated(controllerContext, bindingContext);
        }

        protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, System.ComponentModel.PropertyDescriptor propertyDescriptor)
        {
            base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
        }
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            // get the Cart from the session
            Cart cart = (Cart)controllerContext.HttpContext.Session[sessionKey];
            // create the Cart if there wasn't one in the session data
            if (cart == null)
            {
                cart = new Cart();                
                controllerContext.HttpContext.Session[sessionKey] = cart;
            }            

            // return the cart
            return cart;
            //return base.CreateModel(controllerContext, bindingContext, modelType);
        }

        protected override bool OnModelUpdating(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            return base.OnModelUpdating(controllerContext, bindingContext);
        }
        
    }
}