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
    public class ConstantController : Controller
    {
        private IConstantService constantService;
        private IAdminService adminService;
        private IHostingEnvironment env;
        public ConstantController(IConstantService _constantService,IHostingEnvironment _env,IAdminService _adminService)
        {
            constantService = _constantService;
            env = _env;
            adminService = _adminService;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewModel mymodel = new ViewModel();
            mymodel.Constants = constantService.GetAll().Data;
            return View(mymodel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            
            ViewBag.model = constantService.GetAll().Data;
            return View();            
        }
        [HttpPost]
        public IActionResult Create(Constant constant)
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            if (constant.Id == 0)
            {
                var kayıt = constantService.Add(constant);
                TempData["Mesaj"] = kayıt.BasariliMi ? "Kayıt Eklendi." : kayıt.Mesaj;
                return RedirectToAction("Create", "Constant");
            }
            else
            {
                var kayıt = constantService.Get(x => x.Id == constant.Id).Data;
                constant.LogoUrl = kayıt.LogoUrl;
                constantService.Update(constant);
                return RedirectToAction("Index", "Constant");
            }
        }
        public IActionResult Update(int id)
        {
            var model = constantService.Get(x => x.Id == id).Data;
            return View("Create", model);
        }

        //public IActionResult Delete(int id)
        //{
        //    constantService.SoftDelete(id);
        //    return RedirectToAction("Index", "Constant");
        //}

        
        public async Task<IActionResult> ImageUpload(int id, IFormFile file,Constant constant)
        {
            ViewModel mymodel = new ViewModel();
            if (file is null)
            {
                mymodel.Constant = constantService.Get(x => x.Id == id).Data;
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
            var kayıt = constantService.Get(x => x.Id == id).Data;
            if(constant.FooterLogoUrl =="1")
            {
                kayıt.LogoUrl = "/Images/" + dosyaAdi;
                var result = constantService.Update(kayıt);
                TempData["Mesaj"] = result.BasariliMi ? "Kayıt Eklendi." : result.Mesaj;
            }           
            if (constant.FooterLogoUrl == "2")
            {
                kayıt.FooterLogoUrl = "/Images/" + dosyaAdi;
                var result = constantService.Update(kayıt);
                TempData["Mesaj"] = result.BasariliMi ? "Kayıt Eklendi." : result.Mesaj;                
            }
            mymodel.Constants = constantService.GetAll().Data;
            mymodel.Constant = constantService.Get(x => x.Id == id).Data;
            return View(mymodel);
        }
        public IActionResult DeleteImage(int id)
        {
            var kayıt = constantService.Get(x => x.Id == id).Data;
            kayıt.LogoUrl = null;
            constantService.Update(kayıt);
            return RedirectToAction("Index", "Constant");
        }
        [HttpGet]
        public IActionResult AdminUpdate()
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            var kayıt = adminService.Get(x => x.Id == 1).Data;
            return View(kayıt);
        }

        [HttpPost]
        public IActionResult AdminUpdate(Admin admin)
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }

            var result = adminService.Update(admin);
            TempData["Mesaj"] = result.BasariliMi ? "Kayıt Güncellendi." : result.Mesaj;
            return View();

        }
    }
}
