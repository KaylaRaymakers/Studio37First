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
    public class TutorialPromoPhotoesController : ApiController
    {
        private DataModel db = new DataModel();

        // GET: api/TutorialPromoPhotoes
        public IQueryable<TutorialPromoPhoto> GetTutorialPromoPhotoes()
        {
            return db.TutorialPromoPhotoes;
        }

        // GET: api/TutorialPromoPhotoes/5
        [ResponseType(typeof(TutorialPromoPhoto))]
        public async Task<IHttpActionResult> GetTutorialPromoPhoto(Guid id)
        {
            TutorialPromoPhoto tutorialPromoPhoto = await db.TutorialPromoPhotoes.FindAsync(id);
            if (tutorialPromoPhoto == null)
            {
                return NotFound();
            }

            return Ok(tutorialPromoPhoto);
        }

        // PUT: api/TutorialPromoPhotoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTutorialPromoPhoto(Guid id, TutorialPromoPhoto tutorialPromoPhoto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tutorialPromoPhoto.id)
            {
                return BadRequest();
            }

            db.Entry(tutorialPromoPhoto).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TutorialPromoPhotoExists(id))
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

        // POST: api/TutorialPromoPhotoes
        [ResponseType(typeof(TutorialPromoPhoto))]
        public async Task<IHttpActionResult> PostTutorialPromoPhoto(TutorialPromoPhoto tutorialPromoPhoto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TutorialPromoPhotoes.Add(tutorialPromoPhoto);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TutorialPromoPhotoExists(tutorialPromoPhoto.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tutorialPromoPhoto.id }, tutorialPromoPhoto);
        }

        // DELETE: api/TutorialPromoPhotoes/5
        [ResponseType(typeof(TutorialPromoPhoto))]
        public async Task<IHttpActionResult> DeleteTutorialPromoPhoto(Guid id)
        {
            TutorialPromoPhoto tutorialPromoPhoto = await db.TutorialPromoPhotoes.FindAsync(id);
            if (tutorialPromoPhoto == null)
            {
                return NotFound();
            }

            db.TutorialPromoPhotoes.Remove(tutorialPromoPhoto);
            await db.SaveChangesAsync();

            return Ok(tutorialPromoPhoto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TutorialPromoPhotoExists(Guid id)
        {
            return db.TutorialPromoPhotoes.Count(e => e.id == id) > 0;
        }
    }
}