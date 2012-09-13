using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore.UI.Controllers;
using System.Linq;
using FluentAssertions;
using Moq;
using SportsStore.Domain.Abstract;
using System.Web.Mvc;
using SportsStore.UI.Models;

namespace SportsStore.UnitTests.MVC.Controllers
{
    [TestClass]
    public class AccountControllerTests
    {
        private static Mock<IAccountRepository> accountRepository;
        public static AccountController GetAccountController()
        {
            var accountRepo = new Mock<IAccountRepository>();
            var sut = new AccountController(accountRepo.Object);

            accountRepo.Setup(x => x.Authenticate("admin", "secret")).Returns(() => true).Verifiable();
            accountRepo.Setup(x => x.GetCurrentUser()).Returns(() => "admin").Verifiable();

            accountRepository = accountRepo;
            return sut;
        }

        [TestClass]
        public class TheLoginGetAction
        {
            [TestMethod]
            public void it_should_render_the_default_view()
            {
                var sut = AccountControllerTests.GetAccountController();

                var res = sut.Login("de") as ViewResult;
                var model = res.Model as LoginModel;

                res.ViewName.Should().BeEmpty();
                res.ViewData["ReturnUrl"].ToString().Should().Be("de");
            }
        }

        [TestClass]
        public class TheLoginPostAction
        {
            [TestMethod]
            public void when_the_model_contains_validation_errors_it_should_render_the_default_view_and_pass_the_current_model_back_to_the_view()
            {
                var sut = AccountControllerTests.GetAccountController();
                var loginModel = new LoginModel();

                sut.ModelState.AddModelError("error", "error");

                var res = sut.Login(loginModel, "return") as ViewResult;
                var model = res.Model as LoginModel;

                model.Should().Be(loginModel);
                res.ViewName.Should().BeEmpty();
                res.ViewData["ReturnUrl"].ToString().Should().Be("return");
            }

            [TestMethod]
            public void when_the_user_enters_invalid_credentials_it_should_render_the_default_view_adding_an_error_message_to_the_view()
            {
                var sut = AccountControllerTests.GetAccountController();
                var loginModel = new LoginModel { Password = "invalid", Username = "invalid" };

                var res = sut.Login(loginModel, "de") as ViewResult;
                var model = res.Model as LoginModel;

                model.Should().Be(loginModel);
                sut.ModelState["invalidUser"].Should().NotBeNull();
                sut.ModelState["invalidUser"].Errors.Count.Should().Be(1);
                sut.ModelState["invalidUser"].Errors[0].ErrorMessage.Should().Be("The credentials provided are not valid");
                res.ViewData["ReturnUrl"].ToString().Should().Be("de");
            }

            [TestMethod]
            public void when_the_user_enters_valid_credentials_and_the_returnUrl_parameter_is_not_empty_it_should_redirect_to_that_url()
            {
                var sut = AccountControllerTests.GetAccountController();
                var loginModel = new LoginModel { Username = "admin", Password = "secret" };

                var res = sut.Login(loginModel, "de") as RedirectResult;

                res.Url.Should().Be("de");
            }

            [TestMethod]
            public void when_the_user_enters_valid_credentials_and_the_returnUrl_parameter_is_empty_it_should_redirect_to_the_default_store_url()
            {
                var sut = AccountControllerTests.GetAccountController();
                var loginModel = new LoginModel { Username = "admin", Password = "secret" };

                var res = sut.Login(loginModel, "") as RedirectToRouteResult;

                res.RouteValues["controller"].ToString().Should().Be("Product");
                res.RouteValues["action"].ToString().Should().Be("List");
                res.RouteValues["area"].ToString().Should().Be("");
                res.RouteValues["page"].ToString().Should().Be("1");
            }
        }

        [TestClass]
        public class TheCurrentUserGetAction
        {
            [TestMethod]
            public void it_should_render_the_default_partial_view()
            {
                var sut = AccountControllerTests.GetAccountController();

                var res = sut.CurrentUser() as PartialViewResult;

                res.ViewName.Should().BeEmpty();
            }

            [TestMethod]
            public void it_should_pass_the_current_logged_user_to_the_view()
            {
                var sut = AccountControllerTests.GetAccountController();

                var res = sut.CurrentUser() as PartialViewResult;
                var model = res.Model as LoggedUserModel;

                model.Username.Should().Be("admin");
            }
        }

        [TestClass]
        public class TheLogoutPostAction
        {
            [TestMethod]
            public void it_should_redirect_to_the_default_store_url()
            {
                var sut = AccountControllerTests.GetAccountController();

                var res = sut.Logout() as RedirectToRouteResult;

                res.RouteValues["controller"].ToString().Should().Be("Product");
                res.RouteValues["action"].ToString().Should().Be("List");
                res.RouteValues["area"].ToString().Should().Be(string.Empty);
            }

            [TestMethod]
            public void it_should_logout_the_current_user()
            {
                var sut = AccountControllerTests.GetAccountController();

                sut.Logout();

                accountRepository.Verify(x => x.Logout(), Times.Once());
            }
        }
    }
}
