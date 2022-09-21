﻿using System;
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
    public class TaskTypesController : ApiController
    {
        private TaskDBEntities db = new TaskDBEntities();

        // GET: api/TaskTypes
        public IQueryable<TaskType> GetTaskTypes()
        {
            return db.TaskTypes;
        }

        // GET: api/TaskTypes/5
        [ResponseType(typeof(TaskType))]
        public IHttpActionResult GetTaskType(int id)
        {
            TaskType taskType = db.TaskTypes.Find(id);
            if (taskType == null)
            {
                return NotFound();
            }

            return Ok(taskType);
        }

        // PUT: api/TaskTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTaskType(int id, TaskType taskType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taskType.Id)
            {
                return BadRequest();
            }

            db.Entry(taskType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskTypeExists(id))
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

        // POST: api/TaskTypes
        [ResponseType(typeof(TaskType))]
        public IHttpActionResult PostTaskType(TaskType taskType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TaskTypes.Add(taskType);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TaskTypeExists(taskType.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = taskType.Id }, taskType);
        }

        // DELETE: api/TaskTypes/5
        [ResponseType(typeof(TaskType))]
        public IHttpActionResult DeleteTaskType(int id)
        {
            TaskType taskType = db.TaskTypes.Find(id);
            if (taskType == null)
            {
                return NotFound();
            }

            db.TaskTypes.Remove(taskType);
            db.SaveChanges();

            return Ok(taskType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaskTypeExists(int id)
        {
            return db.TaskTypes.Count(e => e.Id == id) > 0;
        }
    }
}