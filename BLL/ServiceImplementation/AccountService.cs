using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities.Accounts;
using BLL.Interface.Interfaces;
using BLL.Interface.Entities.Owners;
using BLL.Factories;
using BLL.Mappers;
using DAL.Interface.Interfaces;


namespace BLL.ServiceImplementation
{
    public class AccountService : IAccountService
    {
        private IOwnerService ownerService;
        private INumberGenerator<string> numberGenerator;
        private IAccountRepository accountRepository;
        private IUnitOfWork unitOfWork;

        //TODO вынести INumberGenerator із конструктора 
        public AccountService(IAccountRepository accountRepository, IOwnerService ownerService, IUnitOfWork unitOfWork, INumberGenerator<string> numberGenerator)
        {
            this.accountRepository = accountRepository;
            this.ownerService = ownerService;
            this.numberGenerator = numberGenerator;
            this.unitOfWork = unitOfWork;
        }

        //TODO Ask? но тогда на уровне представления мы можем напрямую дtргать методы Account. Они ведь паблик.
        public IEnumerable<Account> GetAllAccounts()
        {
            return accountRepository.GetAll().Select(dto => dto.ToAccount());
        }

        public IEnumerable<Account> GetAllAccountsByOwnerPassport(string passportNumber)
        {
            var accounts = accountRepository.GetByPredicate(a => a.Owner.PassportNumber == passportNumber);
            return accounts.Select(dto => dto.ToAccount());
        }

        public Account GetAccount(string accountNumber)
        {
            return accountRepository.GetByNumber(accountNumber).ToAccount();
        }

        public IEnumerable<Owner> GetAllOwners()
        {
            return ownerService.GetAllOwners();
        }
        
        public Owner GetOwner(string passportNumber)
        {
            return ownerService.FindByPassport(passportNumber);
        }

        public string OpenAccount(AccountType accountType, string passportNumber, decimal initialBalance = 0)
        {
            // CheckInputData(accountCreator, passportNumber, initialBalance);

            //TODO Если такого пользователя не существует
            Owner owner = ownerService.FindByPassport(passportNumber);
            //TODO если такой фабрики нет
            AccountFactory accountCreator = FactoryCollection.Factories.FirstOrDefault(f => f.AccountType == accountType);

            return CreateAccount(accountCreator, owner, initialBalance);
        }

        public string OpenAccount(AccountType accountType, string passportNumber, string firstName, string lastName, string email, decimal initialBalance = 0M)
        {
            //TODO
            //CheckInputData()

            Owner owner = ownerService.CreateOwner(passportNumber, firstName, lastName, email);

            AccountFactory accountCreator = FactoryCollection.Factories.FirstOrDefault(f => f.AccountType == accountType);

            return CreateAccount(accountCreator, owner, initialBalance);
        }

        public void CloseAccount(string accountNumber)
        {
            //CheckInputData(numberAccount); 

            Account account = accountRepository.GetByNumber(accountNumber)?.ToAccount();

            account = account ?? throw new ArgumentException($"Account with number {accountNumber} does not exist.");

            //TODO TRY - CATCH
            account.CloseAccount();
        }

        public void Deposit(string accountNumber, decimal amount)
        {
            Account account = GetAccountForOperation(accountNumber);

            ExecuteAccountOperation(amount, account.Deposit);

            accountRepository.Update(account.ToAccauntDTO());
        }

        public void Withdraw(string accountNumber, decimal amount)
        {
            Account account = GetAccountForOperation(accountNumber);

            ExecuteAccountOperation(amount, account.Withdraw);

            accountRepository.Update(account.ToAccauntDTO());
        }

        public void Transfer(string fromAccountNumber, string toAccountNumber, decimal amount)
        {
            //Две операции нераздельно нужно выполнить
            Withdraw(fromAccountNumber, amount);

            Deposit(toAccountNumber, amount);
        }

        private void ExecuteAccountOperation(decimal amount, Action<decimal> operation)
        {
            operation(amount);
        }

        private Account GetAccountForOperation(string accountNumber)
        {
            Account account = accountRepository.GetByNumber(accountNumber)?.ToAccount();

            if (!account.IsOponed)
            {
                throw new InvalidOperationException();
            }

            return account;
        }

        private string CreateAccount(AccountFactory accountCreator, Owner owner, decimal initialBalance)
        {
            Account account = CreateAccountCore(accountCreator, owner, initialBalance);

            account.Operation += CommitOperation;

            return account.Number;
        }

        private Account CreateAccountCore(AccountFactory accountCreator, Owner owner, decimal initialBalance)
        {
            string accountNumber = ReciveAccountNumber();

            Account account = accountCreator.CreateAccount(accountNumber, owner, initialBalance);            

           // ownerService.OpenNewAccount(owner, account);

            accountRepository.Add(account.ToAccauntDTO());

            unitOfWork.Commit();

            return account;
        }

        //TODO
        private void CommitOperation(object sender, AccauntEventArgs e)
        {
            //Logger
        }

        private string ReciveAccountNumber()
        {
            string accountNumber = numberGenerator.GenerateNumber();

            while (!IsExistsAccountNumber(accountNumber))
            {
                accountNumber = numberGenerator.GenerateNumber();
            }

            return accountNumber;
        }

        private bool IsExistsAccountNumber(string accountNumber)
        {
            Account account = accountRepository.GetByNumber(accountNumber)?.ToAccount();

            return ReferenceEquals(account, null);
        }

        private void CheckInputData(AccountFactory creator, string passportNumber, decimal initialBalance)
        {
            CheckPassportNumber(passportNumber);

            if (ReferenceEquals(creator, null))
            {
                throw new ArgumentNullException($"The {nameof(creator)} can not be null.");
            }

            if (initialBalance < 0)
            {
                throw new ArithmeticException($"The {nameof(initialBalance)} can not be less zero.");
            }
        }

        private void CheckInputData(int numberAccount, string passportNumber)
        {
            if (numberAccount <= 0)
            {
                throw new ArgumentException($"The {nameof(numberAccount)} can not be less zero.");
            }

            CheckPassportNumber(passportNumber);
        }

        private void CheckPassportNumber(string passportNumber)
        {
            if (ReferenceEquals(passportNumber, null))
            {
                throw new ArgumentNullException($"The {nameof(passportNumber)} can not be null.");
            }

            if (passportNumber.Length == 0)
            {
                throw new ArithmeticException($"The {nameof(passportNumber)} can not be empty.");
            }
        }
    }
}
