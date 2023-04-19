using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace VetClink.Data.Enum
{
    public enum WorkerType
    {
        [Display(Name = "Врач")]
        Doctor,
        [Display(Name = @"Медсестра\Медбрат")]
        Nurse,
        [Display(Name = "Персонал")]
        Staff,
    }
}
