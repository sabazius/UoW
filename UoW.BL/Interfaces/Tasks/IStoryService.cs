using System;
using System.Collections.Generic;
using System.Text;
using UoW.Models.Tasks;

namespace UoW.BL.Interfaces.Tasks
{
    public interface IStoryService
    {
        Story GetStoryById(int storyId);
    }
}
