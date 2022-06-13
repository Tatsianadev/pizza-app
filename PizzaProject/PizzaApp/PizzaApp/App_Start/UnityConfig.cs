using PizzaApp.Repository;
using System.Web.Mvc;
using PizzaApp.Repository.Entities;
using Unity;
using Unity.Mvc5;

namespace PizzaApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IRepository,Repository.Repository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}