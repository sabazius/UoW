using System;
using System.Collections.Generic;
using System.Text;
using UoW.BL.Interfaces.Tasks;
using UoW.DL.Interfaces.Users;
using UoW.Models.Tasks;

namespace UoW.BL.Services.Tasks
{
    public class StoryService : IStoryService
    {
        IStoryRepository _storyRepository;
        public StoryService(IStoryRepository storyRepository)
        {
            _storyRepository = storyRepository;
        }

       public Story GetStoryById(int id)
        {
            return _storyRepository.GetById(id);
        }
    }
}
