using System;
using System.Collections.Generic;
using System.Text;

namespace UoW.Models.Contracts.Responses
{
    public class LectorResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateStarted { get; set; }
    }
}
