using System.Collections.Generic;
using System.Linq;
using System.Net;
using AspNetMvcCoreExamples.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetMvc5Examples.Web.Controllers
{
    [Route("/api/movies")]
    public class MoviesApiController : ControllerBase
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public MoviesApiController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: api/Movies
        public IQueryable<Movie> GetMovies()
        {
            return this.context.Movies;
        }

        // GET: api/Movies/5
        public IActionResult GetMovie(int id)
        {
            Movie movie = this.context.Movies.Find(id);
            if (movie == null)
            {
                return this.NotFound();
            }

            return this.Ok(movie);
        }

        // PUT: api/Movies/5
        public IActionResult PutMovie(int id, Movie movie)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != movie.Id)
            {
                return this.BadRequest();
            }

            this.context.Entry(movie).State = EntityState.Modified;

            try
            {
                this.context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.MovieExists(id))
                {
                    return this.NotFound();
                }
                else
                {
                    throw;
                }
            }

            return this.StatusCode((int)HttpStatusCode.NoContent);
        }

        // POST: api/MoviesAPI
        public IActionResult PostMovie(Movie movie)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.context.Movies.Add(movie);
            this.context.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = movie.Id }, movie);
        }

        // DELETE: api/Movies/5
        public IActionResult DeleteMovie(int id)
        {
            Movie movie = this.context.Movies.Find(id);
            if (movie == null)
            {
                return this.NotFound();
            }

            this.context.Movies.Remove(movie);
            this.context.SaveChanges();

            return this.Ok(movie);
        }

        // TODO protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        this.context.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private bool MovieExists(int id)
        {
            return this.context.Movies.Count(e => e.Id == id) > 0;
        }
    }
}