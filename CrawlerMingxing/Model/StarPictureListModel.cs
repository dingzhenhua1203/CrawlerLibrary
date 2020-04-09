using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerMingxing.Model
{
    public class StarPictureListModel
    {
        public StarPictureListModel() {
            data = new List<PictureData>();
        }
        public List<PictureData> data { get; set; }
    }

    public class PictureData
    {
        public string adType { get; set; }
        public string hasAspData { get; set; }
        public string thumbURL { get; set; }
        public string middleURL { get; set; }
        public string largeTnImageUrl { get; set; }
        public string objURL { get; set; }
        public string fromURL { get; set; }
       
    }

  

}
