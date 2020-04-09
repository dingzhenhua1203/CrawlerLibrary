using CrawlerMingxing.Model;
using CrawlerMingxing.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrawlerMingxing.Service
{
    public class CrawlerMingxingService
    {
        private static string SearchUrl = "https://sp0.baidu.com/8aQDcjqpAAV3otqbppnN2DJv/api.php?";
        private static string StarPictureUrl = "http://image.baidu.com/search/acjson?";
        private static string PictureUrl = "http://image.baidu.com/search/flip?";
        /// <summary>
        /// 下载明星列表
        /// </summary>
        /// <param name="search"></param>
        public static List<StarInfo> DownLoadStar(SearchParameter search, string directoryPath)
        {
            List<StarInfo> result = new List<StarInfo>();
            try
            {
                StringBuilder sbQueryString = new StringBuilder();
                sbQueryString.Append("resource_id=28266");
                sbQueryString.Append("&from_mid=1");
                sbQueryString.Append("&format=json");
                sbQueryString.Append("&ie=utf-8");
                sbQueryString.Append("&oe=utf-8");
                sbQueryString.Append("&query=明星");
                sbQueryString.Append("&sort_key=");
                sbQueryString.Append("&sort_type=1");
                sbQueryString.Append("&stat0=" + search.Sex);
                sbQueryString.Append("&stat1=" + search.Area);
                sbQueryString.Append("&stat2=");
                sbQueryString.Append("&stat3=");
                sbQueryString.Append(string.Format("&pn={0}", 12 * (search.PageIndex - 1)));
                sbQueryString.Append("&rn=12");
                sbQueryString.Append("&cb=jQuery110203258522962417485_1539066072267");
                sbQueryString.Append("&_=" + search.Timestamp);
                //请求搜索列表
                var list_response = HttpHelper.HttpGetRequest(SearchUrl + sbQueryString.ToString(), null, null, null, keepAlive: true, contentType: HttpHelper.JsonContentType);
                var list_respStr = HttpHelper.GetResponseStreamToStr(list_response);
                var json = list_respStr.Substring(list_respStr.IndexOf("(")).TrimStart('(').TrimEnd(')');
                list_response.Close();
                StarSearchResponse respModel = JsonConvert.DeserializeObject<StarSearchResponse>(json);
                foreach (var item in respModel.data.First().result)
                {
                    var temp = item;

                    var listPictureUrl = GetPictureUrl(temp.ename, search.PictureCount);
                    List<string> pathList = new List<string>();
                    int counter = 0;
                    foreach (var pic in listPictureUrl)
                    {
                        if (counter >= search.PictureCount)
                        {
                            break;
                        }
                        string path = GetPicture(temp.ename, pic, directoryPath);
                        if (!string.IsNullOrWhiteSpace(path))
                        {
                            pathList.Add(path);
                            counter++;
                        }

                    }
                    var model = new StarInfo();
                    model.Name = temp.ename;
                    model.Sex = search.Sex;
                    model.Area = search.Area;
                    model.PicturePath.AddRange(pathList);
                    result.Add(model);
                }
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }


        //public static List<string> DownloadStarPicture(string name, int num, int pageIndex = 1)
        //{
        //    num = num * 2;
        //    List<string> pictureUrl = new List<string>();

        //    StringBuilder sbQueryString = new StringBuilder();
        //    sbQueryString.Append("tn=resultjson_com");
        //    sbQueryString.Append("&ipn=rj");
        //    sbQueryString.Append("&ct=201326592");
        //    sbQueryString.Append("&is=");
        //    sbQueryString.Append("&fp=result");
        //    sbQueryString.Append("&queryWord=");
        //    sbQueryString.Append("&cl=2");
        //    sbQueryString.Append("&lm=-1");
        //    sbQueryString.Append("&ie=utf-8");
        //    sbQueryString.Append("&oe=utf-8");
        //    sbQueryString.Append("&st=-1");
        //    sbQueryString.Append(string.Format("&word={0}", name));
        //    sbQueryString.Append("&ic=0");
        //    sbQueryString.Append("&face=0");
        //    sbQueryString.Append("&istype=2");
        //    sbQueryString.Append("&nc=1");
        //    sbQueryString.Append(string.Format("&step_word={0}", name));
        //    sbQueryString.Append("&pn=" + 30);
        //    sbQueryString.Append("&rn=30");
        //    sbQueryString.Append("&gsm=1e");
        //    //请求搜索列表
        //    var list_response = HttpHelper.HttpGetRequest(StarPictureUrl + sbQueryString.ToString(), null, null, null, keepAlive: true, contentType: HttpHelper.JsonContentType);
        //    var list_respStr = HttpHelper.GetResponseStreamToStr(list_response);
        //    list_response.Close();
        //    StarPictureListModel respModel = JsonConvert.DeserializeObject<StarPictureListModel>(list_respStr);
        //    if (num <= 30)
        //    {
        //        for (int i = 0; i < num; i++)
        //        {
        //            var temp = respModel.data[i];
        //            pictureUrl.Add(temp.thumbURL);
        //        }
        //        return pictureUrl;
        //    }
        //    else
        //    {
        //        int step = 0;
        //        if (num % 30 == 0)
        //        {
        //            step = num / 30;
        //        }
        //        else
        //        {
        //            step = num / 30 + 1;
        //        }
        //        for (int i = 2; i <= step; i++)
        //        {
        //            pictureUrl.AddRange(DownloadStarPicture(name, num, i));
        //        }
        //        return pictureUrl;
        //    }

        //}

        public static List<string> GetPictureUrl(string name, int num, int pageIndex = 1)
        {

            num = num * 2;//防止有失效图片
            List<string> pictureUrl = new List<string>();
            try
            {
                StringBuilder sbQueryString = new StringBuilder();
                sbQueryString.Append("tn=baiduimage");
                sbQueryString.Append("&ct=201326592");
                sbQueryString.Append("&v=flip");
                sbQueryString.Append("&ie=utf-8");
                sbQueryString.Append(string.Format("&word={0}", name));
                sbQueryString.Append("&pn=" + 20 * (pageIndex - 1));

                //请求搜索列表
                var list_response = HttpHelper.HttpGetRequest(PictureUrl + sbQueryString.ToString(), null, null, null, keepAlive: true);
                if (list_response == null)
                {
                    return pictureUrl;
                }
                var list_respStr = HttpHelper.GetResponseStreamToStr(list_response);
                list_response.Close();
                //正则匹配
                Regex reg = new Regex("\"objURL\":\"(.*?)\"");

                MatchCollection matchCollection = reg.Matches(list_respStr);

                if (num <= 30)
                {
                    for (int i = 0; i < num; i++)
                    {
                        var temp = matchCollection[i].Value;
                        var url = temp.Substring(temp.IndexOf(":\"") + 1).Trim('"');
                        pictureUrl.Add(url);
                    }
                    return pictureUrl;
                }
                else
                {
                    int step = 0;
                    if (num % 30 == 0)
                    {
                        step = num / 30;
                    }
                    else
                    {
                        step = num / 30 + 1;
                    }
                    for (int i = 2; i <= step; i++)
                    {
                        pictureUrl.AddRange(GetPictureUrl(name, num, i));
                    }
                    return pictureUrl;
                }
            }
            catch (Exception ex)
            {
                return pictureUrl;
            }

        }
        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        public static string GetPicture(string name, string url, string directoryPath)
        {
            string fileName = "";
            try
            {
                string directory = directoryPath + @"\";
                if (false == System.IO.Directory.Exists(directory))
                {
                    //创建pic文件夹
                    System.IO.Directory.CreateDirectory(directory);
                }
                fileName = DateTimeHelper.GetMillisecondsSpan() + ".jpg";
                string dirpath = directory + fileName;
                var code_response = HttpHelper.HttpGetRequest(url, null, null, null, contentType: HttpHelper.ImageContentType, keepAlive: true);
                if (code_response == null)
                {
                    return "";
                }
                using (Stream stream = code_response.GetResponseStream())
                {
                    Image img = Image.FromStream(stream, true);

                    img.Save(dirpath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    img.Dispose();
                    img = null;
                }

                code_response.Close();

            }
            catch (Exception ex)
            {
                return "";
            }
            return fileName;
        }
    }
}
