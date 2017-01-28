using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DexCMS.Core.Models
{
    public class Setting
    {
        //Properties
        [Key]
        public int SettingID { get; set; }


        [Required]
        [StringLength(150)]
        public string Name { get; set; }


        [Required]
        [StringLength(1500)]
        public string Value { get; set; }

        [Required]
        public int SettingDataTypeID { get; set; }

        [Required]
        public int SettingGroupID { get; set; }

        //relationships
        public virtual SettingGroup SettingGroup { get; set; }

        public virtual SettingDataType SettingDataType { get; set; }


        [NotMapped]
        public string ReplacementFileName { get; set; }
        [NotMapped]
        public string TemporaryFileName { get; set; }

        [NotMapped]
        public string ReplacementImageName { get; set; }
        [NotMapped]
        public string TemporaryImageName { get; set; }
    }
}
