using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MvcPL.ViewModels
{
    public class AccountViewModel
    {
        [HiddenInput(DisplayValue =false)]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public int AccountTypeId { get; set; }

        public int OwnerId { get; set; }

        //[Required(ErrorMessage ="")]
        public string Number { get; set; }

        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }

        [Display(Name ="Bonus points")]
        public int BonusPoints { get; set; }

        [Display(Name ="Is oponed")]
        public bool IsOponed { get; set; }

        public string Type { get; set; }

    }
}