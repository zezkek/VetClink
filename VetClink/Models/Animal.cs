using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using VetClink.Data.Enum;

namespace VetClink.Models
{
    /// <summary>
    /// Базовый класс для животного
    /// </summary>
    public class Animal : BasicObject
    {
        #region Constructor
        public Animal() { }
        #endregion

        #region Fields

        private AnimalGender _gender;
        private AnimalType _animalType;
        private string? _animalSubType;
        private int _age;
        private Owner _owner;

        #endregion

        #region Properties

        [DisplayName("Пол")]
        public AnimalGender Gender { get => _gender; set => _gender = value; }

        [DisplayName("Семейство")]
        public AnimalType AnimalType { get => _animalType; set => _animalType = value; }

        [DisplayName("Возраст")]
        public int Age { get => _age; set => _age = value; }

        [Required]
        [DisplayName("Владелец")]
        public Owner Owner { get => _owner; set => _owner = value; }

        [DisplayName("Вид")]
        public string AnimalSubType { get => _animalSubType ?? "Не задан"; set => _animalSubType = value; }

        #endregion

    }
}
