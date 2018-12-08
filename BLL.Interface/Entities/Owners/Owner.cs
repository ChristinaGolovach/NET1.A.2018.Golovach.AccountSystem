using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities.Accounts;

namespace BLL.Interface.Entities.Owners
{
    public class Owner
    {
        //TODO добавить валидацию
        private List<Account> accounts;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportNumber { get; set; }
        public string Email { get; set; }

        public IEnumerable<Account> Accounts { get => accounts; }

        public Owner(string passportNumber, string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            PassportNumber = passportNumber;
            Email = email;
            accounts = new List<Account>();
        }

        public void OpenAccount(Account account)
        {
            accounts.Add(account);
        }

        public void AttachAccounts(IEnumerable<Account> accounts)
        {
            foreach(var account in accounts)
            {
                OpenAccount(account);
            }
        }

        public bool Equals(Owner otherOwner)
        {
            if (ReferenceEquals(otherOwner, null))
            {
                throw new ArgumentNullException($"The {nameof(otherOwner)} can not be null.");
            }

            return string.Equals(PassportNumber, otherOwner.PassportNumber, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object otherOwner)
        {
            if (ReferenceEquals(otherOwner, null))
            {
                throw new ArgumentNullException($"The {nameof(otherOwner)} can not be null.");
            }

            if (otherOwner.GetType() != this.GetType())
            {
                return false;
            }

            return Equals(otherOwner as Owner);
        }

        public override int GetHashCode()
        {
            int hash = 19;

            for (int i = 1; i < PassportNumber.Length; i++)
            {
                hash = hash << 1 + PassportNumber[i].GetHashCode();
            }

            return hash;
        }
    }
}

