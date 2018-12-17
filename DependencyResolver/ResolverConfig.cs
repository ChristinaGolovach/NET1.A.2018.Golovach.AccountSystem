using System.Data.Entity;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Interface.Interfaces;
using DAL.Fake.Repositories;
using DAL.Repositories;
using ORMDBFirst;
using DAL;
using Ninject;
using Ninject.Web.Common;


namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolverConsole(this IKernel kernel)
        {
            ConfigurateResolver(kernel, false);
        }

        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            ConfigurateResolver(kernel, true);
        }

        private static void ConfigurateResolver(IKernel kernel, bool isWeb)
        {
            kernel.Bind<IAccountService>().To<AccountService>();
            kernel.Bind<IOwnerService>().To<OwnerService>();
            kernel.Bind<IAccountRepository>().To<AccountRepository>();
            kernel.Bind<IOwnerRepository>().To<OwnerRepository>();
            kernel.Bind<INumberGenerator<string>>().To<AccountNumberGenerator>().InSingletonScope();

            if (isWeb)
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
                kernel.Bind<DbContext>().To<AccountSystemEntities>().InRequestScope();
            }
            else
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
                kernel.Bind<DbContext>().To<AccountSystemEntities>().InSingletonScope();
            }

            //kernel.Bind<IAccountRepository>().To<AccountFakeRepository>();
            //kernel.Bind<IOwnerRepository>().To<OwnerFakeRepository>();            
        }


        //TODO Later fo DBContext

        // https://github.com/ninject/Ninject.Web.Common/wiki/InRequestScope
        // The Ninject kernel maintains a weak reference to scoping objects and will automatically 
        // Dispose of objects associated with a scoping object 
        // when the weak reference to it is no longer valid.Since InRequestScope() uses HttpContext.Current 
        // or OperationContext.Current as the scoping object, any associated objects created will not be destroyed until HttpContext.
        // Current or OperationContext.Current is destroyed.Since IIS/ASP.NET manages the lifecycle of these objects, disposal of your objects 
        //is tied to whenever IIS/.NET decides to destroy them and that may not be predictable.

        //OnePerRequestModule is an IHttpModule provided by Ninject that will hook the EndRequest callback and Dispose instances associated with ASP.NET's
        //HttpContext.Current as part of the Ninject Kernel's Deactivation of tracked instances for you.
    }
}
