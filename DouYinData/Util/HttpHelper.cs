using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DouYinData.Util
{
    public class HttpHelper
    {
        public static readonly string JsonContentType = "application/json; charset=UTF-8";
        public static readonly string FormContentType = "application/x-www-form-urlencoded; charset=UTF-8";
        public static readonly string ImageContentType = "image/jpeg;charset=UTF-8";
        public static readonly string HtmlContentType = "text/html;charset=UTF-8";


        public static readonly string DefaultAccept = "application/json, text/javascript, */*; q=0.01";



        private static Encoding defaultEncoding = Encoding.GetEncoding("utf-8");

        #region 处理ResponseStream
        /// <summary>
        /// 解析xml
        /// </summary>
        /// <param name="stm"></param>
        /// <returns></returns>
        public static string DecompressGzip(Stream stm)
        {
            string strHTML = "";

            GZipStream gzip = new GZipStream(stm, CompressionMode.Decompress);//解压缩
            using (StreamReader reader = new StreamReader(gzip, Encoding.GetEncoding("utf-8")))//中文编码处理
            {
                strHTML = reader.ReadToEnd();
            }

            return strHTML;
        }

        /// <summary>
        /// 读取Response中的内容
        /// </summary>
        /// <param name="response"></param>
        /// <param name="OrderSerialId">订单流水号</param>
        /// <returns></returns>
        public static string GetResponseStreamToStr(HttpWebResponse response)
        {
            try
            {
                var resp_html = "";
                if (response != null)
                {
                    Stream resp_stream = response.GetResponseStream();   //获取响应的字符串流  
                    var resp_type = response.ContentEncoding;
                    if (resp_type == "gzip")
                    {
                        resp_html = DecompressGzip(resp_stream);
                    }
                    else
                    {
                        StreamReader resp_html_sr = new StreamReader(resp_stream); //创建一个stream读取流  
                        resp_html = resp_html_sr.ReadToEnd();   //从头读到尾，放到字符串html
                        resp_html_sr.Close();
                    }
                    resp_stream.Close();
                }


                return resp_html;

            }
            catch (Exception ex)
            {
                return "";
            }
        }
        #endregion


        #region 模拟浏览器登录
        /// <summary>
        /// 模拟浏览器
        /// </summary>
        private static readonly string DefaultUserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.181 Safari/537.36";

        /// <summary>
        /// HTTPS认证总是接受验证方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="certificate"></param>
        /// <param name="chain"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受     
        }

        /// <summary>
        /// HTTP请求方式（禁止请求的跳转）
        /// </summary>
        /// <param name="url"></param>
        /// <param name="parameters"></param>
        /// <param name="encoding"></param>
        /// <param name="cookieContainer">传了该对象进来，会自动赋值，返回出去</param>
        /// <param name="referer"></param>
        /// <param name="method"></param>
        /// <param name="contentType"></param>
        /// <param name="tryCopunt"></param>
        /// <param name="keepAlive"></param>
        /// <returns></returns>
        private static HttpWebResponse HttpRequest(string url, IDictionary<string, string> parameters,
            Encoding encoding, CookieContainer cookieContainer, string referer, string method,
            string contentType, int tryCopunt = 0, bool keepAlive = false, bool isSetAccept = false)
        {
            tryCopunt = tryCopunt + 1;
            HttpWebRequest request = null;
            //HTTPS请求  
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            ServicePointManager.DefaultConnectionLimit = 200;

            request = WebRequest.Create(url) as HttpWebRequest;
            if (cookieContainer != null)
            {
                request.CookieContainer = cookieContainer;//请求cookie
            }
            request.ProtocolVersion = HttpVersion.Version10;//http协议版本
            request.Method = method;
            if (String.IsNullOrWhiteSpace(contentType))
            {
                request.ContentType = FormContentType;//决定文件接收方将以什么形式、什么编码读取这个文件
            }
            else
            {
                request.ContentType = contentType;
            }
            request.UserAgent = DefaultUserAgent;
            if (keepAlive)
            {
                request.Headers.Add(HttpRequestHeader.KeepAlive, "TRUE");
            }
            if (isSetAccept)
            {
                request.Accept = DefaultAccept;
            }
            request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
            request.Headers.Add(HttpRequestHeader.AcceptLanguage, "zh-CN,zh;q=0.9,en;q=0.8");
            request.Timeout = 6000;
            request.ServicePoint.Expect100Continue = false;
            request.AllowAutoRedirect = false;//禁止跳转
            if (!string.IsNullOrWhiteSpace(referer))
            {
                request.Referer = referer;//指定上一页
            }

            try
            {
                byte[] data = null;

                //如果需要POST数据     
                if (!(parameters == null || parameters.Count == 0))
                {
                    StringBuilder sBuilder = new StringBuilder();
                    int i = 0;
                    foreach (string key in parameters.Keys)
                    {
                        if (i > 0)
                        {
                            sBuilder.AppendFormat("&{0}={1}", key, parameters[key]);
                        }
                        else
                        {
                            sBuilder.AppendFormat("{0}={1}", key, parameters[key]);
                        }
                        i++;
                    }
                    data = encoding.GetBytes(sBuilder.ToString());
                    using (Stream stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                }

                return request.GetResponse() as HttpWebResponse;
            }
            catch (WebException webEx)
            {
                Thread.Sleep(500);
                request.Abort();
                request = null;
                System.GC.Collect();
                if (tryCopunt <= 3)
                {
                    return HttpRequest(url, parameters, encoding, cookieContainer, referer, method, contentType, tryCopunt, keepAlive);
                }
                return null;
            }
        }

        /// <summary>
        /// HTTP-GET方式（禁止请求的跳转）
        /// </summary>
        /// <param name="url"></param>
        /// <param name="parameters"></param>
        /// <param name="charset"></param>
        /// <param name="cookieContainer">传了该对象进来，会自动赋值，返回出去</param>
        /// <param name="referer"></param>
        /// <param name="contentType"></param>
        /// <param name="tryCopunt"></param>
        /// <param name="keepAlive"></param>
        /// <returns></returns>
        public static HttpWebResponse HttpGetRequest(string url, IDictionary<string, string> parameters, CookieContainer cookieContainer, string referer, string contentType = "", int tryCopunt = 0, bool keepAlive = false, bool isSetAccept = false)
        {
            string method = "GET";
            return HttpRequest(url, parameters, defaultEncoding, cookieContainer, referer, method, contentType, tryCopunt, keepAlive, isSetAccept);
        }

        /// <summary>
        /// HTTP-POST方式（禁止请求的跳转）
        /// </summary>
        /// <param name="url"></param>
        /// <param name="parameters"></param>
        /// <param name="charset"></param>
        /// <param name="cookieContainer">传了该对象进来，会自动赋值，返回出去</param>
        /// <param name="referer"></param>
        /// <param name="contentType"></param>
        /// <param name="tryCopunt"></param>
        /// <param name="keepAlive"></param>
        /// <returns></returns>
        public static HttpWebResponse HttpPostRequest(string url, IDictionary<string, string> parameters, CookieContainer cookieContainer, string referer, string contentType = "", int tryCopunt = 0, bool keepAlive = false, bool isSetAccept = false)
        {
            string method = "POST";
            return HttpRequest(url, parameters, defaultEncoding, cookieContainer, referer, method, contentType, tryCopunt, keepAlive, isSetAccept);
        }
        #endregion

        /// <summary>
        /// 代理ip请求url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string ProxyHttpRequest(string url, string method)
        {
            string strIPAddress = "";
            int port = 8022;
            WebProxy proxyObject = new WebProxy(strIPAddress, port);//str为IP地址 port为端口号 代理类
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url); // 访问这个网站 ，返回的就是你发出请求的代理ip 这个做代理ip测试非常方便，可以知道代理是否成功

            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.baidu.com"); // 61.183.192.5
            request.UserAgent = DefaultUserAgent;

            request.Proxy = proxyObject; //设置代理 
            request.Method = method;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return GetResponseStreamToStr(response);
        }
    }
}
