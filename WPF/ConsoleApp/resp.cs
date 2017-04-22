using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using HtmlAgilityPack;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class pageResult

    {
        public List<KeyVal> characteristics;
        public string Name;
        public int stoimosti;

    }

    public class KeyVal
    {
        string key;
        string val;
    }

    public class resp
    {
        public pageResult tovarParser(string uri, string hname, string himg, string hmassha)
        {
            pageResult result = new pageResult();

            result.Name = "";
            
            HtmlDocument doc = new HtmlWeb().Load("https://www.chipdip.ru/product/k04kp020");
            var posters = doc.DocumentNode.SelectNodes("//*[@id=\"specification\"]/div[1]/div");
            //string t = posters.InnerText;

            List<KeyVal> result;

            var y = posters.ToList();
            foreach(var el in y)
            {
                List<HtmlNode> u = el.ChildNodes.ToList();
                var t =u[6];

                foreach (var yttttttttt in u)
                {

                }

         
                var yt = el.SelectNodes("div[1]");
                //var uuu= yt.First().SelectNodes();
                foreach(var ii in u)
                {
                    string h = ii.InnerText;
                }
            }
            HttpWebRequest request = WebRequest.CreateHttp(uri);
            request.Method = "GET";
            request.ContentType = "application/json; charset=utf-8";
            
            request.Accept = "application/json";
            request.Timeout *= 2;
            request.ReadWriteTimeout *= 2;
            string response = GetResponseText(request);

            return result;

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
