using ContactInfo.Controllers;
using ContactInfo.DataAccessLayer;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace ContactInfo
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}