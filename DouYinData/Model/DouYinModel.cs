using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerMingxing.Model
{
    public class DouYinModel
    {
        public DouYinModel()
        {
            FamousVideo = new List<string>();

        }

        public string HeadPicture { get; set; }

        public string NickName { get; set; }

        public string Sex { get; set; }

        public string FanNum { get; set; }

        public string ZanNum { get; set; }

        public List<string> FamousVideo { get; set; }
    }



}
