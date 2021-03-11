using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIMearsk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SortArrayController : ControllerBase
    {
        //GET: api/<SortArrayController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    APIRequest aPIRequest = new APIRequest();
        //    aPIRequest.JobId = "1";
        //    aPIRequest.inputArray = new int[] { 2, 23, 34, 34 };
        //    string jsonString = JsonSerializer.Serialize(aPIRequest);
        //    return new string[] { "value1", "value2" };
        //}
        [HttpGet]
        public AllAPIResponse Get()
        {
            SortManagercs manager = new SortManagercs();
            AllAPIResponse allAPIResponse = new AllAPIResponse();
            allAPIResponse = manager.AllElements();
            string jsonString = JsonSerializer.Serialize(allAPIResponse);
            return allAPIResponse;
        }

        [HttpGet("{jobid}")]
        public APIResponse GetByJobId(string jobid)
        {
            SortManagercs manager = new SortManagercs();
            APIResponse response = new APIResponse();
            response = manager.BiJobId(jobid);
            string jsonString = JsonSerializer.Serialize(response);
            return response;
        }

        // GET api/<SortArrayController>/5
        [HttpPost]
        public APIResponse SortedArray([FromBody] APIRequest request)
        {

            SortManagercs manager = new SortManagercs();
            APIResponse aPIResponse = new APIResponse();
            //APIRequest request = System.Text.Json.JsonSerializer.Deserialize(body);
            if (request != null)
            {
                aPIResponse.Array = manager.Sortelements(request);
            }
            return aPIResponse;
        }

        // POST api/<SortArrayController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //    APIRequest aPIRequest = new APIRequest();
        //    aPIRequest.JobId = "1";
        //    aPIRequest.inputArray = new int[] { 2, 23, 34, 34 };
        //    string jsonString = JsonSerializer.Serialize(aPIRequest);
        //}

        // PUT api/<SortArrayController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SortArrayController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
