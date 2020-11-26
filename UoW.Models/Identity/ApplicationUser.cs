using AspNetCore.Identity.MongoDbCore.Models;
using System;

namespace UoW.Models.Identity
{
	public class ApplicationUser : MongoIdentityUser<Guid>
	{
		public ApplicationUser() : base()
		{
		}

		public ApplicationUser(string userName, string password) : base (userName, password)
		{
		}

		public string Name { get; set; }

		public string LastName { get; set; }

		public DateTime? BirthDay { get; set; }

		public string Country { get; set; }

		public string City { get; set; }
	}
}
