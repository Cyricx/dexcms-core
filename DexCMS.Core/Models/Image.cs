using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DexCMS.Core.Models
{
    public class Image
    {
        [Key]
        public int ImageID { get; set; }

        [Required]
        [StringLength(250)]
        public string Alt { get; set; }

        [StringLength(250)]
        public string Credit { get; set; }

        [StringLength(250)]
        public string Caption { get; set; }

        [StringLength(250)]
        public string Thumbnail { get; set; }

        [StringLength(250)]
        public string Slider { get; set; }

        [StringLength(250)]
        public string Gallery { get; set; }

        [StringLength(250)]
        public string Original { get; set; }

        [NotMapped]
        public bool ToDelete { get; set; }
        [NotMapped]
        public string ReplacementFileName { get; set; }
        [NotMapped]
        public string TemporaryFileName { get; set; }

    }
}
