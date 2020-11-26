using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using UoW.BL.Interface.User;
using UoW.BL.Interfaces.Tasks;
using UoW.BL.Interfaces.Users;
using UoW.BL.Services.Tasks;
using UoW.BL.Services.User;
using UoW.BL.Services.Users;
using UoW.DL.InMemoryDB;
using UoW.DL.Interfaces.Users;
using UoW.DL.Repositories;
using UoW.DL.Repositories.Tasks;
using UoW.DL.Repositories.Users;
using UoW.Extensions;
using AutoMapper;
using FluentValidation.AspNetCore;
using UoW.DL.Repositories.MongoDb.Users;
using UoW.Models.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using Microsoft.OpenApi.Models;

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

			services.AddHealthChecks();

			services.AddSingleton<IProjectRepository, ProjectRepository>();
			services.AddSingleton<IProjectService, ProjectService>();
			services.AddSingleton<ITeamRepository, TeamRepository>();
			services.AddSingleton<ITeamService, TeamService>();
			services.AddSingleton<IUserRepository, UserRepository>();
			services.AddSingleton<IUserService, UserService>();
			services.AddSingleton<ISpecialtyService, SpecialtyService>();
			services.AddSingleton<ISprintRepository, SprintRepository>();
			services.AddSingleton<ISprintService, SprintService>();
			services.AddSingleton<ILectorRepository, LectorRepository>();
			services.AddSingleton<ILectorService, LectorService>();
			services.AddSingleton<IFacultyRepository, FacultyRepository>();
			services.AddSingleton<IFacultyService, FacultyService>();
			services.AddSingleton<IStoryRepository, StoryRepository>();
			services.AddSingleton<IStoryService, StoryService>();
            services.AddSingleton<IUserPositionService, UserPositionService>();

			services.AddAutoMapper(typeof(Startup));

			services.AddSingleton(Log.Logger);

			services.AddSingleton<ISpecialityRepository, SpecialtyMongoRepository>();
			services.AddSingleton<IUserPositionRepository, UserPositionMongoRepository>();

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
						ValidateLifetime = true
					};
				});

			services.AddControllers()
				.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>()); 
			// Register the Swagger generator, defining 1 or more Swagger documents
			services.AddSwaggerGen(x =>
			{
				var sercurity = new Dictionary<string, IEnumerable<string>>
				{
					{"Bearer", new string[0] }
				};

				OpenApiSecurityScheme secutiryDefinition = new OpenApiSecurityScheme()
				{
					Name = "Bearer",
					BearerFormat = "JWT",
					Scheme = "bearer",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.Http,
					Description = "Authorization token"
				};

				x.AddSecurityDefinition("jwt", secutiryDefinition);
				x.AddSecurityRequirement(new OpenApiSecurityRequirement()
				{
					{secutiryDefinition, new string[] {} }
				});

			});
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

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapHealthChecks("/health");
			});
		}
	}
}
