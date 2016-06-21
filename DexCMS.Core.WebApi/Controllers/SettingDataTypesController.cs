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
using DexCMS.Core.WebApi.ApiModels;
using DexCMS.Core.Infrastructure.Interfaces;

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

        // GET api/SettingDataTypes
        public List<SettingDataTypeApiModel> GetSettingDataTypes()
        {
			var items = repository.Items.Select(x => new SettingDataTypeApiModel {
				SettingDataTypeID = x.SettingDataTypeID,
				Name = x.Name,
                SettingCount = x.Settings.Count
			}).ToList();

			return items;
        }

        // GET api/SettingDataTypes/5
        [ResponseType(typeof(SettingDataType))]
        public async Task<IHttpActionResult> GetSettingDataType(int id)
        {
			SettingDataType settingDataType = await repository.RetrieveAsync(id);
            if (settingDataType == null)
            {
                return NotFound();
            }

			SettingDataTypeApiModel model = new SettingDataTypeApiModel()
			{
				SettingDataTypeID = settingDataType.SettingDataTypeID,
				Name = settingDataType.Name,
                SettingCount = settingDataType.Settings.Count
			
			};

            return Ok(model);
        }

        // PUT api/SettingDataTypes/5
        public async Task<IHttpActionResult> PutSettingDataType(int id, SettingDataType settingDataType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != settingDataType.SettingDataTypeID)
            {
                return BadRequest();
            }

			await repository.UpdateAsync(settingDataType, settingDataType.SettingDataTypeID);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/SettingDataTypes
        [ResponseType(typeof(SettingDataType))]
        public async Task<IHttpActionResult> PostSettingDataType(SettingDataType settingDataType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

			await repository.AddAsync(settingDataType);

            return CreatedAtRoute("DefaultApi", new { id = settingDataType.SettingDataTypeID }, settingDataType);
        }

        // DELETE api/SettingDataTypes/5
        [ResponseType(typeof(SettingDataType))]
        public async Task<IHttpActionResult> DeleteSettingDataType(int id)
        {
			SettingDataType settingDataType = await repository.RetrieveAsync(id);
            if (settingDataType == null)
            {
                return NotFound();
            }

			await repository.DeleteAsync(settingDataType);

            return Ok(settingDataType);
        }

    }


}