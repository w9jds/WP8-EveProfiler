using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EveProfiler.Core
{
    public class ApiCalls
    {
        public string Response { get; set; }

        public void getCall(string urlbase, string urlpath, List<Parameters> PassedParms)
        {
            List<string> parms = new List<string>();
            for (int i = 0; i < PassedParms.Count; i++)
                parms.Add(NameValuePair(PassedParms[i].ParamName, PassedParms[i].ParamValue));

            HttpWebRequest getXml = (HttpWebRequest)WebRequest.Create(CreateUrl((urlbase + urlpath), parms));

            getXml.Method = "GET";

            getXml.BeginGetResponse(new AsyncCallback(getResponse), getXml);

        }

        private void getResponse(IAsyncResult asynchronousResult)
        {
            HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;

            // End the operation
            HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asynchronousResult);
            Stream streamResponse = response.GetResponseStream();
            Response = new StreamReader(streamResponse).ReadToEnd();

            // Close the stream object
            streamResponse.Close();

            // Release the HttpWebResponse
            response.Close();
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
