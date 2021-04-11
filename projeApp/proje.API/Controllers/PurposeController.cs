using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proje.Business.Abstract;
using proje.Entities;

namespace proje.API.Controllers
{
    //[EnableCors("AllowOrigin")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PurposeController : ControllerBase
    {
        private IPurposeService service;
        public PurposeController(IPurposeService _service)
        {
            service = _service;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            var purposes = service.GetAll().Data;
            return Ok(purposes);
        }
        [HttpGet]
        [Route("[action]/{id}")]
        [AllowAnonymous]
        public IActionResult GetPurposeById(int id)
        {
            var purpose = service.Get(x => x.Id == id).Data;
            if (purpose != null)
            {
                return Ok(purpose);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post(Purpose data)
        {
            var createdAbout = service.Add(data);
            return CreatedAtAction("Get", new { id = createdAbout.Data.Id }, createdAbout);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update([FromBody] Purpose data)
        {
            if (service.Get(x => x.Id == data.Id) != null)
            { 
                return Ok(service.Update(data));
            }
            return NotFound();
        }
        [HttpPost]
        [Route("[action]/{id}")]
        public IActionResult Delete(int id)
        {
            if (service.Get(x => x.Id == id) != null)
            {
                service.SoftDelete(id);
                return Ok();
            }
            return NotFound();
        }
                
    }
}

