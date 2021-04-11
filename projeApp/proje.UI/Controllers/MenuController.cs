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
    public class MenuController : Controller
    {
        private IMenuService menuService;
        private IHostingEnvironment env;
        public MenuController(IMenuService _menuService, IHostingEnvironment _env)
        {
            menuService = _menuService;
            env = _env;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewModel mymodel = new ViewModel();
            mymodel.Menus = menuService.GetAll().Data;
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
            return View(mymodel);
        }
        [HttpPost]
        public IActionResult Create(Menu menu)
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }

            if(menu.Order != 0)
            {
                var result = menuService.Get(x => x.Order == menu.Order && x.isDelete == false && x.mainMenuId == menu.mainMenu.Id).Data;

                if (menu.mainMenu.Id != 0)
                {
                    //New item
                    if (menu.Id == 0)
                    {
                        if (result == null)
                        {
                            var deger = menuService.Get(x => x.Id == menu.mainMenu.Id).Data;
                            menu.mainMenuId = deger.Id;
                            var kayıt = menuService.Add(menu);
                            deger.subMenu = true;
                            menuService.Update(deger);
                            TempData["Mesaj"] = kayıt.BasariliMi ? "Kayıt Eklendi." : kayıt.Mesaj;
                            return RedirectToAction("Create", "Menu");
                        }
                        else
                        {
                            TempData["Mesaj"] = "Aynı sıra numarasına ait iki kayıt olamaz.";
                            ViewModel mymodel = new ViewModel();
                            mymodel.Menus = menuService.GetAll().Data;
                            return View(mymodel);
                        }
                    }

                    //Update
                    else
                    {
                        var kayıt = menuService.Get(x => x.Id == menu.Id).Data;
                        if (result == null)
                        {
                            //todo
                            var deger = menuService.Get(x => x.Id == menu.mainMenu.Id).Data;
                            menu.mainMenuId = deger.Id;
                            menu.imageUrl = kayıt.imageUrl;
                            menuService.Update(menu);
                            return RedirectToAction("Index", "Menu");
                        }
                        else
                        {
                            if (result.Order == kayıt.Order)
                            {
                                var deger = menuService.Get(x => x.Id == menu.mainMenu.Id).Data;
                                menu.mainMenuId = deger.Id;
                                menu.imageUrl = kayıt.imageUrl;
                                menuService.Update(menu);
                                return RedirectToAction("Index", "Menu");
                            }
                            else
                            {
                                TempData["Mesaj"] = "Aynı sıra numarasına ait iki kayıt olamaz.";
                                ViewModel mymodel = new ViewModel();
                                mymodel.Menus = menuService.GetAll().Data;
                                return View(mymodel);

                            }
                        }

                    }
                }

                else
                {
                    //New item
                    if (menu.Id == 0)
                    {
                        if (result == null)
                        {
                            menu.mainMenu.menuName = null;
                            menu.subMenu = false;
                            var kayıt = menuService.Add(menu);
                            TempData["Mesaj"] = kayıt.BasariliMi ? "Kayıt Eklendi." : kayıt.Mesaj;
                            return RedirectToAction("Create", "Menu");
                        }
                        else
                        {
                            TempData["Mesaj"] = "Aynı sıra numarasına ait iki kayıt olamaz.";
                            ViewModel mymodel = new ViewModel();
                            mymodel.Menus = menuService.GetAll().Data;
                            return View(mymodel);
                            

                        }
                    }

                    //Update
                    else
                    {
                        var kayıt = menuService.Get(x => x.Id == menu.Id).Data;
                        if (result == null)
                        {
                            menu.mainMenu.menuName = null;
                            menu.imageUrl = kayıt.imageUrl;
                            menuService.Update(menu);
                            return RedirectToAction("Index",menu);
                        }
                        else
                        {
                            if (result.Order == kayıt.Order)
                            {
                                menu.mainMenu.menuName = null;
                                menu.imageUrl = kayıt.imageUrl;
                                menuService.Update(menu);
                                return RedirectToAction("Index",menu);
                            }
                            else
                            {
                                TempData["Mesaj"] = "Aynı sıra numarasına ait iki kayıt olamaz.";
                                ViewModel mymodel = new ViewModel();
                                mymodel.Menus = menuService.GetAll().Data;
                                return View(mymodel);

                            }
                        }
                    }
                }
            }
            else
            {
                TempData["Mesaj"] = "Sıra numarası giriniz.";

                ViewModel mymodel = new ViewModel();
                mymodel.Menus = menuService.GetAll().Data;
                return View(mymodel);

            }
        }
        public IActionResult Update(int id)
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewModel mymodel = new ViewModel();
            mymodel.Menu = menuService.Get(x => x.Id == id).Data;
            mymodel.Menus = menuService.GetAll().Data;
            return View("Create", mymodel);
        }
        public IActionResult Delete(int id)
        {
            var result = menuService.Get(x => x.Id == id).Data;
            var kayıt = menuService.GetAll().Data;
           
            int count = 0;
            foreach (var item in kayıt)
            {
                if (result.mainMenuId == item.Id)
                {
                    foreach (var item2 in kayıt)
                    {
                        if (item2.mainMenuId == item.Id)
                        {
                            count++;
                        }
                    }
                    if (count == 1)
                    {
                        item.subMenu = false;
                        menuService.Update(item);
                    }
                }
                
                           
            }
            
            menuService.SoftDelete(id);

            return RedirectToAction("Index", "Menu");
        }


        public IActionResult GetHomepage(int id)
        {
            var kayıt = menuService.Get(x => x.Id == id).Data;
            if (kayıt.GetHomepage == true)
            {
                kayıt.GetHomepage = false;
            }
            else
            {
                kayıt.GetHomepage = true;
            }
            menuService.Update(kayıt);
            return RedirectToAction("Index", "Menu");
        }

        public async Task<IActionResult> ImageUpload(int id, IFormFile file)
        {
            ViewModel mymodel = new ViewModel();
            if (file is null)
            {
                mymodel.Menu = menuService.Get(x => x.Id == id).Data;
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
            var kayıt = menuService.Get(x => x.Id == id).Data;
            kayıt.imageUrl = "/Images/" + dosyaAdi;
            var result = menuService.Update(kayıt);
            TempData["Mesaj"] = result.BasariliMi ? "Kayıt Eklendi." : result.Mesaj;

            mymodel.Menus = menuService.GetAll().Data;
            mymodel.Menu = menuService.Get(x => x.Id == id).Data;
            return View(mymodel);
        }
        public IActionResult DeleteImage(int id)
        {
            var kayıt = menuService.Get(x => x.Id == id).Data;
            kayıt.imageUrl = null;
            menuService.Update(kayıt);
            return RedirectToAction("Index", "Menu");
        }
        public IActionResult Active(int id)
        {
            var kayıt = menuService.Get(x => x.Id == id).Data;
            if (kayıt.isActive == false)
            {
                kayıt.isActive = true;
            }
            else
            {
                kayıt.isActive = false;
            }
            menuService.Update(kayıt);
            return RedirectToAction("Index", "Menu");
        }
    }
}
