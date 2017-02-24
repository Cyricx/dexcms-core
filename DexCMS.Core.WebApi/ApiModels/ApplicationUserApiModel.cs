using DexCMS.Core.Attributes;
using System.Collections.Generic;

namespace DexCMS.Core.WebApi.ApiModels
{
    public class ApplicationUserApiModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PreferredName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public string Id { get; set; }
        public string UserName { get; set; }

        public List<ApplicationRoleApiModel> Roles { get; set; }
    }
}
