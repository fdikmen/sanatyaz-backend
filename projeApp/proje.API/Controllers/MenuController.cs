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
    public class MenuController : ControllerBase
    {
        private IMenuService service;
        
        public MenuController(IMenuService _service)
        {
            service = _service;            
        }

        /// <summary>
        /// Get All Menus
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            //var menus = service.GetAll().Data;          
            //return Ok(menus);
            var menus = service.GetAllMenu();
            return Ok(menus);
        }

        /// <summary>
        /// Get Menu By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet()]
        [Route("[action]/{id}")]
        [AllowAnonymous]
        public IActionResult GetMenuById(int id)
        {
            var menu = service.Get(x => x.Id == id).Data;
            if (menu != null)
            {
                return Ok(menu);
            }
            return NotFound();
        }       
        
        /// <summary>
        /// Create an Menu
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Menu data)
        {
            data.isActive = true;
            var createdMenu = service.Add(data);
            return CreatedAtAction("Get", new { id = createdMenu.Data.Id }, createdMenu);
        }

        /// <summary>
        /// Update the Menu
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult Update([FromBody] Menu data)
        {
            if (service.Get(x => x.Id == data.Id) != null)
            {
                data.isActive = true;
                return Ok(service.Update(data));
            }
            return NotFound();
        }

        /// <summary>
        /// Delete the Menu
        /// </summary>
        /// <param name="id"></param>
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

        [HttpGet]
        [AllowAnonymous]
        [Route("[action]")]
        public async Task<IActionResult> GetMainMenu()
        {
            var mainMenu = service.GetAll(x => x.mainMenu == null && x.isDelete == false).Data;
            return Ok(mainMenu);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("[action]")]
        public async Task<IActionResult> GetHomepage()
        {
            var getHomepage = service.GetAll(x => x.GetHomepage == true && x.isDelete == false && x.isActive==true).Data;
            return Ok(getHomepage);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("[action]")]
        public async Task<IActionResult> GetSubmenu()
        {
            var kayıt = service.GetAll(x => x.subMenu == true);
            return Ok(kayıt);
        }

    }
}
