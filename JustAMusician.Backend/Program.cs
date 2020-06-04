using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace JustAMusician.Backend
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var host = new WebHostBuilder()
				.UseKestrel()
				.UseIISIntegration()
				.UseContentRoot(Directory.GetCurrentDirectory())
				.ConfigureAppConfiguration((builderContext, config) =>
				{
					IHostingEnvironment env = builderContext.HostingEnvironment;
					config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

				})
				.UseStartup<Startup>()
				.Build();

			host.Run();
		}
	}
}
