using DexCMS.Core.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity.EntityFramework;
using DexCMS.Core.WebApi.ApiModels;
using System.Web.Http.Description;
using System.Net;
using DexCMS.Core.Infrastructure.Models;

namespace DexCMS.Core.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController: ApiController
    {
        private IRoleRepository repository;

        public RolesController(IRoleRepository repo)
        {
            repository = repo;
        }

        public List<RoleApiModel> GetRoles()
        {
            var items = repository.Items.Select(x => new RoleApiModel
            {
                Id = x.Id,
                Name = x.Name,
                UserCount = x.Users.Count
            }).ToList();
            return items;
        }

        [ResponseType(typeof(RoleApiModel))]
        public async Task<IHttpActionResult> GetRole(string id)
        {
            IdentityRole role = await repository.RetrieveAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            RoleApiModel model = new RoleApiModel()
            {
                Id = role.Id,
                Name = role.Name,
                UserCount = role.Users.Count
            };

            return Ok(model);
        }


        public async Task<IHttpActionResult> PutRole(string id, ApplicationRole role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != role.Id)
            {
                return BadRequest();
            }

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
        public async Task<IHttpActionResult> PostRole(ApplicationRole role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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
