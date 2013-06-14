using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Browser;

namespace EveProfiler.Core
{
    public class ApiCalls
    {
        public delegate void getResponded(string response);
        public event getResponded ApiResponded;

        public void getCall(string urlbase, string urlpath, List<Parameters> PassedParms)
        {
            List<string> parms = new List<string>();
            for (int i = 0; i < PassedParms.Count; i++)
                parms.Add(NameValuePair(PassedParms[i].ParamName, PassedParms[i].ParamValue));

            HttpWebRequest getXml = (HttpWebRequest)WebRequest.Create(CreateUrl((urlbase + urlpath), parms));

            getXml.Method = "GET";

            getXml.BeginGetResponse(new AsyncCallback(getResponse), getXml);
        }

        private void getResponse(IAsyncResult ar)
        {
            try
            {
                HttpWebRequest getXml = ar.AsyncState as HttpWebRequest;

                WebResponse result = getXml.EndGetResponse(ar);
                 
                ApiResponded(new StreamReader(result.GetResponseStream()).ReadToEnd());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private string NameValuePair(string name, string value)
        {
            return name + "=" + value;
        }

        private string CreateUrl(string baseurl, List<string> parms)
        {
            baseurl += "?";

            for (int i = 0; i < parms.Count; i++)
            {
                if (i != parms.Count - 1)
                    baseurl += parms[i] + "&";
                else
                    baseurl += parms[i];
            }

            return baseurl;
        }

    }
}
