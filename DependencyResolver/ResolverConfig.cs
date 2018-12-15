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


namespace DependencyResolver
{
    public static class ResolverConfig
    {
        //public static void ConfigurateResolver(this IKernel kernel)
        //{
        //    kernel.Bind<IAccountService>().To<AccountService>();
        //    //kernel.Bind<IRepository>().To<FakeRepository>();
        //    kernel.Bind<IRepository>().To<AccountBinaryRepository>().WithConstructorArgument("test.bin");
        //    kernel.Bind<IAccountNumberCreateService>().To<AccountNumberCreator>().InSingletonScope();
        //    //kernel.Bind<IApplicationSettings>().To<ApplicationSettings>();
        //}

        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IAccountService>().To<AccountService>();
            kernel.Bind<IOwnerService>().To<OwnerService>();

            kernel.Bind<INumberGenerator<string>>().To<AccountNumberGenerator>().InSingletonScope();

            //kernel.Bind<IAccountRepository>().To<AccountFakeRepository>();
            //kernel.Bind<IOwnerRepository>().To<OwnerFakeRepository>();

            kernel.Bind<IAccountRepository>().To<AccountRepository>();
            kernel.Bind<IOwnerRepository>().To<OwnerRepository>();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();

            //for mvs in InRequestScope()
            kernel.Bind<DbContext>().To<AccountSystemEntities>().InSingletonScope();
            
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
