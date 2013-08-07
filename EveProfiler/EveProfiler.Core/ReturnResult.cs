using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EveProfiler.Core
{
    public class ReturnResult
    {
        public HttpStatusCode Status { get; set; }
        public object oReturn { get; set; }
    }
}
