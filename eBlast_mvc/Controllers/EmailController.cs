using eBlast_mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eBlast_mvc.DAL;
using eBlast_mvc.Core;
using eBlast_mvc.Models;

namespace eBlast_mvc.Controllers
{
    public class EmailController : Controller
    {
        private eBlastContext db = new eBlastContext();

        [HttpGet]
        public ActionResult Send()
        {
            var contactGroups = db.ContactGroups;

            List<SelectListItem> contactGroupItems = new List<SelectListItem>();

            foreach (var cg in contactGroups)
            {
                contactGroupItems.Add(new SelectListItem { Text = cg.Name, Value = cg.ContactGroupId.ToString() });
            }

            EmailViewModel viewModel = new EmailViewModel()
            {
                ContactGroups = contactGroupItems,
                EmailTemplates = db.EmailTemplates.ToList()
            };

            ViewBag.ContactId = new SelectList(db.Contacts, "ContactId", "Email", viewModel.ContactId);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Send(EmailViewModel viewModel)
        {

            if(ModelState.IsValid)
            {
                var emailAddresses = db.Contacts.Where(c => c.ContactGroupId == viewModel.ContactGroupId || c.ContactId == viewModel.ContactId);

                foreach (var address in emailAddresses)
                {
                    viewModel.Recipient.Add(address.Email);
                }

                ViewBag.Success = true;

                RedirectToAction("Index", "Contacts");
            }

          

            // Email emailSender = new Email(email.Recipients, email.Subject, email.Body);

            return View(viewModel);
        }
    }
}