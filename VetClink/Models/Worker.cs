using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using VetClink.Data.Enum;

namespace VetClink.Models
{
    /// <summary>
    /// Класс содержащий информацию о сотруднике
    /// </summary>
    public class Worker : Person
    {
        #region Constructor

        public Worker() { }

        #endregion

        #region Fieleds

        private WorkerType _workerType;
        [AllowNull]
        private Worker _workerChief;

        #endregion

        #region Properties

        [DisplayName("Должность")]
        public WorkerType WorkerType { get => _workerType; set => _workerType = value; }

        [DisplayName("Начальник")]
        public Worker WorkerChief { get => _workerChief; set => _workerChief = value; }

        #endregion
    }
}
