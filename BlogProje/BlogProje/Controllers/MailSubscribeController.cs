using BusinessLayer.Conrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProje.Controllers
{
    [AllowAnonymous]
    public class MailSubscribeController : Controller
    {
        SubscribeMailManager sm = new SubscribeMailManager(new EfSubscribeMailDal());

        [HttpGet] 
        public PartialViewResult AddMail()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult AddMail(SubscribeMail p)
        {            
            sm.TAdd(p);
            return PartialView();
        }

    }
}