using System;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DependencyResolver;
using Ninject;
using BLL.Interface.Entities.Accounts;
using BLL.Interface.Entities.Owners;
using System.Collections.Generic;

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
            
            //only for test 
            IOwnerService ownerService = resolver.Get<IOwnerService>();

            #region Owner1 with fake repository
            //string accontNumber = accountService.OpenAccount(AccountType.BASE, "KB150150150", "Owner1", "Owner1", "email", 15);

            //accountService.Deposit(accontNumber, 17); // accontNumber - Balance - 32

            //Owner owner =  accountService.GetOwner("KB150150150");

            //IEnumerable<Account> accounts = accountService.GetAllAccountsByOwnerPassport("KB150150150"); 

            //foreach (var account in accounts)
            //{
            //    Console.WriteLine($"{owner.FirstName} - {account.Number} , Type - {account.AccountType} - Balance - {account.Balance}");
            //}

            //Console.WriteLine(Environment.NewLine);

            //string accontNumber2 = accountService.OpenAccount(AccountType.GOLDEN, "KB150150150", 11);

            //foreach (var account in accountService.GetAllAccountsByOwnerPassport("KB150150150"))
            //{
            //    Console.WriteLine($"{owner.FirstName} - {account.Number} , Type - {account.AccountType} - Balance - {account.Balance}");
            //}

            //accountService.Transfer(accontNumber, accontNumber2, 32);
            //Account account1 = accountService.GetAccount(accontNumber);
            //Account account2 = accountService.GetAccount(accontNumber2);

            //Console.WriteLine($"{accontNumber} - Balance {account1.Balance}"); // 0
            //Console.WriteLine($"{accontNumber2} - Balance {account2.Balance}"); // 43
            #endregion Owner1


            #region Owner2 with fake repository

            //string accontNumber3 = accountService.OpenAccount(AccountType.BASE, "KB111111111", "Owner2", "Owner2", "email", 10000);

            //Console.WriteLine(Environment.NewLine);

            //foreach (var account in accountService.GetAllAccountsByOwnerPassport("KB111111111"))
            //{
            //    Console.WriteLine($"{account.Owner.FirstName} - {account.Number} , Type - {account.AccountType} - Balance - {account.Balance}");
            //}
            #endregion Owner2

            #region Real DAL
            //var accounts = accountService.GetAllAccounts();
            //foreach (var account in accounts)
            //{
            //    Console.WriteLine($"{account.Owner.FirstName} - {account.Number} , Type - {account.AccountType} - Balance - {account.Balance}");
            //}

            //var owners = ownerService.GetAllOwners();
            //foreach (var owner in owners)
            //{
            //    Console.WriteLine($"{owner.FirstName} - {owner.LastName} - {owner.PassportNumber}");
            //}

            ////Number 1TKAH2
            //var accountByNumber = accountService.GetAccount("1TKAH2");
            //var acountOwner = accountByNumber.Owner;

            ////accountService.Deposit("TO4ETB55AA", 2);
            accountService.Transfer("1TKAH2", "TO4ETB55AA", 190);
            
             var depositedAccount = accountService.GetAccount("TO4ETB55AA");

            Console.WriteLine($"{depositedAccount.Number} - balance - {depositedAccount.Balance}");

            //accountService.OpenAccount(AccountType.PLATINUM, "KB1111111", 14);

            // accountService.OpenAccount(AccountType.SILVER, "KB1111111", "User1", "User1", "email@test", 1111);

            #endregion Real Dal

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
