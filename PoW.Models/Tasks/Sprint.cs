using System;

namespace PoW.Models.Tasks
{
    public class Sprint : BaseTask
    {
        public int TeamID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Duration { get; set; }
    }
}
