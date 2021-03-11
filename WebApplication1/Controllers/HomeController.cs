using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
//using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
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
        }

        public IActionResult GetJobById()
        {
            APIResponse response = new APIResponse();
            return View("GetJobById",response);
        }
        public async Task<IActionResult> GetAllJobs()
        {
            string apiUrl = "https://localhost:44332/api/SortArray/";
            FromAPIResponse fromAPIResponse = new FromAPIResponse();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44332/api/SortArray");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    fromAPIResponse = JsonConvert.DeserializeObject<FromAPIResponse>(data);
                }
            }
            return View("SortArrayDetails",fromAPIResponse);
        }

        public IActionResult GetByJobId(string id)
        {
            string apiUrl = "https://localhost:44332/api/SortArray/";
            APIResponse fromAPIResponse = new APIResponse();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44332/api/SortArray");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(apiUrl+ id).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    fromAPIResponse = JsonConvert.DeserializeObject<APIResponse>(data);
                    if (fromAPIResponse.Array != null)
                    {
                        Array.Sort(fromAPIResponse.Array);
                        fromAPIResponse.StrArray = string.Join(",", fromAPIResponse.Array);
                    }
                }
            }
            return PartialView("GetByJobId", fromAPIResponse);
        }

        [HttpPost]
        public async Task<IActionResult> CreateJob(APIResponse aPIResponse)
        {
            string apiUrl = "https://localhost:44332/api/SortArray/";
            APIRequest apirequest = new APIRequest();
            apirequest.JobId = aPIResponse.JobId;
            apirequest.Array = aPIResponse.StrArray.Split(',').Select(n => Convert.ToInt32(n)).ToArray();

            APIResponse fromAPIResponse = new APIResponse();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44332/api/SortArray");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PostAsync(apiUrl, apirequest, new JsonMediaTypeFormatter());
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    fromAPIResponse = JsonConvert.DeserializeObject<APIResponse>(data);
                }
            }
            return PartialView("GetByJobId", fromAPIResponse);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
