namespace Weather72HRs.Forms.AreaSelector
{
    partial class AreaSelectorForm
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
            cbProvince = new ComboBox();
            cbCity = new ComboBox();
            cbDistrict = new ComboBox();
            lblProvince = new Label();
            lblCity = new Label();
            lblDistrict = new Label();
            btnReset = new Button();
            btnConfirm = new Button();
            SuspendLayout();
            // 
            // cbProvince
            // 
            cbProvince.DropDownStyle = ComboBoxStyle.DropDownList;
            cbProvince.FormattingEnabled = true;
            cbProvince.IntegralHeight = false;
            cbProvince.Location = new Point(124, 43);
            cbProvince.Name = "cbProvince";
            cbProvince.Size = new Size(179, 33);
            cbProvince.TabIndex = 0;
            cbProvince.TextChanged += cbProvince_TextChanged;
            // 
            // cbCity
            // 
            cbCity.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCity.FormattingEnabled = true;
            cbCity.IntegralHeight = false;
            cbCity.Location = new Point(124, 87);
            cbCity.Name = "cbCity";
            cbCity.Size = new Size(179, 33);
            cbCity.TabIndex = 1;
            cbCity.TextChanged += cbCity_TextChanged;
            // 
            // cbDistrict
            // 
            cbDistrict.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDistrict.FormattingEnabled = true;
            cbDistrict.IntegralHeight = false;
            cbDistrict.Location = new Point(124, 131);
            cbDistrict.Name = "cbDistrict";
            cbDistrict.Size = new Size(179, 33);
            cbDistrict.TabIndex = 2;
            // 
            // lblProvince
            // 
            lblProvince.Location = new Point(34, 43);
            lblProvince.Name = "lblProvince";
            lblProvince.Size = new Size(78, 33);
            lblProvince.TabIndex = 3;
            lblProvince.Text = "所在省";
            lblProvince.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCity
            // 
            lblCity.Location = new Point(34, 87);
            lblCity.Name = "lblCity";
            lblCity.Size = new Size(78, 33);
            lblCity.TabIndex = 4;
            lblCity.Text = "所在市";
            lblCity.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDistrict
            // 
            lblDistrict.Location = new Point(34, 131);
            lblDistrict.Name = "lblDistrict";
            lblDistrict.Size = new Size(78, 33);
            lblDistrict.TabIndex = 5;
            lblDistrict.Text = "所在区";
            lblDistrict.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(48, 234);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(251, 36);
            btnReset.TabIndex = 6;
            btnReset.Text = "重置";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(48, 192);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(251, 36);
            btnConfirm.TabIndex = 7;
            btnConfirm.Text = "确认";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // AreaSelectorForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 311);
            Controls.Add(btnConfirm);
            Controls.Add(btnReset);
            Controls.Add(lblDistrict);
            Controls.Add(lblCity);
            Controls.Add(lblProvince);
            Controls.Add(cbDistrict);
            Controls.Add(cbCity);
            Controls.Add(cbProvince);
            Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(5, 4, 5, 4);
            MaximizeBox = false;
            Name = "AreaSelectorForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "选择城市";
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cbProvince;
        private ComboBox cbCity;
        private ComboBox cbDistrict;
        private Label lblProvince;
        private Label lblCity;
        private Label lblDistrict;
        private Button btnReset;
        private Button btnConfirm;
    }
}