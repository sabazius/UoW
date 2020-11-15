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

			services.Configure<MongoDbConfiguration>(Configuration.GetSection(nameof(MongoDbConfiguration)));

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

			services.AddControllers()
				.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>()); 
			// Register the Swagger generator, defining 1 or more Swagger documents
			services.AddSwaggerGen();
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
			});
		}
	}
}
