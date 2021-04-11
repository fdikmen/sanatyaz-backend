using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using proje.Business.Abstract;
using proje.Entities;
using System.Threading.Tasks;

namespace proje.API.Controllers
{
    //[EnableCors("AllowOrigin")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ConstantController : ControllerBase
    {
        private IConstantService service;
        public ConstantController(IConstantService _service)
        {
            service = _service;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            var constants = service.GetAll().Data;
            return Ok(constants);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        [AllowAnonymous]
        public IActionResult GetConstantById(int id)
        {
            var comment = service.Get(x => x.Id == id).Data;
            if (comment != null)
            {
                return Ok(comment);
            }
            return NotFound();
        }

        [HttpPost]        
        public IActionResult Post([FromBody]Constant data)
        {
            var createdConstant = service.Add(data);
            return CreatedAtAction("Get", new { id = createdConstant.Data.Id }, createdConstant);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Update([FromBody]Constant data)
        {
            if (service.Get(x => x.Id == data.Id) != null)
            {
                return Ok(service.Update(data));
            }
            return NotFound();
        }
    }
}
