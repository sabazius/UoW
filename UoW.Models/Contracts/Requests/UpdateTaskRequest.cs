using System;

namespace UoW.Models.Contracts.Requests
{
	public class UpdateTaskRequest
	{
		public int UserTaskID { get; set; }

		public int AssignedToUserId { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public int TaskType { get; set; }

		public string Description { get; set; }

		public string Name { get; set; }

		public int MinutesSpend { get; set; }
	}
}
