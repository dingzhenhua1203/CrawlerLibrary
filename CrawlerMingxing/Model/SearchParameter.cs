using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerMingxing.Model
{
    public class SearchParameter
    {
        public string Sex { get; set; }

        public string Area { get; set; }

        public int PageIndex { get; set; }

        /// <summary>
        /// 单个明星的图片数量
        /// </summary>
        public int PictureCount { get; set; }

        public string Timestamp { get; set; }
    }
}
