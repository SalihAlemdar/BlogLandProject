using BlogProje.Models;
using BusinessLayer.Conrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Conrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProje.Controllers
{   
    public class AuthorController : Controller
    {
        // GET: Author
        BlogManager blogmanager = new BlogManager(new EfBlogDal());
        AuthorManager authormanager = new AuthorManager(new EfAuthorDal());
        Context c = new Context();

        [AllowAnonymous]
        public PartialViewResult AuthorAbout(int id)
        {
            var authordetail = blogmanager.GetBlogByID(id);
            return PartialView(authordetail);
        }

        [AllowAnonymous]
        public PartialViewResult AuthorPopularPost(int id)
        {
            var blogauthorid = blogmanager.GetList().Where(a => a.BlogID == id).Select(b => b.AuthorID).FirstOrDefault();
            var authorblogs = blogmanager.GetBlogByAuthor(blogauthorid);
            return PartialView(authorblogs);
        }

        public ActionResult AuthorList()
        {
            var authorlists= authormanager.GetList();
            return View(authorlists);
        }

        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAuthor(Author p)
        {
            AuthorValidator authorValidation = new AuthorValidator();
            ValidationResult results = authorValidation.Validate(p);
            if (results.IsValid)
            {
                authormanager.AuthorAdd(p);
                return RedirectToAction("AuthorList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();           
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult AddBlogAuthor()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult AddBlogAuthor(Author p)
        {
            AuthorValidator authorValidation = new AuthorValidator();
            ValidationResult results = authorValidation.Validate(p);
             
            if (results.IsValid)
            {
                if (Request.Files.Count>0)
                {
                    string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/image/" + dosyaAdi + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    p.AuthorImage = "/image/" + dosyaAdi + uzanti;
                }
                authormanager.AuthorAdd(p);
                return RedirectToAction("AuthorLogin", "Login");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }


        public ActionResult AuthorDelete(int id)
        {
            authormanager.AuthorStatusFalseBL(id);
            return RedirectToAction("AuthorList");
        }

        public ActionResult AuthorStatusTrue(int id)
        {
            authormanager.AuthorStatusTrueBL(id);
            return RedirectToAction("AuthorList");
        }


        [HttpGet]
        public ActionResult AuthorEdit(int id)
        {
            Author author = authormanager.GetByID(id);
            return View(author);
        }

        [HttpPost]
        public ActionResult AuthorEdit(Author p)        
        {
            AuthorValidator authorValidation = new AuthorValidator();
            ValidationResult results = authorValidation.Validate(p);
            if (results.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/image/" + dosyaAdi + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    p.AuthorImage = "/image/" + dosyaAdi + uzanti;
                }
                authormanager.AuthorUpdate(p);
                return RedirectToAction("AuthorList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();            
        }

    }
}