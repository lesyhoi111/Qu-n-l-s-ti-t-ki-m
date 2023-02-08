using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thong_Tin_Khach_hang;

namespace WindowsFormsApp1
{
    public partial class ForgotPass : Form
    {
        bool check = false;
        public ForgotPass()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ForgotPass_Load(object sender, EventArgs e)
        {
            lblHeader.Text = MainFormManager.Instance.tenNV()+" - "+MainFormManager.Instance.tenCN();
            ptbeye1.Hide();
            ptbeye2.Hide();
            ptbeye3.Hide();
            ptbeyeslash1.Hide();
            ptbeyeslash2.Hide();
            ptbeyeslash3.Hide();
            lblcurrentPassWord.Hide();
            lblreEnterNewPassWord.Hide();
            lblnewPassWord.Hide();
        }

        private void txtcurrentPass_Enter(object sender, EventArgs e)
        {
            if (txtcurrentPass.Text == "Mật khẩu hiện tại")
            {
                txtcurrentPass.Text = "";
                txtcurrentPass.ForeColor = Color.Black;
            }
        }

        private void txtcurrentPass_Leave(object sender, EventArgs e)
        {
            if (txtcurrentPass.Text == "")
            {
                txtcurrentPass.Text = "Mật khẩu hiện tại";
                txtcurrentPass.ForeColor = Color.DimGray;
            }
        }

        private void txtnewPass_Enter(object sender, EventArgs e)
        {
            if (txtnewPass.Text == "Mật khẩu mới")
            {
                txtnewPass.Text = "";
                txtnewPass.ForeColor = Color.Black;
            }
        }

        private void txtnewPass_Leave(object sender, EventArgs e)
        {
            if (txtnewPass.Text == "")
            {
                txtnewPass.Text = "Mật khẩu mới";
                txtnewPass.ForeColor = Color.DimGray;
            }
        }

        private void txtreEnterNewPass_Enter(object sender, EventArgs e)
        {
            if (txtreEnterNewPass.Text == "Nhập lại mật khẩu mới")
            {
                txtreEnterNewPass.Text = "";
                txtreEnterNewPass.ForeColor = Color.Black;
            }
        }

        private void txtreEnterNewPass_Leave(object sender, EventArgs e)
        {
            if (txtreEnterNewPass.Text == "")
            {
                txtreEnterNewPass.Text = "Nhập lại mật khẩu mới";
                txtreEnterNewPass.ForeColor = Color.DimGray;
            }
        }

        private void ptbeye1_Click(object sender, EventArgs e)
        {
            check = false;
            ptbeye1.Hide();
            ptbeyeslash1.Show();
            txtcurrentPass.PasswordChar = '*';
        }

        private void ptbeyeslash1_Click(object sender, EventArgs e)
        {
            check = true;
            ptbeye1.Show();
            ptbeyeslash1.Hide();
            txtcurrentPass.PasswordChar = '\0';
        }

        private void ptbeye2_Click(object sender, EventArgs e)
        {
            check = false;
            ptbeye2.Hide();
            ptbeyeslash2.Show();
            txtnewPass.PasswordChar = '*';
        }

        private void ptbeyeslash2_Click(object sender, EventArgs e)
        {
            check |= true;
            ptbeye2.Show();
            ptbeyeslash2.Hide();
            txtnewPass.PasswordChar = '\0';
        }

        private void ptbeye3_Click(object sender, EventArgs e)
        {
            check = false;
            ptbeye3.Hide();
            ptbeyeslash3.Show();
            txtreEnterNewPass.PasswordChar = '*';
        }

        private void ptbeyeslash3_Click(object sender, EventArgs e)
        {
            check = true;
            ptbeye3.Show();
            ptbeyeslash3.Hide();
            txtreEnterNewPass.PasswordChar = '\0';
        }

