using System.Collections.Generic;
using UoW.Models.Users;

namespace UoW.DL.Interfaces.Users
{
    public interface ISpecialityRepository
    {
    	void Create(Speciality user);
        void Delete(int userId);
        void Update(Speciality user);
        List<Speciality> GetAll();
        Speciality GetById(int userId);
        Speciality GetByName(string name);
    }
}
