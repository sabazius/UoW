using System;
using System.Collections.Generic;
using System.Text;

namespace UoW.Models.Contracts.Responses
{
    public class SpecialtyResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int FacultyId { get; set; }
        public int LectorId { get; set; }
    }
}
