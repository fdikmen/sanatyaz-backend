using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proje.Business.Abstract;
using proje.Entities;
using proje.UI.Models;

namespace proje.UI.Controllers
{
    public class FormController : Controller
    {
        private IFormService formService;
        private IFormElementService formElementService;
        private IFormElementItemService itemService;
        private IFormArchiveService formArchiveService;
        public FormController(IFormService _formService, IFormElementService _formElementService, IFormElementItemService _itemService, IFormArchiveService _formArchiveService)
        {
            formService = _formService;
            formElementService = _formElementService;
            itemService = _itemService;
            formArchiveService = _formArchiveService;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewModel mymodel = new ViewModel();
            mymodel.Forms = formService.GetAll().Data;
            mymodel.FormElementItems = itemService.GetAll().Data;
            mymodel.FormElements = formElementService.GetAll().Data;
            mymodel.FormArchives = formArchiveService.GetAll().Data;
            return View(mymodel);
        }

        [HttpGet]
        public IActionResult FormCreate()
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewModel mymodel = new ViewModel();
            mymodel.Forms = formService.GetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult FormCreate(Form form)
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            if (form.Id == 0)
            {
                form.AddedDate = DateTime.Now;
                var kayıt = formService.Add(form);
                TempData["Mesaj"] = kayıt.BasariliMi ? "Kayıt Eklendi." : kayıt.Mesaj;
                return RedirectToAction("FormCreate", "Form");
            }
            else
            {
                formService.Update(form);
                return RedirectToAction("Index", "Form");
            }
        }

        public IActionResult Update(int id)
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            var model = formService.Get(x => x.Id == id).Data;
            return View("FormCreate", model);
        }

        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            var result = formElementService.GetAll(x => x.FormId == id).Data;
            foreach (var item in result)
            {
                formElementService.SoftDelete(item.Id);
            }

            formService.SoftDelete(id);
            return RedirectToAction("Index", "Form");
        }

        [HttpGet]
        public IActionResult FormElement()
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewModel mymodel = new ViewModel();
            mymodel.FormElements = formElementService.GetAll().Data;
            mymodel.Forms = formService.GetAll().Data;
            mymodel.FormElementItems = itemService.GetAll().Data;
            return View(mymodel);
        }

        [HttpPost]
        public IActionResult FormElement(FormElement formElement)
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            if (formElement.Order != 0)
            {
                formElement.AddedDate = DateTime.Now;
                formElement.isActive = true;
                var kayıt = formElementService.Add(formElement);
                TempData["Mesaj"] = kayıt.BasariliMi ? "Kayıt Eklendi." : kayıt.Mesaj;
                return RedirectToAction("FormElement");
            }
            else
            {
                ViewModel mymodel = new ViewModel();
                mymodel.FormElements = formElementService.GetAll().Data;
                mymodel.Forms = formService.GetAll().Data;
                mymodel.FormElementItems = itemService.GetAll().Data;
                TempData["Mesaj"] = "Sıra numarası giriniz.";
                return View(mymodel);
            }


            
            

        }
        [HttpGet]
        public IActionResult FormElementItem()
        {
            ViewModel mymodel = new ViewModel();
            mymodel.FormElements = formElementService.GetAll().Data;
            mymodel.Forms = formService.GetAll().Data;
            mymodel.FormElementItems = itemService.GetAll().Data;
            return View(mymodel);
        }

        [HttpPost]
        public IActionResult FormElementItem(FormElementItem formElementItem)
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }

            var kayıt = itemService.Add(formElementItem);
            TempData["Mesaj"] = kayıt.BasariliMi ? "Kayıt Eklendi." : kayıt.Mesaj;

            ViewModel mymodel = new ViewModel();
            mymodel.FormElements = formElementService.GetAll().Data;
            mymodel.Forms = formService.GetAll().Data;
            return View(mymodel);
        }

        public IActionResult Active(int id)
        {
            var active = formService.Get(x => x.isActive == true && x.isDelete ==false).Data;
            var kayıt = formService.Get(x => x.Id == id).Data;
            var result = formElementService.GetAll(x => x.FormId == kayıt.Id).Data;
            if (kayıt.isActive == false )
            {
                if (active == null)
                {
                    kayıt.isActive = true;
                    foreach (var item in result)
                    {
                        item.isActive = true;
                        formElementService.Update(item);
                    }
                    formService.Update(kayıt);
                    return RedirectToAction("Index", "Form");
                }
                else
                {
                    TempData["Mesaj"] = "Sadece bir kayıt aktif olabilir.";
                    return RedirectToAction("Index", "Form");
                }
            }
            else
            {
                kayıt.isActive = false;
                foreach (var item in result)
                {
                    item.isActive = false;
                    formElementService.Update(item);
                }
                formService.Update(kayıt);
                return RedirectToAction("Index", "Form");
            }    
        }

        public IActionResult FormArchiveDelete(int id)
        {
            var result = formArchiveService.Get(x => x.Id == id).Data;
            var kayıt = formArchiveService.GetAll().Data;
            
            foreach (var item in kayıt)
            {
                if (result.FormGuid ==item.FormGuid)
                {
                    formArchiveService.SoftDelete(item.Id);
                }
            }
            return RedirectToAction("Index", "Form");
        }
    }
}
