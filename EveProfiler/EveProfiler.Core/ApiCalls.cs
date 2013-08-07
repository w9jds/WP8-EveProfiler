using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Browser;
using System.Net.Http;

namespace EveProfiler.Core
{
    public class ApiCalls
    {

        public static bool getXml(string pathUri, List<Parameters> Params, ref string sResponse, ref ReturnResult rrReturn)
        {

            List<string> parms = new List<string>();
            for (int i = 0; i < Params.Count; i++)
            {
                parms.Add(Params[i].Parm2String());
            }

            HttpClient getXml = new HttpClient();

            getXml.Timeout = TimeSpan.FromSeconds(15);
            getXml.BaseAddress = new Uri("https://api.eveonline.com");

            try
            {
                HttpResponseMessage response = getXml.GetAsync(pathUri + CreateQueryString(parms)).Result;
                rrReturn.Status = response.StatusCode;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    sResponse = response.Content.ReadAsStringAsync().Result;
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private static string CreateQueryString(List<string> parms)
        {
            string sReturn = "?";

            for (int i = 0; i < parms.Count; i++)
            {
                if (i == parms.Count - 1)
                    sReturn += parms[i];
                else
                    sReturn += parms[i] + "&";
            }

            return sReturn;
        }

    }
}
