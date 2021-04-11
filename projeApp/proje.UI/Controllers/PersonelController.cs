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
    public class PersonelController : Controller
    {
        private IPersonelService personelService;
        private IHostingEnvironment env;
        public PersonelController(IPersonelService _personelService,IHostingEnvironment _env)
        {
            personelService = _personelService;
            env = _env;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewModel mymodel = new ViewModel();
            mymodel.Personels = personelService.GetAll().Data;
            return View(mymodel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewBag.model = personelService.GetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Personel personel)
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            var result = personelService.Get(x => x.Order == personel.Order).Data;

            if (personel.Id == 0)
            {
                if (result == null)
                {
                    personel.isActive = true;
                    var kayıt = personelService.Add(personel);
                    TempData["Mesaj"] = kayıt.BasariliMi ? "Kayıt Eklendi." : kayıt.Mesaj;
                    return RedirectToAction("Create", "Personel");
                }
                else
                {
                    TempData["Mesaj"] = "Aynı sıra numarasına ait iki kayıt olamaz.";
                    return View();
                }

            }
            else
            {
                var kayıt = personelService.Get(x => x.Id == personel.Id).Data;
                if (result==null)
                {
                    personel.ImageUrl = kayıt.ImageUrl;
                    personelService.Update(personel);
                    return RedirectToAction("Index", "Personel");
                }
                else
                {
                    if (result.Order == kayıt.Order)
                    {
                        personel.ImageUrl = kayıt.ImageUrl;
                        personelService.Update(personel);
                        return RedirectToAction("Index", "Personel");
                    }
                    else
                    {
                        TempData["Mesaj"] = "Aynı sıra numarasına ait iki kayıt olamaz.";                        
                        return View();
                    }
                }
            }



        }
        public IActionResult Update(int id)
        {
            var model = personelService.Get(x => x.Id == id).Data;
            return View("Create", model);
        }
        public IActionResult Delete(int id)
        {
            personelService.SoftDelete(id);
            return RedirectToAction("Index", "Personel");
        }

        public async Task<IActionResult> ImageUpload(int id, IFormFile file)
        {
            ViewModel mymodel = new ViewModel();
            if (file is null)
            {
                mymodel.Personel = personelService.Get(x => x.Id == id).Data;
                return View(mymodel);
            }
            string rootPath = env.WebRootPath;
            if (!Directory.Exists(rootPath))//Dosya Klasörü Daha Önce Oluşturulmamışsa
            {
                System.IO.Directory.CreateDirectory(rootPath);
            }
            string uzanti = file.FileName.Split(".")[1];
            string dosyaAdi = Guid.NewGuid().ToString() + "." + uzanti;
            var filePath = rootPath+ "/Images/" + dosyaAdi;
            if (file.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            var kayıt = personelService.Get(x => x.Id == id).Data;
            kayıt.ImageUrl = "/Images/" + dosyaAdi;
            var result = personelService.Update(kayıt);
            TempData["Mesaj"] = result.BasariliMi ? "Kayıt Eklendi." : result.Mesaj;

            mymodel.Personels = personelService.GetAll().Data;
            mymodel.Personel = personelService.Get(x => x.Id == id).Data;
            return View(mymodel);
        }
        public IActionResult DeleteImage(int id)
        {
            var kayıt = personelService.Get(x => x.Id == id).Data;
            kayıt.ImageUrl = null;
            personelService.Update(kayıt);
            return RedirectToAction("Index", "Personel");
        }

        public IActionResult Active(int id)
        {
            var kayıt = personelService.Get(x => x.Id == id).Data;
            if (kayıt.isActive == false)
            {
                kayıt.isActive = true;
            }
            else
            {
                kayıt.isActive = false;
            }
            personelService.Update(kayıt);
            return RedirectToAction("Index", "Personel");
        }
    }
}
