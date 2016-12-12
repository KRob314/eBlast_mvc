using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eBlast_mvc.Models;

namespace eBlast_mvc.DAL
{
    public class eBlastInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<eBlastContext>
    {
        //public eBlastInitializer()
        //{
        //    Seed(new eBlastContext());
        //}

        protected override void Seed(eBlastContext context)
        {

            var contacts = new List<Contact>()
            {
                new Contact{ ContactId =1,FirstName ="Luke", Email="lukesdsadfdavid@championBSA.com", ContactGroupId = 1},
                new Contact{ ContactId =2,FirstName ="Mark", Email="abdkla@aol.com", ContactGroupId = 1},
                new Contact{ ContactId =3,FirstName ="Zack", Email="pbrossawnadlee@brownlees.com", ContactGroupId = 2},
                new Contact{ ContactId =4,FirstName ="charles", Email="aomski@aol.com", ContactGroupId = 3 },
                new Contact{ ContactId =5,FirstName ="Guy", Email="saa2m@aol.com"},
                new Contact{ ContactId =6,FirstName ="Paul", Email="pbrownadlee@brosdwnlees.com", ContactGroupId = 3},
                new Contact{ ContactId =7,FirstName ="Paul", Email="pbrownlee@browsddsnlees.com", ContactGroupId = 3},
                new Contact{ ContactId =8,FirstName ="Josh", Email="Joassh@ForcSpoaaassdfrts.com"},
                new Contact{ ContactId =9,FirstName ="Larry", Email="Larsdry@Force-Spoa2adrts.com"},
                new Contact{ ContactId =10,FirstName ="charles", Email="klsjka@sol.com", ContactGroupId = 3},
                new Contact{ ContactId =11,FirstName ="Scott", Email="abcsdkla@aol.com"},
                new Contact{ ContactId =12,FirstName ="Pat", Email="abdkla@aol.com"},
                new Contact{ ContactId =13,FirstName ="Jacob", Email="j_bdaniel@yahoasdo.com", ContactGroupId = 1},
                new Contact{ ContactId =14,FirstName ="Jeff", Email="pizasdfza7up@aol.com"},
                new Contact{ ContactId =15,FirstName ="Paul", Email="abwdkla@aol.com"}

            };

            var contactGroups = new List<ContactGroup>()
            {
                new ContactGroup { ContactGroupId = 1, Name = "Group A" },
                new ContactGroup { ContactGroupId = 2, Name= "Group B" }, 
                new ContactGroup {ContactGroupId = 3, Name = "Group C" }
            };

            var emailTemplates = new List<EmailTemplate>()
            {
                new EmailTemplate {EmailTemplateId = 1, Name = "eblast 1", Subject = "eblast 1",
                    Body = @"How to hide your important files from people without making Hidden folders </br>
                1. Go to Desktop and create a new folder </br>
                2. Name the folder Internet Explorer </br>
                3. Change the folder icon to Internet Explorer </br>
                4. Keep it in a corner of the desktop"  }, 
                
                new EmailTemplate {EmailTemplateId = 2, Name = "eblast 2", Subject = "eblast 2",
                Body = @"<span style=""background-color: rgb(255, 255, 255); ""><font color=""#0066ff""><span style=""font-family: Arial; font-size: 16px;"">Q: ""Whats the object-oriented way to become wealthy?""</span><br style=""position: relative; word-wrap: break-word; font-family: Arial; font-size: 16px;""><span style=""font-family: Arial; font-size: 16px;"">A: Inheritance</span></font></span>"}, 

                new EmailTemplate {EmailTemplateId = 3, Name = "eblast 3", Subject = "eblast 3",
                Body = @"<div class=""block-panel"" style=""position: relative; word - wrap: break-word; margin: 10px; padding: 10px; color: rgb(204, 204, 204); background - color: rgb(51, 51, 51); font - family: Arial; font - size: 16px; "">To understand what recursion is, you must first understand recursion.</div><div><img src=""https://codehs.gitbooks.io/apjava/content/static/algorithms/Algorithms_Recursion_Example.jpg""><br></div>"}
            };

            contacts.ForEach(c => context.Contacts.Add(c));
            contactGroups.ForEach(cg => context.ContactGroups.Add(cg));
            emailTemplates.ForEach(et => context.EmailTemplates.Add(et));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}