using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace CreatioUsersWebApi
{
	public class Program
	{
		/// <summary>
		/// Точка входа в приложение.
		/// </summary>
		/// <param name="args">Аргументы.</param>
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		/// <summary>
		/// Создать конфигурацию хоста.
		/// </summary>
		/// <param name="args">Аргументы.</param>
		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					//webBuilder.UseStartup<Startup>();
					webBuilder.UseStartup("CreatioUsersWebApi");
				});
	}
}
