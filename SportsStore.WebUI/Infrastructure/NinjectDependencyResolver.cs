using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Infrastructure.Abstract;
using SportsStore.Domain.Concrete;
using SportsStore.WebUI.Infrastructure.Concrete;
using SportsStore.Domain.Entities;
using System.Configuration;


namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }

        private void AddBindings()
        {

            // put additional bindings here

            kernel.Bind<IProductRepository>().To<EFProductRepository>();
            kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();

            // create the email settings object
            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(
                    ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")

            };

            kernel.Bind<IOrderProcessor>()
                .To<EmailOrderProcessor>()
                .WithConstructorArgument("settings", emailSettings);
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}