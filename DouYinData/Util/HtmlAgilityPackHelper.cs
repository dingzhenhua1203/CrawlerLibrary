using CrawlerMingxing.Model;
using DouYinData.Util;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerMingxing.Util
{
    public class HtmlAgilityPackHelper
    {
        public static HtmlNode GetAllHtmlNode(Stream stream)
        {
            HtmlNode result = null;
            try
            {
                HtmlDocument doc = new HtmlDocument();
                doc.Load(stream);
                result = doc.DocumentNode;

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
            return result;
        }
        public static HtmlNode GetAllHtmlNode(string source)
        {
            HtmlNode result = null;
            try
            {
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(source);
                result = doc.DocumentNode;

            }
            catch (Exception ex)
            {
            }
            finally
            {

            }
            return result;
        }

        public static string GetSingleInputValueByName(string source, string inputname)
        {
            string result = "";
            try
            {
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(source);
                HtmlNode rootNode = doc.DocumentNode;
                var element = rootNode.SelectSingleNode("//input[@name='" + inputname + "']");//SelectSingleNode
                if (element != null)
                {
                    HtmlAttribute att = element.Attributes["value"];
                    result = att.Value;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {

            }
            return result;
        }

        public static HtmlNode GetSingleInputByAttr(string source, string inputAttr, string inputAttrValue)
        {
            try
            {
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(source);
                HtmlNode rootNode = doc.DocumentNode;
                var node = rootNode.SelectSingleNode("//input[@" + inputAttr + "='" + inputAttrValue + "']");//SelectSingleNode
                if (node != null)
                {
                    return node;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
            return null;
        }

        public static bool CheckInputIsExist(string source, string inputname, string inputvalue)
        {

            try
            {
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(source);
                HtmlNode rootNode = doc.DocumentNode;
                var nodes = rootNode.SelectNodes("//input[@name='" + inputname + "'][@value='" + inputvalue + "']");//SelectSingleNode
                if (nodes != null)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
            }
            return false;
        }

        public static List<DouYinModel> GetTable(string source, string path)
        {
            List<DouYinModel> result = new List<DouYinModel>();
           
            try
            {
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(source);
                HtmlNode rootNode = doc.DocumentNode;
                HtmlNode table = rootNode.SelectSingleNode("//table[@class='table user-list']/tbody");
                HtmlNodeCollection trCollection = table.SelectNodes("./tr");
                if (trCollection == null)
                {
                    return null;
                }
                foreach (var tr in trCollection)
                {
                    DouYinModel model = new DouYinModel();
                    HtmlNodeCollection tdCollection = tr.SelectNodes("./td");
                    string headPicture = tdCollection[1].SelectSingleNode("img").Attributes["src"].Value;
                    string nickname = tdCollection[2].SelectSingleNode("a").InnerText;
                    string sex = tdCollection[3].InnerText;
                    string fans = PictureHelper.SaveBase64ToImage(tdCollection[4].SelectSingleNode("img").Attributes["src"].Value, path, DateTimeHelper.GetMillisecondsSpan());
                    string zans = PictureHelper.SaveBase64ToImage(tdCollection[5].SelectSingleNode("img").Attributes["src"].Value, path, DateTimeHelper.GetMillisecondsSpan());
                    model.HeadPicture = headPicture;
                    model.NickName = nickname;
                    model.Sex = sex;
                    model.FanNum = fans;
                    model.ZanNum = zans;
                    result.Add(model);
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {

            }
            return result;
        }
    }
}
