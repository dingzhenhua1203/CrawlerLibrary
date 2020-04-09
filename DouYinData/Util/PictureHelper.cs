using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouYinData.Util
{
    public class PictureHelper
    {
        /// <summary>
        /// base64编码的文本 转为   图片
        /// </summary>
        /// <param name="basestr">base64字符串</param>
        /// <returns>转换后的Bitmap对象</returns>
        public static Bitmap Base64StringToImage(string basestr)
        {
            Bitmap bitmap = null;
            try
            {
                String inputStr = basestr;
                byte[] arr = Convert.FromBase64String(inputStr);
                MemoryStream ms = new MemoryStream(arr);
                Bitmap bmp = new Bitmap(ms);
                ms.Close();
                bitmap = bmp;
                //MessageBox.Show("转换成功！");
            }
            catch (Exception ex)
            {

            }
            return bitmap;
        }

        public static string SaveBase64ToImage(string baseStr, string path, string imgName)
        {

            string filename = "";
            string base64 = baseStr.Substring(baseStr.IndexOf(",") + 1);      //将‘，’以前的多余字符串删除
            Bitmap bitmap = null;//定义一个Bitmap对象，接收转换完成的图片
            try//会有异常抛出，try，catch一下
            {
                byte[] arr = Convert.FromBase64String(base64);//将纯净资源Base64转换成等效的8位无符号整形数组
                string directory = path + @"\";
                if (false == System.IO.Directory.Exists(directory))
                {
                    //创建pic文件夹
                    System.IO.Directory.CreateDirectory(directory);
                }
                filename = directory + imgName + ".jpg";//所要保存的相对路径及名字
                MemoryStream ms = new MemoryStream(arr);
                bitmap = new Bitmap(ms);
                ms.Dispose();
                ms = null;
                using (MemoryStream memory = new MemoryStream())
                {

                    using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite))
                    {
                        bitmap.Save(memory, ImageFormat.Jpeg);
                        bitmap.Dispose();
                        bitmap = null;
                        byte[] bytes = memory.ToArray();
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return filename;//返回相对路径
        }

    }
}
