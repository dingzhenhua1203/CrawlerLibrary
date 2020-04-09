using CrawlerMingxing.Model;
using CrawlerMingxing.Service;
using CrawlerMingxing.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrawlerMingxing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            lblMsg.Text = "";
            btnDownLoadMingxing.Text = "下载明星图";
        }

        private void btnDownLoadMingxing_Click(object sender, EventArgs e)
        {
            if (!numPageStart.Text.IsNumeric())
            {
                MessageBox.Show("请填写起始页号,并且要求数字");
                return;
            }
            if (!numPageEnd.Text.IsNumeric())
            {
                MessageBox.Show("请填写结尾页号,并且要求数字");
                return;
            }
            if (txtPath.Text == "")
            {
                MessageBox.Show("请选择路径");
                return;
            }
            int pageStart = numPageStart.Text.PackInt();
            int pageEnd = numPageEnd.Text.PackInt();
            if (pageEnd < pageStart)
            {
                MessageBox.Show("结尾页号不得小于起始页号");
                return;
            }

            string sex = "";
            string area = "";
            string path = txtPath.Text;
            for (int i = 0; i < this.gbSex.Controls.Count; i++)
            {
                RadioButton rb = this.gbSex.Controls[i] as RadioButton;
                if (rb.Checked == true)
                {
                    sex = rb.Text.ToString();
                }
            }
            for (int i = 0; i < this.gbArea.Controls.Count; i++)
            {
                RadioButton rb = this.gbArea.Controls[i] as RadioButton;
                if (rb.Checked == true)
                {
                    area = rb.Text.ToString();
                }
            }
            if (string.IsNullOrWhiteSpace(sex))
            {
                MessageBox.Show("请选择性别");
                return;
            }
            if (string.IsNullOrWhiteSpace(area))
            {
                MessageBox.Show("请选择地区");
                return;
            }

            Thread t = new Thread(() =>
            {
                lblMsg.Text = "正在下载图片，请稍后...";
                btnDownLoadMingxing.Text = "loading...";
                btnDownLoadMingxing.Enabled = false;
                SearchParameter search = new SearchParameter();
                List<StarInfo> result = new List<StarInfo>();

                for (int i = pageStart; i <= pageEnd; i++)
                {
                    search.Area = area;
                    search.Sex = sex;
                    search.PageIndex =i;
                    search.PictureCount = txtPictureCount.Text.PackInt();
                    search.Timestamp = DateTimeHelper.GetMillisecondsSpan();
                    result.AddRange(CrawlerMingxingService.DownLoadStar(search, path));
                }
                var excelPath = ExportExcel(result, path, pageStart,pageEnd, sex, area);
                lblMsg.Text = "excel保存成功";
                btnDownLoadMingxing.Text = "下载明星图";
                btnDownLoadMingxing.Enabled = true;
            });
            t.IsBackground = true;
            t.Start();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            txtPath.Text = path.SelectedPath;
        }

        private string ExportExcel(List<StarInfo> list, string filePath, int pageStart,int pageEnd, string sex, string area)
        {
            try
            {
                SaveFileDialog sflg = new SaveFileDialog();
                sflg.Filter = "Excel(*.xls)|*.xls|Excel(*.xlsx)|*.xlsx";

                string fileName = "第" + pageStart + "页至第"+pageEnd+"页" + sex + "明星(地区：" + area + ").xlsx";
                filePath = filePath + @"\" + fileName;
                #region 导出封装
                NPOI.SS.UserModel.IWorkbook book = null;
                //if (sflg.FilterIndex == 1)
                //{
                //    book = new NPOI.HSSF.UserModel.HSSFWorkbook();
                //}
                //else
                //{
                book = new NPOI.XSSF.UserModel.XSSFWorkbook();
                //}
                //添加一个sheet
                NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");
                int pictureCellCount = list.First().PicturePath.Count;
                //给sheet1添加第一行的头部标题
                NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);
                row1.CreateCell(0).SetCellValue("姓名");
                row1.CreateCell(1).SetCellValue("性别");
                row1.CreateCell(2).SetCellValue("归属地");
                for (int i = 0; i < pictureCellCount; i++)
                {
                    row1.CreateCell(3 + i).SetCellValue("图片" + (i + 1));
                }

                //将数据逐步写入sheet1各个行
                for (int i = 0; i < list.Count; i++)
                {
                    NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);
                    rowtemp.CreateCell(0).SetCellValue(list[i].Name);
                    rowtemp.CreateCell(1).SetCellValue(list[i].Sex);
                    rowtemp.CreateCell(2).SetCellValue(list[i].Area);
                    for (int j = 0; j < list[i].PicturePath.Count; j++)
                    {
                        rowtemp.CreateCell(3 + j).SetCellValue(list[i].PicturePath[j]);
                    }
                }
                #endregion
                using (var fs = File.OpenWrite(filePath))
                {
                    book.Write(fs);   //向打开的这个xls文件中写入mySheet表并保存。
                    return "success";
                }
                //using (FileStream fs = new FileStream(sflg.FileName, FileMode.Create, FileAccess.Write))
                //{
                //    byte[] data = ms.ToArray();
                //    fs.Write(data, 0, data.Length);
                //    fs.Flush();
                //}
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        private void numPageStart_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numPageEnd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
