using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ImageResizer;
using System.Web.Hosting;
using System.IO;
using DexCMS.Core.Extensions;
using DexCMS.Core.Interfaces;
using DexCMS.Core.WebApi.ApiModels;
using DexCMS.Core.Models;

namespace DexCMS.Core.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ImagesController : ApiController
    {
		private IImageRepository repository;
        private ISettingRepository settings;

		public ImagesController(IImageRepository repo, ISettingRepository settings) 
		{
			repository = repo;
            this.settings = settings;
		}

        // GET api/Images
        public List<ImageApiModel> GetImages()
        {
            return ImageApiModel.MapForClient(repository.Items);
        }

        // GET api/Images/PageContents/1
        [ResponseType(typeof(List<ImageApiModel>))]
        public IHttpActionResult GetImages(string bytype, int id)
        {
            List<ImageApiModel> items = new List<ImageApiModel>();

            if (bytype == "forpagecontents")
            {
                items = ImageApiModel.MapForClient(repository.Items);
            }
            else
            {
                return NotFound();
            }

            return Ok(items);
        }

        // GET api/Images/5
        [ResponseType(typeof(Image))]
        public async Task<IHttpActionResult> GetImage(int id)
        {
			Image image = await repository.RetrieveAsync(id);
            if (image == null)
            {
                return NotFound();
            }

            return Ok(ImageApiModel.MapForClient(image));
        }


        // PUT api/Images/5
        public async Task<IHttpActionResult> PutImage(int id, ImageApiModel apiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != apiModel.ImageID)
            {
                return BadRequest();
            }

            Image image = await repository.RetrieveAsync(id);
            ImageApiModel.MapForServer(apiModel, image);

            if (!String.IsNullOrEmpty(apiModel.ReplacementFileName))
            {
                SaveFile(image, apiModel);
            }
			await repository.UpdateAsync(image, image.ImageID);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Images
        [ResponseType(typeof(Image))]
        public async Task<IHttpActionResult> PostImage(ImageApiModel apiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Image image = new Image();
            ImageApiModel.MapForServer(apiModel, image);

            await repository.AddAsync(image);

            SaveFile(image, apiModel);
            await repository.UpdateAsync(image, image.ImageID);

            return CreatedAtRoute("DefaultApi", new { id = image.ImageID }, image);
        }

        // DELETE api/Images/5
        [ResponseType(typeof(Image))]
        public async Task<IHttpActionResult> DeleteImage(int id)
        {
			Image image = await repository.RetrieveAsync(id);
            if (image == null)
            {
                return NotFound();
            }

            DeleteImageFiles(image);
            await repository.DeleteAsync(image);
            return Ok(image);
        }

        private void SaveFile(Image item, ImageApiModel apiModel, int? overrideID = null)
        {
            int id = overrideID.HasValue ? overrideID.Value : item.ImageID;
            string uploadFolderName = "content/images/cdn/" + id + "/";
            List<ResizeType> resizeSettings = BuildResizeTypes();

            string uploadFolder = HostingEnvironment.MapPath("~/" + uploadFolderName);

            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            string pictureName = item.Alt.Clean();
            string extension = apiModel.ReplacementFileName.Substring(apiModel.ReplacementFileName.LastIndexOf('.'));

            if (item.Original != null)
            {
                DeleteImageFiles(item);
            }

            //let's make sure alt is unique
            string newName = item.Alt;
            GenerateUniqueName(uploadFolderName, uploadFolder, ref pictureName, extension, ref newName);
            item.Alt = newName;

            //Retrieve file
            var file = System.Web.HttpContext.Current.Server.MapPath("~/Tmp/FileUploads/" + apiModel.TemporaryFileName);

            //resize the image for each of our resize settings
            foreach (ResizeType resize in resizeSettings)
            {
                //remove special characters from file name
                string fileName = pictureName;

                fileName += "_" + resize.uploadName.ToLower();

                string fullfilePath = Path.Combine(uploadFolder, fileName);

                fullfilePath = ImageBuilder.Current.Build(
                    new ImageJob(file, fullfilePath, resize.instructions, false, true)).FinalPath;

                switch (resize.uploadName)
                {
                    case "Thumbnail":
                        item.Thumbnail = uploadFolderName + fileName + fullfilePath.Substring(fullfilePath.LastIndexOf('.'));
                        break;

                    case "Slider":
                        item.Slider = uploadFolderName + fileName + fullfilePath.Substring(fullfilePath.LastIndexOf('.'));
                        break;

                    case "Gallery":
                        item.Gallery = uploadFolderName + fileName + fullfilePath.Substring(fullfilePath.LastIndexOf('.'));
                        break;

                    case "Original":
                        item.Original = uploadFolderName + fileName + fullfilePath.Substring(fullfilePath.LastIndexOf('.'));
                        break;
                }
            }

        }

        private static void GenerateUniqueName(string uploadFolderName, string uploadFolder, ref string pictureName, string extension, ref string newName)
        {
            //image doesn't exist, let's make sure it is unique
            int? appendNumber = null;
            bool foundUnused = false;
            do
            {
                //let's make sure the new image we are about to save doesn't already exist
                string testFile = uploadFolderName + pictureName + appendNumber + "_original" + extension;

                //save file path
                string testPath = Path.Combine(uploadFolder,
                    Path.GetFileName(testFile));

                //test if file exists, if so, increment the number and repeat the loop
                if (File.Exists(testPath))
                {
                    if (appendNumber != null)
                    {
                        appendNumber++;
                    }
                    else
                    {
                        appendNumber = 1;
                    }
                }
                else
                {
                    //file does not exist, so we have a unique name to use
                    pictureName += appendNumber;
                    foundUnused = true;
                    newName += appendNumber;
                }
            } while (!foundUnused);
        }

        private void DeleteImageFiles(Image item)
        {
            DeleteFile(item.Original);
            DeleteFile(item.Thumbnail);
            DeleteFile(item.Gallery);
            DeleteFile(item.Slider);
        }

        private void DeleteFile(string file)
        {
            if (!String.IsNullOrEmpty(file))
            {
                string oldFile = HostingEnvironment.MapPath("~/" + file);
                if (File.Exists(oldFile))
                {
                    File.Delete(oldFile);
                }
            }
        }

        private List<ResizeType> BuildResizeTypes()
        {
            string[] types = { "Thumb", "Gallery", "Slider", "Original" };
            List<ResizeType> resizeTypes = new List<ResizeType>();
            foreach (var type in types)
            {
                resizeTypes.Add(BuildResizeType(type));
            }
            return resizeTypes;
        }

        private ResizeType BuildResizeType(string type)
        {
            ResizeType resizeType = new ResizeType
            {
                uploadName = type == "Thumb" ? "Thumbnail" : type,
                instructions = new Instructions()
                {
                    Mode = type == "Original" ? ImageResizer.FitMode.Max : ImageResizer.FitMode.Crop,
                    Width = int.Parse(settings.GetValue(type + "Width")),
                    Height = int.Parse(settings.GetValue(type + "Height")),
                }
            };

            if (type == "Thumb")
            {
                resizeType.instructions.OutputFormat = OutputFormat.Png;
            }

            return resizeType;
        }
    }


}