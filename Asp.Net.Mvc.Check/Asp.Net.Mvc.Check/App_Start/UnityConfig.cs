using System.Web.Mvc;
using Asp.Net.Mvc.Check.Infrastructure;
using Unity;
using UnityDependencyResolver = Unity.Mvc5.UnityDependencyResolver;
using Unity.AspNet.Mvc;

namespace Asp.Net.Mvc.Check
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<ITestService, TestService>(new PerRequestLifetimeManager());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}