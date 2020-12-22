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

		public async Task<Faculty> UpdateFaculty(int facultyId, string name, string shortName, string description)
		{
            var faculty = await _facultyService.GetById(facultyId);

            if (faculty == null)
            {
                return null;
            }

            if (name != faculty.Name)
            {
                var validName = await _facultyService.GetByName(name) == null;

                if (!validName)
                {
                    return null;
                }
                faculty.Name = name;
            }

            faculty.ShortName = shortName;
            faculty.Description = description;

            var result = await _facultyService.Update(faculty);

            return result;
        }
		
	}
}
