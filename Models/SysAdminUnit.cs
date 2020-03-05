using System;

namespace CreatioUsersWebApi.Models
{
	/// <summary>
	/// Модель данных пользователя.
	/// </summary>
    public class SysAdminUnit
    {
		/// <summary>
		/// Идентификатор.
		/// </summary>
		public Guid Id { get; set; } = Guid.NewGuid();

		/// <summary>
		/// Имя.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Дата создания.
		/// </summary>
		public DateTime? CreatedOn { get; set; } = DateTime.UtcNow;
        
		/// <summary>
		/// Идентификатор контакта.
		/// </summary>
        public Guid? ContactId { get; set; }

		/// <summary>
		/// Контакт.
		/// </summary>
		public virtual Contact Contact { get; set; }

		/// <summary>
		/// Часовой пояс.
		/// </summary>
        public string TimeZoneId { get; set; }

		/// <summary>
		/// Тип записи.
		/// </summary>
		public int SysAdminUnitTypeValue { get; set; } = 4;

		/// <summary>
		/// Контрагент.
		/// </summary>
        public Guid? AccountId { get; set; }

		/// <summary>
		/// Активная запись.
		/// </summary>
        public bool Active { get; set; }

		/// <summary>
		/// Доменный пользователь.
		/// </summary>
		public bool IsDirectoryEntry { get; set; }

		/// <summary>
		/// Синхронизировать с LDAP.
		/// </summary>
		public bool SynchronizeWithLdap { get; set; }

		/// <summary>
		/// Хэш пароля.
		/// </summary>
		public string UserPassword { get; set; } = "rFgtKVqa6JIawkd99Sw0.uZal2ZiT31/vjpss74Dl53IjcbpmvKjW"; // Supervisor.
    }
}
