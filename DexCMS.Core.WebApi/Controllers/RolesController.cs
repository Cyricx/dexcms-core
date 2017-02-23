using DexCMS.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity.EntityFramework;
using DexCMS.Core.WebApi.ApiModels;
using System.Web.Http.Description;
using System.Net;
using DexCMS.Core.Models;

namespace DexCMS.Core.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController: ApiController
    {
        private IApplicationRoleRepository repository;

        public RolesController(IApplicationRoleRepository repo)
        {
            repository = repo;
        }

        public List<ApplicationRoleApiModel> GetRoles()
        {
            return ApplicationRoleApiModel.MapForClient(repository.Items);
        }

        [ResponseType(typeof(ApplicationRoleApiModel))]
        public async Task<IHttpActionResult> GetRole(string id)
        {
            ApplicationRole role = await repository.RetrieveAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            return Ok(ApplicationRoleApiModel.MapForClient(role));
        }


        public async Task<IHttpActionResult> PutRole(string id, ApplicationRoleApiModel apiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != apiModel.Id)
            {
                return BadRequest();
            }

            ApplicationRole role = await repository.RetrieveAsync(id);
            ApplicationRoleApiModel.MapForServer(apiModel, role);

            var result = await repository.UpdateAsync(role, role.Id);
            if (result.Succeeded)
            {
                return StatusCode(HttpStatusCode.NoContent);
            } else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(IdentityRole))]
        public async Task<IHttpActionResult> PostRole(ApplicationRoleApiModel apiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ApplicationRole role = new ApplicationRole();
            ApplicationRoleApiModel.MapForServer(apiModel, role);

            var result = await repository.AddAsync(role);
            if (result.Succeeded)
            {
                return Ok(role);
            } else {
                return BadRequest(ModelState);
            }
        }

        [ResponseType(typeof(IdentityRole))]
        public async Task<IHttpActionResult> DeleteRole(string id)
        {
            ApplicationRole role = await repository.RetrieveAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            var result = await repository.DeleteAsync(role);

            if (result.Succeeded)
            {
                return Ok(role);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
