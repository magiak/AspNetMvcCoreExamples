using AspNetMvcCoreExamples.Entities.Models;
using AspNetMvcCoreExamples.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspNetMvCoreExamples.ConsoleApp.EntityFramework
{
    public class EntityFrameworkTests : IEntityFrameworkTests
    {
        private readonly ApplicationDbContext dbContext;

        public EntityFrameworkTests(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Seed()
        {
            if (dbContext.Movies.Any())
            {
                return;
            }

            dbContext.Movies.Add(new Movie { Title = "Movie 1" });
            dbContext.Movies.Add(new Movie { Title = "Movie 2" });
            dbContext.SaveChanges();
        }

        public void CacheFirstOrDefault()
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("------------------CacheFirstOrDefault----------------------");
            Console.WriteLine("---------------------------------------------");

            Console.WriteLine("this.dbContext.Movies.ToList();");
            var all = this.dbContext.Movies.ToList();

            Console.WriteLine("this.dbContext.Movies.FirstOrDefault(x => x.Id == 1);");
            var movie1 = this.dbContext.Movies.FirstOrDefault(x => x.Id == 1);

            Console.WriteLine("this.dbContext.Movies.FirstOrDefault(x => x.Id == 2);");
            var movie2 = this.dbContext.Movies.FirstOrDefault(x => x.Id == 2);

            Console.WriteLine("this.dbContext.Movies.FirstOrDefault(x => x.Id == 2);");
            movie2 = this.dbContext.Movies.FirstOrDefault(x => x.Id == 2);

            // Number of database queries is 4!
            // There is no caching at all!
        }

        public void CacheFind()
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("------------------CacheFind----------------------");
            Console.WriteLine("---------------------------------------------");

            Console.WriteLine("this.dbContext.Movies.ToList();");
            var all = this.dbContext.Movies.ToList();

            Console.WriteLine("this.dbContext.Movies.Find(1);");
            var movie1 = this.dbContext.Movies.Find(1);

            Console.WriteLine("this.dbContext.Movies.Find(2);");
            var movie2 = this.dbContext.Movies.Find(2);

            Console.WriteLine("this.dbContext.Movies.FirstOrDefault(2);");
            movie2 = this.dbContext.Movies.Find(2);

            // Number of database queries is 1!
            // The first 
        }

        public void AsEnumerable()
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("------------------AsEnumerable----------------------");
            Console.WriteLine("---------------------------------------------");

            Console.WriteLine("this.dbContext.Movies.ToAsyncEnumerable();");
            var all = this.dbContext.Movies.AsEnumerable();

            // Number of database queries is 0!
            // It will only cast IQueryable to IEnumerable
            // public interface IQueryable<out T> : IEnumerable<T>, IEnumerable, IQueryable
        }

        public void ToAsyncEnumerable()
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("------------------ToAsyncEnumerable----------------------");
            Console.WriteLine("---------------------------------------------");

            Console.WriteLine("this.dbContext.Movies.ToAsyncEnumerable();");
            var all = this.dbContext.Movies.AsAsyncEnumerable();

            // TODO!!!!!!
            // Number of database queries is 0!
            // It will only cast IQueryable to IEnumerable
            // public interface IQueryable<out T> : IEnumerable<T>, IEnumerable, IQueryable
        }
    }
}
