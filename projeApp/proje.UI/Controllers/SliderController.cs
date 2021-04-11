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
    public class SliderController : Controller
    {
        private ISliderService sliderService;        
        private IHostingEnvironment env;
        public SliderController(ISliderService _sliderService,IHostingEnvironment _env)
        {
            sliderService = _sliderService;            
            env = _env;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewModel mymodel = new ViewModel();
            mymodel.Sliders = sliderService.GetAll().Data;            
            return View(mymodel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewBag.model = sliderService.GetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Slider slider)
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            var result = sliderService.Get(x => x.Order == slider.Order && x.isDelete == false).Data;
            
            if (slider.Id == 0)
            {
                if (result==null)
                {
                    var kayıt = sliderService.Add(slider);
                    TempData["Mesaj"] = kayıt.BasariliMi ? "Kayıt Eklendi." : kayıt.Mesaj;
                    return RedirectToAction("Create", "Slider");
                }
                else
                {
                    TempData["Mesaj"] = "Aynı sıra numarasına ait iki kayıt olamaz.";
                    return View();
                }
            }
           
            else
            {
                var kayıt = sliderService.Get(x => x.Id == slider.Id).Data;
                if (result==null)
                {                    
                    slider.imageUrl = kayıt.imageUrl;
                    sliderService.Update(slider);
                    return RedirectToAction("Index", "Slider");
                }
                else
                {
                    if (result.Order == kayıt.Order)
                    {
                        slider.imageUrl = kayıt.imageUrl;
                        sliderService.Update(slider);
                        return RedirectToAction("Index", "Slider");
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
            var model = sliderService.Get(x => x.Id == id).Data;
            return View("Create", model);
        }
        public IActionResult Delete(int id)
        {
            sliderService.SoftDelete(id);
            return RedirectToAction("Index", "Slider");
        }
        public async Task<IActionResult> ImageUpload(int id, IFormFile file)
        {
            ViewModel mymodel = new ViewModel();
            if (file is null)
            {
                mymodel.Slider = sliderService.Get(x => x.Id == id).Data;
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
            var kayıt = sliderService.Get(x => x.Id == id).Data;
            kayıt.imageUrl = "/Images/" + dosyaAdi;
            var result = sliderService.Update(kayıt);
            TempData["Mesaj"] = result.BasariliMi ? "Kayıt Eklendi." : result.Mesaj;

            mymodel.Sliders = sliderService.GetAll().Data;
            mymodel.Slider = sliderService.Get(x => x.Id == id).Data;
            return View(mymodel);
        }
        public IActionResult DeleteImage(int id)
        {
            var kayıt = sliderService.Get(x => x.Id == id).Data;
            kayıt.imageUrl = null;
            sliderService.Update(kayıt);
            return RedirectToAction("Index", "Slider");
        }
        public IActionResult Active(int id)
        {
            var kayıt = sliderService.Get(x => x.Id == id).Data;
            if (kayıt.isActive == false)
            {
                kayıt.isActive = true;
            }
            else
            {
                kayıt.isActive = false;
            }
            sliderService.Update(kayıt);
            return RedirectToAction("Index", "Slider");
        }
    }
}
