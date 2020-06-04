using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace JustAMusician.Backend
{
	public class DataBaseContextFactory : IDesignTimeDbContextFactory<DataBaseContext>
	{
		public DataBaseContext CreateDbContext(string[] args)
		{
			var optionBuilder = new DbContextOptionsBuilder<DataBaseContext>();
			var config = new ConfigurationBuilder()
				.AddJsonFile(Directory.GetCurrentDirectory() + "/appsettings.json")
				.Build();

			optionBuilder.UseMySql(config.GetConnectionString("jamcs"));

			return new DataBaseContext(optionBuilder.Options);
		}
	}
}