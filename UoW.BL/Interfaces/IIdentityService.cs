using System.Threading.Tasks;
using UoW.Models.Common;

namespace UoW.BL.Interfaces
{
	public interface IIdentityService
	{
		Task<AuthenticationResult> RegisterAsync(string userName, string password);
		Task<AuthenticationResult> LoginAsync(string userName, string password);
	}
}
