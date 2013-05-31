
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EveProfiler.DataAccess
{
    public class Get
    {
        public async void getCharacterList()
        {
            List<Core.Parameters> Parms = new List<Core.Parameters>();
            Parms.Add(new Core.Parameters { ParamName = "keyid", ParamValue = "1996957" });
            Parms.Add(new Core.Parameters { ParamName = "vCode", ParamValue = "I6YLp1vVB0KYAir2B3Z4mDIPtZrFHlpeysYYSaxGkjV4rO820NpTOBustmNsoEA4" });

            string xml = Core.ApiCalls.getCall(ApiStrings.ApiUri, ApiStrings.ListCharacters, Parms);
            parseCharacterList(xml);
        }

        private void parseCharacterList(string xml)
        {
            //XDocument doc = XDocument.Parse(xml);



        }
    }
}
