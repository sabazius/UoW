using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
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
			services.AddSingleton<IIndentityService, IndentityService>();
		}

		public static void AddUoWRepositories(this IServiceCollection services)
		{
			services.AddSingleton<IProjectRepository, ProjectRepository>();
			services.AddSingleton<ITeamRepository, TeamRepository>();
			services.AddSingleton<IUserRepository, UserRepository>();
			services.AddSingleton<ISprintRepository, SprintRepository>();
			services.AddSingleton<ILectorRepository, LectorRepository>();
			services.AddSingleton<IFacultyRepository, FacultyRepository>();
			services.AddSingleton<IStoryRepository, StoryRepository>();
			services.AddSingleton<ISpecialityRepository, SpecialtyMongoRepository>();
			services.AddSingleton<IUserPositionRepository, UserPositionMongoRepository>();
		}

		public static void AddSwaggerConfiguration(this IServiceCollection services)
		{
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
	}
}
