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
using TaskApi;

namespace TaskApi.Controllers
{
    public class QuoteTypesController : ApiController
    {
        private TaskDBEntities db = new TaskDBEntities();

        // GET: api/QuoteTypes
        public IQueryable<QuoteType> GetQuoteTypes()
        {
            return db.QuoteTypes;
        }

        // GET: api/QuoteTypes/5
        [ResponseType(typeof(QuoteType))]
        public IHttpActionResult GetQuoteType(int id)
        {
            QuoteType quoteType = db.QuoteTypes.Find(id);
            if (quoteType == null)
            {
                return NotFound();
            }

            return Ok(quoteType);
        }

        // PUT: api/QuoteTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQuoteType(int id, QuoteType quoteType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != quoteType.Id)
            {
                return BadRequest();
            }

            db.Entry(quoteType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuoteTypeExists(id))
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

        // POST: api/QuoteTypes
        [ResponseType(typeof(QuoteType))]
        public IHttpActionResult PostQuoteType(QuoteType quoteType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.QuoteTypes.Add(quoteType);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (QuoteTypeExists(quoteType.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = quoteType.Id }, quoteType);
        }

        // DELETE: api/QuoteTypes/5
        [ResponseType(typeof(QuoteType))]
        public IHttpActionResult DeleteQuoteType(int id)
        {
            QuoteType quoteType = db.QuoteTypes.Find(id);
            if (quoteType == null)
            {
                return NotFound();
            }

            db.QuoteTypes.Remove(quoteType);
            db.SaveChanges();

            return Ok(quoteType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuoteTypeExists(int id)
        {
            return db.QuoteTypes.Count(e => e.Id == id) > 0;
        }
    }
}