namespace Weather72HRs
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                realtimeClient?.Dispose();
                hourForecastClient?.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            gbRealtime = new GroupBox();
            btnDetails = new Button();
            btnRefresh = new Button();
            lblWindValue = new Label();
            lblHumidityValue = new Label();
            lblFeelValue = new Label();
            lblWindDesc = new Label();
            lblHumidityDesc = new Label();
            lblFeelDesc = new Label();
            lblRealtimeTemp = new Label();
            lblRealtimeTitle = new Label();
            pbRealtimeIcon = new PictureBox();
            btnAreaSelect = new Button();
            gbForecast = new GroupBox();
            btnRefreshFc = new Button();
            btnDetailsFc = new Button();
            btnAlerts = new Button();
            lvForecast = new ListView();
            time = new ColumnHeader();
            temperature = new ColumnHeader();
            feel = new ColumnHeader();
            humidity = new ColumnHeader();
            windDir = new ColumnHeader();
            windLvl = new ColumnHeader();
            imglForecast = new ImageList(components);
            gbRealtime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbRealtimeIcon).BeginInit();
            gbForecast.SuspendLayout();
            SuspendLayout();
            // 
            // gbRealtime
            // 
            gbRealtime.Controls.Add(btnDetails);
            gbRealtime.Controls.Add(btnRefresh);
            gbRealtime.Controls.Add(lblWindValue);
            gbRealtime.Controls.Add(lblHumidityValue);
            gbRealtime.Controls.Add(lblFeelValue);
            gbRealtime.Controls.Add(lblWindDesc);
            gbRealtime.Controls.Add(lblHumidityDesc);
            gbRealtime.Controls.Add(lblFeelDesc);
            gbRealtime.Controls.Add(lblRealtimeTemp);
            gbRealtime.Controls.Add(lblRealtimeTitle);
            gbRealtime.Controls.Add(pbRealtimeIcon);
            gbRealtime.Location = new Point(28, 31);
            gbRealtime.Name = "gbRealtime";
            gbRealtime.Size = new Size(582, 302);
            gbRealtime.TabIndex = 0;
            gbRealtime.TabStop = false;
            gbRealtime.Text = "直击现状";
            // 
            // btnDetails
            // 
            btnDetails.Location = new Point(368, 197);
            btnDetails.Name = "btnDetails";
            btnDetails.Size = new Size(133, 44);
            btnDetails.TabIndex = 10;
            btnDetails.Text = "查看详情";
            btnDetails.UseVisualStyleBackColor = true;
            btnDetails.Click += btnDetails_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(226, 197);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(133, 44);
            btnRefresh.TabIndex = 9;
            btnRefresh.Text = "刷新信息";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblWindValue
            // 
            lblWindValue.BackColor = Color.Turquoise;
            lblWindValue.Font = new Font("Tahoma", 15.75F);
            lblWindValue.Location = new Point(402, 154);
            lblWindValue.Name = "lblWindValue";
            lblWindValue.Size = new Size(99, 28);
            lblWindValue.TabIndex = 8;
            lblWindValue.Text = "--m/s";
            lblWindValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblHumidityValue
            // 
            lblHumidityValue.BackColor = Color.SpringGreen;
            lblHumidityValue.Font = new Font("Tahoma", 15.75F);
            lblHumidityValue.Location = new Point(402, 118);
            lblHumidityValue.Name = "lblHumidityValue";
            lblHumidityValue.Size = new Size(99, 28);
            lblHumidityValue.TabIndex = 7;
            lblHumidityValue.Text = "--%";
            lblHumidityValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblFeelValue
            // 
            lblFeelValue.BackColor = Color.SandyBrown;
            lblFeelValue.Font = new Font("Tahoma", 15.75F);
            lblFeelValue.Location = new Point(402, 82);
            lblFeelValue.Name = "lblFeelValue";
            lblFeelValue.Size = new Size(99, 28);
            lblFeelValue.TabIndex = 6;
            lblFeelValue.Text = "--°C";
            lblFeelValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblWindDesc
            // 
            lblWindDesc.BackColor = SystemColors.ControlLightLight;
            lblWindDesc.Location = new Point(226, 154);
            lblWindDesc.Name = "lblWindDesc";
            lblWindDesc.Size = new Size(176, 28);
            lblWindDesc.TabIndex = 5;
            lblWindDesc.Text = "--";
            lblWindDesc.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblHumidityDesc
            // 
            lblHumidityDesc.BackColor = SystemColors.ControlLightLight;
            lblHumidityDesc.Location = new Point(226, 118);
            lblHumidityDesc.Name = "lblHumidityDesc";
            lblHumidityDesc.Size = new Size(176, 28);
            lblHumidityDesc.TabIndex = 4;
            lblHumidityDesc.Text = "--";
            lblHumidityDesc.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblFeelDesc
            // 
            lblFeelDesc.BackColor = SystemColors.ControlLightLight;
            lblFeelDesc.Location = new Point(226, 82);
            lblFeelDesc.Name = "lblFeelDesc";
            lblFeelDesc.Size = new Size(176, 28);
            lblFeelDesc.TabIndex = 3;
            lblFeelDesc.Text = "--";
            lblFeelDesc.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRealtimeTemp
            // 
            lblRealtimeTemp.Font = new Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRealtimeTemp.Location = new Point(47, 213);
            lblRealtimeTemp.Name = "lblRealtimeTemp";
            lblRealtimeTemp.Size = new Size(164, 28);
            lblRealtimeTemp.TabIndex = 2;
            lblRealtimeTemp.Text = "--°C";
            lblRealtimeTemp.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRealtimeTitle
            // 
            lblRealtimeTitle.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblRealtimeTitle.Location = new Point(47, 185);
            lblRealtimeTitle.Name = "lblRealtimeTitle";
            lblRealtimeTitle.Size = new Size(164, 28);
            lblRealtimeTitle.TabIndex = 1;
            lblRealtimeTitle.Text = "--";
            lblRealtimeTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pbRealtimeIcon
            // 
            pbRealtimeIcon.BackColor = SystemColors.Control;
            pbRealtimeIcon.Location = new Point(79, 82);
            pbRealtimeIcon.Name = "pbRealtimeIcon";
            pbRealtimeIcon.Size = new Size(100, 100);
            pbRealtimeIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pbRealtimeIcon.TabIndex = 0;
            pbRealtimeIcon.TabStop = false;
            // 
            // btnAreaSelect
            // 
            btnAreaSelect.Location = new Point(28, 738);
            btnAreaSelect.Name = "btnAreaSelect";
            btnAreaSelect.Size = new Size(582, 44);
            btnAreaSelect.TabIndex = 11;
            btnAreaSelect.Text = "选择城市";
            btnAreaSelect.UseVisualStyleBackColor = true;
            btnAreaSelect.Click += btnAreaSelect_Click;
            // 
            // gbForecast
            // 
            gbForecast.Controls.Add(btnRefreshFc);
            gbForecast.Controls.Add(btnDetailsFc);
            gbForecast.Controls.Add(btnAlerts);
            gbForecast.Controls.Add(lvForecast);
            gbForecast.Location = new Point(28, 359);
            gbForecast.Name = "gbForecast";
            gbForecast.Size = new Size(582, 348);
            gbForecast.TabIndex = 12;
            gbForecast.TabStop = false;
            gbForecast.Text = "展望未来";
            // 
            // btnRefreshFc
            // 
            btnRefreshFc.Location = new Point(226, 269);
            btnRefreshFc.Name = "btnRefreshFc";
            btnRefreshFc.Size = new Size(133, 44);
            btnRefreshFc.TabIndex = 13;
            btnRefreshFc.Text = "刷新信息";
            btnRefreshFc.UseVisualStyleBackColor = true;
            btnRefreshFc.Click += btnRefreshFc_Click;
            // 
            // btnDetailsFc
            // 
            btnDetailsFc.Location = new Point(368, 269);
            btnDetailsFc.Name = "btnDetailsFc";
            btnDetailsFc.Size = new Size(133, 44);
            btnDetailsFc.TabIndex = 12;
            btnDetailsFc.Text = "查看详情";
            btnDetailsFc.UseVisualStyleBackColor = true;
            btnDetailsFc.Click += btnDetailsFc_Click;
            // 
            // btnAlerts
            // 
            btnAlerts.Location = new Point(84, 269);
            btnAlerts.Name = "btnAlerts";
            btnAlerts.Size = new Size(133, 44);
            btnAlerts.TabIndex = 11;
            btnAlerts.Text = "天气提示";
            btnAlerts.UseVisualStyleBackColor = true;
            btnAlerts.Click += btnAlerts_Click;
            // 
            // lvForecast
            // 
            lvForecast.Columns.AddRange(new ColumnHeader[] { time, temperature, feel, humidity, windDir, windLvl });
            lvForecast.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lvForecast.HeaderStyle = ColumnHeaderStyle.None;
            lvForecast.LargeImageList = imglForecast;
            lvForecast.Location = new Point(72, 54);
            lvForecast.MultiSelect = false;
            lvForecast.Name = "lvForecast";
            lvForecast.Size = new Size(441, 199);
            lvForecast.SmallImageList = imglForecast;
            lvForecast.TabIndex = 0;
            lvForecast.UseCompatibleStateImageBehavior = false;
            lvForecast.View = View.Details;
            // 
            // time
            // 
            time.Text = "";
            time.Width = 120;
            // 
            // temperature
            // 
            temperature.Text = "";
            temperature.TextAlign = HorizontalAlignment.Center;
            // 
            // feel
            // 
            feel.Text = "";
            feel.TextAlign = HorizontalAlignment.Center;
            // 
            // humidity
            // 
            humidity.Text = "";
            humidity.TextAlign = HorizontalAlignment.Center;
            // 
            // windDir
            // 
            windDir.Text = "";
            windDir.TextAlign = HorizontalAlignment.Center;
            // 
            // windLvl
            // 
            windLvl.Text = "";
            windLvl.TextAlign = HorizontalAlignment.Center;
            // 
            // imglForecast
            // 
            imglForecast.ColorDepth = ColorDepth.Depth32Bit;
            imglForecast.ImageSize = new Size(64, 64);
            imglForecast.TransparentColor = Color.Transparent;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 811);
            Controls.Add(gbForecast);
            Controls.Add(btnAreaSelect);
            Controls.Add(gbRealtime);
            Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(5, 4, 5, 4);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "天气72小时速报";
            gbRealtime.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbRealtimeIcon).EndInit();
            gbForecast.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbRealtime;
        private PictureBox pbRealtimeIcon;
        private Label lblRealtimeTitle;
        private Label lblRealtimeTemp;
        private Label lblWindDesc;
        private Label lblHumidityDesc;
        private Label lblFeelDesc;
        private Label lblWindValue;
        private Label lblHumidityValue;
        private Label lblFeelValue;
        private Button btnRefresh;
        private Button btnDetails;
        private Button btnAreaSelect;
        private GroupBox gbForecast;
        private ListView lvForecast;
        private ImageList imglForecast;
        private ColumnHeader time;
        private ColumnHeader temperature;
        private ColumnHeader feel;
        private ColumnHeader humidity;
        private ColumnHeader windDir;
        private ColumnHeader windLvl;
        private Button btnAlerts;
        private Button btnRefreshFc;
        private Button btnDetailsFc;
    }
}
