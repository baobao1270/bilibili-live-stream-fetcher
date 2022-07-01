namespace BiliBiliLiveStreamFetcher
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ButtonParse = new System.Windows.Forms.Button();
            this.TextBoxRoomIdUrl = new System.Windows.Forms.TextBox();
            this.LabelRoomUrl = new System.Windows.Forms.Label();
            this.ListViewStreamUrls = new System.Windows.Forms.ListView();
            this.WebBrowserInstruction = new System.Windows.Forms.WebBrowser();
            this.ButtonCopyUrl = new System.Windows.Forms.Button();
            this.ButtonFillUrlLuotianyi = new System.Windows.Forms.Button();
            this.ButtonFillUrlTest = new System.Windows.Forms.Button();
            this.ButtonFillUrDev = new System.Windows.Forms.Button();
            this.ProgressBarHttpRequest = new System.Windows.Forms.ProgressBar();
            this.ButtonOpenUrl = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonParse
            // 
            this.ButtonParse.Location = new System.Drawing.Point(747, 12);
            this.ButtonParse.Name = "ButtonParse";
            this.ButtonParse.Size = new System.Drawing.Size(75, 23);
            this.ButtonParse.TabIndex = 0;
            this.ButtonParse.Text = "解析";
            this.ButtonParse.UseVisualStyleBackColor = true;
            this.ButtonParse.Click += new System.EventHandler(this.ButtonParse_Click);
            // 
            // TextBoxRoomIdUrl
            // 
            this.TextBoxRoomIdUrl.Location = new System.Drawing.Point(95, 12);
            this.TextBoxRoomIdUrl.Name = "TextBoxRoomIdUrl";
            this.TextBoxRoomIdUrl.Size = new System.Drawing.Size(646, 21);
            this.TextBoxRoomIdUrl.TabIndex = 1;
            this.TextBoxRoomIdUrl.Text = "https://live.bilibili.com/1546736";
            // 
            // LabelRoomUrl
            // 
            this.LabelRoomUrl.AutoSize = true;
            this.LabelRoomUrl.Location = new System.Drawing.Point(12, 17);
            this.LabelRoomUrl.Name = "LabelRoomUrl";
            this.LabelRoomUrl.Size = new System.Drawing.Size(77, 12);
            this.LabelRoomUrl.TabIndex = 2;
            this.LabelRoomUrl.Text = "直播间地址：";
            // 
            // ListViewStreamUrls
            // 
            this.ListViewStreamUrls.FullRowSelect = true;
            this.ListViewStreamUrls.HideSelection = false;
            this.ListViewStreamUrls.Location = new System.Drawing.Point(14, 202);
            this.ListViewStreamUrls.Name = "ListViewStreamUrls";
            this.ListViewStreamUrls.Size = new System.Drawing.Size(810, 218);
            this.ListViewStreamUrls.TabIndex = 3;
            this.ListViewStreamUrls.UseCompatibleStateImageBehavior = false;
            this.ListViewStreamUrls.View = System.Windows.Forms.View.Details;
            // 
            // WebBrowserInstruction
            // 
            this.WebBrowserInstruction.Location = new System.Drawing.Point(14, 42);
            this.WebBrowserInstruction.MinimumSize = new System.Drawing.Size(20, 20);
            this.WebBrowserInstruction.Name = "WebBrowserInstruction";
            this.WebBrowserInstruction.ScrollBarsEnabled = false;
            this.WebBrowserInstruction.Size = new System.Drawing.Size(602, 154);
            this.WebBrowserInstruction.TabIndex = 4;
            // 
            // ButtonCopyUrl
            // 
            this.ButtonCopyUrl.Location = new System.Drawing.Point(12, 426);
            this.ButtonCopyUrl.Name = "ButtonCopyUrl";
            this.ButtonCopyUrl.Size = new System.Drawing.Size(400, 23);
            this.ButtonCopyUrl.TabIndex = 5;
            this.ButtonCopyUrl.Text = "复制选中直播流 URL";
            this.ButtonCopyUrl.UseVisualStyleBackColor = true;
            this.ButtonCopyUrl.Click += new System.EventHandler(this.ButtonCopyUrl_Click);
            // 
            // ButtonFillUrlLuotianyi
            // 
            this.ButtonFillUrlLuotianyi.Location = new System.Drawing.Point(622, 41);
            this.ButtonFillUrlLuotianyi.Name = "ButtonFillUrlLuotianyi";
            this.ButtonFillUrlLuotianyi.Size = new System.Drawing.Size(200, 23);
            this.ButtonFillUrlLuotianyi.TabIndex = 6;
            this.ButtonFillUrlLuotianyi.Text = "填入洛天依直播间地址";
            this.ButtonFillUrlLuotianyi.UseVisualStyleBackColor = true;
            this.ButtonFillUrlLuotianyi.Click += new System.EventHandler(this.ButtonFillUrlLuotianyi_Click);
            // 
            // ButtonFillUrlTest
            // 
            this.ButtonFillUrlTest.Location = new System.Drawing.Point(622, 70);
            this.ButtonFillUrlTest.Name = "ButtonFillUrlTest";
            this.ButtonFillUrlTest.Size = new System.Drawing.Size(200, 23);
            this.ButtonFillUrlTest.TabIndex = 7;
            this.ButtonFillUrlTest.Text = "填入测试直播间地址 (720P)";
            this.ButtonFillUrlTest.UseVisualStyleBackColor = true;
            this.ButtonFillUrlTest.Click += new System.EventHandler(this.ButtonFillUrlTest_Click);
            // 
            // ButtonFillUrDev
            // 
            this.ButtonFillUrDev.Location = new System.Drawing.Point(622, 99);
            this.ButtonFillUrDev.Name = "ButtonFillUrDev";
            this.ButtonFillUrDev.Size = new System.Drawing.Size(200, 23);
            this.ButtonFillUrDev.TabIndex = 8;
            this.ButtonFillUrDev.Text = "填入测试开发者地址";
            this.ButtonFillUrDev.UseVisualStyleBackColor = true;
            this.ButtonFillUrDev.Click += new System.EventHandler(this.ButtonFillUrDev_Click);
            // 
            // ProgressBarHttpRequest
            // 
            this.ProgressBarHttpRequest.Location = new System.Drawing.Point(622, 128);
            this.ProgressBarHttpRequest.Name = "ProgressBarHttpRequest";
            this.ProgressBarHttpRequest.Size = new System.Drawing.Size(200, 68);
            this.ProgressBarHttpRequest.TabIndex = 9;
            // 
            // ButtonOpenUrl
            // 
            this.ButtonOpenUrl.Location = new System.Drawing.Point(422, 426);
            this.ButtonOpenUrl.Name = "ButtonOpenUrl";
            this.ButtonOpenUrl.Size = new System.Drawing.Size(400, 23);
            this.ButtonOpenUrl.TabIndex = 10;
            this.ButtonOpenUrl.Text = "用自带播放器打开选中 URL";
            this.ButtonOpenUrl.UseVisualStyleBackColor = true;
            this.ButtonOpenUrl.Click += new System.EventHandler(this.ButtonOpenUrl_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 461);
            this.Controls.Add(this.ButtonOpenUrl);
            this.Controls.Add(this.ProgressBarHttpRequest);
            this.Controls.Add(this.ButtonFillUrDev);
            this.Controls.Add(this.ButtonFillUrlTest);
            this.Controls.Add(this.ButtonFillUrlLuotianyi);
            this.Controls.Add(this.ButtonCopyUrl);
            this.Controls.Add(this.WebBrowserInstruction);
            this.Controls.Add(this.ListViewStreamUrls);
            this.Controls.Add(this.LabelRoomUrl);
            this.Controls.Add(this.TextBoxRoomIdUrl);
            this.Controls.Add(this.ButtonParse);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(850, 500);
            this.MinimumSize = new System.Drawing.Size(850, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "链接解析";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonParse;
        private System.Windows.Forms.TextBox TextBoxRoomIdUrl;
        private System.Windows.Forms.Label LabelRoomUrl;
        private System.Windows.Forms.ListView ListViewStreamUrls;
        private System.Windows.Forms.WebBrowser WebBrowserInstruction;
        private System.Windows.Forms.Button ButtonCopyUrl;
        private System.Windows.Forms.Button ButtonFillUrlLuotianyi;
        private System.Windows.Forms.Button ButtonFillUrlTest;
        private System.Windows.Forms.Button ButtonFillUrDev;
        private System.Windows.Forms.ProgressBar ProgressBarHttpRequest;
        private System.Windows.Forms.Button ButtonOpenUrl;
    }
}

