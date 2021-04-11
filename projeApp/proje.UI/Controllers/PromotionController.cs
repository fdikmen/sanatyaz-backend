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
    public class PromotionController : Controller
    {
        private IPromotionService promotionService;
        private IHostingEnvironment env;
        public PromotionController(IPromotionService _promotionService, IHostingEnvironment _env)
        {
            promotionService = _promotionService;
            env = _env;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewModel mymodel = new ViewModel();
            mymodel.Promotions = promotionService.GetAll().Data;
            return View(mymodel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewBag.model = promotionService.GetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Promotion promotion)
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }

            if(promotion.Order != 0)
            {
                var result = promotionService.Get(x => x.Order == promotion.Order && x.isDelete == false).Data;

                if (promotion.Id == 0)
                {
                    if (result == null)
                    {
                        var kayıt = promotionService.Add(promotion);
                        TempData["Mesaj"] = kayıt.BasariliMi ? "Kayıt Eklendi." : kayıt.Mesaj;
                        return RedirectToAction("Create", "Promotion");
                    }
                    else
                    {
                        TempData["Mesaj"] = "Aynı sıra numarasına ait iki kayıt olamaz.";
                        return View();
                    }
                }
                else
                {
                    var kayıt = promotionService.Get(x => x.Id == promotion.Id).Data;

                    if (result == null)
                    {
                        promotion.imageUrl = kayıt.imageUrl;
                        promotion.isActive = kayıt.isActive;
                        promotion.GetHomepage = kayıt.GetHomepage;
                        promotionService.Update(promotion);
                        return RedirectToAction("Index", "Promotion");
                    }
                    else
                    {
                        if (result.Order == kayıt.Order)
                        {
                            promotion.imageUrl = kayıt.imageUrl;
                            promotion.isActive = kayıt.isActive;
                            promotion.GetHomepage = kayıt.GetHomepage;
                            promotionService.Update(promotion);
                            return RedirectToAction("Index", "Promotion");
                        }
                        else
                        {
                            TempData["Mesaj"] = "Aynı sıra numarasına ait iki kayıt olamaz.";
                            return View();
                        }
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
            var model = promotionService.Get(x => x.Id == id).Data;
            return View("Create", model);
        }

        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            promotionService.SoftDelete(id);
            return RedirectToAction("Index", "Promotion");
        }

        public async Task<IActionResult> ImageUpload(int id, IFormFile file)
        {
            ViewModel mymodel = new ViewModel();
            if (file is null)
            {
                mymodel.Promotion = promotionService.Get(x => x.Id == id).Data;
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
            var kayıt = promotionService.Get(x => x.Id == id).Data;
            kayıt.imageUrl = "/Images/" + dosyaAdi;
            var result = promotionService.Update(kayıt);
            TempData["Mesaj"] = result.BasariliMi ? "Kayıt Eklendi." : result.Mesaj;

            mymodel.Promotions = promotionService.GetAll().Data;
            mymodel.Promotion = promotionService.Get(x => x.Id == id).Data;
            return View(mymodel);
        }
        public IActionResult DeleteImage(int id)
        {
            var kayıt = promotionService.Get(x => x.Id == id).Data;
            kayıt.imageUrl = null;
            promotionService.Update(kayıt);
            return RedirectToAction("Index", "Promotion");
        }
        public IActionResult Active(int id)
        {
            var kayıt = promotionService.Get(x => x.Id == id).Data;
            if (kayıt.isActive == false)
            {
                kayıt.isActive = true;
            }
            else
            {
                kayıt.isActive = false;
            }
            promotionService.Update(kayıt);
            return RedirectToAction("Index", "Promotion");
        }

        public IActionResult GetHomepage(int id)
        {
            var kayıt = promotionService.Get(x => x.Id == id && x.isDelete == false).Data;
            if (kayıt.GetHomepage == true)
            {
                kayıt.GetHomepage = false;
            }
            else
            {
                kayıt.GetHomepage = true;
            }
            promotionService.Update(kayıt);
            return RedirectToAction("Index", "Promotion");
        }
    }
}
