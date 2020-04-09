using asprise_ocr_api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DouYinData.Util
{
    public class AspriseOCRHelper
    {

        public static string  ReadImage() {
            AspriseOCR.SetUp();
            AspriseOCR ocr = new AspriseOCR();
            ocr.StartEngine("eng", AspriseOCR.SPEED_FASTEST);
            string s = ocr.Recognize("D:\\DouYin\\1539354248783.jpg", -1, -1, -1, -1, -1, AspriseOCR.RECOGNIZE_TYPE_ALL, AspriseOCR.OUTPUT_FORMAT_PLAINTEXT);

            ocr.StopEngine();
            return s;
        }
    }
}
