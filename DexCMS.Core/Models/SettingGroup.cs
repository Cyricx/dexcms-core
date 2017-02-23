using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DexCMS.Core.Models
{
    public class SettingGroup
    {
        [Key]
        public int SettingGroupID { get; set; }

        [Required]
        [StringLength(50)]
        public string SettingGroupName { get; set; }

        public virtual ICollection<Setting> Settings { get; set; }
    }
}
