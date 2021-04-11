using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using proje.Business.Abstract;
using proje.Entities;

namespace proje.API.Controllers
{
    [Authorize]
    //[EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private IFormService service;
        public FormController(IFormService _service)
        {
            service = _service;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            var forms = service.GetAllForm();
            return Ok(forms);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetFormById(int id)
        {
            var form = service.Get(x => x.Id == id);
            if (form != null)
            {
                return Ok(form);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post(Form data)
        {
            //data.isActive = true;
            var createdForm = service.Add(data);
            return CreatedAtAction("Get", new { id = createdForm.Data.Id }, createdForm);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update([FromBody] Form data)
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
