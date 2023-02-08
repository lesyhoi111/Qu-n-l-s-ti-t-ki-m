using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thong_Tin_Khach_hang;

namespace Lần_1
{
    public partial class ChinhSuaLoaiTK : Form
    {
        
        DataTable dt = new DataTable();
        public ChinhSuaLoaiTK()
        {
            InitializeComponent();
        }

        private void ChinhSuaLoaiTK_Load(object sender, EventArgs e)
        {          
            dgvLoaiLX.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLoaiLX.Columns["ThoiHan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLoaiLX.Columns["LaiXuat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            LoadData();
            
        }
        void LoadData()
        {
            string st = "SELECT * FROM LOAITIETKIEM order by thoihan asc";
            dgvLoaiLX.DataSource = dataProvider.Instance.ExecuteQuery(st);
        }

        private void dgvLoaiLX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            tbMa.Enabled = false;
            i = e.RowIndex;
            if (i == -1)
            {
                return;
            }
            tbMa.Text = dgvLoaiLX.Rows[i].Cells[0].Value.ToString();
            tbTen.Text = dgvLoaiLX.Rows[i].Cells[1].Value.ToString();
            tbLaiXuat.Text = dgvLoaiLX.Rows[i].Cells[3].Value.ToString();
            if (dgvLoaiLX.Rows[i].Cells[2].Value.ToString() == "0")
            {
                tbThoiHan.Text = "0";
            }
            else
            {
                tbThoiHan.Text = dgvLoaiLX.Rows[i].Cells[2].Value.ToString();
                tbThoiHan.Enabled=true;
            }
            
        }
        void KhoiTao()
        {
            tbMa.Enabled = true;
            tbMa.Text = tbTen.Text = tbLaiXuat.Text = tbThoiHan.Text = "";
            LoadData();

            (dgvLoaiLX.DataSource as DataTable).DefaultView.RowFilter = "ThoiHan>=0";
            radioButton1.Checked = radioButton2.Checked = radioButton3.Checked = radioButton4.Checked = false;
            textBox1.Text = "";
        }
        private void btKhoiTao_Click(object sender, EventArgs e)
        {
            KhoiTao();
           
        }
         bool Check()
        {
            if ( tbTen.Text == "" || tbLaiXuat.Text == "" )
            {
                MessageBox.Show("Mời nhập đầy đủ các thông tin!", "Thông báo lỗi!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }
            if (cbThoiHan.Checked && tbThoiHan.Text=="")
            {
                MessageBox.Show("Mời nhập thời hạn!", "Thông báo lỗi!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        bool CheckMa(string st)
        {
            DataTable dtb = new DataTable();
            dt = dataProvider.Instance.ExecuteQuery(st);
            if (dt.Rows.Count==0)
            {
                return true;
            }
            return false;
        }
        int Random()
        {
            Random rd = new Random();
            return rd.Next(1000, 9999);
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            string query;
            if (!Check())
            {
                return;
            }
            string maLTK = Random().ToString();
            string st = "SELECT * FROM LOAITIETKIEM WHERE MaLoaiTK='" + maLTK + "' ";
            while (!CheckMa(st))
            {
                maLTK = Random().ToString();
            }
            tbMa.Text = maLTK;
            st= "SELECT * FROM LOAITIETKIEM WHERE ThoiHan='" + tbThoiHan.Text + "' ";
            if (!CheckMa(st))
            {
                MessageBox.Show("Thời hạn đã tồn tại, mời nhập lại!", "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                tbThoiHan.Focus();
                return;
            }
            if (cbThoiHan.Checked)
            {
                query = "INSERT INTO LOAITIETKIEM VALUES ('" + tbMa.Text + "',N'" + tbTen.Text + "','" + tbThoiHan.Text + "','" + tbLaiXuat.Text + "')";
            }
            else
            {
                 query = "INSERT INTO LOAITIETKIEM VALUES ('" + tbMa.Text + "',N'" + tbTen.Text + "','0','" + tbLaiXuat.Text + "')";
            }

            DialogResult result = MessageBox.Show("Bạn có thực sự muốn thêm Loại tiết kiệm trên?", "Important Question", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (dataProvider.Instance.ExecuteNonQuery(query) == 0)
                {
                    MessageBox.Show("Thêm không thành công!");
                }
                else
                {
                    MessageBox.Show("Thêm thành công!");
                    KhoiTao();
                }
            }
        }

        bool CheckDelete()
        {
            int a = dgvLoaiLX.CurrentRow.Index;
            if (dgvLoaiLX.Rows[a].Cells[0].Value.ToString()!= tbMa.Text || dgvLoaiLX.Rows[a].Cells[1].Value.ToString()!=tbTen.Text || dgvLoaiLX.Rows[a].Cells[3].Value.ToString() != tbLaiXuat.Text || (cbThoiHan.Checked && tbThoiHan.Text!= dgvLoaiLX.Rows[a].Cells[2].Value.ToString()) || (dgvLoaiLX.Rows[a].Cells[2].Value.ToString()!="" && !cbThoiHan.Checked))
            {
                MessageBox.Show("Loại tiết kiệm trên hiện không tồn lại, mời chọn lại loại tiết kiệm muốn xóa!", "Thông báo lỗi!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        bool xoa()
        {
            try
            {
                string st = "DELETE FROM LOAITIETKIEM WHERE MaLoaiTK='" + tbMa.Text + "'";
                if (dataProvider.Instance.ExecuteNonQuery(st) == 0)
                {
                    MessageBox.Show("Xóa không thành công!");
                }
                else
                {
                    MessageBox.Show("Xóa thành công!");
                    KhoiTao();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        private void btXoa_Click(object sender, EventArgs e)
        {
            if (!CheckDelete())
            {
                return;
            }
          
            DialogResult result = MessageBox.Show("Bạn có thực sự muốn xóa loại tiết kiệm trên?", "Important Question", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (!xoa())
                {
                    MessageBox.Show("không xóa được do có sổ tiết kiệm đang sử dụng loại tiết kiệm này, vui lòng thử lại sau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btSua_Click(object sender, EventArgs e)
        {
            if (!Check())
            {
                return;
            }
            string st = "SELECT * FROM LOAITIETKIEM WHERE MaLoaiTK='" + tbMa.Text + "' ";
            if (!CheckMa(st))
            {
                MessageBox.Show("Mã Loại tiết kiệm đã tồn tại, mời nhập lại!", "Thông báo!", MessageBoxButtons.OK);
                tbMa.Focus();
            }
            
            if (cbThoiHan.Checked)
            {
                st= "UPDATE LOAITIETKIEM SET TenLoaiTK= N'" + tbTen.Text + "',ThoiHan='" + tbThoiHan.Text + "',LaiXuat='" + tbLaiXuat.Text + "' WHERE MaLoaiTK= '" + tbMa.Text + "'";
            }
            else
            {
                st = "UPDATE LOAITIETKIEM SET MaLoaiTK= N'" + tbMa.Text + "',TenLoaiTK='" + tbTen.Text + "',ThoiHan= '0',LaiXuat='" + tbLaiXuat.Text + "' WHERE MaLoaiTK= '" + tbMa.Text + "'"; ;
            }
            DialogResult result = MessageBox.Show("Bạn có thực sự muốn sửa thông tin loại tiết kiệm trên?", "Important Question", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (dataProvider.Instance.ExecuteNonQuery(st) == 0)
                {
                    MessageBox.Show("Sửa không thành công!");
                }
                else
                {
                    MessageBox.Show("Sửa thành công!");
                    KhoiTao();
                }
            }
        }

    
        void TimKiem()
        {
            try
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    if (radioButton1.Checked)
                    {
                        string rowFilter = string.Format("{0} like '{1}'", "MaLoaiTK", "*" + textBox1.Text + "*");
                        (dgvLoaiLX.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
                    }
                    else if (radioButton2.Checked)
                    {
                        string rowFilter = string.Format("{0} like '{1}'", "TenLoaiTK", "*" + textBox1.Text + "*");
                        (dgvLoaiLX.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
                    }
                    else if (radioButton3.Checked)
                    {
                        int Result;
                        bool a = int.TryParse(tbThoiHan.Text, out Result);
                        string rowFilter = string.Format("{0} = {1}", "ThoiHan", Result);
                        (dgvLoaiLX.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
                    }
                    else
                    {
                        float Result;
                        bool a = float.TryParse(tbLaiXuat.Text, out Result);
                        string rowFilter = string.Format("{0} > {1}", "LaiXuat", Result);
                        (dgvLoaiLX.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
                    }

                }
                else
                {
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void cbThoiHan_CheckedChanged(object sender, EventArgs e)
        {
            if (cbThoiHan.Checked)
            {
                tbThoiHan.Enabled = true;
            }
            else
            {
                tbThoiHan.Enabled = false;
            }
        }

        private void tbLaiXuat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbThoiHan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
