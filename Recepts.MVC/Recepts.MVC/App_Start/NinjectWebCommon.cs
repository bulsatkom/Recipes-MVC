[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Recepts.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Recepts.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace Recepts.MVC.App_Start
{
    using System;
    using System.Web;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Data;
    using Recepts_MVC_DataServices;
    using DataServices;

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

        public static IKernel Kernel { get; private set; }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
             Kernel = new StandardKernel();
            try
            {
                Kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                Kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(Kernel);
                return Kernel;
            }
            catch
            {
                Kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IEfDbSetWrapper<>)).To(typeof(EfDbSetWrapper<>));
            kernel.Bind(typeof(Recepts_MVC_EFDbContext)).ToSelf().InRequestScope();
            kernel.Bind<IReceptForDayService>().To<ReceptForDayService>();
            kernel.Bind<IKusmetiService>().To<KusmetiService>();
            kernel.Bind<IProductService>().To<ProductService>();
            kernel.Bind<INoviniService>().To<NoviniService>();
            kernel.Bind<ICommentService>().To<CommentService>();
            kernel.Bind<IChatService>().To<ChatService>();
            kernel.Bind<ICommentsForNoviniService>().To<CommentsForNoviniService>();
        }        
    }
}
