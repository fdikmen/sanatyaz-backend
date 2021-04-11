using Microsoft.AspNetCore.Mvc;
using proje.Business.Abstract;
using proje.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proje.UI.Controllers
{
    public class ContactController : Controller
    {
        private IContactService contactService;
        public ContactController(IContactService _contactService)
        {
            contactService = _contactService;
        }

        public IActionResult Index()
        {
            ViewModel mymodel = new ViewModel();
            mymodel.Contacts = contactService.GetAll().Data;             
            return View(mymodel);
        }

        public IActionResult Read(int id)
        {
            ViewModel mymodel = new ViewModel();
            mymodel.Contact = contactService.Get(x => x.Id == id).Data;
            return View(mymodel);
        }

        public IActionResult Delete(int id)
        {
            contactService.SoftDelete(id);
            return RedirectToAction("Index", "Contact");
        }
    }
}
