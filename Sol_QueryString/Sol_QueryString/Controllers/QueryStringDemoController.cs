using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

//http://learningprogramming.net/net/asp-net-core-mvc/use-query-string-in-url-in-asp-net-core-mvc/
namespace Sol_QueryString.Controllers
{
    [Route("web/querystringdemo")]
    public class QueryStringDemoController : Controller
    {
        [Route("index", Name = "index")]
        public IActionResult Index()
        {
            return View();
        }

        // Using Model Binding
        [BindProperty(SupportsGet = true)]
        public int id { get; set; }

        [HttpGet("demo1/{id:int}", Name = "demo1")]
        public IActionResult Demo1()
        {
            ViewBag.Id = id;

            return View();
        }

        // Using FromRoute Model Binding
        //http://localhost:3003/web/querystringdemo/demo2/10/Kishor%20Naik
        [HttpGet("demo2/{id1:int}/{name}", Name = "demo2")]
        public IActionResult Demo2([FromRoute(Name = "id1")] int id1, [FromRoute(Name = "name")] string name)
        {
            ViewBag.Id1 = id1;
            ViewBag.Name = name;
            return View();
        }

        // Using FromQuery Model Binding
        //http://localhost:3003/web/querystringdemo/demo3?id1=10&name=Kishor%20Naik
        [HttpGet("demo3", Name ="demo3")]
        public IActionResult Demo3([FromQuery(Name ="id1")] int id1, [FromQuery(Name ="name")] string name)
        {
            ViewBag.Id1 = id1;
            ViewBag.Name = name;
            return View();
        }

        // Using HttpContext.Request.Query
        // http://localhost:3003/web/querystringdemo/demo4?id1=10&name=Kishor%20Naik
        [HttpGet("demo4",Name ="demo4")]
        public IActionResult Demo4()
        {
            ViewBag.Id1 = Convert.ToInt64(HttpContext.Request.Query["id1"].ToString());
            ViewBag.Name =HttpContext.Request.Query["name"].ToString();
            return View();
        }
    }
}