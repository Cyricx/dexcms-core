using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DexCMS.Core.Models;
using DexCMS.Core.Interfaces;
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

        [ResponseType(typeof(List<SettingGroupApiModel>))]
        public List<SettingGroupApiModel> GetSettingGroups()
        {
            return SettingGroupApiModel.MapForClient(repository.Items);
        }

        [ResponseType(typeof(SettingGroupApiModel))]
        public async Task<IHttpActionResult> GetSettingGroup(int id)
        {
			SettingGroup settingGroup = await repository.RetrieveAsync(id);
            if (settingGroup == null)
            {
                return NotFound();
            }

            return Ok(SettingGroupApiModel.MapForClient(settingGroup));
        }

        public async Task<IHttpActionResult> PutSettingGroup(int id, SettingGroupApiModel apiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != apiModel.SettingGroupID)
            {
                return BadRequest();
            }
            SettingGroup settingGroup = await repository.RetrieveAsync(id);
            SettingGroupApiModel.MapForServer(apiModel, settingGroup);

			await repository.UpdateAsync(settingGroup, settingGroup.SettingGroupID);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(SettingGroupApiModel))]
        public async Task<IHttpActionResult> PostSettingGroup(SettingGroupApiModel apiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            SettingGroup settingGroup = new SettingGroup();
            SettingGroupApiModel.MapForServer(apiModel, settingGroup);

            await repository.AddAsync(settingGroup);

            return CreatedAtRoute("DefaultApi", new { id = settingGroup.SettingGroupID }, SettingGroupApiModel.MapForClient(settingGroup));
        }

        [ResponseType(typeof(SettingGroupApiModel))]
        public async Task<IHttpActionResult> DeleteSettingGroup(int id)
        {
			SettingGroup settingGroup = await repository.RetrieveAsync(id);
            if (settingGroup == null)
            {
                return NotFound();
            }

			await repository.DeleteAsync(settingGroup);

            return Ok(SettingGroupApiModel.MapForClient(settingGroup));
        }
    }
}