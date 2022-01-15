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
    public partial class khachhang : Form
    {
        public khachhang()
        {
            InitializeComponent();
        }
        string chuoiketnoi = @"Data Source=21AK22-COM;Initial Catalog=QUANLYBANSACH;Integrated Security=True";
        SqlConnection conn;
        private void khachhang_Load(object sender, EventArgs e)
        {
            HienthiDGV();
        }
        private void HienthiDGV()
        {
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();

            string nhacungcap = "Select * from tb_khachhang";
            //tạo đối tượng data adapter =>có csdl
            SqlDataAdapter Mydata = new SqlDataAdapter(nhacungcap, conn);
            // mydata có dữ liệu=>đổ dữ liệu từ mydata vào bảng
            DataTable dt = new DataTable(); //tạo 1 bảng
            // đổ dữ liệu từ mydata vào bảng
            Mydata.Fill(dt);
            dgvkh.DataSource = dt;
            conn.Close();
        }
        private void XoaDL()
        {
            
            txtTenKH.Clear();
            txtDiaChi.Clear();
            txtDT.Clear();
            HienthiDGV();
            txtDT.Focus();
        }
        private Boolean kiemtra()
        {
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            string sdt = txtDT.Text;
            string sql_kt = "Select * from tb_khachhang where sdtKhachHang='" + sdt + "'";
            SqlCommand cmd = new SqlCommand(sql_kt, conn);
            SqlDataReader Dr;
            Dr = cmd.ExecuteReader();
            Boolean kt = true;
            while (Dr.Read())
            {
                if (sdt == Dr[0].ToString())
                    kt = false;
                MessageBox.Show("Trùng mã,nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                break;
            }

            conn.Close();
            return kt;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            //Tạo đối tượng Sql ConnectionSq
            conn = new SqlConnection(chuoiketnoi);
            //Mở kết nối =>open()
            conn.Open();
            //Thực hiện câu lệnh insert dữ liệu vào csdl nguồn
            //lấy dữ liệu trên form
            string tenKH = txtTenKH.Text;
            string diachi = txtDiaChi.Text;
            string dienthoai = txtDT.Text;
            

            //khai báo chuỗi insert
            string sqlthem = "Insert into tb_khachhang values(N'" + dienthoai + "',N'" + tenKH + "',N'" + diachi + "')";
            //khai báo và khởi tạo đối tượng sql command
            if (dienthoai == "")
            {
                MessageBox.Show("Chưa nhập số điện thoại khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                SqlCommand cmd = new SqlCommand(sqlthem, conn);
                //thực thi truy vấn
                if (kiemtra() == true)
                {
                    cmd.ExecuteNonQuery();
                    XoaDL();
                    HienthiDGV();
                }

            }

            conn.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            if (txtDT.Text == "")
            {
                MessageBox.Show("Chưa nhập số điện thoại khách hàng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDT.Focus();
            }
            else
            {
                string tg = txtDT.Text;
                //lấy dữ liệu trên form
                string tenKH = txtTenKH.Text;
                string diachi = txtDiaChi.Text;
                string dienthoai = txtDT.Text;
                string sql_update = "Update tb_khachhang set tenKhachHang=N'" + tenKH + "',diaChiKhachHang=N'" + diachi + "' where sdtKhachHang = N'" + tg + "' ";
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
            string sdtKH = txtDT.Text;
            if (sdtKH == "")
            {
                MessageBox.Show("Chưa nhập khách hàng cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string sql_del = "Delete from tb_khachhang where sdtKhachHang=N'" + sdtKH + "'";
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

        private void bntThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dgvnv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i = 0; i < dgvkh.RowCount; i++)
            {
                dgvkh.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            XoaDL();
            HienthiDGV();
        }

        private void dgvkh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDT.Text = dgvkh.CurrentRow.Cells["sdtKhachHang"].Value.ToString();
            txtTenKH.Text = dgvkh.CurrentRow.Cells["tenKhachHang"].Value.ToString();
            txtDiaChi.Text = dgvkh.CurrentRow.Cells["diaChiKhachHang"].Value.ToString();
        }
    }
}
