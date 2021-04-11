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
    public class GalleryController : Controller
    {
        private IPhotoGalleryService photoGalleryService;
        private IPhotoCategoryService photoCategoryService;
        private IHostingEnvironment env;
        public GalleryController(IPhotoCategoryService _photoCategoryService, IPhotoGalleryService _photoGalleryService,IHostingEnvironment _env)
        {
            photoCategoryService = _photoCategoryService;
            photoGalleryService = _photoGalleryService;
            env = _env;
        }
        public IActionResult Category()
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            GalleryViewModel mymodel = new GalleryViewModel();
            mymodel.PhotoCategories = photoCategoryService.GetAll().Data;
            mymodel.PhotoGalleries = photoGalleryService.GetAll().Data;

            return View(mymodel);
        }
        public IActionResult Image()
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            GalleryViewModel mymodel = new GalleryViewModel();
            mymodel.PhotoCategories = photoCategoryService.GetAll().Data;
            mymodel.PhotoGalleries = photoGalleryService.GetAll().Data;

            return View(mymodel);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewBag.model = photoCategoryService.GetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Create(PhotoCategory photoCategory)
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            if(photoCategory.Order != 0)
            {
                var result = photoCategoryService.Get(x => x.Order == photoCategory.Order && x.isDelete == false).Data;

                if (photoCategory.Id == 0)
                {
                    if(result == null)
                    {
                        var kayıt = photoCategoryService.Add(photoCategory);
                        TempData["Mesaj"] = kayıt.BasariliMi ? "Kayıt Eklendi." : kayıt.Mesaj;
                        return RedirectToAction("Create", "Gallery");
                    }
                    else
                    {
                        TempData["Mesaj"] = "Aynı sıra numarasına ait iki kayıt olamaz.";
                        return View();
                    }
                }
                else
                {
                    var kayıt = photoCategoryService.Get(x => x.Id == photoCategory.Id).Data;
                    if(result == null)
                    {
                        photoCategoryService.Update(photoCategory);
                        return RedirectToAction("Category", "Gallery");
                    }
                    else
                    {
                        TempData["Mesaj"] = "Aynı sıra numarasına ait iki kayıt olamaz.";
                        return View();
                    }
                }
            }
            else
            {
                TempData["Mesaj"] = "Sıra numarası giriniz.";
                return View();
            }
            
        }       
       
        public IActionResult Update(int id)
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            var model = photoCategoryService.Get(x => x.Id == id).Data;
            return View("Create", model);
        }
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            photoCategoryService.SoftDelete(id);
            return RedirectToAction("Category", "Gallery");
        }
        public IActionResult Active(int id)
        {
            var kayıt = photoCategoryService.Get(x => x.Id == id).Data;
            if (kayıt.isActive == false)
            {
                kayıt.isActive = true;
            }
            else
            {
                kayıt.isActive = false;
            }
            photoCategoryService.Update(kayıt);
            return RedirectToAction("Category", "Gallery");
        }

        public async Task<IActionResult> ImageUpload(PhotoGallery photoGallery, IFormFile file)
        {

            GalleryViewModel mymodel = new GalleryViewModel();
            if (file is null)
            {
                mymodel.PhotoCategories = photoCategoryService.GetAll().Data;
                mymodel.PhotoGalleries = photoGalleryService.GetAll().Data;
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
            photoGallery.imageUrl = "/Images/" + dosyaAdi;
            var result = photoGalleryService.Add(photoGallery);
            TempData["Mesaj"] = result.BasariliMi ? "Kayıt Eklendi." : result.Mesaj;
           
            mymodel.PhotoCategories = photoCategoryService.GetAll().Data;
            mymodel.PhotoGalleries = photoGalleryService.GetAll().Data;
            return View(mymodel);
        }

        public IActionResult DeleteImage(int id)
        {            
            photoGalleryService.Delete(id);
            return RedirectToAction("Image", "Gallery");
        }
    }
}
