using eBlast_mvc.DAL;
using eBlast_mvc.Models;
using eBlast_mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eBlast_mvc.Controllers
{
    public class EmailTemplateController : Controller
    {
        private eBlastContext db = new eBlastContext();

        public ActionResult Index()
        {
            var emailTemplates = db.EmailTemplates.ToList();

            return View(emailTemplates);
        }

        [HttpGet]
        public EmailTemplate Get(int id)
        {
            return db.EmailTemplates.Find(id);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(EmailTemplateViewModel emailTemplateViewModel)
        {

            if(ModelState.IsValid)
            {
                EmailTemplate emailTemplate = new EmailTemplate()
                {
                    Body = emailTemplateViewModel.Body,
                    Name = emailTemplateViewModel.Name,
                    Subject = emailTemplateViewModel.Subject
                };

                db.EmailTemplates.Add(emailTemplate);
                db.SaveChanges();
                ViewBag.Success = true;
            }

            return View(emailTemplateViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int emailTemplateId)
        {
            EmailTemplate emailTemplate = db.EmailTemplates.Find(emailTemplateId);

            return View(emailTemplate);
        }

    }
}