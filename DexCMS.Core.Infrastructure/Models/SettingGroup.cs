using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DexCMS.Core.Infrastructure.Models
{
    public class SettingGroup
    {
        //Properties
        [Key]
        public int SettingGroupID { get; set; }


        [Required]
        [StringLength(50)]
        public string SettingGroupName { get; set; }

        //Relationships
        public virtual ICollection<Setting> Settings { get; set; }

    }
}
