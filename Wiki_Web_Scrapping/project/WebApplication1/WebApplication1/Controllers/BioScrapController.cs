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
    public class BioScrapController : Controller
    {
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



            //var HeaderNames = doc.DocumentNode.SelectNodes("//div[@class='vector-toc-text']/text()");
            //var titles = new List<OutputModel>();
            //foreach (var item in HeaderNames)
            //{
            //titles.Add(new OutputModel { OutputData = item.InnerText.Trim() });
            //}
            //return View(titles);
            
            string singleOccupation = string.Empty;


            string name = string.Empty;
            string born = string.Empty; 
            string almaMater = string.Empty; 
            
            //string works;
            string children = string.Empty;
            string spouse = string.Empty;
            string parents = string.Empty;
            string family = string.Empty;


            HtmlNode divNode;
            divNode = doc.DocumentNode.SelectSingleNode("//div[@class='fn']");
            if (divNode != null)
            {
                name = divNode.InnerText.Trim();
                divNode = null;
            }

            divNode = doc.DocumentNode.SelectSingleNode("//td[@class='infobox-data role']");
            if (divNode != null)
            {
                singleOccupation = divNode.InnerText.Trim();
                divNode = null;
            }

            var labelNodes = doc.DocumentNode.SelectNodes("//th[@class='infobox-label']");

            if (labelNodes != null)
            {
                foreach (var labelNode in labelNodes)
                {
                    // Get the text content of the label
                    string label = labelNode.InnerText.Trim();

                    // Find the corresponding data in the following sibling td element
                    var dataNode = labelNode.SelectSingleNode("following-sibling::td[@class='infobox-data']");

                    if (dataNode != null)
                    {
                        if (label == "Born")
                        {
                            born = HtmlEntity.DeEntitize(dataNode.InnerText).Trim();
                        }

                        else if (label == "Alma&#160;mater")
                        {
                            almaMater = HtmlEntity.DeEntitize(dataNode.InnerText).Trim();
                        }

                        //else if (label == "Occupation")
                        //{
                        //    occupation = HtmlEntity.DeEntitize(dataNode.InnerText).Trim();
                        //}

                        //else if (label == "Works")
                        //{
                        //    works = HtmlEntity.DeEntitize(dataNode.InnerText).Trim();
                        //}

                        else if (label == "Spouse")
                        {
                            spouse = HtmlEntity.DeEntitize(dataNode.InnerText).Trim();
                        }

                        else if (label == "Children")
                        {
                            children = HtmlEntity.DeEntitize(dataNode.InnerText).Trim();
                        }

                        else if (label == "Parent(s)")
                        {
                            parents = HtmlEntity.DeEntitize(dataNode.InnerText).Trim();
                        }

                        else if (label == "Family")
                        {
                            family = HtmlEntity.DeEntitize(dataNode.InnerText).Trim();
                        }

                        // Get the text content of the corresponding data
                        // string data = HtmlEntity.DeEntitize(dataNode.InnerText).Trim();

                        // Console.WriteLine($"{label}: {data}");
                    }
                }
            }


            BioOutputModel biodata = new BioOutputModel
            {
                Name = name,
                Born = born,
                AlmaMatter = almaMater,
                SingleOccupation = singleOccupation,
                Occupations = new List<string>(),
                ChildrenCount = children,
                Spouse = spouse,
                Parents = parents,
                Family = family,

            };

            var occupationNodes = doc.DocumentNode.SelectNodes("//td[@class='infobox-data role']//div[@class='hlist']//li");

            if (occupationNodes != null)
            {
                foreach (var occupationNode in occupationNodes)
                {
                    string occupation = occupationNode.InnerText.Trim();
                    biodata.Occupations.Add(occupation);
                }
            }



            return View(biodata);
        }
    }
    
}
    


    

       
    



            
