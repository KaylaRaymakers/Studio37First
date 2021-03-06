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
    public class StickersController : ApiController
    {
        private DataModel db = new DataModel();

        // GET: api/Stickers
        public IQueryable<Sticker> GetStickers()
        {
            return db.Stickers;
        }

        // GET: api/Stickers/5
        [ResponseType(typeof(Sticker))]
        public async Task<IHttpActionResult> GetSticker(Guid id)
        {
            Sticker sticker = await db.Stickers.FindAsync(id);
            if (sticker == null)
            {
                return NotFound();
            }

            return Ok(sticker);
        }

        // PUT: api/Stickers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSticker(Guid id, Sticker sticker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sticker.id)
            {
                return BadRequest();
            }

            db.Entry(sticker).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StickerExists(id))
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

        // POST: api/Stickers
        [ResponseType(typeof(Sticker))]
        public async Task<IHttpActionResult> PostSticker(Sticker sticker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Stickers.Add(sticker);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StickerExists(sticker.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sticker.id }, sticker);
        }

        // DELETE: api/Stickers/5
        [ResponseType(typeof(Sticker))]
        public async Task<IHttpActionResult> DeleteSticker(Guid id)
        {
            Sticker sticker = await db.Stickers.FindAsync(id);
            if (sticker == null)
            {
                return NotFound();
            }

            db.Stickers.Remove(sticker);
            await db.SaveChangesAsync();

            return Ok(sticker);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StickerExists(Guid id)
        {
            return db.Stickers.Count(e => e.id == id) > 0;
        }
    }
}