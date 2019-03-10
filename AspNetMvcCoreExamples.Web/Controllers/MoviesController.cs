using AspNetMvcCoreExamples.Entities.Enums;
using AspNetMvcCoreExamples.Entities.Models;
using AspNetMvcCoreExamples.Entities.ViewModels;
using AspNetMvcCoreExamples.Web.Data;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetMvc5Examples.Web.Controllers
{
    public class MoviesController : Controller
    {
        public MoviesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        private List<Movie> moviesDatabase = new List<Movie>()
        {
            new Movie(){ Id = 1, Title = "Homer" },
            new Movie(){ Id = 2, Title = "Pelisky" }
        };

        private List<MovieViewModel> movies = new List<MovieViewModel>()
        {
            new MovieViewModel{ Id = 1, Title = "Homer", ReleasedDate = new DateTime(2017, 1, 1), },
            new MovieViewModel{ Id = 2, Title = "Pelisky", ReleasedDate = new DateTime(2017, 2, 1) },
            new MovieViewModel{ Id = 3, Title = "Pelisky", ReleasedDate = new DateTime(2017, 2, 1) },
            new MovieViewModel{ Id = 4, Title = "Pelisky 2", ReleasedDate = new DateTime(2018, 1, 1) }
        };

        private MovieViewModel viewModel = new MovieViewModel
        {
            Id = 1,
            Title = "My Movie",
            Genre = Genre.Comedy,
            ReleasedDate = DateTime.Today,
        };

        private readonly ApplicationDbContext context;
        
        public IActionResult AutoMapperTest()
        {
            var movies = this.context.Movies;
            return this.Json(movies);
        }

        public IActionResult Index()
        {
            return this.View(this.movies);
        }

        // GET: Movies
        [Route("movies/released/{year:regex(\\d{4})}/{month:range(1,12)}")]
        public IActionResult Released(int year, int month)
        {
            var movies = this.movies.Where(m => m.ReleasedDate.Year == year
                                         && m.ReleasedDate.Month == month)
                                    .ToList();

            var count = movies.Count();

            return this.Json(movies);
            //return this.Content($"Year={year} Month={month} => count {count}");
        }

        [ResponseCache(Duration = 10)]

        public IActionResult Details(int id)
        {
            return this.View(this.context.Movies.FirstOrDefault(x => x.Id == id));
        }

        public IActionResult Create()
        {
            return this.View(new MovieViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MovieViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                //var movie = new Movie()
                //{
                //    Title = viewModel.Title
                //};

                var movie = Mapper.Map<Movie>(viewModel);

                this.context.Set<Movie>().Add(movie);
                this.context.SaveChanges();

                return this.RedirectToAction("Index");
            }

            return this.View(viewModel);
        }

        public IActionResult Delete()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult DeleteOne(int id)
        {
            var entity = this.context.Movies
                .SingleOrDefault(x => x.Id == id);

            // OR
            // var entity = new Movie { Id = id };

            this.context.Movies.Remove(entity);
            this.context.SaveChanges();

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(string[] array)
        {
            var entities = this.context.Movies
                .Where(x => array.Contains(x.Title));
            
            this.context.Movies.RemoveRange(entities);
            this.context.SaveChanges();

            return this.Json(array);
        }

        [HttpGet]
        [Route("api/movies/{id}")]
        public IActionResult Get(int id)
        {
            return this.Json(this.moviesDatabase.FirstOrDefault(x => x.Id == id));
        }

        [HttpGet]
        [Route("api/movies")]
        public IActionResult GetAll()
        {
            return this.Json(this.moviesDatabase);
        }

        [HttpGet]
        [Route("api/movies/{*ids}")]
        public IActionResult Get(int[] ids)
        {
            return this.Json(this.moviesDatabase.FirstOrDefault(x => ids.Any(y => y == x.Id)));
        }

        // Test binding
        //public IActionResult Details(int? id, string name)
        //{
        //    if (id == null)
        //    {
        //        return this.Content($"Name={name}");
        //    }

        //    return this.Content($"Id={id}");
        //}


        public IActionResult Edit(int id)
        {
            return this.Content(id.ToString());
        }
    }
}