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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactController : ControllerBase
    {
        private IContactService service;
        public ContactController(IContactService _service)
        {
            service = _service;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            var contacts = service.GetAll().Data;
            return Ok(contacts);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        [AllowAnonymous]
        public IActionResult GetContactById(int id)
        {
            var contact = service.Get(x => x.Id == id).Data;
            if (contact !=null)
            {
                return Ok(contact);
            }
            return NotFound();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody]Contact contact)
        {
            var createContact = service.Add(contact);
            return CreatedAtAction("Get", new { id=createContact.Data.Id }, createContact);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update([FromBody]Contact contact)
        {
            if (service.Get(x => x.Id == contact.Id) != null)
            {
                return Ok(service.Update(contact));
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
