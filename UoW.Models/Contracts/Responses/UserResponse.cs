using System;
using System.Collections.Generic;
using System.Text;

namespace UoW.Models.Contracts.Responses
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeamID { get; set; }
        public int FacultylID { get; set; }
        public string Email { get; set; }

        public int UserPositionId { get; set; }
    }
}
