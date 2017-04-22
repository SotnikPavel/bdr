using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace ConsoleApp
{
    public class resp
    {
        public void tovarParser(string uri, string hname, string himg, string hmassha)
        {
            
            HttpWebRequest request = WebRequest.CreateHttp(uri);
            request.Method = "GET";
            request.ContentType = "application/json; charset=utf-8";
            
            request.Accept = "application/json";
            request.Timeout *= 2;
            request.ReadWriteTimeout *= 2;
            string response = GetResponseText(request);

            

        }

        public static string GetResponseText(WebRequest webRequest)
        {
            string response = null;
            try
            {
                using (WebResponse httpWebResponse = webRequest.GetResponse() as HttpWebResponse)
                {
                    if (httpWebResponse != null)
                    {
                        using (Stream stream = httpWebResponse.GetResponseStream())
                        {
                            if (stream != null)
                            {
                                using (StreamReader reader = new StreamReader(stream))
                                {
                                    response = reader.ReadToEnd();
                                }
                            }
                            else response = null;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                throw new WebException(ex.Message);
            }
            return response;
        }
    }
}
