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
        public CasterController()
        {
            
        }
        
        [HttpGet]
        public ActionResult<List<Caster>> GetAll()
        {
            return null;
        }
    }
}
