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
    public class PersonnelController : ApiController
    {
        private TaskDBEntities db = new TaskDBEntities();

        // GET: api/Personnel
        public IQueryable<Personnel> GetPersonnels()
        {
            return db.Personnels;
        }

        // GET: api/Personnel/5
        [ResponseType(typeof(Personnel))]
        public IHttpActionResult GetPersonnel(int id)
        {
            Personnel personnel = db.Personnels.Find(id);
            if (personnel == null)
            {
                return NotFound();
            }

            return Ok(personnel);
        }

        // PUT: api/Personnel/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersonnel(int id, Personnel personnel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personnel.Id)
            {
                return BadRequest();
            }

            db.Entry(personnel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonnelExists(id))
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

        // POST: api/Personnel
        [ResponseType(typeof(Personnel))]
        public IHttpActionResult PostPersonnel(Personnel personnel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Personnels.Add(personnel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PersonnelExists(personnel.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = personnel.Id }, personnel);
        }

        // DELETE: api/Personnel/5
        [ResponseType(typeof(Personnel))]
        public IHttpActionResult DeletePersonnel(int id)
        {
            Personnel personnel = db.Personnels.Find(id);
            if (personnel == null)
            {
                return NotFound();
            }

            db.Personnels.Remove(personnel);
            db.SaveChanges();

            return Ok(personnel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonnelExists(int id)
        {
            return db.Personnels.Count(e => e.Id == id) > 0;
        }
    }
}