﻿using System.Collections.Generic;
using UoW.Models.User;

namespace DAL.Interfaces
{
    public interface ISpecialtyRepository
    {
        void InsertSpecialty(Specialty specialty);
        void UpdateSpecialty(Specialty specialty);
        void DeleteSpecialty(Specialty specialty);
        IEnumerable<Specialty> GetAllSpecialties();
    }
}
