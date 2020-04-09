using DouYinData.Service;
using DouYinData.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DouYinData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            txtPath.Text = path.SelectedPath;
        }

        private void btnDownLoad_Click(object sender, EventArgs e)
        {
            string path = txtPath.Text;

            AspriseOCRHelper.ReadImage();
            //CrawlerService.DownLoad(1, path);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string date1 = DateTime.Today.AddHours(1).ToString("HH:mm");
            string date2 = DateTime.Now.ToString("HH:mm");
           var ss= DateTime.Compare(Convert.ToDateTime(date1), Convert.ToDateTime(date2));
            var mm=DateTime.Today+  date2;
        }
    }
}
