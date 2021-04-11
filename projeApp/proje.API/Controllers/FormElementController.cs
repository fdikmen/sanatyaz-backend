using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proje.Business.Abstract;
using proje.Entities;

namespace proje.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FormElementController : ControllerBase
    {
        private IFormElementService service;
        public FormElementController(IFormElementService _service)
        {
            service = _service;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            var formElements = service.GetAllFormElement();
            return Ok(formElements);
        }
        [HttpGet]
        [Route("[action]/{id}")]
        [AllowAnonymous]
        public IActionResult GetFormElementById(int id)
        {
            var formElement = service.Get(x => x.Id == id).Data;
            if (formElement != null)
            {
                return Ok(formElement);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post(FormElement data)
        {
            data.isActive = true;
            var createdAbout = service.Add(data);
            return CreatedAtAction("Get", new { id = createdAbout.Data.Id }, createdAbout);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update([FromBody] FormElement data)
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

        [AllowAnonymous]
        [HttpGet]
        [Route("[action]")]
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
