﻿using DexCMS.Core.Contexts;
using DexCMS.Core.Globals;
using DexCMS.Core.Models;
using DexCMS.Core.Mvc.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;

namespace DexCMS.Core.Mvc.Startup
{
    public static class Authentication
    {
        public static void ConfigureAuth(IAppBuilder app, AuthenticationConfig config)
        {
            // Configure the db context, user manager and role manager to use a single instance per request
            app.CreatePerOwinContext(DexCMSContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            if (config.UseCookies)
            {
                app.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString(config.LoginUrl),
                    Provider = new CookieAuthenticationProvider
                    {
                        // Enables the application to validate the security stamp when the user logs in.
                        // This is a security feature which is used when you change a password or add an external login to your account.  
                        OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                            validateInterval: TimeSpan.FromMinutes(30),
                            regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                    }
                });
                app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            }

            if (config.UseTwoFactor)
            {
                // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
                app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

                // Enables the application to remember the second login verification factor such as phone or email.
                // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
                // This is similar to the RememberMe option when you log in.
                app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);
            }

            if (config.SigininOptionConfigs != null)
            {
                foreach (var signinConfig in config.SigininOptionConfigs)
                {
                    ProcessSiginOption(app, signinConfig);
                }
            }
        }

        private static void ProcessSiginOption(IAppBuilder app, SigininOptionConfig signinConfig)
        {
            switch (signinConfig.SigninOption)
            {
                case SigninOption.MicrosoftAccount:
                    app.UseMicrosoftAccountAuthentication(
                        clientId: signinConfig.IdOrKey,
                        clientSecret: signinConfig.Secret);
                    break;
                case SigninOption.Twitter:
                    app.UseTwitterAuthentication(
                       consumerKey: signinConfig.IdOrKey,
                       consumerSecret: signinConfig.Secret);
                    break;
                case SigninOption.Facebook:
                    app.UseFacebookAuthentication(
                       appId: signinConfig.IdOrKey,
                       appSecret: signinConfig.Secret);
                    break;
                case SigninOption.Google:
                    app.UseGoogleAuthentication(
                        clientId: signinConfig.IdOrKey,
                        clientSecret: signinConfig.Secret);
                    break;
                default:
                    break;
            }
        }
    }
}
