namespace WindowsFormsApp1
{
    partial class ForgotPass
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
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.txtcurrentPass = new System.Windows.Forms.TextBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtnewPass = new System.Windows.Forms.TextBox();
            this.txtreEnterNewPass = new System.Windows.Forms.TextBox();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.ptbeye1 = new FontAwesome.Sharp.IconPictureBox();
            this.ptbeye2 = new FontAwesome.Sharp.IconPictureBox();
            this.ptbeye3 = new FontAwesome.Sharp.IconPictureBox();
            this.ptbeyeslash1 = new FontAwesome.Sharp.IconPictureBox();
            this.ptbeyeslash2 = new FontAwesome.Sharp.IconPictureBox();
            this.ptbeyeslash3 = new FontAwesome.Sharp.IconPictureBox();
            this.lblreEnterNewPassWord = new System.Windows.Forms.Label();
            this.lblnewPassWord = new System.Windows.Forms.Label();
            this.lblcurrentPassWord = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ptbeye1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbeye2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbeye3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbeyeslash1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbeyeslash2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbeyeslash3)).BeginInit();
            this.SuspendLayout();
            // 
            // iconButton1
            // 
            this.iconButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.iconButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.Location = new System.Drawing.Point(337, 406);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(479, 45);
            this.iconButton1.TabIndex = 0;
            this.iconButton1.Text = "Đổi mật khẩu";
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // txtcurrentPass
            // 
            this.txtcurrentPass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtcurrentPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcurrentPass.ForeColor = System.Drawing.Color.DimGray;
            this.txtcurrentPass.Location = new System.Drawing.Point(344, 134);
            this.txtcurrentPass.Multiline = true;
            this.txtcurrentPass.Name = "txtcurrentPass";
            this.txtcurrentPass.Size = new System.Drawing.Size(480, 40);
            this.txtcurrentPass.TabIndex = 2;
            this.txtcurrentPass.Text = "Mật khẩu hiện tại";
            this.txtcurrentPass.TextChanged += new System.EventHandler(this.txtcurrentPass_TextChanged);
            this.txtcurrentPass.Enter += new System.EventHandler(this.txtcurrentPass_Enter);
            this.txtcurrentPass.Leave += new System.EventHandler(this.txtcurrentPass_Leave);
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(341, 1);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(24, 26);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "?";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(340, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 36);
            this.label3.TabIndex = 1;
            this.label3.Text = "Đổi mật khẩu";
            // 
            // txtnewPass
            // 
            this.txtnewPass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtnewPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnewPass.ForeColor = System.Drawing.Color.DimGray;
            this.txtnewPass.Location = new System.Drawing.Point(344, 219);
            this.txtnewPass.Multiline = true;
            this.txtnewPass.Name = "txtnewPass";
            this.txtnewPass.Size = new System.Drawing.Size(480, 40);
            this.txtnewPass.TabIndex = 2;
            this.txtnewPass.Text = "Mật khẩu mới";
            this.txtnewPass.TextChanged += new System.EventHandler(this.txtnewPass_TextChanged);
            this.txtnewPass.Enter += new System.EventHandler(this.txtnewPass_Enter);
            this.txtnewPass.Leave += new System.EventHandler(this.txtnewPass_Leave);
            // 
            // txtreEnterNewPass
            // 
            this.txtreEnterNewPass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtreEnterNewPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreEnterNewPass.ForeColor = System.Drawing.Color.DimGray;
            this.txtreEnterNewPass.Location = new System.Drawing.Point(342, 298);
            this.txtreEnterNewPass.Multiline = true;
            this.txtreEnterNewPass.Name = "txtreEnterNewPass";
            this.txtreEnterNewPass.Size = new System.Drawing.Size(480, 40);
            this.txtreEnterNewPass.TabIndex = 2;
            this.txtreEnterNewPass.Text = "Nhập lại mật khẩu mới";
            this.txtreEnterNewPass.TextChanged += new System.EventHandler(this.txtreEnterNewPass_TextChanged);
            this.txtreEnterNewPass.Enter += new System.EventHandler(this.txtreEnterNewPass_Enter);
            this.txtreEnterNewPass.Leave += new System.EventHandler(this.txtreEnterNewPass_Leave);
            // 
            // iconButton2
            // 
            this.iconButton2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.iconButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton2.IconColor = System.Drawing.Color.Black;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.Location = new System.Drawing.Point(337, 464);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(479, 45);
            this.iconButton2.TabIndex = 0;
            this.iconButton2.Text = "Quay lại";
            this.iconButton2.UseVisualStyleBackColor = true;
            this.iconButton2.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // ptbeye1
            // 
            this.ptbeye1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ptbeye1.BackColor = System.Drawing.SystemColors.Window;
            this.ptbeye1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ptbeye1.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.ptbeye1.IconColor = System.Drawing.SystemColors.ControlText;
            this.ptbeye1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ptbeye1.Location = new System.Drawing.Point(781, 139);
            this.ptbeye1.Name = "ptbeye1";
            this.ptbeye1.Size = new System.Drawing.Size(35, 32);
            this.ptbeye1.TabIndex = 4;
            this.ptbeye1.TabStop = false;
            this.ptbeye1.Click += new System.EventHandler(this.ptbeye1_Click);
            // 
            // ptbeye2
            // 
            this.ptbeye2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ptbeye2.BackColor = System.Drawing.SystemColors.Window;
            this.ptbeye2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ptbeye2.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.ptbeye2.IconColor = System.Drawing.SystemColors.ControlText;
            this.ptbeye2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ptbeye2.Location = new System.Drawing.Point(781, 223);
            this.ptbeye2.Name = "ptbeye2";
            this.ptbeye2.Size = new System.Drawing.Size(35, 32);
            this.ptbeye2.TabIndex = 4;
            this.ptbeye2.TabStop = false;
            this.ptbeye2.Click += new System.EventHandler(this.ptbeye2_Click);
            // 
            // ptbeye3
            // 
            this.ptbeye3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ptbeye3.BackColor = System.Drawing.SystemColors.Window;
            this.ptbeye3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ptbeye3.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.ptbeye3.IconColor = System.Drawing.SystemColors.ControlText;
            this.ptbeye3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ptbeye3.Location = new System.Drawing.Point(781, 302);
            this.ptbeye3.Name = "ptbeye3";
            this.ptbeye3.Size = new System.Drawing.Size(35, 32);
            this.ptbeye3.TabIndex = 4;
            this.ptbeye3.TabStop = false;
            this.ptbeye3.Click += new System.EventHandler(this.ptbeye3_Click);
            // 
            // ptbeyeslash1
            // 
            this.ptbeyeslash1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ptbeyeslash1.BackColor = System.Drawing.SystemColors.Window;
            this.ptbeyeslash1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ptbeyeslash1.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            this.ptbeyeslash1.IconColor = System.Drawing.SystemColors.ControlText;
            this.ptbeyeslash1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ptbeyeslash1.Location = new System.Drawing.Point(781, 139);
            this.ptbeyeslash1.Name = "ptbeyeslash1";
            this.ptbeyeslash1.Size = new System.Drawing.Size(35, 32);
            this.ptbeyeslash1.TabIndex = 4;
            this.ptbeyeslash1.TabStop = false;
            this.ptbeyeslash1.Click += new System.EventHandler(this.ptbeyeslash1_Click);
            // 
            // ptbeyeslash2
            // 
            this.ptbeyeslash2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ptbeyeslash2.BackColor = System.Drawing.SystemColors.Window;
            this.ptbeyeslash2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ptbeyeslash2.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            this.ptbeyeslash2.IconColor = System.Drawing.SystemColors.ControlText;
            this.ptbeyeslash2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ptbeyeslash2.Location = new System.Drawing.Point(781, 223);
            this.ptbeyeslash2.Name = "ptbeyeslash2";
            this.ptbeyeslash2.Size = new System.Drawing.Size(35, 32);
            this.ptbeyeslash2.TabIndex = 4;
            this.ptbeyeslash2.TabStop = false;
            this.ptbeyeslash2.Click += new System.EventHandler(this.ptbeyeslash2_Click);
            // 
            // ptbeyeslash3
            // 
            this.ptbeyeslash3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ptbeyeslash3.BackColor = System.Drawing.SystemColors.Window;
            this.ptbeyeslash3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ptbeyeslash3.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            this.ptbeyeslash3.IconColor = System.Drawing.SystemColors.ControlText;
            this.ptbeyeslash3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ptbeyeslash3.Location = new System.Drawing.Point(781, 302);
            this.ptbeyeslash3.Name = "ptbeyeslash3";
            this.ptbeyeslash3.Size = new System.Drawing.Size(35, 32);
            this.ptbeyeslash3.TabIndex = 4;
            this.ptbeyeslash3.TabStop = false;
            this.ptbeyeslash3.Click += new System.EventHandler(this.ptbeyeslash3_Click);
            // 
            // lblreEnterNewPassWord
            // 
            this.lblreEnterNewPassWord.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblreEnterNewPassWord.AutoSize = true;
            this.lblreEnterNewPassWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblreEnterNewPassWord.ForeColor = System.Drawing.Color.Red;
            this.lblreEnterNewPassWord.Location = new System.Drawing.Point(341, 341);
            this.lblreEnterNewPassWord.Name = "lblreEnterNewPassWord";
            this.lblreEnterNewPassWord.Size = new System.Drawing.Size(20, 24);
            this.lblreEnterNewPassWord.TabIndex = 1;
            this.lblreEnterNewPassWord.Text = "?";
            // 
            // lblnewPassWord
            // 
            this.lblnewPassWord.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblnewPassWord.AutoSize = true;
            this.lblnewPassWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnewPassWord.ForeColor = System.Drawing.Color.Red;
            this.lblnewPassWord.Location = new System.Drawing.Point(341, 262);
            this.lblnewPassWord.Name = "lblnewPassWord";
            this.lblnewPassWord.Size = new System.Drawing.Size(20, 24);
            this.lblnewPassWord.TabIndex = 1;
            this.lblnewPassWord.Text = "?";
            // 
            // lblcurrentPassWord
            // 
            this.lblcurrentPassWord.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblcurrentPassWord.AutoSize = true;
            this.lblcurrentPassWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcurrentPassWord.ForeColor = System.Drawing.Color.Red;
            this.lblcurrentPassWord.Location = new System.Drawing.Point(341, 177);
            this.lblcurrentPassWord.Name = "lblcurrentPassWord";
            this.lblcurrentPassWord.Size = new System.Drawing.Size(20, 24);
            this.lblcurrentPassWord.TabIndex = 1;
            this.lblcurrentPassWord.Text = "?";
            // 
            // ForgotPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 627);
            this.Controls.Add(this.ptbeye3);
            this.Controls.Add(this.ptbeye2);
            this.Controls.Add(this.ptbeyeslash3);
            this.Controls.Add(this.ptbeyeslash2);
            this.Controls.Add(this.ptbeyeslash1);
            this.Controls.Add(this.ptbeye1);
            this.Controls.Add(this.txtreEnterNewPass);
            this.Controls.Add(this.txtnewPass);
            this.Controls.Add(this.txtcurrentPass);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblcurrentPassWord);
            this.Controls.Add(this.lblnewPassWord);
            this.Controls.Add(this.lblreEnterNewPassWord);
            this.Controls.Add(this.iconButton2);
            this.Controls.Add(this.iconButton1);
            this.MinimumSize = new System.Drawing.Size(875, 500);
            this.Name = "ForgotPass";
            this.Text = "Đạt lại mật khẩu";
            this.Load += new System.EventHandler(this.ForgotPass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbeye1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbeye2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbeye3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbeyeslash1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbeyeslash2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbeyeslash3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.TextBox txtcurrentPass;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtnewPass;
        private System.Windows.Forms.TextBox txtreEnterNewPass;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconPictureBox ptbeye1;
        private FontAwesome.Sharp.IconPictureBox ptbeye2;
        private FontAwesome.Sharp.IconPictureBox ptbeye3;
        private FontAwesome.Sharp.IconPictureBox ptbeyeslash1;
        private FontAwesome.Sharp.IconPictureBox ptbeyeslash2;
        private FontAwesome.Sharp.IconPictureBox ptbeyeslash3;
        private System.Windows.Forms.Label lblreEnterNewPassWord;
        private System.Windows.Forms.Label lblnewPassWord;
        private System.Windows.Forms.Label lblcurrentPassWord;
    }
}