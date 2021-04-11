using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using proje.Business.Abstract;
using proje.Entities;
using System.Threading.Tasks;

namespace proje.API.Controllers
{
    //[EnableCors("AllowOrigin")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private IPromotionService service;        
        public PromotionController(IPromotionService _service)
        {
            service = _service;            
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            var promotions = service.GetAll().Data;
            return Ok(promotions);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPromotionById(int id)
        {
            var promotion = service.Get(x => x.Id == id).Data;
            if (promotion != null)
            {
                return Ok(promotion);
            }
            return NotFound();
        }
        
        [HttpPost]
        public IActionResult Post(Promotion data)
        {
            data.isActive = true;
            var createdPromotion = service.Add(data);
            return CreatedAtAction("Get", new { id = createdPromotion.Data.Id }, createdPromotion);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(Promotion data)
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
