using System;

namespace CreatioUsersWebApi.Models
{
	/// <summary>
	/// Контакт.
	/// </summary>
    public class Contact
    {
	    /// <summary>
		/// Идентификатор.
		/// </summary>
        public Guid Id { get; set; }

	    /// <summary>
		/// Дата создания.
		/// </summary>
        public DateTime? CreatedOn { get; set; }

		/// <summary>
		/// ФИО.
		/// </summary>
        public string Name { get; set; }

		/// <summary>
		/// Идентификатор контрагента.
		/// </summary>
        public Guid? AccountId { get; set; }

		/// <summary>
		/// Обращение.
		/// </summary>
        public string Dear { get; set; }

		/// <summary>
		/// Идентификатор пола.
		/// </summary>
        public Guid? GenderId { get; set; }

		/// <summary>
		/// Дата рождения.
		/// </summary>
        public DateTime? BirthDate { get; set; }

		/// <summary>
		/// Мобильный телефон.
		/// </summary>
        public string MobilePhone { get; set; }

		/// <summary>
		/// Email.
		/// </summary>
        public string Email { get; set; }

		/// <summary>
		/// Фамилия.
		/// </summary>
        public string Surname { get; set; }

		/// <summary>
		/// Имя.
		/// </summary>
        public string GivenName { get; set; }

		/// <summary>
		/// Отчество.
		/// </summary>
        public string MiddleName { get; set; }
    }
}
