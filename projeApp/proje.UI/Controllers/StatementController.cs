using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proje.Business.Abstract;
using proje.Entities;

namespace proje.UI.Controllers
{
    public class StatementController : Controller
    {
        private IStatementService statementService;
        public StatementController(IStatementService _statementService)
        {
            statementService = _statementService;
        }        
        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewBag.model = statementService.GetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Statement statement)
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }            
            
            var result=statementService.Update(statement);
            TempData["Mesaj"] = result.BasariliMi ? "Kayıt Güncellendi." : result.Mesaj;
            return RedirectToAction("Update", "Statement");
           
        }
        public IActionResult Update(int id)
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            var model = statementService.Get(x => x.Id == 1).Data;
            return View("Create", model);
        }
    }
}
