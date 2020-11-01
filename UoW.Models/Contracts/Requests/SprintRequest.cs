using System;

namespace UoW.Models.Contracts.Requests
{
    public class SprintRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TeamID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Duration { get; set; }
    }
}
