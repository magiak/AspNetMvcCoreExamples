using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetMvcCoreExamples.Web.Controllers
{
    public class AsyncController : Controller
    {
        public async Task<IActionResult> WrongAsync()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var model1 = await this.Get1Async();
            var model2 = await this.Get2Async();

            sw.Stop();
            return this.Content(this.PrintResult(sw, model1, model2));
        }

        public async Task<IActionResult> Async()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var task1 = this.Get1Async();
            var task2 = this.Get2Async();

            var model1 = await task1;
            var model2 = await task2;

            // Using WhenAll
            //var models = await Task.WhenAll(task1, task2);
            //var model1 = models[0];
            //var model2 = models[1];

            sw.Stop();
            return this.Content(this.PrintResult(sw, model1, model2));
        }
        
        private string PrintResult(
            Stopwatch sw,
            IEnumerable<AsyncModel> model1,
            IEnumerable<AsyncModel> model2)
        {
            return $"Elapsed milliseconds: {sw.ElapsedMilliseconds} Results: {model1.Count()} and {model2.Count()}";
        }

        private async Task<IEnumerable<AsyncModel>> Get1Async()
        {
            await Task.Delay(3000);

            return new[] { new AsyncModel { Name = "Get 1" } };
        }

        private async Task<IEnumerable<AsyncModel>> Get2Async()
        {
            await Task.Delay(3000);

            return new[] 
            {
                new AsyncModel { Name = "Get 2.1" },
                new AsyncModel { Name = "Get 2.2" }
            };
        }
    }

    public class AsyncModel
    {
        public string Name { get; set; }
    }

    public class AsyncViewModel
    {
        public IEnumerable<AsyncModel> Model1 { get; set; }
        public IEnumerable<AsyncModel> Model2 { get; set; }
    }
}