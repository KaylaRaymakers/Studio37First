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
    public class TutorialCattegoriesController : ApiController
    {
        private DataModel db = new DataModel();

        // GET: api/TutorialCattegories
        public IQueryable<TutorialCattegory> GetTutorialCattegories()
        {
            return db.TutorialCattegories;
        }

        // GET: api/TutorialCattegories/5
        [ResponseType(typeof(TutorialCattegory))]
        public async Task<IHttpActionResult> GetTutorialCattegory(Guid id)
        {
            TutorialCattegory tutorialCattegory = await db.TutorialCattegories.FindAsync(id);
            if (tutorialCattegory == null)
            {
                return NotFound();
            }

            return Ok(tutorialCattegory);
        }

        // PUT: api/TutorialCattegories/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTutorialCattegory(Guid id, TutorialCattegory tutorialCattegory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tutorialCattegory.id)
            {
                return BadRequest();
            }

            db.Entry(tutorialCattegory).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TutorialCattegoryExists(id))
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

        // POST: api/TutorialCattegories
        [ResponseType(typeof(TutorialCattegory))]
        public async Task<IHttpActionResult> PostTutorialCattegory(TutorialCattegory tutorialCattegory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TutorialCattegories.Add(tutorialCattegory);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TutorialCattegoryExists(tutorialCattegory.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tutorialCattegory.id }, tutorialCattegory);
        }

        // DELETE: api/TutorialCattegories/5
        [ResponseType(typeof(TutorialCattegory))]
        public async Task<IHttpActionResult> DeleteTutorialCattegory(Guid id)
        {
            TutorialCattegory tutorialCattegory = await db.TutorialCattegories.FindAsync(id);
            if (tutorialCattegory == null)
            {
                return NotFound();
            }

            db.TutorialCattegories.Remove(tutorialCattegory);
            await db.SaveChangesAsync();

            return Ok(tutorialCattegory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TutorialCattegoryExists(Guid id)
        {
            return db.TutorialCattegories.Count(e => e.id == id) > 0;
        }
    }
}