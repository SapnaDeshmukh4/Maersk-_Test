using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class APIResponse
    {
        public string JobId { get; set; }
        public string timestamp { get; set; }
        public object dration { get; set; }
        public object status { get; set; }
        public int[] Array { get; set; }
        //public StringBuilder sb { get; set; }
        //public APIResponse()
        //{
        //    sb = new StringBuilder();
        //}
        public string StrArray { get; set; }

    }
    public class FromAPIResponse
    {
        public List<APIResponse> lstaPIResponses { get; set; }
        public FromAPIResponse()
        {
            lstaPIResponses = new List<APIResponse>();
        }
    }

    public class APIRequest
    {
        public string JobId { get; set; }
        public int[] Array { get; set; }
    }
}
