using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proje.Business.Abstract;
using proje.Entities;
using proje.UI.Models;
using System;
using System.Web;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace proje.UI.Controllers
{
    public class BlogController : Controller
    {
        private IBlogService blogService;
        private ICommentService commentService;
        private ILikeService likeService;
        private IHostingEnvironment env;
        public BlogController(IBlogService _blogService, ICommentService _commnetService, ILikeService _likeService, IHostingEnvironment _env)
        {
            blogService = _blogService;
            commentService = _commnetService;
            likeService = _likeService;
            env = _env;

        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            BlogViewModel mymodel = new BlogViewModel();
            mymodel.Blogs = blogService.GetAll().Data;
            return View(mymodel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Create(Blog blog)
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }

            if(blog.Order != 0)
            {
                var result = blogService.Get(x => x.Order == blog.Order && x.isDelete == false).Data;

                if (blog.Id == 0)
                {
                    if (result == null)
                    {
                        blog.DateTime = DateTime.Now;
                        var kayıt = blogService.Add(blog);
                        TempData["Mesaj"] = kayıt.BasariliMi ? "Kayıt Eklendi." : kayıt.Mesaj;
                        return RedirectToAction("Create", "Blog");
                    }
                    else
                    {
                        TempData["Mesaj"] = "Aynı sıra numarasına ait iki kayıt olamaz.";
                        return View();
                    }
                }
                else
                {
                    var kayıt = blogService.Get(x => x.Id == blog.Id).Data;
                    if (result == null)
                    {
                        blog.ImageUrl = kayıt.ImageUrl;
                        blog.DateTime = DateTime.Now;
                        blogService.Update(blog);
                        return RedirectToAction("Index", "Blog");
                    }
                    else
                    {
                        if (result.Order == kayıt.Order)
                        {
                            blog.ImageUrl = kayıt.ImageUrl;
                            blog.DateTime = DateTime.Now;
                            blogService.Update(blog);
                            return RedirectToAction("Index", "Blog");
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
            //BlogViewModel mymodel = new BlogViewModel();
            //mymodel.Blog = blogService.Get(x => x.Id == id).Data;
            var model = blogService.Get(x => x.Id == id).Data;
            //mymodel.Comments = commentService.GetAll(x => x.BlogId == id && x.isDelete == false).Data;
            return View("Create", model);
        }
        public IActionResult Delete(int id)
        {
            blogService.SoftDelete(id);
            return RedirectToAction("Index", "Blog");
        }

        public IActionResult CommentDelete(int id)
        {
            if (HttpContext.Session.GetString("Name") == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            commentService.Delete(id);
            return RedirectToAction("Update", "Blog");
        }


        public async Task<IActionResult> ImageUpload(int id, IFormFile file)
        {
            BlogViewModel mymodel = new BlogViewModel();
            if (file is null)
            {
                mymodel.Blog = blogService.Get(x => x.Id == id).Data;
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
            var kayıt = blogService.Get(x => x.Id == id).Data;
            kayıt.ImageUrl = "/Images/" + dosyaAdi;
            var result = blogService.Update(kayıt);
            TempData["Mesaj"] = result.BasariliMi ? "Kayıt Eklendi." : result.Mesaj;

            mymodel.Blogs = blogService.GetAll().Data;
            mymodel.Blog = blogService.Get(x => x.Id == id).Data;
            return View(mymodel);
        }


        public IActionResult DeleteImage(int id)
        {
            var kayıt = blogService.Get(x => x.Id == id).Data;
            kayıt.ImageUrl = null;
            blogService.Update(kayıt);
            return RedirectToAction("Index", "Blog");
        }

        public IActionResult Active(int id)
        {
            var kayıt = blogService.Get(x => x.Id == id).Data;
            if (kayıt.isActive == false)
            {
                kayıt.isActive = true;
            }
            else
            {
                kayıt.isActive = false;
            }
            blogService.Update(kayıt);
            return RedirectToAction("Index", "Blog");
        }

        public IActionResult GetHomepage(int id)
        {
            var kayıt = blogService.Get(x => x.Id == id && x.isDelete == false).Data;
            if (kayıt.GetHomepage == true)
            {
                kayıt.GetHomepage = false;
            }
            else
            {
                kayıt.GetHomepage = true;
            }
            blogService.Update(kayıt);
            return RedirectToAction("Index", "Blog");
        }

    }
}
