using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thong_Tin_Khach_hang;

namespace WindowsFormsApp1
{
    public partial class frmForgotPassWord : Form
    {
        public frmForgotPassWord()
        {
            InitializeComponent();
        }
        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.Black;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {

                txtEmail.Text = "Email";
                txtEmail.ForeColor = Color.Gray;
            }
        }

        private void frmForgotPassWord_Load(object sender, EventArgs e)
        {
            label3.Hide();
            this.ActiveControl = label1;
        }

        private void iconPictureBox3_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            string query = "select Email from NHANVIEN where Email='" + txtEmail.Text + "'";
            bool kq = dataProvider.Instance.ExecuteReader(query);
            if (kq)
            {
                Random rand =new Random();
                string matKhau = rand.Next(100000, 999999).ToString();
                string subject = "RESET MẬT KHẨU";
                string content = "<h2 > HỆ THỐNG QUẢN LÝ NGÂN HÀNG SỐ META BANK</h2> <h4> Chúng tôi đã hỗ trợ bạn reset mật khẩu. Đây là mật khẩu mới của bạn </h4><p><b> Mật khẩu: </b><i> " + matKhau + " </i></p><p> !!!Chú ý: Nên đổi mật khẩu trong lần đầu đăng nhập!!! </p> ";
                string query1 = "update NHANVIEN set MatKhau ='" + matKhau + "' where Email='" + txtEmail.Text + "'";
                if (dataProvider.Instance.ExecuteNonQuery(query1) != 0 && SendMail("bankingmeta@gmail.com", txtEmail.Text, subject, content)) 
                {
                    MessageBox.Show("Mật khẩu đã được thay đổi, Vui lòng kiểm tra email của bạn để biết thêm chi tiết!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information); 
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra, Vui lòng thử lại sau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                label3.Show();
            }
        }
        bool SendMail(string mailfrom, string mailto, string subject, string content)
        {
            try
            {
                MailMessage mail = new MailMessage(mailfrom, mailto, subject, content); //
                mail.IsBodyHtml = true;
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("bankingmeta@gmail.com", "gxokcndrtxerjuwy"); /// Sử dụng tài khoản gmail người gửi
                client.EnableSsl = true;
                client.Send(mail);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private void txtCCCD_TextChanged(object sender, EventArgs e)
        {
            label3.Hide();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            label3.Hide();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
            
        }
    }
}
