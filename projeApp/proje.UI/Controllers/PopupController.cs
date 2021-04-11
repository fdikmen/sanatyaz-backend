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
    public class PopupController : Controller
    {
        private IPopupService popupService;
        private IHostingEnvironment env;
        public PopupController(IPopupService _popupService,IHostingEnvironment _env)
        {
            popupService = _popupService;
            env = _env;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewModel mymodel = new ViewModel();
            mymodel.Popups = popupService.GetAll().Data;
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
            mymodel.Popups = popupService.GetAll().Data;
            return View(mymodel);
        }

        [HttpPost]
        public IActionResult Create(Popup popup)
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewModel mymodel = new ViewModel();
            mymodel.Popups = popupService.GetAll().Data;
            if (popup.Id == 0)
            {
                var kayıt=popupService.Add(popup);
                TempData["Mesaj"] = kayıt.BasariliMi ? "Kayıt Eklendi." : kayıt.Mesaj;
                return RedirectToAction("Create", "Popup");
            }
            else
            {
                var kayıt = popupService.Get(x => x.Id == popup.Id).Data;
                popup.imageUrl = kayıt.imageUrl;
                popupService.Update(popup);
                return RedirectToAction("Index", "Popup");
            }
        }
        public IActionResult Update(int id)
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewModel mymodel = new ViewModel();
            mymodel.Popup = popupService.Get(x => x.Id == id).Data;
            return View("Create", mymodel);
        }
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            popupService.SoftDelete(id);
            return RedirectToAction("Index", "Popup");
        }

        public async Task<IActionResult> ImageUpload(int id, IFormFile file)
        {
            ViewModel mymodel = new ViewModel();
            if (file is null)
            {
                mymodel.Popup = popupService.Get(x => x.Id == id).Data;
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
            var kayıt = popupService.Get(x => x.Id == id).Data;
            kayıt.imageUrl = "/Images/" + dosyaAdi;
            var result = popupService.Update(kayıt);
            TempData["Mesaj"] = result.BasariliMi ? "Kayıt Eklendi." : result.Mesaj;

            mymodel.Popups = popupService.GetAll().Data;
            mymodel.Popup = popupService.Get(x => x.Id == id).Data;
            return View(mymodel);
        }

        public IActionResult DeleteImage(int id)
        {
            var kayıt = popupService.Get(x => x.Id == id).Data;
            kayıt.imageUrl = null;
            popupService.Update(kayıt);
            return RedirectToAction("Index", "Popup");
        }
        public IActionResult Active(int id)
        {
            var kayıt = popupService.Get(x => x.Id == id).Data;
            if (kayıt.isActive == false)
            {
                kayıt.isActive = true;
            }
            else
            {
                kayıt.isActive = false;
            }
            popupService.Update(kayıt);
            return RedirectToAction("Index", "Popup");
        }
    }
}
