using System.ComponentModel.DataAnnotations;

namespace VetClink.Data.Enum
{
    public enum AnimalType
    {
        [Display(Name = "Собака")]
        Dog,
        [Display(Name = "Кошка")]
        Cat,
        [Display(Name = "Рыба")]
        Fish,
    }
}
