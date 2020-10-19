using PoW.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace UoW.BL.Interfaces.Users
{
    public interface ISpecialtyService
    {
        Speciality GetSpecialtyById(int id);
    }
}
