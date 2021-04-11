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
    public class SliderController : ControllerBase
    {
        private ISliderService service;
        

        public SliderController(ISliderService _service)
        {
            service = _service;            
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            var sliders = service.GetAll(x=>x.isActive==true).Data;           
            return Ok(sliders);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetSliderById(int id)
        {
            var menu = service.Get(x => x.Id == id).Data;
            if (menu!=null)
            {
                return Ok(menu);                
            }            
            return NotFound();            
        }

        [HttpPost]
        public IActionResult Post([FromBody]Slider data)
        {
            var createSlider = service.Add(data);            
            return CreatedAtAction("Get", new { id = createSlider.Data.Id }, createSlider);            
        }
             
        [HttpPost]
        [Route("[action]")]
        public IActionResult Update([FromBody]Slider data)
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
