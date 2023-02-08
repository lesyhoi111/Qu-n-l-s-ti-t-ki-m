namespace Lần_1
{
    partial class ThongTinChinhSach
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTTBanDau = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTTThem = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSNTTSauGoi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(552, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(464, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "THÔNG TIN CÁC CHÍNH SÁCH";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(454, 231);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(342, 25);
            this.label2.TabIndex = 41;
            this.label2.Text = "Số tiền gởi tối thiểu ban đầu của 1 sổ :";
            // 
            // tbTTBanDau
            // 
            this.tbTTBanDau.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbTTBanDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTTBanDau.Location = new System.Drawing.Point(911, 225);
            this.tbTTBanDau.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbTTBanDau.Name = "tbTTBanDau";
            this.tbTTBanDau.ReadOnly = true;
            this.tbTTBanDau.Size = new System.Drawing.Size(376, 34);
            this.tbTTBanDau.TabIndex = 42;
            this.tbTTBanDau.Tag = "VNĐ";
            this.tbTTBanDau.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbTTBanDau.TextChanged += new System.EventHandler(this.tbTTBanDau_TextChanged);
            this.tbTTBanDau.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbTTBanDau_KeyPress);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(454, 295);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(235, 25);
            this.label3.TabIndex = 43;
            this.label3.Text = "Số tiền gởi thêm tối thiểu :";
            // 
            // tbTTThem
            // 
            this.tbTTThem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbTTThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTTThem.Location = new System.Drawing.Point(911, 289);
            this.tbTTThem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbTTThem.Name = "tbTTThem";
            this.tbTTThem.ReadOnly = true;
            this.tbTTThem.Size = new System.Drawing.Size(376, 34);
            this.tbTTThem.TabIndex = 44;
            this.tbTTThem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbTTThem.TextChanged += new System.EventHandler(this.tbTTThem_TextChanged);
            this.tbTTThem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbTTThem_KeyPress);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(454, 367);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(377, 25);
            this.label4.TabIndex = 45;
            this.label4.Text = "Số ngày tối thiểu được rút tiền sau khi gởi :";
            // 
            // tbSNTTSauGoi
            // 
            this.tbSNTTSauGoi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbSNTTSauGoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSNTTSauGoi.Location = new System.Drawing.Point(911, 361);
            this.tbSNTTSauGoi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSNTTSauGoi.Name = "tbSNTTSauGoi";
            this.tbSNTTSauGoi.ReadOnly = true;
            this.tbSNTTSauGoi.Size = new System.Drawing.Size(139, 34);
            this.tbSNTTSauGoi.TabIndex = 46;
            this.tbSNTTSauGoi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbSNTTSauGoi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSNTTSauGoi_KeyPress);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1295, 231);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 25);
            this.label5.TabIndex = 48;
            this.label5.Text = "VNĐ";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1295, 295);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 25);
            this.label6.TabIndex = 49;
            this.label6.Text = "VNĐ";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1054, 367);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 25);
            this.label7.TabIndex = 50;
            this.label7.Text = "Ngày";
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.IconChar = FontAwesome.Sharp.IconChar.Cog;
            this.button2.IconColor = System.Drawing.Color.Black;
            this.button2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.button2.IconSize = 35;
            this.button2.Location = new System.Drawing.Point(791, 524);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(173, 55);
            this.button2.TabIndex = 51;
            this.button2.Text = "Sửa";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ThongTinChinhSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1754, 1055);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbSNTTSauGoi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbTTThem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbTTBanDau);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ThongTinChinhSach";
            this.Text = "ThongTinChinhSach";
            this.Load += new System.EventHandler(this.ThongTinChinhSach_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTTBanDau;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbTTThem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSNTTSauGoi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private FontAwesome.Sharp.IconButton button2;
    }
}