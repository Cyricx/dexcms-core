using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using DexCMS.Core.WebApi.ApiModels;

namespace DexCMS.Core.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FileUploadController : ApiController
    {
        private string tempFolder = HttpContext.Current.Server.MapPath("~/Tmp/FileUploads");

        [HttpPost]
        public async Task<HttpResponseMessage> Upload()
        {
            //check if request contains multipart/form-data
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var provider = new MultipartFormDataStreamProvider(tempFolder);

            var result = await Request.Content.ReadAsMultipartAsync(provider);
            UploadedFile uploadedFile = new UploadedFile();

            ProcessFile(result.FileData.First(), uploadedFile);

            return this.Request.CreateResponse(HttpStatusCode.OK, uploadedFile);
        }

        private string GetDeserializedFileName(MultipartFileData fileData)
        {
            var fileName = GetFileName(fileData);
            return JsonConvert.DeserializeObject(fileName).ToString();
        }

        private string GetFileName(MultipartFileData fileData)
        {
            return fileData.Headers.ContentDisposition.FileName;
        }

        private void ProcessFile(MultipartFileData fileData, UploadedFile uploadedFile)
        {
            uploadedFile.OriginalName = GetDeserializedFileName(fileData);

            string fileExtension = uploadedFile.OriginalName.Substring(uploadedFile.OriginalName.LastIndexOf('.'));
            uploadedFile.TemporaryName = Guid.NewGuid().ToString() + fileExtension;
            //includes path
            var uploadedFileInfo = new FileInfo(fileData.LocalFileName);

            File.Move(uploadedFileInfo.FullName, tempFolder + '/' + uploadedFile.TemporaryName);
        }
    }
}
