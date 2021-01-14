using System;
using System.Collections.Generic;
using System.Text;
using UoW.Models.Tasks;

namespace UoW.Models.Contracts.Requests
{
    public class ProjectRequest : BaseTask
    {
        public int OwnerId { get; set; }
        public int TeamId { get; set; }
        public TimeSpan TimeSpended { get; set; }
    }
}
