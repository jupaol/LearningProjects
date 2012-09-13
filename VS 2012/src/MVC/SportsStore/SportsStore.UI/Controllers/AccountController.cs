using SportsStore.Domain.Abstract;
using SportsStore.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.UI.Controllers
{
    public partial class AccountController : Controller
    {
        private IAccountRepository accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        [HttpGet]
        public virtual ActionResult Login(string ReturnUrl)
        {
            this.ViewData["ReturnUrl"] = ReturnUrl;

            return View();
        }

        [HttpPost]
        public virtual ActionResult Login(LoginModel loginModel, string ReturnUrl)
        {
            this.ViewData["ReturnUrl"] = ReturnUrl;

            if (!this.ModelState.IsValid)
            {
                loginModel.Password = string.Empty;
                return View(loginModel);
            }

            var authenticated = this.accountRepository.Authenticate(loginModel.Username, loginModel.Password);

            if (!authenticated)
            {
                loginModel.Password = string.Empty;
                this.ModelState.AddModelError("invalidUser", "The credentials provided are not valid");
                return View(loginModel);
            }

            if (!string.IsNullOrWhiteSpace(ReturnUrl))
            {
                return Redirect(ReturnUrl);
            }

            return RedirectToAction(MVC.Product.List());
        }

        public virtual ActionResult CurrentUser()
        {
            var currentUser = this.accountRepository.GetCurrentUser();

            return PartialView(new LoggedUserModel { Username = currentUser });
        }

        public virtual ActionResult Logout()
        {
            this.accountRepository.Logout();

            return RedirectToAction(MVC.Product.List());
        }
    }
}
