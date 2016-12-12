using eBlast_mvc.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using eBlast_mvc.Models;
using System.Web.Mvc;

namespace eBlast_mvc.ViewModels
{
    public class EmailViewModel
    {
        private eBlastContext db = new eBlastContext();

        public int ContactGroupId { get; set; }
        public int ContactId { get; set; }

        [Required (AllowEmptyStrings = false, ErrorMessage ="Please enter a subject.")]
        [StringLength(75, ErrorMessage ="Subject cannot be longer than 75 characters.")]
        [Display(Name = "Subject")]
        public string Subject { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter text in the body of the email.")]
        [AllowHtml]
        [Display(Name = "Body")]
        public string Body { get; set; }

        [Display(Name = "ContactId")]
        public  Contact Contacts { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Pleasesad.")]
        public List<string> Recipient { get; set; }

        //[Display(Name = "Contact Groups")]
        public IEnumerable<SelectListItem> ContactGroups { get; set; }

        [Display(Name = "Template")]
        public List<EmailTemplate> EmailTemplates { get; set; }


        public EmailViewModel()
        {
            this.Recipient = new List<string>();
        }
    }
}