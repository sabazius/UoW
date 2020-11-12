using System.Threading.Tasks;
using UoW.BL.Interfaces.Users;
using UoW.DL.Interfaces.Users;
using UoW.Models.Users;

namespace UoW.BL.Services.Users
{
    public class FacultyService : IFacultyService
    {
        IFacultyRepository _facultyService;

        public FacultyService(IFacultyRepository facultyService) 
        {
            _facultyService = facultyService;
        }

		public async Task<Faculty> Create(Faculty user)
		{
			return await _facultyService.Create(user);
		}

		public async Task Delete(int facultyId)
		{
			await _facultyService.Delete(facultyId);
		}

		public async Task<Faculty> GetById(int facultyId)
		{
			return await _facultyService.GetById(facultyId);
		}

		public async Task<Faculty> GetFacultyById(int id)
        {
            return await _facultyService.GetById(id);
        }

		public async Task<Faculty> Update(Faculty user)
		{
			return await _facultyService.Update(user);
		}
	}
}
