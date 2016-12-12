using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBlast_mvc.Models
{
    public class ContactGroup
    {
        [Key]
        public int ContactGroupId { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage ="Please enter a name for this group.")]
        [StringLength(50, ErrorMessage ="Please enter a group name that is less than 51 characters.")]
        public string Name { get; set; }

        public virtual ICollection<Contact> Contact { get; set; } 
    }
}