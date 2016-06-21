using System.Collections.Generic;

namespace DexCMS.Core.Mvc.Models
{
    public class AuthenticationConfig
    {
        public string LoginUrl { get; set; }
        public List<SigininOptionConfig> SigininOptionConfigs { get; set; }
        public bool UseCookies { get; set; }
        public bool UseTwoFactor { get; set; }

        public AuthenticationConfig()
        {
            LoginUrl = "/Account/Login";
            UseCookies = true;
            UseTwoFactor = true;
        }
    }

    public enum SigninOption
    {
        MicrosoftAccount,
        Twitter,
        Facebook,
        Google
    }

    public class SigininOptionConfig
    {
        public SigninOption SigninOption { get; set; }
        public string IdOrKey { get; set; }
        public string Secret { get; set; }
    }
}
