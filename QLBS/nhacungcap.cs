using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QLBS
{
    public partial class nhacungcap : Form
    {
        public nhacungcap()
        {
            InitializeComponent();
        }
        string chuoiketnoi = @"Data Source=21AK22-COM;Initial Catalog=QUANLYBANSACH;Integrated Security=True";
        SqlConnection conn;
        private void nhacungcap_Load(object sender, EventArgs e)
        {
            HienthiDGV();
        }
        private void HienthiDGV()
        {
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();

            string nhacungcap = "Select * from tb_nhacungcap";
            //tạo đối tượng data adapter =>có csdl
            SqlDataAdapter Mydata = new SqlDataAdapter(nhacungcap, conn);
            // mydata có dữ liệu=>đổ dữ liệu từ mydata vào bảng
            DataTable dt = new DataTable(); //tạo 1 bảng
            // đổ dữ liệu từ mydata vào bảng
            Mydata.Fill(dt);
            dgvNCC.DataSource = dt;
            conn.Close();

        }
        private void XoaDL()
        {
            txtmancc.Clear();
            txttenncc.Clear();
            txtdiachi.Clear();
            txtdt.Clear();
            txtghichu.Clear();
            txtChietKhau.Clear();
            HienthiDGV();
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            //Tạo đối tượng Sql ConnectionSq
            conn = new SqlConnection(chuoiketnoi);
            //Mở kết nối =>open()
            conn.Open();
            //Thực hiện câu lệnh insert dữ liệu vào csdl nguồn
            //lấy dữ liệu trên form
            string tenNCC = txttenncc.Text;
            string diachi = txtdiachi.Text;
            string sodienthoai = txtdt.Text;
            string ghichu = txtghichu.Text;
            int chietkhau = Int32.Parse(txtChietKhau.Text);

            //khai báo chuỗi insert
            string sqlthem = "Insert into tb_nhacungcap values(N'" + tenNCC + "',N'" + diachi + "',N'" + sodienthoai + "','"+chietkhau+"',N'" + ghichu + "')";
            //khai báo và khởi tạo đối tượng sql command

            SqlCommand cmd = new SqlCommand(sqlthem, conn);
            //thực thi truy vấn

            cmd.ExecuteNonQuery();
            XoaDL();
            HienthiDGV();




            conn.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            if (txtmancc.Text == "")
            {
                MessageBox.Show("Chưa chọn nhà cung cấp ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmancc.Focus();
            }
            else
            {
                int tg =Int32.Parse( txtmancc.Text);
                string tenNCC = txttenncc.Text;
                string diachi = txtdiachi.Text;
                string sodienthoai = txtdt.Text;
                string ghichu = txtghichu.Text;
                int chietkhau = Int32.Parse(txtChietKhau.Text);
                string sql_update = "Update tb_nhacungcap set tenNhaCungCap=N'" + tenNCC + "',diaChi=N'" + diachi + "',sdtNhaCungCap=N'" + sodienthoai + "',chietKhau='" + chietkhau + "' ,ghichu=N'" + ghichu + "' where maNhaCungCap = N'" + tg + "' ";
                SqlCommand cmd = new SqlCommand(sql_update, conn);
                DialogResult Rsulet = MessageBox.Show("Bạn có chắc chắn muốn sửa không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Rsulet == DialogResult.OK)
                {
                    cmd.ExecuteNonQuery();
                    HienthiDGV();
                    XoaDL();
                }
            }

            conn.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //KẾT NỐI , MỞ KẾT NỐI
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            //Chuỗi sql xóa có đk
            string maNCC = txtmancc.Text;
            if (maNCC == "")
            {
                MessageBox.Show("Chưa chọn nhà cung cấp cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string sql_del = "Delete from tb_nhacungcap where maNhaCungCap=N'" + maNCC + "'";
                SqlCommand cmd = new SqlCommand(sql_del, conn);
                DialogResult Rsulet = MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Rsulet == DialogResult.OK)
                {
                    cmd.ExecuteNonQuery();
                    HienthiDGV();
                    XoaDL();
                }
            }
            conn.Close();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            XoaDL();
        }

        private void bntThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dgvNCC_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i = 0; i < dgvNCC.RowCount; i++)
            {
                dgvNCC.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmancc.Text = dgvNCC.CurrentRow.Cells["maNhaCungCap"].Value.ToString();
            txttenncc.Text = dgvNCC.CurrentRow.Cells["tenNhaCungCap"].Value.ToString();
            txtdiachi.Text = dgvNCC.CurrentRow.Cells["diaChi"].Value.ToString();
            txtdt.Text = dgvNCC.CurrentRow.Cells["dienThoai"].Value.ToString();
            txtghichu.Text = dgvNCC.CurrentRow.Cells["ghiChu"].Value.ToString();
            txtChietKhau.Text = dgvNCC.CurrentRow.Cells["chietKhau"].Value.ToString();
        }
    }
}
