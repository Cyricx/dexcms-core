using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DexCMS.Core.Infrastructure.Models;
using DexCMS.Core.Infrastructure.Interfaces;
using DexCMS.Core.WebApi.ApiModels;

namespace DexCMS.Core.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SettingGroupsController : ApiController
    {
		private ISettingGroupRepository repository;

		public SettingGroupsController(ISettingGroupRepository repo) 
		{
			repository = repo;
		}

        // GET api/SettingGroups
        public List<SettingGroupApiModel> GetSettingGroups()
        {
			var items = repository.Items.Select(x => new SettingGroupApiModel {
				SettingGroupID = x.SettingGroupID,
				SettingGroupName = x.SettingGroupName,
                SettingCount = x.Settings.Count
			}).ToList();

			return items;
        }

        // GET api/SettingGroups/5
        [ResponseType(typeof(SettingGroup))]
        public async Task<IHttpActionResult> GetSettingGroup(int id)
        {
			SettingGroup settingGroup = await repository.RetrieveAsync(id);
            if (settingGroup == null)
            {
                return NotFound();
            }

			SettingGroupApiModel model = new SettingGroupApiModel()
			{
				SettingGroupID = settingGroup.SettingGroupID,
				SettingGroupName = settingGroup.SettingGroupName,
                SettingCount = settingGroup.Settings.Count
			};

            return Ok(model);
        }

        // PUT api/SettingGroups/5
        public async Task<IHttpActionResult> PutSettingGroup(int id, SettingGroup settingGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != settingGroup.SettingGroupID)
            {
                return BadRequest();
            }

			await repository.UpdateAsync(settingGroup, settingGroup.SettingGroupID);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/SettingGroups
        [ResponseType(typeof(SettingGroup))]
        public async Task<IHttpActionResult> PostSettingGroup(SettingGroup settingGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

			await repository.AddAsync(settingGroup);

            return CreatedAtRoute("DefaultApi", new { id = settingGroup.SettingGroupID }, settingGroup);
        }

        // DELETE api/SettingGroups/5
        [ResponseType(typeof(SettingGroup))]
        public async Task<IHttpActionResult> DeleteSettingGroup(int id)
        {
			SettingGroup settingGroup = await repository.RetrieveAsync(id);
            if (settingGroup == null)
            {
                return NotFound();
            }

			await repository.DeleteAsync(settingGroup);

            return Ok(settingGroup);
        }

    }


}