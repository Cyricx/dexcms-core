using System.ComponentModel.DataAnnotations;

namespace DexCMS.Core.Models
{
    public class State
    {
        //Properties
        [Key]
        public int StateID { get; set; }


        [Required]
        [StringLength(250)]
        public string Name { get; set; }


        [Required]
        public int CountryID { get; set; }


        [Required]
        [StringLength(3)]
        public string Abbreviation { get; set; }

        //Relationships
        public virtual Country Country { get; set; }

    }
}
