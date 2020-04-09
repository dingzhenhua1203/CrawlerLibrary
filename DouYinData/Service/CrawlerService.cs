using CrawlerMingxing.Model;
using CrawlerMingxing.Util;
using DouYinData.Model;
using DouYinData.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DouYinData.Service
{
    public class CrawlerService
    {
        private static string SearchUrl = "https://kolranking.com/home?s=&category=&ot=DESC&order=follower_count&page={0}";
        /// <summary>
        /// 下载列表
        /// </summary>
        /// <param name="search"></param>
        public static List<DouYinModel> DownLoad(int index, string directoryPath)
        {
            List<DouYinModel> result = new List<DouYinModel>();
            try
            {
                string url = string.Format(SearchUrl, index);
                //请求搜索列表
                var list_response = HttpHelper.HttpGetRequest(url, null, null, null, keepAlive: true);
                var list_respStr = HttpHelper.GetResponseStreamToStr(list_response);
               
                list_response.Close();
                result=HtmlAgilityPackHelper.GetTable(list_respStr, directoryPath);


                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }

    }
}
