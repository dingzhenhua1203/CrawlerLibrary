using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerMingxing.Model
{
    public class StarInfo
    {
        public StarInfo() {
            PicturePath = new List<string>();
        }
        public string Name { get; set; }

        public string Sex { get; set; }

        public string Area { get; set; }
        public List<string> PicturePath { get; set; }

    }
}
