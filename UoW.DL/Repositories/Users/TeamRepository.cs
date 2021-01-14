using UoW.DL.InMemoryDB;
using UoW.DL.Interfaces.Users;
using UoW.Models.Users;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UoW.DL.Repositories.Users
{
    public class TeamRepository : ITeamRepository
    {
        private static List<Team> dbTable;

        public TeamRepository()
        {
            dbTable = InMemoryDb.Teams;
        }

        public Task<Team> Create(Team team)
        {
            dbTable.Add(team);
            return Task.FromResult(team);
        }

        public void Delete(int teamId)
        {
            var result = dbTable.FirstOrDefault(x => x.Id == teamId);
            if (result != null)
            {
                dbTable.Remove(result);
            }
        }

        public Task<IEnumerable<Team>> GetAll()
        {
            return Task.FromResult(dbTable.AsEnumerable());
        }

        public Task<Team> GetById(int teamId)
        {
            var result = dbTable.FirstOrDefault(x => x.Id == teamId);
            return Task.FromResult(result);
        }

        public Task<Team> Update(Team team)
        {
            var result = dbTable.FirstOrDefault(x => x.Id == team.Id);

            if (result != null)
            {
                Delete(team.Id);
                Create(team);

            }
            return Task.FromResult(team);
        }

        
    }
}
