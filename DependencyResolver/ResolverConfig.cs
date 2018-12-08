using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
//using DAL.Fake;
using DAL.Interface.Interfaces;
using DAL.Fake.Repositories;
//using DAL.Repositories;
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

            kernel.Bind<INumberGenerator<string>>().To<AccountNumberGenerator>();

            kernel.Bind<IAccountRepository>().To<AccountRepository>();
            kernel.Bind<IOwnerRepository>().To<OwnerRepository>();


        }
    }
}
