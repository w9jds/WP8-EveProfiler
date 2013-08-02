using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveProfiler.Core
{
    public class Parameters
    {
        public string name { get; set; }
        public string value { get; set; }

        public string Parm2String()
        {
            return this.name + "=" + this.value;
        }
    }
}
