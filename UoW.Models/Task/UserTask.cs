using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace UoW.Models.Task
{
    public class UserTask

    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Describtion { get; set; }
        public int OwnerID { get; set; }
        public int AssignedToUserID { get; set; }
        public DateTime DateAndTime { get; set; }
        public DateTime EndTime { get; set; }
        public int StoryID { get; set; }
        public DateTime TimeSpend { get; set; }
        public int TaskType { get; set; }


    }
}
