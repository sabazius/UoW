using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UoW.DL.Interfaces.Users;
using UoW.Models.Common;
using UoW.Models.Tasks;

namespace UoW.DL.Repositories.MongoDB.Tasks
{
    public class ProjectMongoRepository : IProjectRepository
    {
        private readonly IMongoCollection<Project> _projects;

        public ProjectMongoRepository(IOptions<MongoDbConfiguration> config)
        {
            var client = new MongoClient(config.Value.ConnectionString);
            var database = client.GetDatabase(config.Value.DatabaseName);

            _projects = database.GetCollection<Project>("Project");
        }

        public async Task<Project> Create(Project project)
        {
            await _projects.InsertOneAsync(project);
            return project;
        }
        public async Task Delete(int projectId)
        {
            await _projects.DeleteOneAsync(p => p.Id == projectId);
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            var result = await _projects.FindAsync(p => true);

            return result.ToEnumerable();
        }

        public async Task<Project> GetById(int projectId)
        {
            var result = await _projects.FindAsync(p => p.Id == projectId);

            return result.FirstOrDefault();
        }

        public async Task<Project> GetByName(string name)
        {
            var result = await _projects.FindAsync(p => p.Name == name);

            return result.FirstOrDefault();
        }

        public async Task<Project> Update(Project project)
        {
            await _projects.ReplaceOneAsync(p => p.Id == project.Id, project);

            return project;
        }
    }
}
