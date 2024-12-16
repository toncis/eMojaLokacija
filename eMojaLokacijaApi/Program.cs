
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace eMojaLokacijaApi
{
	public class Program
	{
		public static int Main(string[] args)
		{
			try
			{
				CreateHostBuilder(args).Build().Run();
				return 0;
			}
			catch (Exception ex)
			{
				return 1;
			}
			finally
			{
			}
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.ConfigureAppConfiguration((context, config) =>
					{
						// Add configuration sources here
					});
					webBuilder.UseStartup<Startup>();
				});
	}
}
