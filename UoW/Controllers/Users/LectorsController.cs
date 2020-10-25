using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UoW.BL.Services.Users;
using UoW.Models.Users;

namespace UoW.Controllers.Users
{
    public class LectorsController : ControllerBase
    {
        public LectorService _lectorController;

        public LectorsController(LectorService lectorController)
        {
            _lectorController = lectorController;
        }

        [HttpGet]
        public Lector GetById(int id)
        {
            return _lectorController.GetLectorId(id);
        }

    }
}
