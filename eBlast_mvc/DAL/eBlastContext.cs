using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using eBlast_mvc.Models;

namespace eBlast_mvc.DAL
{
    public class eBlastContext : DbContext
    {
        public eBlastContext() : base("eBlastContext")
        {

        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactGroup> ContactGroups { get; set; }
        public DbSet<EmailTemplate> EmailTemplates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<eBlast_mvc.ViewModels.ContactViewModel> ContactViewModels { get; set; }
    }
}