        private void txtcurrentPass_TextChanged(object sender, EventArgs e)
        {
            if (txtcurrentPass.Text != "" && txtcurrentPass.Text!="Mật khẩu hiện tại")
            {
                if (!check)
                {
                    lblcurrentPassWord.Hide();
                    txtcurrentPass.ForeColor = Color.Black;
                    ptbeyeslash1.Show();
                    txtcurrentPass.PasswordChar = '*';
                }
                else
                {
                    lblcurrentPassWord.Hide();
                    txtcurrentPass.ForeColor = Color.Black;
                    ptbeye1.Show();
                    txtcurrentPass.PasswordChar = '\0';
                }
            }
            else
            {
                ptbeyeslash1.Hide();
                ptbeye1.Hide();
                txtcurrentPass.PasswordChar = '\0';
                check = false;
            }
        }

        private void txtnewPass_TextChanged(object sender, EventArgs e)
        {
            if (txtnewPass.Text != "" && txtnewPass.Text != "Mật khẩu mới")
            {
                if (!check)
                {
                    ptbeyeslash2.Show();
                    txtnewPass.PasswordChar = '*';
                }
                else
                {
                    ptbeye2.Show();
                    txtnewPass.PasswordChar = '\0';
                }

            }
            else
            {
                ptbeyeslash2.Hide();
                ptbeye2.Hide();
                txtnewPass.PasswordChar = '\0';
                check=false;
            }
            if(txtcurrentPass.Text !=""&&txtcurrentPass.Text!="Mật khẩu hiện tại")
            {
                if (txtnewPass.Text.Length < 6)
                {
                    txtnewPass.ForeColor = Color.Red;
                    lblnewPassWord.Show();
                    lblnewPassWord.Text = "Mật khẩu của bạn phải có ít nhất 6 ký tự.";
                }
                else
                {
                    txtnewPass.ForeColor = Color.Black;
                    lblnewPassWord.Hide();
                }
            }
            
        }

        private void txtreEnterNewPass_TextChanged(object sender, EventArgs e)
        {
            if (txtreEnterNewPass.Text != "" && txtreEnterNewPass.Text != "Nhập lại mật khẩu mới")
            {
                if (!check)
                {
                    ptbeyeslash3.Show();
                    txtreEnterNewPass.PasswordChar = '*';
                }
                else
                {
                    ptbeye3.Show();
                    txtreEnterNewPass.PasswordChar = '\0';
                }

            }
            else
            {
                ptbeyeslash3.Hide();
                ptbeye3.Hide();
                txtreEnterNewPass.PasswordChar = '\0';
                check = false;
            }
            if(txtreEnterNewPass.Text != txtnewPass.Text && txtreEnterNewPass.Text !="" && txtreEnterNewPass.Text != "Nhập lại mật khẩu mới")
            {
                txtreEnterNewPass.ForeColor = Color.Red;
                lblreEnterNewPassWord.Show();
                lblreEnterNewPassWord.Text = "Mật khẩu mới không khớp.";
            }
            else
            {
                txtreEnterNewPass.ForeColor = Color.Black;
                lblreEnterNewPassWord.Hide();
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            string query;
            query = "select MatKhau from NHANVIEN where MaNV='" + MainFormManager.Instance.maNV() + "' and MatKhau='" + txtcurrentPass.Text + "'";
            if (dataProvider.Instance.ExecuteReader(query))
            {
                query = "update NHANVIEN set MatKhau ='"+txtnewPass.Text+"' where MaNV = '"+MainFormManager.Instance.maNV() + "'";
                if (txtnewPass.Text.Length >= 6)
                {
                    if(txtnewPass.Text == txtreEnterNewPass.Text)
                    {
                        if (dataProvider.Instance.ExecuteNonQuery(query) != 0)
                        {
                            MessageBox.Show("Mật khẩu đã được thay đổi, vui lòng đăng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Login login = new Login();
                            login.Show();
                            MainFormManager.Instance.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Hệ thống xảy ra lỗi, vui lòng thử lại sau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu mới không khớp, xin vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
                else
                {
                    MessageBox.Show("Độ dài mật khẩu tối thiểu phải có 6 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            else
            {
                txtcurrentPass.ForeColor = Color.Red;
                lblcurrentPassWord.Show();
                lblcurrentPassWord.Text = "Sai mật khẩu hiện tại, hãy thử lại!";
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            MainFormManager.Instance.openChildForm(new frmAccount());
        }
    }
}
