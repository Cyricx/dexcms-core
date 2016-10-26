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

        public async Task<IHttpActionResult> PutUser(string id, ApplicationUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            if (id != user.Id)
            {
                return BadRequest();
            }

            var result = await repository.UpdateAsync(user, user.Id);
            if (result.Succeeded)
            {
                var roleResult = await repository.UpdateRolesAsync(user.Id, user.Roles.Select(x => x.RoleId).ToArray());

                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return BadRequest();
            }
        }

        //[ResponseType(typeof(IdentityRole))]
        //public async Task<IHttpActionResult> PostRole(IdentityRole role)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var result = await roleRepository.AddAsync(role);
        //    if (result.Succeeded)
        //    {
        //        return CreatedAtRoute("DefaultApi", new { id = role.Id }, role);
        //    } else {
        //        return BadRequest(ModelState);
        //    }
        //}

        //[ResponseType(typeof(IdentityRole))]
        //public async Task<IHttpActionResult> DeleteRole(string id)
        //{
        //    IdentityRole role = await roleRepository.RetrieveAsync(id);
        //    if (role == null)
        //    {
        //        return NotFound();
        //    }

        //    var result = await roleRepository.DeleteAsync(role);

        //    if (result.Succeeded)
        //    {
        //        return Ok(role);
        //    }
        //    else
        //    {
        //        return BadRequest(ModelState);
        //    }
        //}
    }
}
