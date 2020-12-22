using System;
using System.Collections.Generic;
using System.Text;

namespace UoW.Models.Contracts.Requests
{
    public class FacultyRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortName { get; set; }
    }
}
