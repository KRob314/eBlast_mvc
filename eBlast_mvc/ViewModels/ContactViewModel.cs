using eBlast_mvc.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace eBlast_mvc.ViewModels
{
    public class ContactViewModel
    {
        [Key]
        [Display(Name ="Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactId { get; set; }

        public int? ContactGroupId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Please enter an email address.")]
        public string Email { get; set; }

        [Display(Name = "Contact Group")]
        public List<ContactGroup> ContactGroups { get; set; }

    }
}