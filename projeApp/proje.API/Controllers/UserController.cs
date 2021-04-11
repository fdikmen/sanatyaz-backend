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
    public class UserController : ControllerBase
    {
        private IUserService service;        
        public UserController(IUserService _service)
        {
            service = _service;            
        }

        [HttpGet]
        
        public IActionResult Get()
        {           
            var users=service.GetAll().Data;
            return Ok(users);            
        }
        
        [HttpGet("{id}")]
        
        public IActionResult GetUserById(int id)
        {
            var user = service.Get(x => x.Id == id).Data;
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody]User data)
        {
            var createUser = service.Add(data);
            return CreatedAtAction("Get", new { id = createUser.Data.Id }, createUser);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Update([FromBody]User data)
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
        
        [HttpGet]
        [Route("[action]/{eMail}/{password}")]
        public async Task<IActionResult> Login(string eMail,string password)
        {
            var login = service.Get(x => x.EMail == eMail && x.Password == password);
            if (login != null)
            {
                return Ok(login);
            }
            return BadRequest("Kullanıcı veya şifre bilgileri hatalı!");
        }        
    }
}
