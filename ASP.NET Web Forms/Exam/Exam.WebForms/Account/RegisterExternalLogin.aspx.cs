﻿namespace Exam.WebForms.Account
{
    using System;
    using System.Web;
    using System.Web.UI;

    using Exam.WebForms.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security;

    public partial class RegisterExternalLogin : Page
    {
        protected string ProviderName
        {
            get
            {
                return (string)this.ViewState["ProviderName"] ?? string.Empty;
            }

            private set
            {
                this.ViewState["ProviderName"] = value;
            }
        }

        protected string ProviderAccountKey
        {
            get
            {
                return (string)this.ViewState["ProviderAccountKey"] ?? string.Empty;
            }

            private set
            {
                this.ViewState["ProviderAccountKey"] = value;
            }
        }

        private void RedirectOnFail()
        {
            this.Response.Redirect(this.User.Identity.IsAuthenticated ? "~/Account/Manage" : "~/Account/Login");
        }

        protected void Page_Load()
        {
            // Process the result from an auth provider in the request
            this.ProviderName = IdentityHelper.GetProviderNameFromRequest(this.Request);
            if (string.IsNullOrEmpty(this.ProviderName))
            {
                this.RedirectOnFail();
                return;
            }

            if (!this.IsPostBack)
            {
                var manager = this.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var loginInfo = this.Context.GetOwinContext().Authentication.GetExternalLoginInfo();
                if (loginInfo == null)
                {
                    this.RedirectOnFail();
                    return;
                }

                var user = manager.Find(loginInfo.Login);
                if (user != null)
                {
                    IdentityHelper.SignIn(manager, user, false);
                    IdentityHelper.RedirectToReturnUrl(this.Request.QueryString["ReturnUrl"], this.Response);
                }
                else if (this.User.Identity.IsAuthenticated)
                {
                    // Apply Xsrf check when linking
                    var verifiedloginInfo =
                        this.Context.GetOwinContext()
                            .Authentication.GetExternalLoginInfo(IdentityHelper.XsrfKey, this.User.Identity.GetUserId());
                    if (verifiedloginInfo == null)
                    {
                        this.RedirectOnFail();
                        return;
                    }

                    var result = manager.AddLogin(this.User.Identity.GetUserId(), verifiedloginInfo.Login);
                    if (result.Succeeded)
                    {
                        IdentityHelper.RedirectToReturnUrl(this.Request.QueryString["ReturnUrl"], this.Response);
                    }
                    else
                    {
                        this.AddErrors(result);
                    }
                }
                else
                {
                    this.email.Text = loginInfo.Email;
                }
            }
        }

        protected void LogIn_Click(object sender, EventArgs e)
        {
            this.CreateAndLoginUser();
        }

        private void CreateAndLoginUser()
        {
            if (!this.IsValid)
            {
                return;
            }

            var manager = this.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = new ApplicationUser { UserName = this.email.Text, Email = this.email.Text };
            var result = manager.Create(user);
            if (result.Succeeded)
            {
                var loginInfo = this.Context.GetOwinContext().Authentication.GetExternalLoginInfo();
                if (loginInfo == null)
                {
                    this.RedirectOnFail();
                    return;
                }

                result = manager.AddLogin(user.Id, loginInfo.Login);
                if (result.Succeeded)
                {
                    IdentityHelper.SignIn(manager, user, false);

                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // var code = manager.GenerateEmailConfirmationToken(user.Id);
                    // Send this link via email: IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id)
                    IdentityHelper.RedirectToReturnUrl(this.Request.QueryString["ReturnUrl"], this.Response);
                    return;
                }
            }

            this.AddErrors(result);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                this.ModelState.AddModelError(string.Empty, error);
            }
        }
    }
}