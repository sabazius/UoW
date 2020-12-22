using UoW.DL.Interfaces.Users;
using UoW.DL.Repositories.Users;
using UoW.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;
using UoW.BL.Interface.User;
using System.Threading.Tasks;

namespace UoW.BL.Services.User
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<Team> Create(Team team)
        {
            return await _teamRepository.Create(team);
        }

        public async Task Delete(int teamId)
        {
            await _teamRepository.Delete(teamId);
        }

        public async Task<IEnumerable<Team>> GetAll()
        {
            return await _teamRepository.GetAll();
        }

        public async Task<Team> GetTeamById(int id)
        {
            return await _teamRepository.GetTeamById(id);
        }

        public async Task<Team> Update(Team team)
        {
            return await _teamRepository.Update(team);
        }

        public async Task<Team> UpdateFacultyID(int facultyId, int teamId)
        {
            var lector = await _teamRepository.GetById(teamId);

            if (lector == null)
                return null;

            var faculty = await _facultyRepository.GetById(facultyId);

            if (faculty == null)
                return null;

            lector.FacultyId = facultyId;

            var result = await _lectorRepository.Update(lector);

            return result;
        }

        public Task<Team> UpdateName(string name, int teamId)
        {
            throw new NotImplementedException();
        }
    }
}
