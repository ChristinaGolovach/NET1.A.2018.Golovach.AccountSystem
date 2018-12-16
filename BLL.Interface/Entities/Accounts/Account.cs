using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities.Owners;

namespace BLL.Interface.Entities.Accounts
{
    //TODO make internal (friendly assembly)
    public abstract class Account
    {
        private int id;
        private string number;
        private decimal balance;
        private int bonusPoints;
        private bool isOpened;
        private Owner owner;

        public event EventHandler<AccauntEventArgs> Operation = delegate { };

        #region property
        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Number
        {
            get => number;
            private set => number = value ?? throw new ArgumentNullException($"The {nameof(number)} can not be null.");
        }

        public decimal Balance
        {
            get => balance;
            private set => balance = value;
        }

        public int BonusPoints
        {
            get => bonusPoints;
            set => bonusPoints = value;
        }

        public bool IsOponed
        {
            get => isOpened;
            //TODO  ask was private set => isOpened = value; but not allowed for mapper
            set => isOpened = value;
        }

        public Owner Owner
        {
            get => owner;

            private set => owner = value ?? throw new ArgumentNullException($"The {nameof(owner)} can not be null.");
        }

        public abstract AccountType AccountType { get; }

        #endregion property

        #region ctor

        public Account(string accountNumber, Owner owner, decimal initialBalance = 0M)
        {
            IsOponed = true;
            Number = accountNumber;
            Owner = owner;
            Balance = initialBalance;
        }

        #endregion

        #region public methods

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                GenerateEventInfo(nameof(Deposit), "Error.");

                throw new ArgumentException($"The count of {nameof(amount)} must be more than zero for this operation.");
            }

            Balance += amount;
            BonusPoints += CalculateBonusPoints(amount);
            GenerateEventInfo(nameof(Deposit), "Done");
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                GenerateEventInfo(nameof(Withdraw), "Error.");

                throw new ArgumentException($"The count of {nameof(amount)} must be more than zero for this operation.");
            }

            if (!IsAllowedToWithdraw(amount))
            {
                // верное ли исключение??
                GenerateEventInfo(nameof(Withdraw), "Not allowed.");
                throw new InvalidOperationException();
            }

            Balance -= amount;
            BonusPoints -= CalculateBonusPoints(amount);
            GenerateEventInfo(nameof(Withdraw), "Done.");
        }

        public void CloseAccount()
        {
            if (Balance < 0)
            {
                throw new InvalidOperationException($"The current balance is {Balance}. You can not close account with negative balance.");
            }

            IsOponed = false;
        }

        #endregion public methods

        #region protected methods

        protected abstract int CalculateBonusPoints(decimal amount);

        protected abstract bool IsAllowedToWithdraw(decimal amount);

        protected void OnOperation(AccauntEventArgs accauntEventArgs)
        {
            if (ReferenceEquals(accauntEventArgs, null))
            {
                throw new ArgumentNullException($"The {nameof(accauntEventArgs)} can not be null.");
            }

            Operation?.Invoke(this, accauntEventArgs);
        }
        #endregion protected methods

        private void GenerateEventInfo(string nameOperation, string status)
        {
            //TODO make enum for operation status
            string message = $"The operation {nameOperation} has done with status {status}.";
            AccauntEventArgs accauntEventArgs = new AccauntEventArgs(number, balance, owner.PassportNumber, message);
            OnOperation(accauntEventArgs);
        }
    }

    public class AccauntEventArgs : EventArgs
    {
        private string accountNumber;
        private decimal balance;
        private string message;
        private string passportNumber;

        public string AccountNumber { get => accountNumber; }
        public decimal Balance { get => balance; }
        public string Message { get => message; }
        public string PassportNumber { get => passportNumber; }

        public AccauntEventArgs(string accountNumber, decimal balance, string passportNumber, string message)
        {
            this.accountNumber = accountNumber;
            this.balance = balance;
            this.message = message;
            this.passportNumber = passportNumber;
        }
    }
}
