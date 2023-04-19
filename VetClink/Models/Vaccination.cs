using System.ComponentModel;
using VetClink.Data.Enum;

namespace VetClink.Models
{
    /// <summary>
    /// Класс содержащий информацию о привиках
    /// </summary>
    public class Vaccination : BasicService
    {
        #region Constructor
        public Vaccination() { }

        #endregion

        #region Fields

        private AnimalType _animalType;

        #endregion

        #region Properties

        [DisplayName("Вид животного")]
        public AnimalType AnimalType { get => _animalType; set => _animalType = value; }

        #endregion
    }
}
