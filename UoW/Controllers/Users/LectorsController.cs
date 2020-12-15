using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UoW.BL.Interfaces.Users;
using UoW.Models.Contracts.Requests;
using UoW.Models.Contracts.Responses;
using UoW.Models.Users;

namespace UoW.Controllers.Users
{
    
    public class LectorsController : ControllerBase
    {
        public ILectorService _lectorService;

        private IMapper _mapper;

        public LectorsController(ILectorService lectorService, IMapper mapper)
        {
            _lectorService = lectorService;
            _mapper = mapper;
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody]LectorRequest request)
        {
            var result = await _lectorService.Update(_mapper.Map<Lector>(request));

            if (result == null) return NotFound();

            var lector = _mapper.Map<LectorResponse>(result);

            return Ok(lector);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody]LectorRequest request)
        {
            var result = await _lectorService.Create(_mapper.Map<Lector>(request));

            if (result == null) return NotFound();

            var lector = _mapper.Map<LectorResponse>(result);

            return Ok(lector);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _lectorService.GetAll();

            if (result == null) return NotFound();

            var lectors = _mapper.Map<IEnumerable<LectorResponse>>(result);

            return Ok(lectors);

        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _lectorService.GetById(id);

            if (result == null) return NotFound();

            var lector = _mapper.Map<LectorResponse>(result);

            return Ok(lector);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _lectorService.Delete(id);
            return Ok();
        }

    }
}
