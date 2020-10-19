using UoW.BL.Interface.Tasks;
using UoW.DL.Interfaces.Users;
using UoW.Models.Tasks;

namespace UoW.BL.Services.Tasks
{
    public class SprintService : ISprintService
    {
        ISprintRepository _sprintRepository;
        public SprintService(ISprintRepository sprintRepository)
        {
            _sprintRepository = sprintRepository;
        }

        public Sprint GetSprintById(int id)
        {
            return _sprintRepository.GetById(id);
        }
    }
}
