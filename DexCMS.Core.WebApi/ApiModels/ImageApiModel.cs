using DexCMS.Core.Attributes;
using DexCMS.Core.Globals;
using DexCMS.Core.Models;
using ImageResizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Core.WebApi.ApiModels
{
    public class ImageApiModel: DexCMSViewModel<ImageApiModel, Image>
    {
        public int ImageID { get; set; }

        public string Alt { get; set; }

        public string Credit { get; set; }

        public string Caption { get; set; }

        public string Thumbnail { get; set; }

        public string Slider { get; set; }

        public string Gallery { get; set; }

        public string Original { get; set; }

        [OverrideMappingType(MappingType.NoMappings)]
        public bool ToDelete { get; set; }
        [OverrideMappingType(MappingType.NoMappings)]
        public string ReplacementFileName { get; set; }
        [OverrideMappingType(MappingType.NoMappings)]
        public string TemporaryFileName { get; set; }

    }

    public class ResizeType
    {
        public Instructions instructions { get; set; }
        public string uploadName { get; set; }
    }
}
