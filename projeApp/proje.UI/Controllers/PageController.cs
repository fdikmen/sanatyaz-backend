using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proje.Business.Abstract;
using proje.Entities;
using proje.UI.Models;

namespace proje.UI.Controllers
{
    public class PageController : Controller
    {
        private ICreatePageService createPageService;
        private IMenuService menuService;
        public PageController(ICreatePageService _createPageService,IMenuService _menuService)
        {
            createPageService = _createPageService;
            menuService = _menuService;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewModel mymodel = new ViewModel();
            mymodel.Menus = menuService.GetAll().Data;
            mymodel.CreatePages = createPageService.GetAll().Data;
            return View(mymodel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewModel mymodel = new ViewModel();
            mymodel.Menus = menuService.GetAll().Data;
            mymodel.CreatePages = createPageService.GetAll().Data;
            return View(mymodel);
        }

        [HttpPost]
        public IActionResult Create(CreatePage createPage)
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            if (createPage.Id == 0)
            {
                var result = createPageService.Get(x => x.MenuId == createPage.MenuId).Data;
                if(result == null)
                {
                    var kayıt = createPageService.Add(createPage);
                    TempData["Mesaj"] = kayıt.BasariliMi ? "Kayıt Eklendi." : kayıt.Mesaj;
                }
                else
                {
                    TempData["Mesaj"] = "Bu menüye ait sayfa bulunmaktadır.";
                }
                
                return RedirectToAction("Create", "Page");
            }
            else
            {               
                createPageService.Update(createPage);
                return RedirectToAction("Index", "Page");
            }
        }
        public IActionResult Update(int id)
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }            
            ViewModel mymodel = new ViewModel();
            mymodel.CreatePage = createPageService.Get(x => x.Id == id).Data;
            mymodel.Menus = menuService.GetAll().Data;
            return View("Create", mymodel);
        }
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            createPageService.Delete(id);
            return RedirectToAction("Index", "Page");
        }      
        public IActionResult Active(int id)
        {
            var kayıt = createPageService.Get(x => x.Id == id).Data;
            if (kayıt.isActive == false)
            {
                kayıt.isActive = true;
            }
            else
            {
                kayıt.isActive = false;
            }
            createPageService.Update(kayıt);
            return RedirectToAction("Index", "Page");
        }
    }
}
