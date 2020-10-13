using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using UoW.Models.Tasks;
using UoW.Models.User;

namespace TroubleT.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : Controller
    {
        public UserController()
        {

        }

        [HttpGet]
        public TaskTypes GetUser()
            
        {
            return new TaskTypes()
            {
                ID = 11,
                Description = "IKI",
                Name = "Petar"




                

 

           };
        }

    }
}
