using BusinessLayer.Conrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Conrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogProje.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: User
        UserProfileManager userprofile = new UserProfileManager();
        BlogManager bm = new BlogManager(new EfBlogDal());
        AuthorManager authormanager = new AuthorManager(new EfAuthorDal());
        Author author = new Author();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Partial1(string p)
        {
            
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/image/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                author.AuthorImage = "/image/" + dosyaAdi + uzanti;
            }
            p = (string)Session["Mail"];
            var profilevalus = userprofile.GetAuthorByMail(p);
            return PartialView(profilevalus);
        }

        public ActionResult UpdateUserProfile(Author p)
        {
            Author author = new Author();
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/image/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                author.AuthorImage = "/image/" + dosyaAdi + uzanti;
            }
            userprofile.EditAuthor(p);
            return RedirectToAction("BlogList", "User");
        }

        public ActionResult BlogList(string p)
        {
            p = (string)Session["Mail"];
            Context c = new Context();
            int id = c.Authors.Where(a => a.Mail == p).Select(b => b.AuthorID).FirstOrDefault();
            var blogs =userprofile.GetBlogByAuthor(id);
            return View(blogs);
        }

        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {

            Blog blog = bm.GetByID(id);
            Context c = new Context();
            List<SelectListItem> values = (from a in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = a.CategoryName,
                                               Value = a.CategoryID.ToString()
                                           }).ToList();
            ViewBag.values = values;

            List<SelectListItem> values2 = (from a in c.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = a.AuthorName,
                                                Value = a.AuthorID.ToString()
                                            }).ToList();
            ViewBag.values2 = values2;
            return View(blog);
        }

        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/image/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.BlogImage = "/image/" + dosyaAdi + uzanti;
            }
            bm.TUpdate(p);
            return RedirectToAction("BlogList");
        }

        [HttpGet]
        public ActionResult AddNewBlog()
        {
            Context c = new Context();
            List<SelectListItem> values = (from a in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = a.CategoryName,
                                               Value = a.CategoryID.ToString()
                                           }).ToList();
            ViewBag.values = values;

            List<SelectListItem> values2 = (from a in c.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = a.AuthorName,
                                                Value = a.AuthorID.ToString()
                                            }).ToList();
            ViewBag.values2 = values2;

            return View();
        }

        [HttpPost]
        public ActionResult AddNewBlog(Blog p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/image/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.BlogImage = "/image/" + dosyaAdi + uzanti;
            }
            p.BlogDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            bm.TAdd(p);
            return RedirectToAction("BlogList");
        }
        
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AuthorLogin","Login");
        }

    }
}