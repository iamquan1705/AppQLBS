
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace QLBS
{
    public partial class nhanvien : Form
    {
        public nhanvien()
        {
            InitializeComponent();
        }

        private void nhanvien_Load(object sender, EventArgs e)
        {
            HienThiDGV();
        }

        string chuoiketnoi = @"Data Source=21AK22-COM;Initial Catalog=QUANLYBANSACH;Integrated Security=True";
        SqlConnection conn;


        private void HienThiDGV()
        {
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            string danhmuc = "Select * from tb_nhanvien";
            //tạo đối tượng data adapter =>có csdl
            SqlDataAdapter Mydata = new SqlDataAdapter(danhmuc, conn);
            // mydata có dữ liệu=>đổ dữ liệu từ mydata vào bảng
            DataTable dt = new DataTable(); //tạo 1 bảng
            // đổ dữ liệu từ mydata vào bảng
            Mydata.Fill(dt);
            dgvnv.DataSource = dt;
            conn.Close();
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            //Tạo đối tượng Sql ConnectionSq
            conn = new SqlConnection(chuoiketnoi);
            //Mở kết nối =>open()
            conn.Open();
            //Thực hiện câu lệnh insert dữ liệu vào csdl nguồn
            //lấy dữ liệu trên form
            string gioitinh;
            string tenNhanVien = txttennv.Text;
            string ngaysinh = txtngaysinh.Text;
            if (rbnam.Checked == true)
                gioitinh = "Nam";
            else gioitinh = "Nữ";
            string sdtNhanVien = txtdienthoai.Text;
            string diachi = txtdiachi.Text;

            //khai báo chuỗi insert
            string sqlthem = "Insert into tb_nhanvien values(N'" + tenNhanVien + "',N'" + ngaysinh + "',N'" + gioitinh + "',N'" + sdtNhanVien + "',N'" + diachi + "')";
            //khai báo và khởi tạo đối tượng sql command

            SqlCommand cmd = new SqlCommand(sqlthem, conn);
            //thực thi truy vấn


            cmd.ExecuteNonQuery();
            XoaDL();
            HienThiDGV();




            conn.Close();
        }
        private void XoaDL()
        {
            txtmanv.Clear();
            txttennv.Clear();
            txtdiachi.Clear();
            txtdienthoai.Clear();
            txtngaysinh.Clear();
            HienThiDGV();
            txtmanv.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //KẾT NỐI , MỞ KẾT NỐI
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            //Chuỗi sql xóa có đk
            string maNhanVien = txtmanv.Text;
            if (maNhanVien == "")
            {
                MessageBox.Show("Chưa chọn mã danh mục cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string sql_del = "Delete from tb_nhanvien where maNhanVien=N'" + maNhanVien + "'";
                SqlCommand cmd = new SqlCommand(sql_del, conn);
                DialogResult Rsulet = MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Rsulet == DialogResult.OK)
                {
                    cmd.ExecuteNonQuery();
                    HienThiDGV();
                    HienThiDGV();
                    XoaDL();
                }
            }
            conn.Close();
        }

        private void bntThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            XoaDL();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            if (txtmanv.Text == "")
            {
                MessageBox.Show("Chưa chọn nhân viên cần sửa ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmanv.Focus();
            }
            else
            {
                string gioitinh;
                int maNhanVien = Int32.Parse( txtmanv.Text);
                string tenNhanVien = txttennv.Text;
                string ngaysinh = txtngaysinh.Text;
                if (rbnam.Checked == true)
                    gioitinh = "Nam";
                else gioitinh = "Nữ";
                string sdtNhanVien = txtdienthoai.Text;
                string diachi = txtdiachi.Text;
                string sql_update = "Update tb_nhanvien set tenNhanVien=N'" + tenNhanVien + "',sdtNhanVien=N'" + sdtNhanVien + "',gioitinh=N'" + gioitinh + "',diachi=N'" + diachi + "' where maNhanVien = N'" + maNhanVien + "' ";
                SqlCommand cmd = new SqlCommand(sql_update, conn);
                DialogResult Rsulet = MessageBox.Show("Bạn có chắc chắn muốn sửa không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Rsulet == DialogResult.OK)
                {
                    cmd.ExecuteNonQuery();
                    HienThiDGV();
                    XoaDL();
                }
            }

            conn.Close();
        }

        private void dgvnv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i = 0; i < dgvnv.RowCount; i++)
            {
                dgvnv.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void dgvnv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmanv.Text = dgvnv.CurrentRow.Cells["maNhanVien"].Value.ToString();
            txttennv.Text = dgvnv.CurrentRow.Cells["tenNhanVien"].Value.ToString();
            txtngaysinh.Text = dgvnv.CurrentRow.Cells["ngaySinh"].Value.ToString();
            txtdienthoai.Text = dgvnv.CurrentRow.Cells["dienThoai"].Value.ToString();
            txtdiachi.Text = dgvnv.CurrentRow.Cells["diaChi"].Value.ToString();
            if (dgvnv.CurrentRow.Cells["gioiTinh"].Value.ToString()=="Nam")
            {
                rbnam.Checked=true;
                rbnu.Checked = false;
            } else
            {
                rbnam.Checked = false;
                rbnu.Checked = true;
            }
        }
    }
}