using Asp.Net.Mvc.Check.Infrastructure;
using System.Linq;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Asp.Net.Mvc.Check.UnityMvcActivator), nameof(Asp.Net.Mvc.Check.UnityMvcActivator.Start))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(Asp.Net.Mvc.Check.UnityMvcActivator), nameof(Asp.Net.Mvc.Check.UnityMvcActivator.Shutdown))]

namespace Asp.Net.Mvc.Check
{
    public static class UnityMvcActivator
    {
        public static void Start() 
        {
            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            UnityConfig.Container = new UnityContainer();
            UnityConfig.Container.RegisterType<ITestService, TestService>(new PerRequestLifetimeManager());
            UnityConfig.Container.RegisterType<ITempDataProvider, CustomSessionTempDataProvider>();
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(UnityConfig.Container));

            DependencyResolver.SetResolver(new UnityDependencyResolver(UnityConfig.Container));
            Microsoft.Web.Infrastructure.DynamicModuleHelper.DynamicModuleUtility.RegisterModule(typeof(UnityPerRequestHttpModule));
        }

        public static void Shutdown()
        {
            UnityConfig.Container.Dispose();
        }
    }
}