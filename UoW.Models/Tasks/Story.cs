using System;

namespace UoW.Models.Tasks
{
    public class Story : BaseTask
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ProjectId { get; set; }

        public int MinutesSpended { get; set; }

        public int SprintId { get; set; }
	}
}
