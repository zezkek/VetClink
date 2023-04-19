using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace VetClink.Models
{
    /// <summary>
    /// Класс содержащий информацию о клиентах
    /// </summary>
    public class Owner : Person
    {
        #region Constructor

        public Owner() { }
        #endregion

        #region Fields

        [AllowNull]
        private ICollection<Animal> _animals;

        #endregion

        #region Properties

        [AllowNull]
        [DisplayName("Питомцы")]
        public ICollection<Animal> Animals { get => _animals; set => _animals = value; }

        #endregion
    }
}
