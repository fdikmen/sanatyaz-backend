using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proje.Business.Abstract;
using proje.Entities;

namespace proje.UI.Controllers
{
    public class AdminController : Controller
    {
        IAdminService service;
        public AdminController(IAdminService _service)
        {
            service = _service;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return View();
            }            
            return RedirectToAction("Index", "Menu");
        }

        [HttpPost]
        public IActionResult Login(Admin admin)
        {
            var user = service.Get(x => x.Name == admin.Name && x.Password == admin.Password);
            if (user.Data != null)
            {                
                HttpContext.Session.SetString("Name", user.Data.Name);
                HttpContext.Session.SetInt32("Id", user.Data.Id);

                return RedirectToAction("Index", "Menu");
            }            
            return View();
        }
               
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();                      
            return RedirectToAction("Login", "Admin");
        }


    }
}
