using FluentValidation.Results;
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
using System.Web.Http.Results;
using TaskApiNew.Helpers;
using TaskApiNew.Models;

namespace TaskApiNew.Controllers
{
    [Helpers.CheckForNullArguments]
    public class QuotesController : ApiController
    {
        private readonly TaskEntities db = new TaskEntities();
        private readonly QuoteValidator _validator;

        public QuotesController()
        {
            _validator = new QuoteValidator(db);
        }

        // GET: api/Quotes
        public IQueryable<Quote> GetQuotes()
        {
            return db.Quotes;
        }

        // GET: api/Quotes/5
        [ResponseType(typeof(Quote))]
        public IHttpActionResult GetQuote(string id)
        {
            Quote quote = db.Quotes.Find(id);
            if (quote == null)
            {
                return NoItemFound(id);
            }

            return Ok(quote);
        }

        // PUT: api/Quotes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQuote(string id, Quote quote)
        {
            ValidationResult results = _validator.Validate(quote);

            if (!results.IsValid)
            {
                return new ResponseMessageResult(new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(results.ToString(@"\n"))
                });
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
                if (!QuoteExists(id))
                {
                    return NoItemFound(quote.Id);
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Quotes
        [ResponseType(typeof(Quote))]
        public IHttpActionResult PostQuote(Quote quote)
        {
            ValidationResult results = _validator.Validate(quote);

            if (!results.IsValid)
            {
                return new ResponseMessageResult(new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(results.ToString("~"))
                });
            }

            db.Quotes.Add(quote);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = quote.Id }, quote);
        }

        // DELETE: api/Quotes/5
        [ResponseType(typeof(Quote))]
        public IHttpActionResult DeleteQuote(string id)
        {
            Quote quote = db.Quotes.Find(id);
            if (quote == null)
            {
                return NoItemFound(id);
            }

            db.Quotes.Remove(quote);
            db.SaveChanges();

            return Ok(quote);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuoteExists(string id)
        {
            return db.Quotes.Count(e => e.Id == id) > 0;
        }

        private IHttpActionResult NoItemFound(string id)
        {
            return new ResponseMessageResult(new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(String.Format("A quote with the id {0} cannot be found", id))
            });
        }

        private IHttpActionResult Exists(string id)
        {
            return new ResponseMessageResult(new HttpResponseMessage(HttpStatusCode.Conflict)
            {
                Content = new StringContent(String.Format("A quote with the id {0} already exists", id))
            });
        }
    }
}