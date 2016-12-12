using eBlast_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eBlast_mvc.ViewModels
{
    [Serializable]
    public class ddContactsViewModel
    {
        public List<Contact> Contacts { get; set; }
        public List<SelectListItem> ContactsList = new List<SelectListItem>();

        public ddContactsViewModel()
        {
            if(Contacts != null)
            {
                foreach(Contact c in Contacts)
            {
                    ContactsList.Add(new SelectListItem
                    {
                        Text = c.FirstName + " " + c.LastName,
                        Value = c.Email
                    });
                }
            }
        }
    }
}