using Microsoft.AspNetCore.Mvc;

// Additional libraries added to the codebase
using HtmlAgilityPack;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System.IO;
using WebApplication1.Models;
using System.Diagnostics;

namespace WebApplication1.Controllers
{
    public class ScrapController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public ScrapController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Output(FormDataModel formData)
        {
            // Process the form data, store it in a variable, or perform any other actions
            string url = formData.InputData;

            // Store the data in TempData to pass it back to the view
            TempData["FormData"] = url;

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);

            var HeaderNames = doc.DocumentNode.SelectNodes("//div[@class='vector-toc-text']");

            var titles = new List<OutputModel>();
            foreach (var item in HeaderNames)
            {
                titles.Add(new OutputModel { OutputData = item.InnerText.Trim() });
            }

            return View(titles);
        }

    }


}
