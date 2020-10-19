using Microsoft.AspNetCore.Mvc;
using UoW.BL.Services.Users;

namespace UoW.Controllers
{
    [Route("specialties")]
    [ApiController]
    public class SpecialtyController : ControllerBase
    {
        private SpecialtyService _specialtyService;
        public SpecialtyController(SpecialtyService specialtyService)
        {
            specialtyService = _specialtyService;
        }
        

    }
}
