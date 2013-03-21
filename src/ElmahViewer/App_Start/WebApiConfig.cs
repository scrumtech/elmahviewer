// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebApiConfig.cs" company="General">
//   © 2013
// </copyright>
// <summary>
//   Defines the WebApiConfig type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ElmahViewer
{
    using ElmahViewer.Data;
    using ElmahViewer.Infrastructure;
    using ElmahViewer.Models;
    using Ninject;
    using Ninject.Web.Common;
    using System.Net.Http.Formatting;
    using System.Web.Http;

    /// <summary>
    /// The web API config.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="config">
        /// The config.
        /// </param>
        public static void Register(HttpConfiguration config)
        {
            var kernel = new StandardKernel();
            kernel.Bind<ICache>().To<Cache>();
            kernel.Bind<IErrorLogFactory>().To<SqlErrorLogFactory>().InRequestScope();
            kernel.Bind<IErrorDetailsViewModelFactory>().To<ErrorViewModelFactory>().InRequestScope();
            kernel.Bind<IErrorListViewModelFactory>().To<ErrorViewModelFactory>().InRequestScope();
            kernel.Bind<IElmahApplicationRepository>().To<ElmahApplicationRepository>().InRequestScope();
            Register(config, kernel);
        }

        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="config">
        /// The config.
        /// </param>
        /// <param name="kernel">
        /// The kernel.
        /// </param>
        public static void Register(HttpConfiguration config, IKernel kernel)
        {
            config.Formatters.JsonFormatter.MediaTypeMappings.Add(new UriPathExtensionMapping("json", "application/json"));
            config.Formatters.XmlFormatter.MediaTypeMappings.Add(new UriPathExtensionMapping("xml", "application/xml"));

            config.DependencyResolver = new NinjectWebApiDependencyResolver(kernel);

            config.Routes.MapHttpRoute(
                name: "ControllerWithExt",
                routeTemplate: "api/{controller}.{ext}");
            config.Routes.MapHttpRoute(
                name: "IdWithExt",
                routeTemplate: "api/{controller}/{id}.{ext}");
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}
