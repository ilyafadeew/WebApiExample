using System;
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
using WebApiExample;
using WebApiExample.Models;

namespace WebApiExample.Controllers
{
    public class StatisticController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Statistics
        public IQueryable<Statistic> GetStatistics()
        {
            return db.Statistics;
        }

        // GET: api/Statistics/5
        [ResponseType(typeof(Statistic))]
        public async Task<IHttpActionResult> GetStatistic(int id)
        {
            Statistic statistic = await db.Statistics.FindAsync(id);
            if (statistic == null)
            {
                return NotFound();
            }

            return Ok(statistic);
        }

        // PUT: api/Statistics/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStatistic(int id, Statistic statistic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statistic.Id)
            {
                return BadRequest();
            }

            db.Entry(statistic).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatisticExists(id))
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

        // POST: api/Statistics
        [ResponseType(typeof(Statistic))]
        public async Task<IHttpActionResult> PostStatistic(Statistic statistic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Statistics.Add(statistic);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = statistic.Id }, statistic);
        }

        // DELETE: api/Statistics/5
        [ResponseType(typeof(Statistic))]
        public async Task<IHttpActionResult> DeleteStatistic(int id)
        {
            Statistic statistic = await db.Statistics.FindAsync(id);
            if (statistic == null)
            {
                return NotFound();
            }

            db.Statistics.Remove(statistic);
            await db.SaveChangesAsync();

            return Ok(statistic);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatisticExists(int id)
        {
            return db.Statistics.Count(e => e.Id == id) > 0;
        }
    }
}

