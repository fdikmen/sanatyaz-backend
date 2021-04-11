using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proje.Business.Abstract;
using proje.Entities;
using proje.UI.Models;

namespace proje.UI.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService categoryService;
        public CategoryController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewModel mymodel = new ViewModel();
            mymodel.Categories = categoryService.GetAll().Data;
            return View(mymodel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewBag.model = categoryService.GetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            var result = categoryService.Get(x => x.Order == category.Order && x.isDelete == false).Data;

            if (category.Id == 0)
            {
                if (result == null)
                {
                    var kayıt = categoryService.Add(category);
                    TempData["Mesaj"] = kayıt.BasariliMi ? "Kayıt Eklendi." : kayıt.Mesaj;
                    return RedirectToAction("Create", "Category");
                }
                else
                {
                    TempData["Mesaj"] = "Aynı sıra numarasına ait iki kayıt olamaz.";
                    return View();
                }
            }
            else
            {
                var kayıt = categoryService.Get(x => x.Id == category.Id).Data;
                if (result==null)
                {
                    categoryService.Update(category);
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    if (kayıt.Order == result.Order)
                    {
                        categoryService.Update(category);
                        return RedirectToAction("Index", "Category");
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
            var model = categoryService.Get(x => x.Id == id).Data;
            return View("Create", model);
        }
        public IActionResult Delete(int id)
        {
            var result = categoryService.Get(x => x.Id == id).Data;
            result.isActive = false;
            categoryService.Update(result);

            categoryService.SoftDelete(id);
            return RedirectToAction("Index", "Category");
        }

        public IActionResult Active(int id)
        {

            var kayıt = categoryService.Get(x => x.Id == id).Data;
            if (kayıt.isActive == false)
            {
                var result = categoryService.GetAll(x => x.isActive == true).Data;
                if (result.Count < 4)
                {
                    kayıt.isActive = true;
                }
                else
                {
                    TempData["Mesaj"] = "Aktif kayıt dörtten fazla olamaz.";
                }
            }
            else
            {
                kayıt.isActive = false;
            }
            categoryService.Update(kayıt);
            return RedirectToAction("Index", "Category");
        }
    }
}
