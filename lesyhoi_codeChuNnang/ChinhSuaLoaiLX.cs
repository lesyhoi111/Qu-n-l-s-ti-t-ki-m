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

namespace Lần_1
{
    public partial class ChinhSuaLoaiTK : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string strcon = @"Data Source=LESYHOI;Initial Catalog=QLSTK;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable dt = new DataTable();
        bool Search = false;

        public ChinhSuaLoaiTK()
        {
            InitializeComponent();
        }

        private void ChinhSuaLoaiTK_Load(object sender, EventArgs e)
        {          
            dgvLoaiLX.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLoaiLX.Columns["ThoiHan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLoaiLX.Columns["LaiXuat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            connection = new SqlConnection(strcon);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            LoadData();
        }
        void LoadData()
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM LOAITIETKIEM";
            adapter.SelectCommand = command;
            dt.Clear();
            adapter.Fill(dt);
            dgvLoaiLX.DataSource = dt;
            tbThoiHan.Enabled = false;
        }

        private void ChinhSuaLoaiTK_FormClosed(object sender, FormClosedEventArgs e)
        {
            connection.Close();
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
            if (dgvLoaiLX.Rows[i].Cells[2].Value.ToString() == "")
            {
                cbThoiHan.Checked = false;
                tbThoiHan.Text = "";
            }
            else
            {
                cbThoiHan.Checked = true;
                tbThoiHan.Text = dgvLoaiLX.Rows[i].Cells[2].Value.ToString();
                tbThoiHan.Enabled=true;
            }
            
        }
        void KhoiTao()
        {
            tbMa.Enabled = true;
            tbMa.Text = tbTen.Text = tbLaiXuat.Text = tbThoiHan.Text = "";
            cbThoiHan.Checked = false;
            tbThoiHan.Enabled = false;
            LoadData();

            (dgvLoaiLX.DataSource as DataTable).DefaultView.RowFilter = "ThoiHan>=0";
        }
        private void btKhoiTao_Click(object sender, EventArgs e)
        {
            KhoiTao();
            Search = false;
            btTimKiem.Text = "Tìm kiếm";
        }
         void Check()
        {
            if (tbMa.Text == "" || tbTen.Text == "" || tbLaiXuat.Text == "" )
            {
                MessageBox.Show("Mời nhập đầy đủ các thông tin!", "Thông báo lỗi!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            if (cbThoiHan.Checked && tbThoiHan.Text=="")
            {
                MessageBox.Show("Mời nhập thời hạn!", "Thông báo lỗi!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }
        bool CheckMa(string st)
        {
            command = connection.CreateCommand();
            command.CommandText = st;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                return false;
            }
            return true;
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            Check();
            string st = "SELECT * FROM LOAITIETKIEM WHERE MaLoaiTK='" + tbMa.Text + "' ";
            if (!CheckMa(st))
            {
                MessageBox.Show("Mã Loại tiết kiệm đã tồn tại, mời nhập lại!", "Thông báo!", MessageBoxButtons.OK);
                tbMa.Focus();
            }
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            command = connection.CreateCommand();
            if (cbThoiHan.Checked)
            {
                command.CommandText = "INSERT INTO LOAITIETKIEM VALUES ('" + tbMa.Text + "',N'" + tbTen.Text + "','" + tbThoiHan.Text + "','" + tbLaiXuat.Text + "')";
            }
            else
            {
                command.CommandText = "INSERT INTO LOAITIETKIEM VALUES ('" + tbMa.Text + "',N'" + tbTen.Text + "','0','" + tbLaiXuat.Text + "')";
            }

            DialogResult result = MessageBox.Show("Bạn có thực sự muốn thêm Loại tiết kiệm trên?", "Important Question", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (command.ExecuteNonQuery() == 0)
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
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -2))
            {
                e.Handled = true;
            }
        }

        private void cbThoiHan_Click(object sender, EventArgs e)
        {
            
            if (cbThoiHan.Checked)
            {
                tbThoiHan.Enabled = true;
            }
            else
            {
                tbThoiHan.Enabled = false;
                tbThoiHan.Text = "";
            }
            if (Search)
            {
                if (cbThoiHan.Checked)
                {
                    int Result;
                    bool a = int.TryParse(tbThoiHan.Text, out Result);
                    string rowFilter = string.Format("{0} > {1}", "ThoiHan", Result);
                    (dgvLoaiLX.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
                }
                else
                {
                    string rowFilter = string.Format("{0} = 0", "ThoiHan");
                    (dgvLoaiLX.DataSource as DataTable).DefaultView.RowFilter = rowFilter;

                }
            }
        }

        void CheckDelete()
        {
            int a = dgvLoaiLX.CurrentRow.Index;
            if (dgvLoaiLX.Rows[a].Cells[0].Value.ToString()!= tbMa.Text || dgvLoaiLX.Rows[a].Cells[1].Value.ToString()!=tbTen.Text || dgvLoaiLX.Rows[a].Cells[3].Value.ToString() != tbLaiXuat.Text || (cbThoiHan.Checked && tbThoiHan.Text!= dgvLoaiLX.Rows[a].Cells[2].Value.ToString()) || (dgvLoaiLX.Rows[a].Cells[2].Value.ToString()!="" && !cbThoiHan.Checked))
            {
                MessageBox.Show("Loại tiết kiệm trên hiện không tồn lại, mời chọn lại loại tiết kiệm muốn xóa!", "Thông báo lỗi!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
        private void btXoa_Click(object sender, EventArgs e)
        {
            CheckDelete();
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            command = connection.CreateCommand();
            command.CommandText = "DELETE FROM LOAITIETKIEM WHERE MaLoaiTK='" + tbMa.Text + "'";
            DialogResult result = MessageBox.Show("Bạn có thực sự muốn xóa Nhân viên trên?", "Important Question", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (command.ExecuteNonQuery() == 0)
                {
                    MessageBox.Show("Xóa không thành công!");
                }
                else
                {
                    MessageBox.Show("Xóa thành công!");
                    KhoiTao();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void btSua_Click(object sender, EventArgs e)
        {
            Check();
            string st = "SELECT * FROM LOAITIETKIEM WHERE MaLoaiTK='" + tbMa.Text + "' ";
            if (!CheckMa(st))
            {
                MessageBox.Show("Mã Loại tiết kiệm đã tồn tại, mời nhập lại!", "Thông báo!", MessageBoxButtons.OK);
                tbMa.Focus();
            }
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            command = connection.CreateCommand();
            if (cbThoiHan.Checked)
            {
                command.CommandText = "UPDATE LOAITIETKIEM SET TenLoaiTK= N'" + tbTen.Text + "',ThoiHan='" + tbThoiHan.Text + "',LaiXuat='" + tbLaiXuat.Text + "' WHERE MaLoaiTK= '" + tbMa.Text + "'";
            }
            else
            {
                command.CommandText = "UPDATE LOAITIETKIEM SET MaLoaiTK= N'" + tbMa.Text + "',TenLoaiTK='" + tbTen.Text + "',ThoiHan= '0',LaiXuat='" + tbLaiXuat.Text + "' WHERE MaLoaiTK= '" + tbMa.Text + "'"; ;
            }
            DialogResult result = MessageBox.Show("Bạn có thực sự muốn sửa thông tin Nhân viên trên?", "Important Question", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (command.ExecuteNonQuery() == 0)
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

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            if (Search)
            {
                Search = false;
                KhoiTao();
                btTimKiem.Text = "Tìm kiếm";
            }
            else
            {
                Search = true;
                btTimKiem.Text = "Bỏ tìm kiếm";
                btKhoiTao.Enabled = true;
            }
        }

        private void tbMa_TextChanged(object sender, EventArgs e)
        {
            if (Search)
            {
                string rowFilter = string.Format("{0} like '{1}'", "MaLoaiLX", "*" + tbMa.Text + "*");
                (dgvLoaiLX.DataSource as DataTable).DefaultView.RowFilter = rowFilter;

            }
        }

        private void tbTen_TextChanged(object sender, EventArgs e)
        {
            if (Search)
            {
                string rowFilter = string.Format("{0} like '{1}'", "TenLoaiLX", "*" + tbTen.Text + "*");
                (dgvLoaiLX.DataSource as DataTable).DefaultView.RowFilter = rowFilter;

            }
        }

        private void tbLaiXuat_TextChanged(object sender, EventArgs e)
        {
            if (Search)
            {
                float Result;
                bool a = float.TryParse(tbLaiXuat.Text, out Result);
                string rowFilter = string.Format("{0} > {1}", "LaiXuat", Result);
                (dgvLoaiLX.DataSource as DataTable).DefaultView.RowFilter = rowFilter;

            }
        }

        private void tbThoiHan_TextChanged(object sender, EventArgs e)
        {
            if (cbThoiHan.Checked)
            {
                int Result;
                bool a = int.TryParse(tbThoiHan.Text, out Result);
                string rowFilter = string.Format("{0} > {1}", "ThoiHan", Result);
                (dgvLoaiLX.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
            }
        }
    }
}
