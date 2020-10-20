using Microsoft.AspNetCore.Mvc;
using UoW.BL.Interfaces.Users;
using UoW.BL.Services.Users;

namespace UoW.Controllers
{
    [Route("specialties")]
    [ApiController]
    public class SpecialtyController : ControllerBase
    {
        private ISpecialtyService _specialtyService;

        public SpecialtyController(ISpecialtyService specialtyService)
        {
            specialtyService = _specialtyService;
        }
        

    }
}
