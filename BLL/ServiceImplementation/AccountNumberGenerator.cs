using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    //TODO move in another project
    public class AccountNumberGenerator : INumberGenerator<string>
    {
        private const string SYMBOLS = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public string GenerateNumber(int numberLength = 10)
        {
            Random random = new Random();
            StringBuilder number = new StringBuilder(numberLength);

            for (int i = 0; i < numberLength; i++)
            {
                int index = random.Next(0, SYMBOLS.Length - 1);
                number.Append(SYMBOLS[index]);
            }

            return number.ToString();
        }
    }
}
