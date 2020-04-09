using CrawlerLibrary;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatPayDOMCrawler
{
    public class WechatPayRobot
    {
        /// <summary>
        /// 特约商户进件接口爬取 转excel
        /// </summary>
        /// <param name="docUrl"></param>
        /// <returns></returns>
        public string exportRequest(string docUrl)
        {
            docUrl = "https://pay.weixin.qq.com/wiki/doc/apiv3/wxpay/tool/applyment4sub/chapter3_1.shtml";
            var resp = CrawlerHttpUtil.HttpGetRequest(docUrl, null, null, "");
            var response_Str = CrawlerHttpUtil.GetResponseStreamToStr(resp);

            StringBuilder modelStr = new StringBuilder();
            List<ReqModel> req = new List<ReqModel>();
            try
            {
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(response_Str);
                HtmlNode rootNode = doc.DocumentNode;
                var nodes = rootNode.SelectNodes("//div[@class='table-wrp']//tbody//tr");
                if (nodes != null && nodes.Any())
                {
                    HtmlAttribute att = null;
                    foreach (var elem in nodes)
                    {
                        var tdnodes = elem.SelectNodes("./td");
                        if (tdnodes != null && tdnodes.Count == 5)
                        {
                            req.Add(new ReqModel()
                            {
                                名称 = tdnodes[0].InnerText,
                                变量名 = tdnodes[1].InnerText,
                                类型 = tdnodes[2].InnerText,
                                必填 = tdnodes[3].InnerText,
                                说明 = tdnodes[4].InnerText,
                            });
                        }
                        else
                        {

                        }
                    }
                }
                modelStr.Append("}");
                var reqStr = JsonConvert.SerializeObject(req);
                return modelStr.ToString();
            }
            catch (Exception ex)
            {
                modelStr.Append("}");
                return modelStr.ToString();
            }
            finally
            {

            }
        }

        public class ReqModel
        {

            public string 名称 { get; set; }
            public string 变量名 { get; set; }
            public string 类型 { get; set; }

            public string 必填 { get; set; }

            public string 说明 { get; set; }
        }

        /// <summary>
        /// 特约商户进件接口爬取
        /// </summary>
        /// <param name="docUrl"></param>
        /// <returns></returns>
        public string GetRequestModel1(string docUrl)
        {
            //docUrl = "https://pay.weixin.qq.com/wiki/doc/apiv3/wxpay/tool/applyment4sub/chapter3_1.shtml";
            var resp = CrawlerHttpUtil.HttpGetRequest(docUrl, null, null, "");
            var response_Str = CrawlerHttpUtil.GetResponseStreamToStr(resp);

            StringBuilder modelStr = new StringBuilder();
            modelStr.Append(@"
/// <summary>
/// 
/// </summary>
public class WechatPayV3Robot
    {
");
            try
            {
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(response_Str);
                HtmlNode rootNode = doc.DocumentNode;
                var nodes = rootNode.SelectNodes("//div[@class='table-wrp']//tbody//tr");
                if (nodes != null && nodes.Any())
                {
                    HtmlAttribute att = null;
                    foreach (var elem in nodes)
                    {
                        var tdnodes = elem.SelectNodes("./td");
                        if (tdnodes != null && tdnodes.Count == 5)
                        {
                            //名称 = tdnodes[0].InnerText,
                            //    变量名 = tdnodes[1].InnerText,
                            //    类型 = tdnodes[2].InnerText,
                            //    必填 = tdnodes[3].InnerText,
                            //    说明 = tdnodes[4].InnerText,
                            //"query\r\n                      \r\n                        1、服务商自定义的唯一编号。\r\n                        2、每个编号对应一个申请单，每个申请单审核通过后会生成一个微信支付商户号。 \r\n                        3、若申请单被驳回，可填写相同的“业务申请编号”，即可覆盖修改原申请单信息。\r\n                      \r\n                    示例值：APPLYMENT_00000000001 "
                            modelStr.Append($@"
                                /// <summary>
                                        /// {tdnodes[0].InnerText}
                                        /// {tdnodes[4].InnerText.Replace("\r\n", " ").Replace(" ","")}
                                        /// </summary>
                                        public {GetType(tdnodes[2].InnerText)} {tdnodes[1].InnerText} {{ get; set; }}
                                ");

                        }
                        else
                        {

                        }
                    }
                }
                modelStr.Append("}");
                return modelStr.ToString();
            }
            catch (Exception ex)
            {
                modelStr.Append("}");
                return modelStr.ToString();
            }
            finally
            {

            }
        }



        public string GetRequestModel2(string docUrl)
        {
            //docUrl = "https://pay.weixin.qq.com/wiki/doc/api/wxa/wxa_sl_api.php?chapter=9_1";
            var resp = CrawlerHttpUtil.HttpGetRequest(docUrl, null, null, "");
            var response_Str = CrawlerHttpUtil.GetResponseStreamToStr(resp);

            StringBuilder modelStr = new StringBuilder();
            modelStr.Append(@"
                            /// <summary>
                            /// 
                            /// </summary>
                            public class WechatPayV3Robot
                                {
                            ");
            try
            {
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(response_Str);
                HtmlNode rootNode = doc.DocumentNode;
                //var htmlNode = rootNode.SelectSingleNode("//table[contains(@class,'table')]//tbody");
                var htmlNode = rootNode.SelectSingleNode("//table[contains(@class,'table')]");
                if (htmlNode != null)
                {
                    var nodes = htmlNode.SelectNodes("//tr");
                    HtmlAttribute att = null;
                    foreach (var elem in nodes)
                    {
                        var tdnodes = elem.SelectNodes("./td");
                        if (tdnodes != null && tdnodes.Count == 6)
                        {

                            modelStr.Append($@"
                                /// <summary>
                                        /// {tdnodes[0].InnerText}
                                        /// {tdnodes[5].InnerText.Replace("\r\n", " ").Replace(" ", "")}
                                        /// </summary>
                                        public {GetType(tdnodes[3].InnerText)} {tdnodes[1].InnerText} {{ get; set; }}
                                ");

                        }
                        else
                        {

                        }
                    }
                }
                modelStr.Append("}");
                return modelStr.ToString();
            }
            catch (Exception ex)
            {
                modelStr.Append("}");
                return modelStr.ToString();
            }
            finally
            {

            }
        }


        private string GetType(string str)
        {
            if (str.Contains("String")|| str.Contains("string"))
                return "string";
            else if (str.Contains("Int") || str.Contains("int"))
                return "int";
            else return str;
        }
    }
}
