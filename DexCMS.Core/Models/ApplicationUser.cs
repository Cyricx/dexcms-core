using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DexCMS.Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        [Display(Name = "Legal First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Legal Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Preferred Name")]
        public string PreferredName { get; set; }
    }
}
