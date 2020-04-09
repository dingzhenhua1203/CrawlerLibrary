using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerMingxing.Model
{
    public class StarSearchResponse
    {
        public StarSearchResponse()
        {
            data = new List<Datum>();
        }
        public List<Datum> data { get; set; }
    }

    public class Datum
    {
        public Datum (){
            result = new List<Result>();
        }
        public List<Result> result { get; set; }
    }

    public class Result
    {
        public string ename { get; set; }
        public string pic_4n_78 { get; set; }
        public string selpic { get; set; }
    }


}
