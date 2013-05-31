using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EveProfiler.Core
{
    public static class ApiCalls
    {
        private static string Response = null;

        public static string getCall(string urlbase, string urlpath, List<Parameters> PassedParms)
        {
            List<string> parms = new List<string>();
            for (int i = 0; i < PassedParms.Count; i++)
                parms.Add(NameValuePair(PassedParms[i].ParamName, PassedParms[i].ParamValue));

            HttpWebRequest getXml = (HttpWebRequest)WebRequest.Create(CreateUrl((urlbase + urlpath), parms));

            getXml.Method = "GET";

            IAsyncResult result = getXml.BeginGetResponse(new AsyncCallback(getResponse), getXml);

            result.AsyncWaitHandle.WaitOne();
            
            return Response;
            
        }

        private static void getResponse(IAsyncResult asynchronousResult)
        {
            HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;

            WebResponse response = request.EndGetResponse(asynchronousResult);
            Response = new StreamReader(response.GetResponseStream()).ReadToEnd();

        }

        private static string NameValuePair(string name, string value)
        {
            return name + "=" + value;
        }

        private static string CreateUrl(string baseurl, List<string> parms)
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
