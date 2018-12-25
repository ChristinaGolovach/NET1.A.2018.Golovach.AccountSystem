 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Interfaces;
using MvcPL.Infrastructure.Mappers;

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
            var accounts = accountService.GetAllAccounts().Select(accountEntity => accountEntity.ToAccountVM());

            return View(accounts);
        }

        [ActionName("Details")]
        public ActionResult ShowDetails(int? id)
        {
            ViewBag.Id = id;
            return View();
        }

    }
}