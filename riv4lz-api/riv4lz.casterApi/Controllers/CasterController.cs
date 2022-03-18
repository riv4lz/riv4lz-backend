using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using riv4lz.core.IServices;
using riv4lz.core.Models;

namespace riv4lz.casterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasterController : ControllerBase
    {
        private readonly ICasterService _casterService;

        public CasterController(ICasterService casterService)
        {
            if (casterService == null)
            {
                throw new InvalidDataException("Constructor must have a CasterService");
            }

            _casterService = casterService;
        }
        
        [HttpGet]
        public ActionResult<List<Caster>> GetAll()
        {
            return _casterService.GetCasters();
        }
    }
}
