using UoW.BL.Interfaces.Tasks;
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

        public Sprint Create(Sprint sprint)
        {
            _sprintRepository.Create(sprint);

            return _sprintRepository.GetById(sprint.Id);
        }

        public void Delete(int userId)
        {
            _sprintRepository.Delete(userId);
        }

        public Sprint GetSprintById(int id)
        {
            return _sprintRepository.GetById(id);
        }

        public Sprint Update(Sprint sprint)
        {
            _sprintRepository.Update(sprint);

            return _sprintRepository.GetById(sprint.Id);
        }
    }
}
