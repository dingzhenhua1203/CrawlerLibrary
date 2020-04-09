namespace CrawlerMingxing
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.numPageEnd = new System.Windows.Forms.NumericUpDown();
            this.numPageStart = new System.Windows.Forms.NumericUpDown();
            this.lblMsg = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPictureCount = new System.Windows.Forms.TextBox();
            this.gbArea = new System.Windows.Forms.GroupBox();
            this.rabtnAmerica = new System.Windows.Forms.RadioButton();
            this.rabtnHan = new System.Windows.Forms.RadioButton();
            this.rabtnTokyo = new System.Windows.Forms.RadioButton();
            this.rabtnTW = new System.Windows.Forms.RadioButton();
            this.rabtnHK = new System.Windows.Forms.RadioButton();
            this.rabtnDalu = new System.Windows.Forms.RadioButton();
            this.rabtnAll = new System.Windows.Forms.RadioButton();
            this.gbSex = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rabtnWoman = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDownLoadMingxing = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPageEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPageStart)).BeginInit();
            this.gbArea.SuspendLayout();
            this.gbSex.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numPageEnd);
            this.panel1.Controls.Add(this.numPageStart);
            this.panel1.Controls.Add(this.lblMsg);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtPath);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtPictureCount);
            this.panel1.Controls.Add(this.gbArea);
            this.panel1.Controls.Add(this.gbSex);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnDownLoadMingxing);
            this.panel1.Location = new System.Drawing.Point(23, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(765, 426);
            this.panel1.TabIndex = 0;
            // 
            // numPageEnd
            // 
            this.numPageEnd.Location = new System.Drawing.Point(202, 187);
            this.numPageEnd.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numPageEnd.Name = "numPageEnd";
            this.numPageEnd.Size = new System.Drawing.Size(67, 21);
            this.numPageEnd.TabIndex = 12;
            this.numPageEnd.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numPageEnd.ValueChanged += new System.EventHandler(this.numPageEnd_ValueChanged);
            // 
            // numPageStart
            // 
            this.numPageStart.Location = new System.Drawing.Point(76, 187);
            this.numPageStart.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPageStart.Name = "numPageStart";
            this.numPageStart.Size = new System.Drawing.Size(67, 21);
            this.numPageStart.TabIndex = 12;
            this.numPageStart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPageStart.ValueChanged += new System.EventHandler(this.numPageStart_ValueChanged);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMsg.Location = new System.Drawing.Point(149, 340);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 29);
            this.lblMsg.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(209, 238);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 24);
            this.button1.TabIndex = 10;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(102, 241);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(100, 21);
            this.txtPath.TabIndex = 9;
            this.txtPath.Text = "D:\\Picture";
            this.txtPath.TextChanged += new System.EventHandler(this.txtPath_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "选择路径：";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(376, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "明星图片数量：";
            // 
            // txtPictureCount
            // 
            this.txtPictureCount.Location = new System.Drawing.Point(481, 187);
            this.txtPictureCount.Name = "txtPictureCount";
            this.txtPictureCount.Size = new System.Drawing.Size(100, 21);
            this.txtPictureCount.TabIndex = 6;
            this.txtPictureCount.Text = "3";
            // 
            // gbArea
            // 
            this.gbArea.Controls.Add(this.rabtnAmerica);
            this.gbArea.Controls.Add(this.rabtnHan);
            this.gbArea.Controls.Add(this.rabtnTokyo);
            this.gbArea.Controls.Add(this.rabtnTW);
            this.gbArea.Controls.Add(this.rabtnHK);
            this.gbArea.Controls.Add(this.rabtnDalu);
            this.gbArea.Controls.Add(this.rabtnAll);
            this.gbArea.Location = new System.Drawing.Point(30, 103);
            this.gbArea.Name = "gbArea";
            this.gbArea.Size = new System.Drawing.Size(522, 59);
            this.gbArea.TabIndex = 5;
            this.gbArea.TabStop = false;
            this.gbArea.Text = "地区";
            // 
            // rabtnAmerica
            // 
            this.rabtnAmerica.AutoSize = true;
            this.rabtnAmerica.Location = new System.Drawing.Point(331, 21);
            this.rabtnAmerica.Name = "rabtnAmerica";
            this.rabtnAmerica.Size = new System.Drawing.Size(47, 16);
            this.rabtnAmerica.TabIndex = 0;
            this.rabtnAmerica.TabStop = true;
            this.rabtnAmerica.Text = "欧美";
            this.rabtnAmerica.UseVisualStyleBackColor = true;
            // 
            // rabtnHan
            // 
            this.rabtnHan.AutoSize = true;
            this.rabtnHan.Location = new System.Drawing.Point(278, 20);
            this.rabtnHan.Name = "rabtnHan";
            this.rabtnHan.Size = new System.Drawing.Size(47, 16);
            this.rabtnHan.TabIndex = 0;
            this.rabtnHan.TabStop = true;
            this.rabtnHan.Text = "韩国";
            this.rabtnHan.UseVisualStyleBackColor = true;
            // 
            // rabtnTokyo
            // 
            this.rabtnTokyo.AutoSize = true;
            this.rabtnTokyo.Location = new System.Drawing.Point(225, 20);
            this.rabtnTokyo.Name = "rabtnTokyo";
            this.rabtnTokyo.Size = new System.Drawing.Size(47, 16);
            this.rabtnTokyo.TabIndex = 0;
            this.rabtnTokyo.TabStop = true;
            this.rabtnTokyo.Text = "日本";
            this.rabtnTokyo.UseVisualStyleBackColor = true;
            // 
            // rabtnTW
            // 
            this.rabtnTW.AutoSize = true;
            this.rabtnTW.Location = new System.Drawing.Point(172, 20);
            this.rabtnTW.Name = "rabtnTW";
            this.rabtnTW.Size = new System.Drawing.Size(47, 16);
            this.rabtnTW.TabIndex = 0;
            this.rabtnTW.TabStop = true;
            this.rabtnTW.Text = "台湾";
            this.rabtnTW.UseVisualStyleBackColor = true;
            // 
            // rabtnHK
            // 
            this.rabtnHK.AutoSize = true;
            this.rabtnHK.Location = new System.Drawing.Point(119, 20);
            this.rabtnHK.Name = "rabtnHK";
            this.rabtnHK.Size = new System.Drawing.Size(47, 16);
            this.rabtnHK.TabIndex = 0;
            this.rabtnHK.TabStop = true;
            this.rabtnHK.Text = "香港";
            this.rabtnHK.UseVisualStyleBackColor = true;
            // 
            // rabtnDalu
            // 
            this.rabtnDalu.AutoSize = true;
            this.rabtnDalu.Location = new System.Drawing.Point(66, 21);
            this.rabtnDalu.Name = "rabtnDalu";
            this.rabtnDalu.Size = new System.Drawing.Size(47, 16);
            this.rabtnDalu.TabIndex = 0;
            this.rabtnDalu.TabStop = true;
            this.rabtnDalu.Text = "内地";
            this.rabtnDalu.UseVisualStyleBackColor = true;
            // 
            // rabtnAll
            // 
            this.rabtnAll.AutoSize = true;
            this.rabtnAll.Location = new System.Drawing.Point(13, 21);
            this.rabtnAll.Name = "rabtnAll";
            this.rabtnAll.Size = new System.Drawing.Size(47, 16);
            this.rabtnAll.TabIndex = 0;
            this.rabtnAll.TabStop = true;
            this.rabtnAll.Text = "全部";
            this.rabtnAll.UseVisualStyleBackColor = true;
            // 
            // gbSex
            // 
            this.gbSex.Controls.Add(this.radioButton1);
            this.gbSex.Controls.Add(this.rabtnWoman);
            this.gbSex.Location = new System.Drawing.Point(30, 18);
            this.gbSex.Name = "gbSex";
            this.gbSex.Size = new System.Drawing.Size(166, 56);
            this.gbSex.TabIndex = 4;
            this.gbSex.TabStop = false;
            this.gbSex.Text = "性别";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(13, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(35, 16);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "男";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // rabtnWoman
            // 
            this.rabtnWoman.AutoSize = true;
            this.rabtnWoman.Location = new System.Drawing.Point(66, 20);
            this.rabtnWoman.Name = "rabtnWoman";
            this.rabtnWoman.Size = new System.Drawing.Size(35, 16);
            this.rabtnWoman.TabIndex = 3;
            this.rabtnWoman.TabStop = true;
            this.rabtnWoman.Text = "女";
            this.rabtnWoman.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(161, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "页尾:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "页起:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnDownLoadMingxing
            // 
            this.btnDownLoadMingxing.Location = new System.Drawing.Point(30, 291);
            this.btnDownLoadMingxing.Name = "btnDownLoadMingxing";
            this.btnDownLoadMingxing.Size = new System.Drawing.Size(75, 23);
            this.btnDownLoadMingxing.TabIndex = 0;
            this.btnDownLoadMingxing.Text = "下载明星图片";
            this.btnDownLoadMingxing.UseVisualStyleBackColor = true;
            this.btnDownLoadMingxing.Click += new System.EventHandler(this.btnDownLoadMingxing_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "图片采集";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPageEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPageStart)).EndInit();
            this.gbArea.ResumeLayout(false);
            this.gbArea.PerformLayout();
            this.gbSex.ResumeLayout(false);
            this.gbSex.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDownLoadMingxing;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbSex;
        private System.Windows.Forms.RadioButton rabtnWoman;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox gbArea;
        private System.Windows.Forms.RadioButton rabtnAmerica;
        private System.Windows.Forms.RadioButton rabtnHan;
        private System.Windows.Forms.RadioButton rabtnTokyo;
        private System.Windows.Forms.RadioButton rabtnTW;
        private System.Windows.Forms.RadioButton rabtnHK;
        private System.Windows.Forms.RadioButton rabtnDalu;
        private System.Windows.Forms.RadioButton rabtnAll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPictureCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.NumericUpDown numPageStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numPageEnd;
    }
}

