using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcPL.ViewModels
{
    public class AccountViewModel
    {
        public int Id { get; set; }

        public int AccountTypeId { get; set; }

        public int OwnerId { get; set; }

        public string Number { get; set; }

        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }

        public int BonusPoints { get; set; }

        public bool IsOponed { get; set; }

        public string Type { get; set; }

    }
}