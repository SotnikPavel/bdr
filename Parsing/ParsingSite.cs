using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel;
using System.Net;
using System.IO;
using HtmlAgilityPack;

namespace Parsing
{
    public class ParsingSite
    {
        string StartUrl;
        string NextUrl;
        string PathToElementPage;
        string PathToName;
        Guid ComponentsClassId;
        string PathToProducter;
        string PathToShellType;
        string SiteName;
        Guid ParsingId;

        public ParsingSite(string parsingTeamplateName)
        {
            var parsingTeamplate = DBWorker.Parsing.GetByName(parsingTeamplateName);
            ParsingTeamlateLoad(parsingTeamplate.Id, parsingTeamplate.StartUrl, parsingTeamplate.NextUrl, parsingTeamplate.PathToElementPage, parsingTeamplate.PathToName, parsingTeamplate.ComponentsClassId, parsingTeamplate.PathToProducter, parsingTeamplate.PathToShellType);
        }

        public void ParsingTeamlateLoad(Guid parsingTeamplateId, string startUrl, string nextUrl, string pathToElementPage, string pathToName, Guid componentsClassId, string pathToProducter, string pathToShellType)
        {
            ParsingId = parsingTeamplateId;
            StartUrl = startUrl;
            NextUrl = nextUrl;
            PathToElementPage = pathToElementPage;
            PathToName = pathToName;
            ComponentsClassId = componentsClassId;
            PathToProducter = pathToProducter;
            PathToShellType = pathToShellType;
            string siteNameR = startUrl.Substring(8, startUrl.Length - 8);
            SiteName = startUrl.Substring(0, 8);
            SiteName += siteNameR.Substring(0, siteNameR.IndexOf("/"));
        }

        public void ParsingSiteByTeamplate(int startNumber, Guid userId)
        {
            try
            {
                int number = startNumber;
                bool result = true;
                while (result && number < 5)
                {
                    string url = StartUrl;
                    if (number != 0)
                    {
                        string purl = NextUrl.Replace("{num}", number.ToString());
                        url += purl;
                    }
                    result = ParsingPage(url, userId, ParsingId);
                    number++;
                }
            }
            catch(Exception ex)
            {

            }
        }

        public bool ParsingPage(string url, Guid userId, Guid parsingId)
        {
            HtmlDocument doc = new HtmlDocument();
            var req = GetRequest(url);
            if (!String.IsNullOrEmpty(req))
            {
                doc.LoadHtml(req);
                bool result = true;
                int elementPageNum = 1;

                while (result)
                {
                    string pathToElementPage = PathToElementPage.Replace("{numel}", elementPageNum.ToString());
                    HtmlNode node = doc.DocumentNode.SelectSingleNode(pathToElementPage);
                    try
                    {
                        string urlPage = node.InnerHtml.Substring(node.InnerHtml.IndexOf("href=\"") + 6, node.InnerHtml.Length - node.InnerHtml.IndexOf("href=\"") - 6);
                        urlPage = SiteName + urlPage.Substring(0, urlPage.IndexOf("\""));
                        result = ParsingElement(urlPage, userId, parsingId);
                        elementPageNum++;
                    }
                    catch(Exception ex)
                    {
                        return true;
                    }
                    
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ParsingElement(string url, Guid userId, Guid parsingId)
        {
            var listParsingOtherFields = DBWorker.ParsingOtherFields.GetListByParsingComponentsId(parsingId);

            HtmlDocument doc = new HtmlDocument();
            var req = GetRequest(url);
            if(!String.IsNullOrEmpty(req))
            {
                string name = "";
                Guid producterId = Guid.Empty;
                Guid shellTypeId = Guid.Empty;
                doc.LoadHtml(req);
                if(!String.IsNullOrEmpty(PathToName))
                {
                    HtmlNode node = doc.DocumentNode.SelectSingleNode(PathToName);
                    name = node.InnerHtml;
                }
                if (!String.IsNullOrEmpty(PathToProducter))
                {
                    HtmlNode node = doc.DocumentNode.SelectSingleNode(PathToProducter);
                    string producterName = node.InnerHtml;
                    if(DBWorker.Producers.GetIdByName(producterName) != null)
                    {
                        producterId = DBWorker.Producers.GetIdByName(producterName).Value;
                    }
                }
                if (!String.IsNullOrEmpty(PathToShellType))
                {
                    HtmlNode node = doc.DocumentNode.SelectSingleNode(PathToShellType);
                    string shellTypeName = node.InnerHtml;
                    if (DBWorker.ShellTypes.GetIdByName(shellTypeName) != null)
                    {
                        shellTypeId = DBWorker.ShellTypes.GetIdByName(shellTypeName).Value;
                    }
                }
                Guid res = DBWorker.Components.Add(userId, name, producterId, shellTypeId, ComponentsClassId);
                foreach(var parsingOtherField in listParsingOtherFields)
                {
                    if(!string.IsNullOrEmpty(parsingOtherField.Value))
                    {
                        HtmlNode node = doc.DocumentNode.SelectSingleNode(parsingOtherField.Value);
                        if (node != null)
                        {
                            var component = DBWorker.TypeElementFieldComponents.GetGuidByComponentIdTypeElementFieldId(res, parsingOtherField.TypeElementFieldId);
                            DBWorker.TypeElementFieldComponents.Change(component.Id, node.InnerText);
                        }
                    }
                   
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        private string GetRequest(string url)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.AllowAutoRedirect = false;
                httpWebRequest.Method = "GET";
                httpWebRequest.Referer = "http://google.com";
                using (var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
                {
                    using (var stream = httpWebResponse.GetResponseStream())
                    {
                        using (var reader = new StreamReader(stream, Encoding.GetEncoding(httpWebResponse.CharacterSet)))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
            catch
            {
                return String.Empty;
            }
        }
    }
}
