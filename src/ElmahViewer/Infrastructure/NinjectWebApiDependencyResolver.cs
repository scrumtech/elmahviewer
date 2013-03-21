
namespace ElmahViewer.Infrastructure
{
    using Ninject;
    using System;
    using System.Collections.Generic;

    public class NinjectWebApiDependencyResolver : System.Web.Http.Dependencies.IDependencyResolver
    {
        private readonly IKernel kernel;

        public NinjectWebApiDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
        }
        public System.Web.Http.Dependencies.IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            return this.kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return this.kernel.GetAll(serviceType);
            }
            catch (Exception)
            {
                return new List<object>();
            }
        }

        public void Dispose()
        {
            // When BeginScope returns 'this', the Dispose method must be a no-op.
        }
    }
}