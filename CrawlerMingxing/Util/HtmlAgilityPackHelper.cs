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

        /// <summary>
        /// 获取购物车下所有删除链接
        /// </summary>
        /// <param name="source"></param>
        /// <param name="inputAttr"></param>
        /// <param name="inputAttrValue"></param>
        /// <returns></returns>
        public static List<string> GetAllRemoveLink(string source)
        {
            //返回内容 /cart/remove?orderItemId=3503563&productId=10534
            List<string> linkList = new List<string>();

            try
            {
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(source);
                HtmlNode rootNode = doc.DocumentNode;
                var nodes = rootNode.SelectNodes("//tr[@class='cart-table']//a[@class='remove_item']");
                if (nodes != null && nodes.Any())
                {
                    HtmlAttribute att = null;
                    foreach (var elem in nodes)
                    {
                        att = elem.Attributes["href"];
                        linkList.Add(att.Value);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
            return linkList;
        }
    }
}
