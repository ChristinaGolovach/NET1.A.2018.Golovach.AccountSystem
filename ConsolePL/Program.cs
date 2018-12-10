using System;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DependencyResolver;
using Ninject;
using BLL.Interface.Entities.Accounts;
using BLL.Interface.Entities.Owners;

namespace ConsolePL
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel resolver = new StandardKernel();
            resolver.ConfigurateResolver();

            INumberGenerator<string> numberGenerator = resolver.Get<INumberGenerator<string>>();

             IAccountService accountService = resolver.Get<IAccountService>();

            string accontNumber = accountService.OpenAccount(AccountType.BASE, "KB150150150", "Owner1", "Owner1", "email", 15);

            accountService.Deposit(accontNumber, 17);
            Owner owner =  accountService.GetOwner("KB150150150");

            decimal currentBalance =  owner.Accounts.FirstOrDefault(a => a.Number == accontNumber).Balance; // 32
            Console.WriteLine(currentBalance);

            Console.ReadKey();
            
        }
        //private static readonly IKernel resolver;

        //static Program()
        //{
        //    resolver = new StandardKernel();
        //    resolver.ConfigurateResolver();
        //}

        //static void Main(string[] args)
        //{
        //    IAccountService service = resolver.Get<IAccountService>();
        //    IAccountNumberCreateService creator = resolver.Get<IAccountNumberCreateService>();

        //    service.OpenAccount("Account owner 1", AccountType.Base, creator);
        //    service.OpenAccount("Account owner 2", AccountType.Base, creator);
        //    service.OpenAccount("Account owner 3", AccountType.Silver, creator);
        //    service.OpenAccount("Account owner 4", AccountType.Base, creator);

        //    var creditNumbers = service.GetAllAccounts().Select(acc => acc.AccountNumber).ToArray();

        //    foreach (var t in creditNumbers)
        //    {
        //        service.DepositAccount(t, 100);
        //    }

        //    foreach (var item in service.GetAllAccounts())
        //    {
        //        Console.WriteLine(item);
        //    }

        //    foreach (var t in creditNumbers)
        //    {
        //        service.WithdrawAccount(t, 10);
        //    }

        //    foreach (var item in service.GetAllAccounts())
        //    {
        //        Console.WriteLine(item);
        //    }
        //}
    }
}
