using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using proje.Business.Abstract;
using proje.Entities;

namespace proje.API.Controllers
{
    //[EnableCors("AllowOrigin")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StatementController : ControllerBase
    {
        private IStatementService service;
        public StatementController(IStatementService _service)
        {
            service = _service;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            var statements = service.GetAll().Data;
            return Ok(statements);
        }
        [HttpGet]
        [Route("[action]/{id}")]
        [AllowAnonymous]
        public IActionResult GetStatementById(int id)
        {
            var statement = service.Get(x => x.Id == id).Data;
            if (statement != null)
            {
                return Ok(statement);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post(Statement data)
        {
            var createdAbout = service.Add(data);
            return CreatedAtAction("Get", new { id = createdAbout.Data.Id }, createdAbout);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update([FromBody] Statement data)
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
