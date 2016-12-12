using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eBlast_mvc.DAL;
using eBlast_mvc.Models;
using System.Net;
using eBlast_mvc.ViewModels;
using System.Data.Entity.Core;

namespace eBlast_mvc.Controllers
{
    public class ContactController : Controller
    {
        private eBlastContext db = new eBlastContext();

        //public ContactController()
        //{
        //    db = new eBlastContext();
        //}

        [HttpGet]
        public ActionResult Index()
        {
            var contacts = db.Contacts;

            return View(contacts.ToList());
        }


        // GET: Contact
        [HttpGet]
        public ActionResult Add()
        {
            ContactViewModel viewModel = new ContactViewModel()
            {
                ContactGroups = db.ContactGroups.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ContactViewModel contactViewModel, FormCollection form)
        {

            if (ModelState.IsValid)
            {
                Contact contact = new Contact()
                {
                    ContactGroupId = (form["ContactGroups"] != null) ? Convert.ToInt32(form["ContactGroups"]) : default(int?),
                    FirstName = contactViewModel.FirstName,
                    LastName = contactViewModel.LastName,
                    Email = contactViewModel.Email
                };

                db.Contacts.Add(contact);
                db.SaveChanges();
                ViewBag.Success = true;

                return View();
            }

            return View(contactViewModel);

        }

        [HttpGet]
        public ActionResult Edit(int? contactId)
        {
            var contact = db.Contacts.Find(contactId);
            //ContactViewModel viewModel = new ContactViewModel()
            //{
            //     ContactGroups = db.ContactGroups.ToList(), 
            //     ContactGroupId = contact.ContactGroupId != null ? contact.ContactGroupId : (int?) null,               
            //};

            if (contact == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Contact contact)
        {

            if (ModelState.IsValid)
            {
                db.Entry(contact).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                ViewBag.Success = true;

                return View(contact);
            }

            return View(contact);
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            Contact viewModel = db.Contacts.Find(Id);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Contact contact)
        {
            db.Entry(contact).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}