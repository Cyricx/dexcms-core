using DexCMS.Core.Interfaces;
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
using DexCMS.Core.Models;

namespace DexCMS.Core.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController: ApiController
    {
        private IApplicationUserRepository repository;
        private IApplicationRoleRepository roleRepository;

        public UsersController(IApplicationUserRepository repo, IApplicationRoleRepository roleRepo)
        {
            repository = repo;
            roleRepository = roleRepo;
        }

        public List<ApplicationUserApiModel> GetUsers()
        {
            var roles = roleRepository.Items.ToList();

            var items = repository.Items.Select(x => new ApplicationUserApiModel
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                PreferredName = x.PreferredName,
                Email= x.Email,
                EmailConfirmed = x.EmailConfirmed,
                PhoneNumber = x.PhoneNumber,
                Id = x.Id,
                UserName = x.UserName,
                Roles = x.Roles.Select(y => new ApplicationRoleApiModel
                {
                    Id = y.RoleId
                }).ToList()
            }).ToList();

            foreach (var item in items)
            {
                foreach (var userRole in item.Roles)
                {
                    var role = roles.Where(x => x.Id == userRole.Id).SingleOrDefault();
                    if (role != null)
                    {
                        userRole.Name = role.Name;
                    }
                }
            }

            return items;
        }

        [ResponseType(typeof(ApplicationUserApiModel))]
        public async Task<IHttpActionResult> GetUser(string id)
        {
            ApplicationUser user = await repository.RetrieveAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var roles = roleRepository.Items.ToList();

            ApplicationUserApiModel model = new ApplicationUserApiModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                PreferredName = user.PreferredName,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                PhoneNumber = user.PhoneNumber,
                Id = user.Id,
                UserName = user.UserName,
                Roles = user.Roles.Select(x => new ApplicationRoleApiModel
                {
                    Id = x.RoleId,
                    Name = roles.Where(y => y.Id == x.RoleId).Select(y => y.Name).SingleOrDefault()
                }).ToList()
            };

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutUser(string id, ApplicationUserApiModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            if (id != user.Id)
            {
                return BadRequest();
            }

            var userData = await repository.RetrieveAsync(user.Id);

            if (userData == null)
            {
                return BadRequest();
            }

            userData.FirstName = user.FirstName;
            userData.LastName = user.LastName;
            userData.PreferredName = user.PreferredName;
            userData.Email = user.Email;
            userData.EmailConfirmed = user.EmailConfirmed;
            userData.PhoneNumber = user.PhoneNumber;

            var result = await repository.UpdateAsync(userData, userData.Id);

            if (result.Succeeded)
            {
                var roleResult = await repository.UpdateRolesAsync(userData, user.Roles.Select(x => x.Name).ToArray());
                if (roleResult.Succeeded)
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
