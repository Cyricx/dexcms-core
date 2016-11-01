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
    public class UsersController: ApiController
    {
        private IUserRepository repository;
        private IRoleRepository roleRepository;

        public UsersController(IUserRepository repo, IRoleRepository roleRepo)
        {
            repository = repo;
            roleRepository = roleRepo;
        }

        public List<UserApiModel> GetUsers()
        {
            var roles = roleRepository.Items.ToList();

            var items = repository.Items.Select(x => new UserApiModel
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                PreferredName = x.PreferredName,
                Email= x.Email,
                EmailConfirmed = x.EmailConfirmed,
                PhoneNumber = x.PhoneNumber,
                Id = x.Id,
                UserName = x.UserName,
                Roles = x.Roles.Select(y => new RoleApiModel
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

        [ResponseType(typeof(UserApiModel))]
        public async Task<IHttpActionResult> GetUser(string id)
        {
            ApplicationUser user = await repository.RetrieveAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var roles = roleRepository.Items.ToList();

            UserApiModel model = new UserApiModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                PreferredName = user.PreferredName,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                PhoneNumber = user.PhoneNumber,
                Id = user.Id,
                UserName = user.UserName,
                Roles = user.Roles.Select(x => new RoleApiModel
                {
                    Id = x.RoleId,
                    Name = roles.Where(y => y.Id == x.RoleId).Select(y => y.Name).SingleOrDefault()
                }).ToList()
            };

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutUser(string id, UserApiModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            if (id != user.Id)
            {
                return BadRequest();
            }

            //var userData = await repository.RetrieveAsync(user.Id);
            var userData = await repository.UserManager.FindByIdAsync(user.Id);

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

            //var result = await repository.UpdateAsync(userData, userData.Id);

            //if (result.Succeeded)
            //{
            //    //var roleResult = await repository.UpdateRolesAsync(userData.Id, user.Roles.Select(x => x.Id).ToArray());
            //    var roleResult = await repository.UpdateRolesAsync(userData, user.Roles.Select(x => x.Id).ToArray());
            //    if (roleResult.Succeeded)
            //    {
            //        return StatusCode(HttpStatusCode.NoContent);
            //    }
            //    else
            //    {
            //        return BadRequest();
            //    }
            //}
            //else
            //{
            //    return BadRequest();
            //}
            string[] selectedRoles = user.Roles.Select(x => x.Id).ToArray<string>();

            var userRoles = await repository.UserManager.GetRolesAsync(userData.Id);

            var result = await repository.UserManager.AddToRolesAsync(userData.Id, selectedRoles.Except(userRoles).ToArray<string>());

            if (!result.Succeeded)
            {

                return BadRequest();
            }
            result = await repository.UserManager.RemoveFromRolesAsync(user.Id, userRoles.Except(selectedRoles).ToArray<string>());

            if (!result.Succeeded)
            {
                return BadRequest();
            }

            return Ok();
        }

    }
}
