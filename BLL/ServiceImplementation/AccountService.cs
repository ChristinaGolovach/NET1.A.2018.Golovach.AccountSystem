using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.Mappers;
using BLL.Models.Accounts;
using BLL.Models.Owners;
using BLL.Models.Factories;
using DAL.Interface.Interfaces;


namespace BLL.ServiceImplementation
{
    //TODO validation, TRY - CATCH, Logger, move INumberGenerator from ctor

    public class AccountService : IAccountService
    {
        private IOwnerService ownerService;
        private INumberGenerator<string> numberGenerator;
        private IAccountRepository accountRepository;
        private IUnitOfWork unitOfWork;

        public AccountService(IAccountRepository accountRepository, IOwnerService ownerService, IUnitOfWork unitOfWork, INumberGenerator<string> numberGenerator)
        {
            this.accountRepository = accountRepository;
            this.ownerService = ownerService;
            this.numberGenerator = numberGenerator;
            this.unitOfWork = unitOfWork;
        }
        
        public IEnumerable<AccountEntity> GetAllAccounts()
        {
            return accountRepository.GetAll().Select(dto => dto.ToAccountEntity());
        }

        public IEnumerable<AccountEntity> GetAllAccountsByOwnerPassport(string passportNumber)
        {
            //TODO I'm not implement expression visitor - will fall with real dal
            var accounts = accountRepository.GetByPredicate(a => a.Owner.PassportNumber == passportNumber);
            return accounts.Select(dto => dto.ToAccountEntity());
        }

        public AccountEntity GetAccount(string accountNumber)
        {
            return accountRepository.GetByNumber(accountNumber).ToAccountEntity();
        }

        public IEnumerable<OwnerEntity> GetAllOwners()
        {
            return ownerService.GetAllOwners();
        }
        
        public OwnerEntity GetOwner(string passportNumber)
        {
            return ownerService.FindByPassport(passportNumber);
        }

        public string OpenAccount(int idAccountType, string passportNumber, decimal initialBalance = 0)
        {
            OwnerEntity ownerEntity = ownerService.FindByPassport(passportNumber);

            AccountFactory accountCreator = FactoryCollection.Factories.FirstOrDefault(f => (int)f.AccountType == idAccountType);

            return CreateAccount(accountCreator, ownerEntity.ToOwner(), initialBalance);
        }

        public string OpenAccount(int idAccountType, string passportNumber, string firstName, string lastName, string email, decimal initialBalance = 0M)
        {
            OwnerEntity ownerEntity = ownerService.CreateOwner(passportNumber, firstName, lastName, email);

            AccountFactory accountCreator = FactoryCollection.Factories.FirstOrDefault(f => (int)f.AccountType == idAccountType);

            return CreateAccount(accountCreator, ownerEntity.ToOwner(), initialBalance);
        }

        public void CloseAccount(string accountNumber)
        {
            Account account = accountRepository.GetByNumber(accountNumber)?.ToAccount();

            account = account ?? throw new ArgumentException($"Account with number {accountNumber} does not exist.");

            account.CloseAccount();

            accountRepository.Update(account.ToAccountDTO());

            unitOfWork.Commit();
        }

        public void Deposit(string accountNumber, decimal amount)
        {
            Account account = DepositCore(accountNumber, amount);

            SaveChangesAfterOperation(account);
        }

        public void Withdraw(string accountNumber, decimal amount)
        {
            Account account =  WithdrawCore(accountNumber, amount);

            SaveChangesAfterOperation(account);
        }

        public void Transfer(string fromAccountNumber, string toAccountNumber, decimal amount)
        {
            Account accountFrom = WithdrawCore(fromAccountNumber, amount);
            Account accountTo = DepositCore(toAccountNumber, amount);

            accountRepository.Update(accountFrom.ToAccountDTO());
            accountRepository.Update(accountTo.ToAccountDTO());

            unitOfWork.Commit();
        }

        private Account WithdrawCore(string accountNumber, decimal amount)
        {
            Account account = GetAccountForOperation(accountNumber);

            ExecuteAccountOperation(amount, account.Withdraw);

            return account;
        }

        private Account DepositCore(string accountNumber, decimal amount)
        {
            Account account = GetAccountForOperation(accountNumber);

            ExecuteAccountOperation(amount, account.Deposit);

            return account;
        }

        private void ExecuteAccountOperation(decimal amount, Action<decimal> operation)
        {
            operation(amount);
    
            //accountRepository.Update(account.ToAccauntDTO());

            //unitOfWork.Commit();
        }

        private void SaveChangesAfterOperation(Account account)
        {
            accountRepository.Update(account.ToAccountDTO());

            unitOfWork.Commit();
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

            account.Operation += LogOperation;

            return account.Number;
        }

        private Account CreateAccountCore(AccountFactory accountCreator, Owner owner, decimal initialBalance)
        {
            string accountNumber = ReciveAccountNumber();

            Account account = accountCreator.CreateAccount(accountNumber, owner, initialBalance);          
            
            accountRepository.Add(account.ToAccountDTO());

            unitOfWork.Commit();

            return account;
        }

        //TODO
        private void LogOperation(object sender, AccauntEventArgs e)
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
