using System;
using System.Collections.Generic;
using System.Text;

namespace UoW.Models.Contracts.Requests
{
    public  class TeamRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public int FacultyID { get; set; }
    }
}
