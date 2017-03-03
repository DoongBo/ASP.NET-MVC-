using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ninject;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Concrete;

namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver:IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            //绑定放在这
            //Mock<IProductRespository> mock = new Mock<IProductRespository>();
            //mock.Setup(m => m.Products).Returns(new List<Product>{
            //    new Product{Name="Football",Price=25,Category="Soccer",Description="Description0"},
            //    new Product{Name="Surf board",Price=179,Category="Soccer",Description="Description1"},
            //    new Product{Name="Running shoes",Price=95,Category="Soccer1",Description="Description2"}
            //});
            kernel.Bind<IProductRespository>().To<EFProductRepository>();
            //kernel.Bind<IProductRespository>().ToConstant(mock.Object);
        }
       
    }
}