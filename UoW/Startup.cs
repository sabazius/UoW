using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System;
using System.Text;
using UoW.BL.Interfaces;
using UoW.BL.Services;
using UoW.DL.InMemoryDB;
using UoW.Extensions;
using UoW.Models.Common;
using UoW.Models.Identity;

namespace UoW
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
			InMemoryDb.Init();

			var jwtSettings = new JwtSettings();
			Configuration.Bind(nameof(jwtSettings), jwtSettings);
			services.AddSingleton(jwtSettings);

			services.Configure<MongoDbConfiguration>(Configuration.GetSection(nameof(MongoDbConfiguration)));

			var mongoSettings = Configuration.GetSection(nameof(MongoDbConfiguration)).Get<MongoDbConfiguration>();

			services.AddScoped<IIdentityService, IdentityService>();

			services.AddIdentity<ApplicationUser, ApplicationRole>()
				.AddMongoDbStores<ApplicationUser, ApplicationRole, Guid>(mongoSettings.ConnectionString, mongoSettings.DatabaseName)
				.AddSignInManager()
				.AddDefaultTokenProviders();

			services.AddHealthChecks();
			services.AddUoWServices();
			services.AddUoWRepositories();

			services.AddAutoMapper(typeof(Startup));

			services.AddSingleton(Log.Logger);

			services.AddAuthentication(op =>
			{
				op.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				op.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
				op.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

			})
				.AddJwtBearer(x =>
				{
					x.SaveToken = true;
					x.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
						ValidateIssuer = false,
						RequireExpirationTime = false,
						ValidateLifetime = true,
						ValidateAudience = false
					};
				});

			services.AddAuthorization(options =>
			{
				options.AddPolicy("ViewUserPositions", p => p.RequireAuthenticatedUser().RequireClaim("View"));
			});


			services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());

			// Register the Swagger generator, defining 1 or more Swagger documents
			services.AddSwaggerConfiguration();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger logger)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.ConfigureExceptionHandler(logger);

			// Enable middleware to serve generated Swagger as a JSON endpoint.
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "UoW API V1");
			});

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();
			app.UseAuthentication();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapHealthChecks("/health");
			});
		}
	}
}
