using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proje.Business.Abstract;
using proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proje.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FormArchiveController : ControllerBase
    {
        private IFormArchiveService service;
        public FormArchiveController(IFormArchiveService _service)
        {
            service = _service;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            var formArchives = service.GetAll().Data;
            return Ok(formArchives);
        }
        [HttpGet]
        [Route("[action]/{id}")]
        [AllowAnonymous]
        public IActionResult GetFormArchiveById(int id)
        {
            var formArchive = service.Get(x => x.Id == id).Data;
            if (formArchive != null)
            {
                return Ok(formArchive);
            }
            return NotFound();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post(FormArchive data)
        {            
            var createdFormArchive = service.Add(data);
            return CreatedAtAction("Get", new { id = createdFormArchive.Data.Id }, createdFormArchive);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update([FromBody] FormArchive data)
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
