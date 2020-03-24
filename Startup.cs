using System;
using System.IO;
using System.Reflection;
using CreatioUsersWebApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CreatioUsersWebApi
{
	/// <summary>
	/// Конфигуратор приложения.
	/// </summary>
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
			ConnectionString = $"Server={Configuration["Server"]};" +
			                   $"Database={Configuration["Database"]};" +
			                   $"Integrated Security=SSPI;" +
					   //$"User id={Configuration["UserId"]};" +
					   //$"Password={Configuration["Password"]};" +
			                   $"Trusted_Connection={Configuration["TrustedConnection"]};";
		}

		/// <summary>
		/// Политика, разрешающая кроссдоменные запросы (CORS).
		/// </summary>
		public static readonly string CorsPolicyName = "CorsPolicy";

		/// <summary>
		/// Конфигурация.
		/// </summary>
		public IConfiguration Configuration { get; }

		/// <summary>
		/// Строка подключения.
		/// </summary>
		private string ConnectionString { get; }

		/// <summary>
		/// Подключить сервисы.
		/// </summary>
		/// <param name="services">Сервисы для подключения.</param>
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy(CorsPolicyName,
					builder =>
					{
						builder.WithOrigins("http://localhost:8080")
							.AllowAnyHeader()
							.AllowAnyMethod();
					});
			});

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

				var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				c.IncludeXmlComments(xmlPath);
			});

			services.AddDbContext<CreatioUserDbContext>(options => options.UseSqlServer(ConnectionString));

			services.AddControllers();
		}

		/// <summary>
		/// Добавить модули.
		/// </summary>
		/// <param name="app">Приложение.</param>
		/// <param name="env">Окружение.</param>
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
			});

			//app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseCors(CorsPolicyName);

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
