namespace Weather72HRs.Forms.Detail
{
    partial class DetailForm
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
            dgvInfo = new DataGridView();
            key = new DataGridViewTextBoxColumn();
            value = new DataGridViewTextBoxColumn();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvInfo).BeginInit();
            SuspendLayout();
            // 
            // dgvInfo
            // 
            dgvInfo.AllowUserToAddRows = false;
            dgvInfo.AllowUserToDeleteRows = false;
            dgvInfo.AllowUserToResizeColumns = false;
            dgvInfo.AllowUserToResizeRows = false;
            dgvInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInfo.ColumnHeadersVisible = false;
            dgvInfo.Columns.AddRange(new DataGridViewColumn[] { key, value });
            dgvInfo.Location = new Point(27, 28);
            dgvInfo.Name = "dgvInfo";
            dgvInfo.ReadOnly = true;
            dgvInfo.RowHeadersVisible = false;
            dgvInfo.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInfo.RowTemplate.DefaultCellStyle.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dgvInfo.Size = new Size(394, 253);
            dgvInfo.TabIndex = 0;
            // 
            // key
            // 
            key.HeaderText = "项目";
            key.Name = "key";
            key.ReadOnly = true;
            key.Resizable = DataGridViewTriState.False;
            // 
            // value
            // 
            value.HeaderText = "值";
            value.Name = "value";
            value.ReadOnly = true;
            value.Resizable = DataGridViewTriState.False;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(27, 300);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(394, 39);
            btnClose.TabIndex = 1;
            btnClose.Text = "关闭";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // DetailForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(449, 366);
            Controls.Add(btnClose);
            Controls.Add(dgvInfo);
            Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(5, 4, 5, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DetailForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "详细信息";
            ((System.ComponentModel.ISupportInitialize)dgvInfo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvInfo;
        private DataGridViewTextBoxColumn key;
        private DataGridViewTextBoxColumn value;
        private Button btnClose;
    }
}