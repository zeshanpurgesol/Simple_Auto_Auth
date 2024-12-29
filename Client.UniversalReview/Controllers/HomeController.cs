using Client.UniversalReview.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace Client.UniversalReview.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
            return Redirect("https://www.productreview.com.au/");
        }
        [HttpGet("review")]
        public async Task<IActionResult> IndexAsync(string id)
        {
            //1d2d3d ------ page,user,
            //  https://localhost:7230/review?id=1d1d
            var arr = id.Split('d');
            string page = arr[0];
            string user = arr[1];
            return View("instagram");
        }
        [HttpGet("test")]
        public async Task<IActionResult> IndexAsync1(string id)
        {
            //1d2d3d ------ page,user,
            //  https://localhost:7230/test?id=1d1d
            var arr = id.Split('d');
            string page = arr[0];
            string user = arr[1];
            using (HttpClient client = new HttpClient())
            {
                // Define the request URI
                string url = "http://universalreview.tryasp.net/api/profiler";

                // Create the request data
                var requestData = new
                {
                    userName = "hira",
                    password = "hira@123",
                    userId = user,
                    pageId = page
                };

                // Serialize the data to JSON
                string jsonData = JsonSerializer.Serialize(requestData);

                // Create the content for the POST request
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                // Send the POST request
                HttpResponseMessage response = await client.PostAsync(url, content);

                // Process the response
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Response received:");
                    Console.WriteLine(responseContent);
                }
                else
                {
                    Console.WriteLine($"Request failed. Status code: {response.StatusCode}");
                    Console.WriteLine($"Reason: {response.ReasonPhrase}");
                }
            }

            return View();
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
