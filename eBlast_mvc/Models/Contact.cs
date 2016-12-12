using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eBlast_mvc.Models
{
    public class Contact
    {
       [Key]
        public int ContactId { get; set; }
       
        public int? ContactGroupId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required (AllowEmptyStrings =false, ErrorMessage ="Please enter an email address.")]
        public string Email { get; set; }

        [ForeignKey("ContactGroupId")]
        public virtual ICollection<ContactGroup> ContactGroups { get; set; }
    }
}