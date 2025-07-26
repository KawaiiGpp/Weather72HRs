namespace Weather72HRs.Forms.AlertList
{
    partial class AlertListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lvAlertList = new ListView();
            title = new ColumnHeader();
            description = new ColumnHeader();
            imglAlertList = new ImageList(components);
            lblTitle = new Label();
            SuspendLayout();
            // 
            // lvAlertList
            // 
            lvAlertList.Columns.AddRange(new ColumnHeader[] { title, description });
            lvAlertList.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lvAlertList.HeaderStyle = ColumnHeaderStyle.None;
            lvAlertList.LargeImageList = imglAlertList;
            lvAlertList.Location = new Point(28, 63);
            lvAlertList.MultiSelect = false;
            lvAlertList.Name = "lvAlertList";
            lvAlertList.Size = new Size(430, 296);
            lvAlertList.SmallImageList = imglAlertList;
            lvAlertList.TabIndex = 0;
            lvAlertList.UseCompatibleStateImageBehavior = false;
            lvAlertList.View = View.Details;
            lvAlertList.DoubleClick += lvAlertList_DoubleClick;
            // 
            // title
            // 
            title.Width = 175;
            // 
            // description
            // 
            description.Width = 230;
            // 
            // imglAlertList
            // 
            imglAlertList.ColorDepth = ColorDepth.Depth32Bit;
            imglAlertList.ImageSize = new Size(90, 72);
            imglAlertList.TransparentColor = Color.Transparent;
            // 
            // lblTitle
            // 
            lblTitle.Location = new Point(28, 22);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(430, 36);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "--";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AlertListForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(490, 392);
            Controls.Add(lblTitle);
            Controls.Add(lvAlertList);
            Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(5, 4, 5, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AlertListForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "天气提示";
            ResumeLayout(false);
        }

        #endregion

        private ListView lvAlertList;
        private ImageList imglAlertList;
        private ColumnHeader title;
        private ColumnHeader description;
        private Label lblTitle;
    }
}