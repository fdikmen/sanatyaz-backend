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
    public class PopupController : ControllerBase
    {
        private IPopupService service;
        
        public PopupController(IPopupService _service)
        {
            service = _service;            
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            var popups = service.GetAll().Data;            
            return Ok(popups);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetPopupById(int id)
        {
            var popup = service.Get(x => x.Id == id).Data;
            if (popup != null)
            {
                return Ok(popup);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post(Popup data)
        {
            data.isActive = true;
            var createdPopup = service.Add(data);
            return CreatedAtAction("Get", new { id = createdPopup.Data.Id }, createdPopup);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update([FromBody]Popup data)
        {
            if (service.Get(x => x.Id == data.Id) != null)
            {
                data.isActive = true;
                return Ok(service.Update(data));
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
