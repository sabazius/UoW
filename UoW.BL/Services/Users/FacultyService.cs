using UoW.BL.Interfaces.Users;
using UoW.Models.Users;

namespace UoW.BL.Services.Users
{
    public class FacultyService : IFacultyService
    {
        IFacultyService _facultyService;

        public FacultyService() 
        { 
        }

        public Faculty GetFacultyById(int id)
        {
            return _facultyService.GetFacultyById(id);
        }
    }
}
