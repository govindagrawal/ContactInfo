using System.Web.Mvc;
using ContactInfo.DataAccessLayer;
using ContactInfo.DataAccessLayer.Repositories;
using Unity;
using Unity.Mvc5;

namespace ContactInfo
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<IContactRepository, ContactRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}