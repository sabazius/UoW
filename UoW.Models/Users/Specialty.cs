using System;
using System.Collections.Generic;
using System.Text;

namespace UoW.Models.User
{
    public class Specialty
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int FacultyID { get; set; }
        public int LectorID { get; set; }
    }
}
