using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eBlast_mvc.Models
{
    public class EmailTemplate
    {
        [Key]
        public int EmailTemplateId { get; set; }

        [Required (AllowEmptyStrings =false, ErrorMessage ="Please enter a name.")]
        [StringLength(50, ErrorMessage = "Please enter a name less than 51 characters.")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a subject.")]
        [StringLength(75, ErrorMessage = "Please enter a name less than 75 characters.")]
        public string Subject { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter text for the body of the email.")]
        [StringLength(1500, ErrorMessage = "Please enter an email body with less than 1500 characters.")]
        public string Body { get; set; }

    }
}