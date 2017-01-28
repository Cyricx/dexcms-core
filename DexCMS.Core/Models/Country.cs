using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DexCMS.Core.Models
{
    public class Country
    {
        //Properties
        [Key]
        public int CountryID { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        //Relationships
        public virtual ICollection<State> States { get; set; }

    }
}
