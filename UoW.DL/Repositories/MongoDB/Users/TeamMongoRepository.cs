using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UoW.DL.Interfaces.Users;
using UoW.Models.Users;

namespace UoW.DL.Repositories.MongoDB.Users
{
    class TeamMongoRepository : ITeamRepository
    {
        public Task<Team> Create(Team user)
        {
            throw new NotImplementedException();
        }

        public void Delete(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Team>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Team> GetById(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<Team> Update(Team user)
        {
            throw new NotImplementedException();
        }
    }
}
