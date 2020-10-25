using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UoW.BL.Interfaces.Users;
using UoW.BL.Services.Users;
using UoW.DL.InMemoryDB;
using UoW.DL.Interfaces.Users;
using UoW.DL.Repositories.Users;

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

			services.AddSingleton<IUserRepository, UserRepository>();
			services.AddSingleton<IUserService, UserService>();
			services.AddSingleton<ISpecialityRepository, SpecialityRepository>();
			services.AddSingleton<ISpecialtyService, SpecialtyService>();
			services.AddSwaggerGen();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
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
