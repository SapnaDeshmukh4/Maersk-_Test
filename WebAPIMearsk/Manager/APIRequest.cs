using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIMearsk
{
    //{"JobId":"1","inputArray":[2,23,34,34]}
    public class APIRequest
    {
        public string JobId { get; set; }
        public int[] Array { get; set; }
    }
}
