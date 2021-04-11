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
    public class PurposeController : Controller
    {
        private IPurposeService purposeService;
        private IHostingEnvironment env;
        public PurposeController(IPurposeService _purposeService,IHostingEnvironment _env)
        {
            purposeService = _purposeService;
            env = _env;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewModel mymodel = new ViewModel();
            mymodel.Purposes = purposeService.GetAll().Data;
            return View(mymodel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }

            ViewBag.model = purposeService.GetAll().Data;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Purpose purpose)
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            var kayıt = purposeService.Get(x => x.Id == purpose.Id).Data;
            purpose.imageUrl = kayıt.imageUrl;
            purposeService.Update(purpose);
            
            return RedirectToAction("Index", "Purpose");
        }
        public IActionResult Update(int id)
        {
            var model = purposeService.Get(x => x.Id == id).Data;
            return View("Create", model);
        }       

        public async Task<IActionResult> ImageUpload(int id, IFormFile file)
        {
            ViewModel mymodel = new ViewModel();
            if (file is null)
            {
                mymodel.Purpose = purposeService.Get(x => x.Id == id).Data;
                return View(mymodel);
            }
            string rootPath = env.WebRootPath;
            if (!Directory.Exists(rootPath))//Dosya Klasörü Daha Önce Oluşturulmamışsa
            {
                System.IO.Directory.CreateDirectory(rootPath);
            }
            string uzanti = file.FileName.Split(".")[1];
            string dosyaAdi = Guid.NewGuid().ToString() + "." + uzanti;
            var filePath = rootPath+"/Images/" + dosyaAdi;
            if (file.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            var kayıt = purposeService.Get(x => x.Id == id).Data;
            kayıt.imageUrl = "/Images/" + dosyaAdi;
            var result = purposeService.Update(kayıt);
            TempData["Mesaj"] = result.BasariliMi ? "Kayıt Eklendi." : result.Mesaj;

            mymodel.Purposes = purposeService.GetAll().Data;
            mymodel.Purpose = purposeService.Get(x => x.Id == id).Data;
            return View(mymodel);
        }
        public IActionResult DeleteImage(int id)
        {
            var kayıt = purposeService.Get(x => x.Id == id).Data;
            kayıt.imageUrl = null;
            purposeService.Update(kayıt);
            return RedirectToAction("Index", "Purpose");
        }
    }
}
