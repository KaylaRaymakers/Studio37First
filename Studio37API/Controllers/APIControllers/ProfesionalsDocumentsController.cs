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
    public class ProfesionalsDocumentsController : ApiController
    {
        private DataModel db = new DataModel();

        // GET: api/ProfesionalsDocuments
        public IQueryable<ProfesionalsDocument> GetProfesionalsDocuments()
        {
            return db.ProfesionalsDocuments;
        }

        // GET: api/ProfesionalsDocuments/5
        [ResponseType(typeof(ProfesionalsDocument))]
        public async Task<IHttpActionResult> GetProfesionalsDocument(Guid id)
        {
            ProfesionalsDocument profesionalsDocument = await db.ProfesionalsDocuments.FindAsync(id);
            if (profesionalsDocument == null)
            {
                return NotFound();
            }

            return Ok(profesionalsDocument);
        }

        // PUT: api/ProfesionalsDocuments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProfesionalsDocument(Guid id, ProfesionalsDocument profesionalsDocument)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profesionalsDocument.id)
            {
                return BadRequest();
            }

            db.Entry(profesionalsDocument).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfesionalsDocumentExists(id))
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

        // POST: api/ProfesionalsDocuments
        [ResponseType(typeof(ProfesionalsDocument))]
        public async Task<IHttpActionResult> PostProfesionalsDocument(ProfesionalsDocument profesionalsDocument)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProfesionalsDocuments.Add(profesionalsDocument);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProfesionalsDocumentExists(profesionalsDocument.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = profesionalsDocument.id }, profesionalsDocument);
        }

        // DELETE: api/ProfesionalsDocuments/5
        [ResponseType(typeof(ProfesionalsDocument))]
        public async Task<IHttpActionResult> DeleteProfesionalsDocument(Guid id)
        {
            ProfesionalsDocument profesionalsDocument = await db.ProfesionalsDocuments.FindAsync(id);
            if (profesionalsDocument == null)
            {
                return NotFound();
            }

            db.ProfesionalsDocuments.Remove(profesionalsDocument);
            await db.SaveChangesAsync();

            return Ok(profesionalsDocument);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProfesionalsDocumentExists(Guid id)
        {
            return db.ProfesionalsDocuments.Count(e => e.id == id) > 0;
        }
    }
}