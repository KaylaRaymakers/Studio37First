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
    public class LiveShowsController : ApiController
    {
        private DataModel db = new DataModel();

        // GET: api/LiveShows
        public IQueryable<LiveShow> GetLiveShows()
        {
            return db.LiveShows;
        }

        // GET: api/LiveShows/5
        [ResponseType(typeof(LiveShow))]
        public async Task<IHttpActionResult> GetLiveShow(Guid id)
        {
            LiveShow liveShow = await db.LiveShows.FindAsync(id);
            if (liveShow == null)
            {
                return NotFound();
            }

            return Ok(liveShow);
        }

        // PUT: api/LiveShows/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLiveShow(Guid id, LiveShow liveShow)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != liveShow.id)
            {
                return BadRequest();
            }

            db.Entry(liveShow).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LiveShowExists(id))
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

        // POST: api/LiveShows
        [ResponseType(typeof(LiveShow))]
        public async Task<IHttpActionResult> PostLiveShow(LiveShow liveShow)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LiveShows.Add(liveShow);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LiveShowExists(liveShow.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = liveShow.id }, liveShow);
        }

        // DELETE: api/LiveShows/5
        [ResponseType(typeof(LiveShow))]
        public async Task<IHttpActionResult> DeleteLiveShow(Guid id)
        {
            LiveShow liveShow = await db.LiveShows.FindAsync(id);
            if (liveShow == null)
            {
                return NotFound();
            }

            db.LiveShows.Remove(liveShow);
            await db.SaveChangesAsync();

            return Ok(liveShow);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LiveShowExists(Guid id)
        {
            return db.LiveShows.Count(e => e.id == id) > 0;
        }
    }
}