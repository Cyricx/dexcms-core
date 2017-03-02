using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Hosting;
using System.IO;
using DexCMS.Core.Extensions;
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

        [ResponseType(typeof(List<SettingApiModel>))]
        public List<SettingApiModel> GetSettings()
        {
            return HidePassword(SettingApiModel.MapForClient(repository.Items));
        }

        [ResponseType(typeof(SettingApiModel))]
        public async Task<IHttpActionResult> GetSetting(int id)
        {
            Setting setting = await repository.RetrieveAsync(id);
            if (setting == null)
            {
                return NotFound();
            }
            return Ok(SettingApiModel.MapForClient(setting));
        }

        public async Task<IHttpActionResult> PutSetting(int id, SettingApiModel apiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != apiModel.SettingID)
            {
                return BadRequest();
            }

            Setting setting = await repository.RetrieveAsync(id);
            SettingApiModel.MapForServer(apiModel, setting);

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

        [ResponseType(typeof(SettingApiModel))]
        public async Task<IHttpActionResult> PostSetting(SettingApiModel apiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var setting = new Setting();
            SettingApiModel.MapForServer(apiModel, setting);

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

            return CreatedAtRoute("DefaultApi", new { id = setting.SettingID }, HidePassword(SettingApiModel.MapForClient(setting)));
        }

        [ResponseType(typeof(SettingApiModel))]
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

            return Ok(HidePassword(SettingApiModel.MapForClient(setting)));
        }

        private List<SettingApiModel> HidePassword(List<SettingApiModel> models)
        {
            foreach (var item in models)
            {
                HidePassword(item);
            }
            return models;
        }

        private SettingApiModel HidePassword(SettingApiModel model)
        {
            if (model.SettingDataTypeName == "Password")
            {
                model.Value = "********";
            }
            return model;
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