using System;
using UoW.Models.Tasks;

namespace UoW.Models.Contracts.Responses
{
	public class UserTaskResponse
    {
        public int OwnerId { get; set; }
        public int AssignedToUserID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StoryId { get; set; }
        public int MinutesSpended { get; set; }
        public int TaskType { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
