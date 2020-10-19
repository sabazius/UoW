using UoW.DL.InMemoryDB;
using UoW.DL.Interfaces.Users;
using UoW.Models.Users;
using System.Collections.Generic;
using System.Linq;

namespace UoW.DL.Repositories.Users
{
    public class TeamRepository : ITeamRepository
    {
        private static List<Team> dbTable;

        public TeamRepository()
        {
            dbTable = InMemoryDb.Teams;
        }

        public void Create(Team team)
        {
            dbTable.Add(team);
        }

        public void Delete(int teamId)
        {
            var result = dbTable.FirstOrDefault(x => x.Id == teamId);
            if (result != null)
            {
                dbTable.Remove(result);
            }
        }

        public Team GetById(int teamId)
        {
            return dbTable.FirstOrDefault(x => x.Id == teamId);
        }

        public void Update(Team team)
        {
            var result = dbTable.FirstOrDefault(x => x.Id == team.Id);
            if (result != null)
            {
                Delete(result.Id);
                Create(team);
            }
        }
    }
}
