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

        public Faculty GetFacultyById(int id)
        {
            return _facultyService.GetById(id);
        }
    }
}
