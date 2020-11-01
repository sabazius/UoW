using System;

namespace UoW.Models.Tasks
{
    public class Project : BaseTask
    {
        public int OwnerId { get; set; }
        public int TeamId { get; set; }
        public TimeSpan TimeSpended { get; set; }
    }
}
