using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetClink.Models
{
    /// <summary>
    /// Базовый класс для всех предоставляемых услуг
    /// </summary>
    [NotMapped]
    public class BasicService
    {
        #region Constructor
        public BasicService()
        {
            _title = string.Empty;
            _description = string.Empty;
        }

        #endregion

        #region Fields 

        private string _title;
        private decimal _price;
        private string _description;

        #endregion

        #region Properties

        [DisplayName("Название")]
        public string Title { get => _title; set => _title = value; }

        [DisplayName("Цена")]
        public decimal Price { get => _price; set => _price = value; }

        [DisplayName("Название")]
        public string Description { get => _description; set => _description = value; }

        #endregion
    }
}
