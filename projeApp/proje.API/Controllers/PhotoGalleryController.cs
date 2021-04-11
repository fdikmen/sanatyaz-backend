using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proje.Business.Abstract;
using proje.Entities;

namespace proje.API.Controllers
{
    //[EnableCors("AllowOrigin")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoGalleryController : ControllerBase
    {
        private IPhotoGalleryService service;
        public PhotoGalleryController(IPhotoGalleryService _service)
        {
            service = _service;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            var photoGalleries = service.GetAll().Data;
            return Ok(photoGalleries);
        }
        [HttpGet]
        [Route("[action]/{id}")]
        [AllowAnonymous]
        public IActionResult GetPhotoGallertById(int id)
        {
            var photoGallery = service.Get(x => x.Id == id).Data;
            if (photoGallery != null)
            {
                return Ok(photoGallery);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post(PhotoGallery data)
        {
            data.isActive = true;
            var createdAbout = service.Add(data);
            return CreatedAtAction("Get", new { id = createdAbout.Data.Id }, createdAbout);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update([FromBody] PhotoGallery data)
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
