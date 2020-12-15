using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using UoW.BL.Interface.User;
using UoW.BL.Interfaces;
using UoW.BL.Interfaces.Tasks;
using UoW.BL.Interfaces.Users;
using UoW.BL.Services;
using UoW.BL.Services.Tasks;
using UoW.BL.Services.User;
using UoW.BL.Services.Users;
using UoW.DL.Interfaces.Users;
using UoW.DL.Repositories;
using UoW.DL.Repositories.MongoDb.Users;
using UoW.DL.Repositories.MongoDB.Users;
using UoW.DL.Repositories.Tasks;
using UoW.DL.Repositories.Users;

namespace UoW.Extensions
{
	public static class ServiceConfiguration
	{
		public static void AddUoWServices(this IServiceCollection services)
		{
			services.AddSingleton<IProjectService, ProjectService>();
			services.AddSingleton<ITeamService, TeamService>();
			services.AddSingleton<IUserService, UserService>();
			services.AddSingleton<ISpecialtyService, SpecialtyService>();
			services.AddSingleton<ISprintService, SprintService>();
			services.AddSingleton<ILectorService, LectorService>();
			services.AddSingleton<IFacultyService, FacultyService>();
			services.AddSingleton<IStoryService, StoryService>();
			services.AddSingleton<IUserPositionService, UserPositionService>();
		}

		public static void AddUoWRepositories(this IServiceCollection services)
		{
			services.AddSingleton<IProjectRepository, ProjectRepository>();
			services.AddSingleton<ITeamRepository, TeamRepository>();
			services.AddSingleton<IUserRepository, UserRepository>();
			services.AddSingleton<ISprintRepository, SprintRepository>();
			services.AddSingleton<ILectorRepository, LectorMongoRepository>();
			services.AddSingleton<IFacultyRepository, FacultyRepository>();
			services.AddSingleton<IStoryRepository, StoryRepository>();
			services.AddSingleton<ISpecialityRepository, SpecialtyMongoRepository>();
			services.AddSingleton<IUserPositionRepository, UserPositionMongoRepository>();
		}

		public static void AddSwaggerConfiguration(this IServiceCollection services)
		{
			services.AddSwaggerGen(x =>
			{
				// Include 'SecurityScheme' to use JWT Authentication
				var jwtSecurityScheme = new OpenApiSecurityScheme
				{
					Scheme = "bearer",
					BearerFormat = "JWT",
					Name = "JWT Authentication",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.Http,
					Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

					Reference = new OpenApiReference
					{
						Id = JwtBearerDefaults.AuthenticationScheme,
						Type = ReferenceType.SecurityScheme
					}
				};

				x.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

				x.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{ jwtSecurityScheme, Array.Empty<string>() }
				});
			});
		}
	}
}
