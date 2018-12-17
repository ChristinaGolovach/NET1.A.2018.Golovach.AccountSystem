using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Interfaces;

namespace MvcPL.Controllers
{
    public class AccountController : Controller
    {
        IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        // GET: Account
        public ActionResult Index()
        {
            var accounts = accountService.GetAllAccounts();

            //for chek only
            foreach(var account in accounts)
            {

            }
            return View();
        }

    }
}