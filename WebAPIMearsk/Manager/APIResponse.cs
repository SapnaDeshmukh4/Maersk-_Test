using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIMearsk
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

    }
    public class AllAPIResponse
    {
        public List<APIResponse> lstaPIResponses { get; set; }
        public AllAPIResponse()
        {
            lstaPIResponses = new List<APIResponse>();
        }
    }
}
