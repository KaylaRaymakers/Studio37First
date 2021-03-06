﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Studio37API.Models.DataBaseMdels;

namespace Studio37API.Controllers.APIControllers
{
    public class TutorialsController : ApiController
    {
        private DataModel db = new DataModel();

        // GET: api/Tutorials
        public IQueryable<Tutorial> GetTutorials()
        {
            return db.Tutorials;
        }

        // GET: api/Tutorials/5
        [ResponseType(typeof(Tutorial))]
        public async Task<IHttpActionResult> GetTutorial(Guid id)
        {
            Tutorial tutorial = await db.Tutorials.FindAsync(id);
            if (tutorial == null)
            {
                return NotFound();
            }

            return Ok(tutorial);
        }

        // PUT: api/Tutorials/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTutorial(Guid id, Tutorial tutorial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tutorial.id)
            {
                return BadRequest();
            }

            db.Entry(tutorial).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TutorialExists(id))
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

        // POST: api/Tutorials
        [ResponseType(typeof(Tutorial))]
        public async Task<IHttpActionResult> PostTutorial(Tutorial tutorial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tutorials.Add(tutorial);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TutorialExists(tutorial.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tutorial.id }, tutorial);
        }

        // DELETE: api/Tutorials/5
        [ResponseType(typeof(Tutorial))]
        public async Task<IHttpActionResult> DeleteTutorial(Guid id)
        {
            Tutorial tutorial = await db.Tutorials.FindAsync(id);
            if (tutorial == null)
            {
                return NotFound();
            }

            db.Tutorials.Remove(tutorial);
            await db.SaveChangesAsync();

            return Ok(tutorial);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TutorialExists(Guid id)
        {
            return db.Tutorials.Count(e => e.id == id) > 0;
        }
    }
}