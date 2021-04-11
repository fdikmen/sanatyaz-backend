using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proje.Business.Abstract;
using proje.Entities;
using proje.UI.Models;

namespace proje.UI.Controllers
{
    public class AboutController : Controller
    {
        private IAboutService aboutService;
        private IHostingEnvironment env;
        public AboutController(IAboutService _aboutService,IHostingEnvironment _env)
        {
            aboutService = _aboutService;
            env = _env;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewModel mymodel = new ViewModel();
            mymodel.Abouts = aboutService.GetAll().Data;
            return View(mymodel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewBag.model = aboutService.GetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Create(About about)
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }            
            if (about.Id == 0)
            {
                var kayıt=aboutService.Add(about);
                TempData["Mesaj"] = kayıt.BasariliMi ? "Kayıt Eklendi." : kayıt.Mesaj;
                return RedirectToAction("Create", "About");
            }
            else
            {
                var kayıt=aboutService.Get(x => x.Id == about.Id).Data;
                about.imageUrl = kayıt.imageUrl;
                aboutService.Update(about);
                return RedirectToAction("Index", "About");
            }
        }
        public IActionResult Update(int id)
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            var model = aboutService.Get(x => x.Id == id).Data;
            return View("Create", model);
        }
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            aboutService.SoftDelete(id);
            return RedirectToAction("Index", "About");
        }
        
        public async Task<IActionResult> ImageUpload(int id, IFormFile file)
        {

            ViewModel mymodel = new ViewModel();
            if (file is null)
            {                
                mymodel.About = aboutService.Get(x=>x.Id==id).Data;
                return View(mymodel);
            }
            string rootPath = env.WebRootPath;
            if (!Directory.Exists(rootPath))//Dosya Klasörü Daha Önce Oluşturulmamışsa
            {
                System.IO.Directory.CreateDirectory(rootPath);
            }
            string uzanti = file.FileName.Split(".")[1];
            string dosyaAdi = Guid.NewGuid().ToString() + "." + uzanti;
            var filePath = rootPath + "/Images/" + dosyaAdi;            
            if (file.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            var kayıt = aboutService.Get(x => x.Id == id).Data;
            kayıt.imageUrl = "/Images/" + dosyaAdi;
            var result = aboutService.Update(kayıt);
            TempData["Mesaj"] = result.BasariliMi ? "Kayıt Eklendi." : result.Mesaj;
            
            mymodel.Abouts = aboutService.GetAll().Data;
            mymodel.About = aboutService.Get(x => x.Id == id).Data;
            return View(mymodel);
         }

        public IActionResult DeleteImage(int id)
        {
            var kayıt = aboutService.Get(x => x.Id == id).Data;
            kayıt.imageUrl = null;
            aboutService.Update(kayıt);            
            return RedirectToAction("Index","About");
        }

        public IActionResult Active(int id)
        {
            var kayıt = aboutService.Get(x => x.Id == id).Data;
            if(kayıt.isActive == false)
            {
                kayıt.isActive = true;
            }
            else
            {
                kayıt.isActive = false;
            }
            aboutService.Update(kayıt);
            return RedirectToAction("Index", "About"); 
        }
    }
}
