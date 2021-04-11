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
    public class CategoryController : ControllerBase
    {
        private ICategoryService service;
        public CategoryController(ICategoryService _service)
        {
            service = _service;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var categories = service.GetAll().Data;
            return Ok(categories);
            //if (categories != null)
            //{
                
            //}
            //return NotFound("Kayıt yok.");
        }
        [HttpGet]
        [Route("[action]/{id}")]
        [AllowAnonymous]
        public IActionResult GetCategoryById(int id)
        {
            var category = service.Get(x => x.Id == id).Data;
            if(category != null)
            {
                return Ok(category);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Post([FromBody]Category data)
        {
            data.isActive = true;
            var createdCategory = service.Add(data);
            return CreatedAtAction("Get", new { id = createdCategory.Data.Id }, createdCategory);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Update([FromBody]Category data)
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
