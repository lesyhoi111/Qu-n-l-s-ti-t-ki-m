namespace Lần_1
{
    partial class ChinhSuaLoaiTK
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
            this.dgvLoaiLX = new System.Windows.Forms.DataGridView();
            this.MaLoaiTK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLoaiTK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiHan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LaiXuat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btTimKiem = new System.Windows.Forms.Button();
            this.btKhoiTao = new System.Windows.Forms.Button();
            this.cbThoiHan = new System.Windows.Forms.CheckBox();
            this.tbLaiXuat = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbThoiHan = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbMa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btXoa = new System.Windows.Forms.Button();
            this.btSua = new System.Windows.Forms.Button();
            this.btThem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiLX)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLoaiLX
            // 
            this.dgvLoaiLX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLoaiLX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoaiLX.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaLoaiTK,
            this.TenLoaiTK,
            this.ThoiHan,
            this.LaiXuat});
            this.dgvLoaiLX.Location = new System.Drawing.Point(43, 203);
            this.dgvLoaiLX.Name = "dgvLoaiLX";
            this.dgvLoaiLX.RowHeadersWidth = 51;
            this.dgvLoaiLX.RowTemplate.Height = 24;
            this.dgvLoaiLX.Size = new System.Drawing.Size(824, 320);
            this.dgvLoaiLX.TabIndex = 0;
            this.dgvLoaiLX.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoaiLX_CellClick);
            // 
            // MaLoaiTK
            // 
            this.MaLoaiTK.DataPropertyName = "MaLoaiTK";
            this.MaLoaiTK.HeaderText = "Mã loại tiết kiệm";
            this.MaLoaiTK.MinimumWidth = 6;
            this.MaLoaiTK.Name = "MaLoaiTK";
            this.MaLoaiTK.ReadOnly = true;
            this.MaLoaiTK.Width = 125;
            // 
            // TenLoaiTK
            // 
            this.TenLoaiTK.DataPropertyName = "TenLoaiTK";
            this.TenLoaiTK.HeaderText = "Tên loại tiết kiệm";
            this.TenLoaiTK.MinimumWidth = 6;
            this.TenLoaiTK.Name = "TenLoaiTK";
            this.TenLoaiTK.ReadOnly = true;
            this.TenLoaiTK.Width = 200;
            // 
            // ThoiHan
            // 
            this.ThoiHan.DataPropertyName = "ThoiHan";
            this.ThoiHan.HeaderText = "Thời hạn (Tháng)";
            this.ThoiHan.MinimumWidth = 6;
            this.ThoiHan.Name = "ThoiHan";
            this.ThoiHan.ReadOnly = true;
            this.ThoiHan.Width = 125;
            // 
            // LaiXuat
            // 
            this.LaiXuat.DataPropertyName = "LaiXuat";
            this.LaiXuat.HeaderText = "Lãi xuất (%)";
            this.LaiXuat.MinimumWidth = 6;
            this.LaiXuat.Name = "LaiXuat";
            this.LaiXuat.ReadOnly = true;
            this.LaiXuat.Width = 110;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(324, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(372, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "THÔNG TIN CÁC LOẠI LÃI XUẤT";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btTimKiem);
            this.groupBox1.Controls.Add(this.btKhoiTao);
            this.groupBox1.Controls.Add(this.cbThoiHan);
            this.groupBox1.Controls.Add(this.tbLaiXuat);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.tbThoiHan);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbMa);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbTen);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(5, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1020, 147);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(641, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 20);
            this.label5.TabIndex = 51;
            this.label5.Text = "Tháng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(889, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 20);
            this.label4.TabIndex = 50;
            this.label4.Text = "%";
            // 
            // btTimKiem
            // 
            this.btTimKiem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTimKiem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btTimKiem.Location = new System.Drawing.Point(729, 109);
            this.btTimKiem.Name = "btTimKiem";
            this.btTimKiem.Size = new System.Drawing.Size(158, 32);
            this.btTimKiem.TabIndex = 49;
            this.btTimKiem.Text = "Tìm Kiếm";
            this.btTimKiem.UseVisualStyleBackColor = false;
            this.btTimKiem.Click += new System.EventHandler(this.btTimKiem_Click);
            // 
            // btKhoiTao
            // 
            this.btKhoiTao.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btKhoiTao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btKhoiTao.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btKhoiTao.Location = new System.Drawing.Point(893, 109);
            this.btKhoiTao.Name = "btKhoiTao";
            this.btKhoiTao.Size = new System.Drawing.Size(109, 32);
            this.btKhoiTao.TabIndex = 48;
            this.btKhoiTao.Text = "Khởi tạo";
            this.btKhoiTao.UseVisualStyleBackColor = false;
            this.btKhoiTao.Click += new System.EventHandler(this.btKhoiTao_Click);
            // 
            // cbThoiHan
            // 
            this.cbThoiHan.AutoSize = true;
            this.cbThoiHan.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbThoiHan.Location = new System.Drawing.Point(411, 38);
            this.cbThoiHan.Name = "cbThoiHan";
            this.cbThoiHan.Size = new System.Drawing.Size(121, 24);
            this.cbThoiHan.TabIndex = 47;
            this.cbThoiHan.Text = "Có thời hạn:";
            this.cbThoiHan.UseVisualStyleBackColor = true;
            this.cbThoiHan.Click += new System.EventHandler(this.cbThoiHan_Click);
            // 
            // tbLaiXuat
            // 
            this.tbLaiXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLaiXuat.Location = new System.Drawing.Point(765, 35);
            this.tbLaiXuat.Name = "tbLaiXuat";
            this.tbLaiXuat.Size = new System.Drawing.Size(122, 27);
            this.tbLaiXuat.TabIndex = 45;
            this.tbLaiXuat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbLaiXuat.TextChanged += new System.EventHandler(this.tbLaiXuat_TextChanged);
            this.tbLaiXuat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLaiXuat_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(686, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 20);
            this.label11.TabIndex = 46;
            this.label11.Text = "Lãi xuất:";
            // 
            // tbThoiHan
            // 
            this.tbThoiHan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbThoiHan.Location = new System.Drawing.Point(518, 92);
            this.tbThoiHan.Name = "tbThoiHan";
            this.tbThoiHan.Size = new System.Drawing.Size(122, 27);
            this.tbThoiHan.TabIndex = 43;
            this.tbThoiHan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbThoiHan.TextChanged += new System.EventHandler(this.tbThoiHan_TextChanged);
            this.tbThoiHan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbThoiHan_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(434, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 20);
            this.label6.TabIndex = 44;
            this.label6.Text = "Thời hạn:";
            // 
            // tbMa
            // 
            this.tbMa.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMa.Location = new System.Drawing.Point(154, 38);
            this.tbMa.Name = "tbMa";
            this.tbMa.Size = new System.Drawing.Size(130, 27);
            this.tbMa.TabIndex = 39;
            this.tbMa.TextChanged += new System.EventHandler(this.tbMa_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 20);
            this.label2.TabIndex = 40;
            this.label2.Text = "Mã loại lãi xuất:";
            // 
            // tbTen
            // 
            this.tbTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTen.Location = new System.Drawing.Point(154, 92);
            this.tbTen.Name = "tbTen";
            this.tbTen.Size = new System.Drawing.Size(243, 27);
            this.tbTen.TabIndex = 41;
            this.tbTen.TextChanged += new System.EventHandler(this.tbTen_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 20);
            this.label3.TabIndex = 42;
            this.label3.Text = "Tên loại lãi xuất:";
            // 
            // btXoa
            // 
            this.btXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btXoa.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXoa.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btXoa.Location = new System.Drawing.Point(898, 331);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(95, 32);
            this.btXoa.TabIndex = 30;
            this.btXoa.Text = "Xóa";
            this.btXoa.UseVisualStyleBackColor = false;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // btSua
            // 
            this.btSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSua.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSua.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btSua.Location = new System.Drawing.Point(898, 385);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(95, 32);
            this.btSua.TabIndex = 28;
            this.btSua.Text = "Sửa";
            this.btSua.UseVisualStyleBackColor = false;
            this.btSua.Click += new System.EventHandler(this.btSua_Click);
            // 
            // btThem
            // 
            this.btThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btThem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btThem.Location = new System.Drawing.Point(898, 273);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(95, 32);
            this.btThem.TabIndex = 29;
            this.btThem.Text = "Thêm";
            this.btThem.UseVisualStyleBackColor = false;
            this.btThem.Click += new System.EventHandler(this.btThem_Click);
            // 
            // ChinhSuaLoaiTK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 528);
            this.Controls.Add(this.btXoa);
            this.Controls.Add(this.btSua);
            this.Controls.Add(this.btThem);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvLoaiLX);
            this.Name = "ChinhSuaLoaiTK";
            this.Text = "ChinhSuaLoaiTK";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChinhSuaLoaiTK_FormClosed);
            this.Load += new System.EventHandler(this.ChinhSuaLoaiTK_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiLX)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLoaiLX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbLaiXuat;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbThoiHan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbMa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbThoiHan;
        private System.Windows.Forms.Button btKhoiTao;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.Button btSua;
        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.Button btTimKiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLoaiTK;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLoaiTK;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiHan;
        private System.Windows.Forms.DataGridViewTextBoxColumn LaiXuat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}