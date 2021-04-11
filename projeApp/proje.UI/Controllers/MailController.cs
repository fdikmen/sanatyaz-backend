using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using proje.Business.Abstract;
using proje.Entities;
using proje.UI.Models;
using System;
using System.Net;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace proje.UI.Controllers
{
    public class MailController : Controller
    {
        private IMailService mailService;
        private IUserService userService;
        private IFormService formService;
        private IFormElementService formElementService;
        private IFormArchiveService formArchiveService;
        private IContactService contactService;
        private IWebHostEnvironment env;
        
        public MailController(IMailService _mailService, IUserService _userService,IFormService _formService,IFormElementService _formElementService,
            IFormArchiveService _formArchiveService,IContactService _contactService , IWebHostEnvironment _env)
        {
            mailService = _mailService;
            userService = _userService;
            formService = _formService;
            formElementService = _formElementService;
            formArchiveService = _formArchiveService;
            contactService = _contactService;
            env = _env;
        }
        public IActionResult Inbox()
        {
            MailViewModel mymodel = new MailViewModel();
            mymodel.Mails = mailService.GetAll().Data;
            return View(mymodel);
        }
        
        [HttpGet]
        public IActionResult Ebulten()
        {
            MailViewModel mymodel = new MailViewModel();
            mymodel.Mails = mailService.GetAll().Data;
            mymodel.Users = userService.GetAll().Data;
            return View(mymodel);
        }
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            userService.SoftDelete(id);
            return RedirectToAction("Ebulten", "Mail");
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewModel mymodel = new ViewModel();
            mymodel.Forms = formService.GetAll().Data;
            mymodel.FormElements = formElementService.GetAll().Data;
            return View(mymodel);
        }

        [HttpPost]
        public IActionResult Create(Mail mail, FormElement formElement)
        {          
            if (formElement.Id != 0)
            {
                try
                {                 
                    var kayıt = formArchiveService.GetAll(x => x.FormElementId == formElement.Id).Data;
                    foreach (var item in kayıt)
                    {                      
                        var msj = new MimeMessage();
                        msj.From.Add(new MailboxAddress("Sanatyaz Eğitim Kurumları", "sanatyazkisiselgelisim@gmail.com"));
                        msj.To.Add(new MailboxAddress(item.Content));
                        msj.Subject = mail.Subject;
                        msj.Body = new TextPart("html")
                        {
                            Text = mail.Message
                        };

                        using (var client = new SmtpClient())
                        {
                            client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                            if (env.IsDevelopment())
                            {
                                client.Connect("smtp.gmail.com", 465, true);
                            }
                            else
                            {
                                client.Connect("smtp.gmail.com");
                            }
                            client.Authenticate("sanatyazkisiselgelisim@gmail.com", "dilsim11");
                            client.Send(msj);

                        }
                    }

                    mail.AddDateTime = DateTime.Now;
                    mailService.Add(mail);

                }
                catch (Exception)
                {
                    TempData["Mesaj"] = "Mesaj Gönderilirken hata oluştu";
                    ViewModel model = new ViewModel();
                    model.Forms = formService.GetAll().Data;
                    model.FormElements = formElementService.GetAll().Data;
                    return View(model);
                }
            }

            if (mail.Contact == true)
            {
                try
                {                                     

                    var kayıt = contactService.GetAll().Data;
                    foreach (var item in kayıt)
                    {
                        var msj = new MimeMessage();
                        msj.From.Add(new MailboxAddress("Sanatyaz Eğitim Kurumları", "sanatyazkisiselgelisim@gmail.com"));
                        msj.To.Add(new MailboxAddress(item.Email));
                        msj.Subject = mail.Subject;
                        msj.Body = new TextPart("html")
                        {
                            Text = mail.Message
                        };

                        using (var client = new SmtpClient())
                        {
                            client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                            if (env.IsDevelopment())
                            {
                                client.Connect("smtp.gmail.com", 465, true);
                            }
                            else
                            {
                                client.Connect("smtp.gmail.com");
                            }
                            client.Authenticate("sanatyazkisiselgelisim@gmail.com", "dilsim11");
                            client.Send(msj);

                        }
                    }

                    mail.AddDateTime = DateTime.Now;
                    mailService.Add(mail);

                }
                catch (Exception)
                {
                    TempData["Mesaj"] = "Mesaj Gönderilirken hata oluştu";
                    ViewModel model = new ViewModel();
                    model.Forms = formService.GetAll().Data;
                    model.FormElements = formElementService.GetAll().Data;
                    return View(model);
                }
            }

            if (mail.Ebulten == true)
            {
                try
                {                   
                    var model = userService.GetAll().Data;
                    foreach (var item in model)
                    {
                        var msj = new MimeMessage();
                        msj.From.Add(new MailboxAddress("Sanatyaz Eğitim Kurumları", "sanatyazkisiselgelisim@gmail.com"));
                        msj.To.Add(new MailboxAddress(item.EMail));
                        msj.Subject = mail.Subject;
                        msj.Body = new TextPart("html")
                        {
                            Text = mail.Message
                        };

                        using (var client = new SmtpClient())
                        {
                            client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                            if (env.IsDevelopment())
                            {
                                client.Connect("smtp.gmail.com", 465, true);
                            }
                            else
                            {
                                client.Connect("smtp.gmail.com");
                            }
                            client.Authenticate("sanatyazkisiselgelisim@gmail.com", "dilsim11");
                            client.Send(msj);

                        }
                    }

                    mail.AddDateTime = DateTime.Now;
                    mailService.Add(mail);

                }
                catch (Exception)
                {
                    TempData["Mesaj"] = "Mesaj Gönderilirken hata oluştu";
                    ViewModel model = new ViewModel();
                    model.Forms = formService.GetAll().Data;
                    model.FormElements = formElementService.GetAll().Data;
                    return View(model);
                }
            }

            if(mail.Email != null)
            {
                try
                {
                    var msj = new MimeMessage();
                    msj.From.Add(new MailboxAddress("Sanatyaz Eğitim Kurumları", "sanatyazkisiselgelisim@gmail.com"));
                    msj.To.Add(new MailboxAddress(mail.Email));
                    msj.Subject = mail.Subject;
                    msj.Body = new TextPart("html")
                    {
                        Text = mail.Message
                    };

                    using (var client = new SmtpClient())
                    {
                        client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                        if (env.IsDevelopment())
                        {
                            client.Connect("smtp.gmail.com", 465, true);
                        }
                        else
                        {
                            client.Connect("smtp.gmail.com");
                        }
                        client.Authenticate("sanatyazkisiselgelisim@gmail.com", "dilsim11");
                        client.Send(msj);

                    }

                    mail.AddDateTime = DateTime.Now;
                    mailService.Add(mail);


                }
                catch (Exception err)
                {
                    TempData["Mesaj"] = "Mesaj Gönderilirken hata oluştu";
                    ViewModel model = new ViewModel();
                    model.Forms = formService.GetAll().Data;
                    model.FormElements = formElementService.GetAll().Data;
                    return View(model);
                }



            }



            TempData["Mesaj"] = "Mesajınız başarılı bir şekilde gönderildi.";
            ViewModel mymodel = new ViewModel();
            mymodel.Forms = formService.GetAll().Data;
            mymodel.FormElements = formElementService.GetAll().Data;
            return View(mymodel);

            
        }


        public IActionResult Read(int id)
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewModel mymodel = new ViewModel();
            mymodel.Mail = mailService.Get(x => x.Id == id).Data;
            mymodel.Mails = mailService.GetAll().Data;
            return View(mymodel);
        }

        
        public IActionResult MailDelete(int id)
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }

            mailService.SoftDelete(id);
            return RedirectToAction("Inbox");
        }
        

       

    }
}
