using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eBlast_mvc.ViewModels
{
    public class ContactGroupViewModel
    {
        public int ContactGroupId { get; set; }
        
        [Required(ErrorMessage ="Please enter a name for the contact group.")]
        [Display(Name ="Group Name")]
        public string Name { get; set; }
    }
}