using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VetClink.Data.Enum
{
    public enum AnimalGender
    {
        [Display(Name = "м")]
        Male,
        [Display(Name = "ж")]
        Female,
    }
}
