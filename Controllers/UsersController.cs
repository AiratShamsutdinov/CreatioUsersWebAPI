using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreatioUsersWebApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CreatioUsersWebApi.Controllers
{
	/// <summary>
	/// Контроллер для работы с пользователями.
	/// </summary>
	[Produces("application/json")]
	[ApiController]
	[Route("api/[controller]")]
	[EnableCors("CorsPolicy")]
	public class UsersController : ControllerBase
	{
		private readonly CreatioUserDbContext _dbContext;

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="context">Контекст базы данных.</param>
		public UsersController(CreatioUserDbContext context)
		{
			if (null == context)
			{
				throw new ArgumentException($"{nameof(context)}");
			}

			_dbContext = context;
		}

		/// <summary>
		/// Получить список пользователей.
		/// </summary>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<SysAdminUnit>>> Get()
		{
			return await _dbContext
				.SysAdminUnit
				.Where(s => s.SysAdminUnitTypeValue == 4)
				.ToListAsync();
		}

		/// <summary>
		/// Получить данные пользователя.
		/// </summary>
		/// <param name="id">Идентификатор пользователя.</param>
		[HttpGet("{id}")]
		public async Task<ActionResult<SysAdminUnit>> Get(Guid id)
		{
			if (id == Guid.Empty)
			{
				throw new ArgumentException($"{nameof(id)}");
			}

			var user = await _dbContext
				.SysAdminUnit
				.FirstOrDefaultAsync(u => u.Id == id);

			if (user == null)
			{
				return NotFound();
			}

			_dbContext.Entry(user).Reference(r => r.Contact).Load();

			return new ObjectResult(user);
		}

		/// <summary>
		/// Активировать пользователя.
		/// </summary>
		/// <param name="user">Данные пользователя.</param>
		[HttpPut("activate")]
		public async Task<ActionResult<SysAdminUnit>> Activate(SysAdminUnit user)
		{
			if (null == user)
			{
				throw new ArgumentException($"{nameof(user)}");
			}

			var updatedUser = await ChangeUserActivate(user.Id, true);

			if (updatedUser == null)
			{
				return NotFound();
			}

			return Ok(updatedUser);
		}

		/// <summary>
		/// Деактивировать пользователя.
		/// </summary>
		/// <param name="user">Данные пользователя.</param>
		[HttpPut("deactivate")]
		public async Task<ActionResult<SysAdminUnit>> Deactivate(SysAdminUnit user)
		{
			if (null == user)
			{
				throw new ArgumentException($"{nameof(user)}");
			}

			var updatedUser = await ChangeUserActivate(user.Id, false);

			if (updatedUser == null)
			{
				return NotFound();
			}

			return Ok(updatedUser);
		}

		/// <summary>
		/// Создать пользователя.
		/// </summary>
		/// <param name="user">Данные пользователя.</param>
		[HttpPost]
		public async Task<ActionResult<SysAdminUnit>> Post(SysAdminUnit user)
		{
			if (user == null)
			{
				return BadRequest();
			}

			var contact = await _dbContext
				.Contact
				.SingleOrDefaultAsync(c => c.Name == user.Contact.Name);

			if (null != contact)
			{
				user.Contact = contact;
			}

			_dbContext
				.SysAdminUnit
				.Add(user);

			await _dbContext.SaveChangesAsync();
			return Ok(user);
		}

		/// <summary>
		/// Обновить данные пользователя.
		/// </summary>
		/// <param name="user">Данные пользователя.</param>
		[HttpPut]
		public async Task<ActionResult<SysAdminUnit>> Put(SysAdminUnit user)
		{
			if (user == null)
			{
				return BadRequest();
			}

			var hasUser = await _dbContext
				.SysAdminUnit
				.AnyAsync(x => x.Id == user.Id);

			if (!hasUser)
			{
				return NotFound();
			}

			_dbContext.Update(user);
			await _dbContext.SaveChangesAsync();
			return Ok(user);
		}

		/// <summary>
		/// Удалить пользователя.
		/// </summary>
		/// <param name="id">Идентификатор пользователя.</param>
		[HttpDelete("{id}")]
		public async Task<ActionResult<SysAdminUnit>> Delete(Guid id)
		{
			if (id == Guid.Empty)
			{
				throw new ArgumentException($"{nameof(id)}");
			}

			var user = await _dbContext
				.SysAdminUnit
				.SingleOrDefaultAsync(u => u.Id == id);

			if (user == null)
			{
				return NotFound();
			}

			_dbContext
				.SysAdminUnit
				.Remove(user);

			await _dbContext.SaveChangesAsync();
			return Ok(user);
		}

		/// <summary>
		/// Изменить признак активности пользователя.
		/// </summary>
		/// <param name="id">Идентификатор пользователя.</param>
		/// <param name="isActive">Признак активности пользователя.</param>
		private async Task<SysAdminUnit> ChangeUserActivate(Guid id, bool isActive)
		{
			if (id == Guid.Empty)
			{
				throw new ArgumentException($"{nameof(id)}");
			}

			var user = await _dbContext
				.SysAdminUnit
				.SingleOrDefaultAsync(u => u.Id == id);

			if (user == null)
			{
				return null;
			}

			if (user.Active == isActive)
			{
				return user;
			}

			user.Active = isActive;
			
			_dbContext
				.SysAdminUnit
				.Update(user);

			await _dbContext.SaveChangesAsync();

			return user;
		}
	}
}
