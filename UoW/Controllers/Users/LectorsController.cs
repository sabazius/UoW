using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UoW.BL.Interfaces.Users;
using UoW.Models.Users;

namespace UoW.Controllers.Users
{
    public class LectorsController : ControllerBase
    {
        public ILectorService _lectorController;

        public LectorsController(ILectorService lectorController)
        {
            _lectorController = lectorController;
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(Lector lector)
        {
            var result = await _lectorController.Update(lector);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _lectorController.GetAll();

            if (result == null) return NotFound();

            return Ok(result);

        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _lectorController.GetById(id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _lectorController.Delete(id);
            return Ok();
        }
    }
}
