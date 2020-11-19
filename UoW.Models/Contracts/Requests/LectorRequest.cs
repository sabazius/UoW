using System;

namespace UoW.Models.Contracts.Requests
{
    public class LectorRequest
    {   
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateStarted { get; set; }
        public int FacultyId { get; set; }
    }
}
