using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Core.WebApi.ApiModels
{
    public class RoleApiModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int? UserCount { get; set; }

    }
}
