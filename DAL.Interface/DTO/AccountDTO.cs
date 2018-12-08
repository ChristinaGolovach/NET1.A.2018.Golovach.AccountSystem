using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public int IdAccountType { get; set; }
        public string Number { get; set; }
        public decimal Balance { get; set; }
        public int BonusPoints { get; set; }
        public bool IsOponed { get; set; }
        public OwnerDTO Owner { get; set; }

    }
}
