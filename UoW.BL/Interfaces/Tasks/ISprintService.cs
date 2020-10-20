using System;
using System.Collections.Generic;
using System.Text;
using UoW.Models.Tasks;

namespace UoW.BL.Interfaces.Tasks
{
    public interface ISprintService
    {
        Sprint GetSprintById(int id);
    }
}
