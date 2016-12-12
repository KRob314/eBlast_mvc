using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using eBlast_mvc.DAL;
using eBlast_mvc.Models;

namespace eBlast_mvc.Controllers.API
{
    public class EmailTemplatesController : ApiController
    {
        private eBlastContext db = new eBlastContext();

        // GET: api/EmailTemplates
        public IQueryable<EmailTemplate> GetEmailTemplates()
        {
            return db.EmailTemplates;
        }

        // GET: api/EmailTemplates/5
        [ResponseType(typeof(EmailTemplate))]
        public IHttpActionResult GetEmailTemplate(int id)
        {
            EmailTemplate emailTemplate = db.EmailTemplates.Find(id);
            if (emailTemplate == null)
            {
                return NotFound();
            }

            return Ok(emailTemplate);
        }

        // PUT: api/EmailTemplates/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmailTemplate(int id, EmailTemplate emailTemplate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != emailTemplate.EmailTemplateId)
            {
                return BadRequest();
            }

            db.Entry(emailTemplate).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailTemplateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/EmailTemplates
        [ResponseType(typeof(EmailTemplate))]
        public IHttpActionResult PostEmailTemplate(EmailTemplate emailTemplate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmailTemplates.Add(emailTemplate);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = emailTemplate.EmailTemplateId }, emailTemplate);
        }

        // DELETE: api/EmailTemplates/5
        [ResponseType(typeof(EmailTemplate))]
        public IHttpActionResult DeleteEmailTemplate(int id)
        {
            EmailTemplate emailTemplate = db.EmailTemplates.Find(id);
            if (emailTemplate == null)
            {
                return NotFound();
            }

            db.EmailTemplates.Remove(emailTemplate);
            db.SaveChanges();

            return Ok(emailTemplate);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmailTemplateExists(int id)
        {
            return db.EmailTemplates.Count(e => e.EmailTemplateId == id) > 0;
        }
    }
}