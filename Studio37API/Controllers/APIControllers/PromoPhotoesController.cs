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
    public class PromoPhotoesController : ApiController
    {
        private DataModel db = new DataModel();

        // GET: api/PromoPhotoes
        public IQueryable<PromoPhoto> GetPromoPhotos()
        {
            return db.PromoPhotos;
        }

        // GET: api/PromoPhotoes/5
        [ResponseType(typeof(PromoPhoto))]
        public async Task<IHttpActionResult> GetPromoPhoto(Guid id)
        {
            PromoPhoto promoPhoto = await db.PromoPhotos.FindAsync(id);
            if (promoPhoto == null)
            {
                return NotFound();
            }

            return Ok(promoPhoto);
        }

        // PUT: api/PromoPhotoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPromoPhoto(Guid id, PromoPhoto promoPhoto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != promoPhoto.id)
            {
                return BadRequest();
            }

            db.Entry(promoPhoto).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromoPhotoExists(id))
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

        // POST: api/PromoPhotoes
        [ResponseType(typeof(PromoPhoto))]
        public async Task<IHttpActionResult> PostPromoPhoto(PromoPhoto promoPhoto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PromoPhotos.Add(promoPhoto);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PromoPhotoExists(promoPhoto.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = promoPhoto.id }, promoPhoto);
        }

        // DELETE: api/PromoPhotoes/5
        [ResponseType(typeof(PromoPhoto))]
        public async Task<IHttpActionResult> DeletePromoPhoto(Guid id)
        {
            PromoPhoto promoPhoto = await db.PromoPhotos.FindAsync(id);
            if (promoPhoto == null)
            {
                return NotFound();
            }

            db.PromoPhotos.Remove(promoPhoto);
            await db.SaveChangesAsync();

            return Ok(promoPhoto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PromoPhotoExists(Guid id)
        {
            return db.PromoPhotos.Count(e => e.id == id) > 0;
        }
    }
}