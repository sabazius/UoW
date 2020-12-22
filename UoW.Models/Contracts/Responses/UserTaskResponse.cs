using System;
using System.Collections.Generic;
using System.Text;

namespace UoW.Models.Contracts.Responses
{
    public class UserTaskResponse
    {
        public int OwnerId { get; set; }
        public int AssignedToUserID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StoryId { get; set; }
        public TimeSpan TimeSpend { get; set; }
        public int TaskType { get; set; }
    }
}
