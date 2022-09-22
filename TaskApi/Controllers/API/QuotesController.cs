using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TaskApi.ApiControllers
{
    using Models;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Web.Http.Description;

    [Authorize]
    public class QuotesController : ApiController
    {
        private readonly TaskContext db = new TaskContext();

        // GET api/quotes
        public IQueryable<Quote> Get()
        {
            return db.Quotes;
        }

        // GET api/quotes/5
        public IHttpActionResult Get(string id)
        {
            Quote quote = db.Quotes.Find(id);
            if (quote == null)
            {
                return NotFound();
            }

            return Ok(quote);
        }

        // POST api/quotes
        [ResponseType(typeof(Quote))]
        public IHttpActionResult Post([FromBody] Quote quote)
        {
            if (db.Quotes.Any(q => q.Id == quote.Id))
            {
                return BadRequest("A quote with this ID exists");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Quotes.Add(quote);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (db.Quotes.Find(quote.Id) != null)
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = quote.Id }, quote);
        }

        // PUT api/quotes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(string id, [FromBody] Quote quote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != quote.Id)
            {
                return BadRequest();
            }

            db.Entry(quote).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (db.Quotes.Find(quote.Id) == null)
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

        // DELETE api/quotes/5
        public IHttpActionResult Delete(string id)
        {
            Quote quote = db.Quotes.Find(id);
            if (quote == null)
            {
                return NotFound();
            }

            db.Quotes.Remove(quote);
            db.SaveChanges();

            return Ok(quote);
        }
    }
}