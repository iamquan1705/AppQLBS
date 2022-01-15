
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLBS
{
    public partial class danhmuc : Form
    {
        public danhmuc()
        {
            InitializeComponent();
        }
        private void danhmuc_Load(object sender, EventArgs e)
        {
            Hienthi_DGView();
        }

        string chuoiketnoi = @"Data Source=21AK22-COM;Initial Catalog=QUANLYBANSACH;Integrated Security=True";
        SqlConnection conn;
        private void btnThem_Click(object sender, EventArgs e)
        {
            //Tạo đối tượng Sql ConnectionSq
            conn = new SqlConnection(chuoiketnoi);
            //Mở kết nối =>open()
            conn.Open();
            //Thực hiện câu lệnh insert dữ liệu vào csdl nguồn
            //lấy dữ liệu trên form
            string tenLoaiSach = tbTenloaisach.Text;

            //khai báo chuỗi insert
            string sqlthem = "Insert into tb_loaisach values(N'" + tenLoaiSach + "')";
            //khai báo và khởi tạo đối tượng sql command

            SqlCommand cmd = new SqlCommand(sqlthem, conn);
            //thực thi truy vấn

            cmd.ExecuteNonQuery();
            XoaDL();
            Hienthi_DGView();
            conn.Close();
        }
        private void Hienthi_DGView()
        {
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            string danhmuc = "Select * from tb_loaisach";
            //tạo đối tượng data adapter =>có csdl
            SqlDataAdapter Mydata = new SqlDataAdapter(danhmuc, conn);
            // mydata có dữ liệu=>đổ dữ liệu từ mydata vào bảng
            DataTable dt = new DataTable(); //tạo 1 bảng
            // đổ dữ liệu từ mydata vào bảng
            Mydata.Fill(dt);
            dgvdm.DataSource = dt;
            conn.Close();

        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            XoaDL();
        }
        public void XoaDL()
        {
            tbMaloaisach.Clear();
            tbTenloaisach.Clear();
            Hienthi_DGView();
        }

        private void dgvdm_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i = 0; i < dgvdm.RowCount; i++)
            {
                dgvdm.Rows[i].Cells[0].Value = i + 1;
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();
                
            //lấy dữ liệu trên form
                string maLoaiSach = tbMaloaisach.Text;
                string tenLoaiSach = tbTenloaisach.Text;
                string sql_update = "Update tb_loaisach set tenLoaiSach=N'" + tenLoaiSach + "' where maLoaiSach = N'" + maLoaiSach + "' ";
                SqlCommand cmd = new SqlCommand(sql_update, conn);
                DialogResult Rsulet = MessageBox.Show("Bạn có chắc chắn muốn sửa không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Rsulet == DialogResult.OK)
                {
                    cmd.ExecuteNonQuery();
                    Hienthi_DGView();
                    XoaDL();
                }

            conn.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //KẾT NỐI , MỞ KẾT NỐI
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            //Chuỗi sql xóa có đk
            string maLoaiSach = tbMaloaisach.Text;
            if (maLoaiSach  == "")
            {
                MessageBox.Show("Chưa nhập mã danh mục cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string sql_del = "Delete from tb_loaisach where maLoaiSach=N'" + maLoaiSach + "'";
                SqlCommand cmd = new SqlCommand(sql_del, conn);
                DialogResult Rsulet = MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Rsulet == DialogResult.OK)
                {
                    cmd.ExecuteNonQuery();
                    Hienthi_DGView();
                    XoaDL();
                }
            }
            conn.Close();
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            string key = txttimkiem.Text;
            string Sql_tim = "select * from tb_loaisach where tenLoaiSach like N'%" + key + "%' or tenLoaiSach like N'%" + key + "%'";
            SqlDataAdapter Mydata = new SqlDataAdapter(Sql_tim, conn);
            // mydata có dữ liệu=>đổ dữ liệu từ mydata vào bảng
            DataTable dt = new DataTable(); //tạo 1 bảng
            // đổ dữ liệu từ mydata vào bảng
            Mydata.Fill(dt);
            dgvdm.DataSource = dt;
            conn.Close();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
                     this.Hide();
           

        }

        private void dgvdm_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbMaloaisach.Text = dgvdm.CurrentRow.Cells[1].Value.ToString();
            tbTenloaisach.Text = dgvdm.CurrentRow.Cells[2].Value.ToString();
        }
    }
}