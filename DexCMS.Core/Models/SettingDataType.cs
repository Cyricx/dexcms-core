using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DexCMS.Core.Models
{
    public class SettingDataType
    {
        //Properties
        [Key]
        public int SettingDataTypeID { get; set; }


        [Required]
        [StringLength(150)]
        public string Name { get; set; }


        //Relationships
        public virtual ICollection<Setting> Settings { get; set; }

    }
}
