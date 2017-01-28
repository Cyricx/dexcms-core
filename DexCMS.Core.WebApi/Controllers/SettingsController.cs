using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Hosting;
using System.IO;
using DexCMS.Core.Extensions;
using DexCMS.Core;
using DexCMS.Core.Models;
using DexCMS.Core.Interfaces;
using DexCMS.Core.WebApi.ApiModels;

namespace DexCMS.Core.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SettingsController : ApiController
    {
		private ISettingRepository repository;

		public SettingsController(ISettingRepository repo) 
		{
			repository = repo;
		}

        // GET api/Settings
        public List<SettingApiModel> GetSettings()
        {
			var items = repository.Items.Select(x => new SettingApiModel {
				SettingID = x.SettingID,
				Name = x.Name,
				Value = x.Value,
				SettingDataTypeID = x.SettingDataTypeID,
				SettingGroupID = x.SettingGroupID,
                SettingDataTypeName = x.SettingDataType.Name,
                SettingGroupName = x.SettingGroup.SettingGroupName
			}).ToList();

			return items;
        }

        // GET api/Settings/5
        [ResponseType(typeof(Setting))]
        public async Task<IHttpActionResult> GetSetting(int id)
        {
			Setting setting = await repository.RetrieveAsync(id);
            if (setting == null)
            {
                return NotFound();
            }

			SettingApiModel model = new SettingApiModel()
			{
				SettingID = setting.SettingID,
				Name = setting.Name,
				Value = setting.Value,
				SettingDataTypeID = setting.SettingDataTypeID,
                SettingDataTypeName = setting.SettingDataType.Name,
				SettingGroupID = setting.SettingGroupID
			
			};

            return Ok(model);
        }

        // PUT api/Settings/5
        public async Task<IHttpActionResult> PutSetting(int id, Setting setting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != setting.SettingID)
            {
                return BadRequest();
            }

            if (setting.SettingDataTypeID == 10 && !string.IsNullOrEmpty(setting.ReplacementFileName))
            {

                DeleteFile(GetValue(setting.SettingID));
                SaveFile(setting, setting.ReplacementFileName, setting.TemporaryFileName);
            }
            else if (setting.SettingDataTypeID == 11 && !string.IsNullOrEmpty(setting.ReplacementImageName))
            {
                DeleteFile(GetValue(setting.SettingID));
                SaveFile(setting, setting.ReplacementImageName, setting.TemporaryImageName);
            }

            await repository.UpdateAsync(setting, setting.SettingID);

            (new SiteSettingsBuilder(repository)).Initialize();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Settings
        [ResponseType(typeof(Setting))]
        public async Task<IHttpActionResult> PostSetting(Setting setting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await repository.AddAsync(setting);

            if (setting.SettingDataTypeID == 10 && !string.IsNullOrEmpty(setting.ReplacementFileName))
            {
                SaveFile(setting, setting.ReplacementFileName, setting.TemporaryFileName);
                await repository.UpdateAsync(setting, setting.SettingID);
            }
            else if (setting.SettingDataTypeID == 11 && !string.IsNullOrEmpty(setting.ReplacementImageName))
            {
                SaveFile(setting, setting.ReplacementImageName, setting.TemporaryImageName);
                await repository.UpdateAsync(setting, setting.SettingID);
            }

            (new SiteSettingsBuilder(repository)).Initialize();

            return CreatedAtRoute("DefaultApi", new { id = setting.SettingID }, setting);
        }

        // DELETE api/Settings/5
        [ResponseType(typeof(Setting))]
        public async Task<IHttpActionResult> DeleteSetting(int id)
        {
			Setting setting = await repository.RetrieveAsync(id);
            if (setting == null)
            {
                return NotFound();
            }

            if (setting.SettingDataTypeID == 10 || setting.SettingDataTypeID == 11)
            {
                DeleteFile(setting.Value);
            }

			await repository.DeleteAsync(setting);

            (new SiteSettingsBuilder(repository)).Initialize();

            return Ok(setting);
        }

        private string GetValue(int id)
        {
            return repository.Items.Where(x => x.SettingID == id).Select(x => x.Value).Single();
        }

        private void DeleteFile(string filepath)
        {
            string oldFile = HostingEnvironment.MapPath("~/" + filepath);
            if (File.Exists(oldFile))
            {
                File.Delete(oldFile);
            }
        }

        private void SaveFile(Setting item, string replacementFile, string tempName)
        {
            int id = item.SettingID;
            string uploadFolderName = "content/images/" + id + "/";

            string uploadFolder = HostingEnvironment.MapPath("~/" + uploadFolderName);

            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            string pictureName = item.Name.Clean();
            string extension = replacementFile.Substring(replacementFile.LastIndexOf('.'));

            //let's make sure alt is unique
            string newName = item.Name;
 //           GenerateUniqueName(uploadFolderName, uploadFolder, ref pictureName, extension, ref newName);
            item.Name = newName;

            //Retrieve file
            var file = System.Web.HttpContext.Current.Server.MapPath("~/Tmp/FileUploads/" + tempName);

            //remove special characters from file name
            string fileName = pictureName + extension;

            string fullfilePath = Path.Combine(uploadFolder, fileName);

            File.Copy(file, fullfilePath);

            File.Delete(file);
            item.Value = uploadFolderName + fileName;
        }
        
    }
}