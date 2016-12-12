using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eBlast_mvc.DAL;
using eBlast_mvc.Models;

namespace eBlast_mvc.Controllers
{
    public class ContactGroupsController : Controller
    {
        private eBlastContext db = new eBlastContext();


        [HttpGet]
        public ActionResult Index()
        {
            var contactGroups = db.ContactGroups.ToList();

            return View(contactGroups);
        }

        [HttpGet]
        public ActionResult Edit(int contactGroupId)
        {
            ContactGroup contactGroup = db.ContactGroups.Find(contactGroupId);

            return View(contactGroup);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ContactGroup contactGroup)
        {
           if(ModelState.IsValid)
            {
                db.Entry(contactGroup).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                ViewBag.Success = true;
                return View();
            }

            return View(contactGroup);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ContactGroup viewModel)
        {
            if(ModelState.IsValid)
            {
                db.ContactGroups.Add(new ContactGroup()
                {
                    Name = viewModel.Name
                });

                db.SaveChanges();
                ViewBag.Success = true;
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Delete(int contactGroupId)
        {
            ContactGroup viewModel = db.ContactGroups.Find(contactGroupId);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Delete(ContactGroup viewModel)
        {
            db.Entry(viewModel).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}