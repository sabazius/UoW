using System;
using System.Collections.Generic;
using System.Text;

namespace UoW.Models.Tasks
{
    public class Story
    {
        public int ID { get; set};
        public string Description { get; set};
        public string Name { get; set};
        public DateTime StartDate { get; set};
        public DateTime EndDate { get; set};
        public int ProjectID { get; set};
    }
}
