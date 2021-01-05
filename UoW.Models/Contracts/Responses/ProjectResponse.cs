using System;
using System.Collections.Generic;
using System.Text;
using UoW.Models.Tasks;

namespace UoW.Models.Contracts.Responses
{
    public class ProjectResponse : BaseTask
    {
        public int OwnerId { get; set; }
        public int TeamId { get; set; }
        public TimeSpan TimeSpended { get; set; }
    }
}
