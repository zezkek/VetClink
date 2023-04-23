using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetClink.Models
{
    /// <summary>
    /// Базовый класс для всех объектов
    /// </summary>
    public class BasicObject
    {
        #region Constructor
        //Задает уникальный Guid при создании любого объекта
        public BasicObject() => _guid = Guid.NewGuid();

        #endregion

        #region Fields

        private Guid _guid;
        private string? _name;

        #endregion

        #region Properties

        [Key]
        public Guid Guid { get => _guid; set => _guid = value; }

        [DisplayName("Имя")]
        public string? Name { get => _name ?? "Имя не задано"; set => _name = value; }

        #endregion
    }
}
