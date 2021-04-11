using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using proje.Business.Abstract;
using proje.Entities;
using System.Threading.Tasks;

namespace proje.API.Controllers
{
    //[EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BlogController : ControllerBase
    {
        private IBlogService service;

        public BlogController(IBlogService _service)
        {
            service = _service;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            var blogs = service.GetAllBlog();
            return Ok(blogs);
        }


        [HttpGet()]
        [Route("[action]/{id}")]
        [AllowAnonymous]
        public IActionResult GetBlogById(int id)
        {
            var blog = service.Get(x => x.Id == id).Data;
            if (blog != null)
            {
                return Ok(blog);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Blog data)
        {
            data.isActive = true;
            var createdAbout = service.Add(data);
            return CreatedAtAction("Get", new { id = createdAbout.Data.Id }, createdAbout);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update([FromBody] Blog data)
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
        public async Task<IActionResult> Active()
        {
            var aktifKayıt = service.GetAll(x => x.isActive == true).Data;
            if (aktifKayıt.Count != 0)
            {
                return Ok(aktifKayıt);
            }
            return NotFound("Aktif kayıt bulunamadı.");
        }
        [HttpGet]
        [Route("[action]")]
        [AllowAnonymous]
        public IActionResult GetHomepage()
        {
            var blogs = service.GetAll(x => x.isActive == true && x.GetHomepage == true && x.isDelete==false).Data;
            return Ok(blogs);
        }
    }
}
