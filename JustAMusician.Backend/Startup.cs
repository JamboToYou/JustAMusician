using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using JustAMusician.Backend.Helpers;

namespace JustAMusician.Backend
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<DataBaseContext>(options =>
				options.UseMySql(Configuration.GetConnectionString("jamcs")));
			services.AddCors(options =>
					{
						options.AddPolicy(
							name: "AllowCors",
							builder =>
							{
								builder.AllowAnyHeader()
										.AllowAnyMethod()
										.AllowAnyOrigin();
							});
					});

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.RequireHttpsMetadata = false;
					options.TokenValidationParameters = new TokenValidationParameters
					{
						// укзывает, будет ли валидироваться издатель при валидации токена
						ValidateIssuer = true,
						// строка, представляющая издателя
						ValidIssuer = AuthOptions.ISSUER,

						// будет ли валидироваться потребитель токена
						ValidateAudience = true,
						// установка потребителя токена
						ValidAudience = AuthOptions.AUDIENCE,
						// будет ли валидироваться время существования
						ValidateLifetime = true,

						// установка ключа безопасности
						IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
						// валидация ключа безопасности
						ValidateIssuerSigningKey = true,
					};
				});

			services.AddMvc()
				.AddJsonOptions(options =>
				{
					var settings = options.SerializerSettings;
					settings.NullValueHandling = NullValueHandling.Ignore;
					settings.DefaultValueHandling = DefaultValueHandling.Ignore;
				});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseAuthentication();

			app.UseHttpsRedirection();
			app.UseCors();
			app.UseMvc();
		}
	}
}
