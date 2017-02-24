using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DexCMS.Core.Models;
using DexCMS.Core.WebApi.ApiModels;
using DexCMS.Core.Interfaces;

namespace DexCMS.Core.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SettingDataTypesController : ApiController
    {
		private ISettingDataTypeRepository repository;

		public SettingDataTypesController(ISettingDataTypeRepository repo) 
		{
			repository = repo;
		}

        [ResponseType(typeof(List<SettingDataTypeApiModel>))]
        public List<SettingDataTypeApiModel> GetSettingDataTypes()
        {
            return SettingDataTypeApiModel.MapForClient(repository.Items);
        }

        [ResponseType(typeof(SettingDataTypeApiModel))]
        public async Task<IHttpActionResult> GetSettingDataType(int id)
        {
			SettingDataType settingDataType = await repository.RetrieveAsync(id);
            if (settingDataType == null)
            {
                return NotFound();
            }

            return Ok(SettingDataTypeApiModel.MapForClient(settingDataType));
        }

        public async Task<IHttpActionResult> PutSettingDataType(int id, SettingDataTypeApiModel apiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != apiModel.SettingDataTypeID)
            {
                return BadRequest();
            }
            SettingDataType settingDataType = await repository.RetrieveAsync(id);
            SettingDataTypeApiModel.MapForServer(apiModel, settingDataType);

			await repository.UpdateAsync(settingDataType, settingDataType.SettingDataTypeID);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(SettingDataTypeApiModel))]
        public async Task<IHttpActionResult> PostSettingDataType(SettingDataTypeApiModel apiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            SettingDataType settingDataType = new SettingDataType();
            SettingDataTypeApiModel.MapForServer(apiModel, settingDataType);

			await repository.AddAsync(settingDataType);

            return CreatedAtRoute("DefaultApi", new { id = settingDataType.SettingDataTypeID }, SettingDataTypeApiModel.MapForClient(settingDataType));
        }

        [ResponseType(typeof(SettingDataTypeApiModel))]
        public async Task<IHttpActionResult> DeleteSettingDataType(int id)
        {
			SettingDataType settingDataType = await repository.RetrieveAsync(id);
            if (settingDataType == null)
            {
                return NotFound();
            }

			await repository.DeleteAsync(settingDataType);

            return Ok(SettingDataTypeApiModel.MapForClient(settingDataType));
        }
    }
}