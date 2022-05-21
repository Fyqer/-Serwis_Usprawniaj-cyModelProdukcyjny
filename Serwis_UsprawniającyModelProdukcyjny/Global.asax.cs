using Serwis_UsprawniającyModelProdukcyjny.Controllers;
using Serwis_UsprawniającyModelProdukcyjny.Services.Implementations;
using Serwis_UsprawniającyModelProdukcyjny.Services.Interfaces;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.ComponentModel;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Serwis_UsprawniającyModelProdukcyjny
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new SimpleInjector.Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            container.Register<CalculatorContext>(Lifestyle.Scoped);
            container.Register<CitiesController>(Lifestyle.Scoped);
            container.Register<ICityService, CityService>(Lifestyle.Scoped);
            container.Register<IModuleService, ModuleService>(Lifestyle.Scoped);
            container.Register<ICalculatorCostService , CalculatorCostService>(Lifestyle.Scoped);
            container.Register<ISearchHistoryService , SearchHistoryService>(Lifestyle.Scoped);
            container.Register<IShowResultService, ShowResultService>(Lifestyle.Scoped);
            container.Verify
                ();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
