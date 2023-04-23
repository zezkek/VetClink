using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace VetClink.Models
{
    /// <summary>
    /// Базовый класс для клиента/сотрудника
    /// </summary>
    public class Person : BasicObject
    {

        #region Constructor
        public Person () 
        {
            _adress = string.Empty;
            _phone = string.Empty;
            _email = string.Empty;
        }

        #endregion

        #region Fields

        private string _adress;
        private string _phone;
        private string _email;
        private AppUser _appUser;

        #endregion

        #region Properties

        [DisplayName("Адрес")]
        public string? Adress { get => _adress; set => _adress = value; }

        [Phone]
        [DisplayName("Моб. телефон")]
        public string? Phone { get => _phone; set => _phone = value; }

        [EmailAddress]
        [DisplayName("Почта")]
        public string? Email { get => _email; set => _email = value; }

        public AppUser? AppUser { get => _appUser; set => _appUser = value; }

        #endregion
    }
}
