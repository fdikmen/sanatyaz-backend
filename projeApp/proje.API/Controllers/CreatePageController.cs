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
    public class CreatePageController : ControllerBase
    {
        private ICreatePageService service;
        public CreatePageController(ICreatePageService _service)
        {
            service = _service;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            var createPages = service.GetAll().Data;
            return Ok(createPages);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetCreatePageById(int id)
        {
            var createPage = service.Get(x => x.Id == id).Data;
            if (createPage != null)
            {
                return Ok(createPage);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreatePage data)
        {
            var createPersonel = service.Add(data);
            return CreatedAtAction("Get", new { id = createPersonel.Data.Id }, createPersonel);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update([FromBody] CreatePage data)
        {
            if (service.Get(x => x.Id == data.Id) != null)
            {
                data.isActive = true;
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
        [HttpGet]
        [Route("[action]")]
        [AllowAnonymous]
        public IActionResult Active()
        {
            var aktifKayıt = service.GetAll(x => x.isActive == true).Data;
            if (aktifKayıt.Count != 0)
            {
                return Ok(aktifKayıt);
            }
            return NotFound("Aktif kayıt bulunamadı.");
        }
    }
}
