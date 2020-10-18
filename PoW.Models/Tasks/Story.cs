using System;

namespace PoW.Models.Tasks
{
    public class Story : BaseTask
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ProjectId { get; set; }
    }
}
