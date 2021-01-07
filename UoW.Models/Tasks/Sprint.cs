﻿using System;

namespace UoW.Models.Tasks
{
    public class Sprint : BaseTask
    {
        public int TeamID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

		public TimeSpan TimeSpend { get; set; }
	}
}
