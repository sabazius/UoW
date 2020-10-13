using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using UoW.Models.User;

namespace UoW.Models.Tasks
{
    
   public class Project
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductOwnerID { get; set; }

    }
}
