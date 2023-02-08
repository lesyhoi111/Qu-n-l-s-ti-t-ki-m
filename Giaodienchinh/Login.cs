using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thong_Tin_Khach_hang;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {

        public static string sdt = "";
        private bool check = false;
        public Login()
        {
            InitializeComponent();
            
        }


        private void rjTextBox1_Enter(object sender, EventArgs e)
        {
            if (txtSDT.Text == "Phone Number")
            {
                txtSDT.Text = "";
                txtSDT.ForeColor = Color.Black;
            }
    
        }

        private void txtGmail_Leave(object sender, EventArgs e)
        {
            if (txtSDT.Text == "")
            {
                txtSDT.Text = "Phone Number";
                txtSDT.ForeColor = Color.FromArgb(64, 64, 64);
            }

        }

        private void txtMatKhau_Leave(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == "")
            {
                
                txtMatKhau.Text = "Password";
                txtMatKhau.ForeColor = Color.FromArgb(64, 64, 64);
                txtMatKhau.PasswordChar = '\0';
            }
        }

        private void txtMatKhau_Enter(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == "Password")
            {
                txtMatKhau.Text = "";
                txtMatKhau.ForeColor = Color.Black;
            }
        }


        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            if(txtMatKhau.Text==""||txtMatKhau.Text== "Password")
            {
                ptbeye.Hide();
                ptbeyeslash.Hide();
                txtMatKhau.PasswordChar = '\0';
                if (txtMatKhau.Text == "")
                check=false;
            }
            else
            {
                if (check)
                {
                    ptbeye.Show();
                    txtMatKhau.PasswordChar = '\0';
                }
                else
                {
                    ptbeyeslash.Show();
                    txtMatKhau.PasswordChar = '*';
                }
            }  
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            string query = "select MatKhau,SDT from NHANVIEN where SDT='" + txtSDT.Text + "' and MatKhau='" + txtMatKhau.Text + "'";
            bool kq = dataProvider.Instance.ExecuteReader(query);
            if (kq)
            {
                Thread th;
                sdt = txtSDT.Text;
                this.Close();
                th = new Thread(OpenAdminForm);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else
            {
                lblerror.Text = "Số điện thoại hoặc mật khẩu không đúng!";
                lblerror.ForeColor = Color.FromArgb(255, 90, 120);
                txtMatKhau.Focus();
                txtMatKhau.Text = "";
                lblerror.Show();
            }
        }
        
        private void OpenAdminForm()
        {
            Application.Run(new MainFormManager());
        }

        private void Login_Load(object sender, EventArgs e)
        {
            lblerror.Hide();
            ptbeye.Hide();
            ptbeyeslash.Hide();
            this.ActiveControl = label1;
        }

        private void txtGmail_TextChanged(object sender, EventArgs e)
        {
            lblerror.Hide();
        }

        private void iconPictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ptbeyeslash_Click(object sender, EventArgs e)
        {
            check = true;
            ptbeyeslash.Hide();
            ptbeye.Show();
            txtMatKhau.PasswordChar = '\0';
        }

        private void ptbeye_Click(object sender, EventArgs e)
        {
            check = false;
            ptbeye.Hide();
            ptbeyeslash.Show();
            txtMatKhau.PasswordChar = '*';
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmForgotPassWord fg = new frmForgotPassWord();
            fg.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
