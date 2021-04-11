using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using proje.Business.Abstract;
using proje.Entities;
using System.Threading.Tasks;

namespace proje.API.Controllers
{
    [Authorize]
    //[EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private ICommentService service;
        
        public CommentController(ICommentService _service)
        {
            service = _service;           
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var comments = service.GetAll().Data;
            return Ok(comments);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var comment = service.Get(x => x.Id == id).Data;
            if (comment != null)
            {
                return Ok(comment);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Comment data)
        {           
            var createdComment = service.Add(data);
            return CreatedAtAction("Get", new { id = createdComment.Data.Id }, createdComment);
        }        

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Update([FromBody]Comment data) 
        {
            if (service.Get(x => x.Id == data.Id) != null)
            {                
                return Ok(service.Update(data));
            }
            return NotFound();
        }

        [HttpPost]
        [Route("[action]/{id}")]
        public async Task<IActionResult> Delete(int id)
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
