using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Owners
{
    public class Owner
    {
        //TODO add validation
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportNumber { get; set; }
        public string Email { get; set; }

        public Owner(string passportNumber, string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            PassportNumber = passportNumber;
            Email = email;
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
