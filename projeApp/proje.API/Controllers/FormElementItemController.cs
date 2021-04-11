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
    public class FormElementItemController : ControllerBase
    {
        private IFormElementItemService service;
        public FormElementItemController(IFormElementItemService _service)
        {
            service = _service;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            var formElementItems = service.GetAll().Data;
            return Ok(formElementItems);
        }
        [HttpGet]
        [Route("[action]/{id}")]
        [AllowAnonymous]
        public IActionResult GetFormElementItemById(int id)
        {
            var formElementItem = service.Get(x => x.Id == id).Data;
            if (formElementItem != null)
            {
                return Ok(formElementItem);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post(FormElementItem data)
        {
            var createdFormElementItem = service.Add(data);
            return CreatedAtAction("Get", new { id = createdFormElementItem.Data.Id }, createdFormElementItem);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update([FromBody] FormElementItem data)
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
