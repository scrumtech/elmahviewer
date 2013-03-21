namespace ElmahViewer
{
    using ElmahViewer.Data;
    using ElmahViewer.Models;
    using Ninject;
    using Ninject.Web.Common;
    using System.Reflection;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : NinjectHttpApplication
    {
        protected override void OnApplicationStarted() 
        {
            base.OnApplicationStarted();
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        protected static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ICache>().To<Cache>();
            kernel.Bind<IErrorLogFactory>().To<SqlErrorLogFactory>().InRequestScope();
            kernel.Bind<IErrorDetailsViewModelFactory>().To<ErrorViewModelFactory>().InRequestScope();
            kernel.Bind<IErrorListViewModelFactory>().To<ErrorViewModelFactory>().InRequestScope();
            kernel.Bind<IElmahApplicationRepository>().To<ElmahApplicationRepository>().InRequestScope();
        }
    }
}