using System.Collections.Generic;

namespace UoW.Models.Contracts.Responses
{
	public class AuthFailedResponse
	{
		public IEnumerable<string> Errors { get; set; }
	}
}
