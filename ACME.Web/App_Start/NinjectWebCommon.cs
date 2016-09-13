[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ACME.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ACME.Web.App_Start.NinjectWebCommon), "Stop")]

namespace ACME.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject.Extensions.Conventions;
    using Ninject;
    using Ninject.Web.Common;
    using Common.Interfaces;
    using Business.Services;
    using Business.Common;
    using Common.Repository;
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            

            kernel.Bind(x => x.FromAssembliesMatching(
                 "ACME.Data.*",
                 "ACME.DataAccess.*",
                 "ACME.Common.*",
                 "ACME.Business.*")
                         .SelectAllClasses()
                         .BindDefaultInterface());         

            //Console.WriteLine("Mode NOMSQ..."); 
            //kernel.Bind<ITicketService>().To<TicketDbService>();
            //kernel.Bind<IAvailableService>().To<AvailableDbService>();

            Console.WriteLine("Mode MSQ...");
            kernel.Bind<ITicketService>().To<TicketQueueService>();
            kernel.Bind<IAvailableService>().To<AvailableInQueueService>();

        }
    }
}
