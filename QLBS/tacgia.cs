
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QLBS
{
    public partial class tacgia : Form
    {
        public tacgia()
        {
            InitializeComponent();
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
            string tenTacGia = txttentg.Text;
            string trinhdo = txtTrinhDo.Text;
            string gioitinh;
            if (rbnam.Checked == true)
                gioitinh = "Nam";
            else gioitinh = "Nữ";
            string ngaysinh = dtpNgaySinh.Text;
            //khai báo chuỗi insert
            string sqlthem = "Insert into tb_tacgia values(N'" + tenTacGia + "',N'" + gioitinh + "',N'" + ngaysinh + "',N'" + trinhdo + "')";
            //khai báo và khởi tạo đối tượng sql command

            SqlCommand cmd = new SqlCommand(sqlthem, conn);
            //thực thi truy vấn

            cmd.ExecuteNonQuery();
            XoaDL();
            Hienthi_DGView();
            conn.Close();
        }

        private void tacgia_Load(object sender, EventArgs e)
        {
            Hienthi_DGView();
        }
        public void XoaDL()
        {
            txtmatg.Clear();
            txttentg.Clear();
            dtpNgaySinh.ResetText();
            txtTrinhDo.Clear();
            txtmatg.Focus();
            Hienthi_DGView();
        }
        private void Hienthi_DGView()
        {
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            string tacgia = "select * from tb_tacgia";
            //tạo đối tượng data adapter =>có csdl
            SqlDataAdapter Mydata = new SqlDataAdapter(tacgia, conn);
            // mydata có dữ liệu=>đổ dữ liệu từ mydata vào bảng
            DataTable dt = new DataTable(); //tạo 1 bảng
            // đổ dữ liệu từ mydata vào bảng
            Mydata.Fill(dt);
            dgvtg.DataSource = dt;
            conn.Close();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            if (txtmatg.Text == "")
            {
                MessageBox.Show("Chưa chọn tác giả cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmatg.Focus();
            }
            else
            {
                string maTacGia = txtmatg.Text;
                string tenTacGia = txttentg.Text;
                string tdo = txtTrinhDo.Text;
                string gioitinh;
                if (rbnam.Checked == true)
                {
                    gioitinh = "Nam";
                }
                else
                {
                    gioitinh = "Nữ";
                }
                string ngaysinh = dtpNgaySinh.Text;
                string sql_update = "Update tb_tacgia set tenTacGia=N'" + tenTacGia + "',gioitinh=N'" + gioitinh + "',ngaysinh=N'" + ngaysinh + "',trinhDo=N'" + tdo + "' where maTacGia = N'" + maTacGia + "' ";
                SqlCommand cmd = new SqlCommand(sql_update, conn);
                DialogResult Rsulet = MessageBox.Show("Bạn có chắc chắn muốn sửa không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Rsulet == DialogResult.OK)
                {
                    cmd.ExecuteNonQuery();
                    Hienthi_DGView();
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
            string maTacGia = txtmatg.Text;
            if (maTacGia == "")
            {
                MessageBox.Show("Chưa chọn tác giả cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string sql_del = "Delete from tb_tacgia where maTacGia=N'" + maTacGia + "'";
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            XoaDL();
        }

        private void bntThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

       

        private void dgvtg_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i = 0; i < dgvtg.RowCount; i++)
            {
                dgvtg.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void btTimkiem_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            String tk = txtTimkiem.Text;
            String sqltimkiem = "select * from tb_tacgia where tenTacGia like %'"+tk+"'%";
            //tạo đối tượng data adapter =>có csdl
            SqlDataAdapter Mydata = new SqlDataAdapter(sqltimkiem, conn);
            // mydata có dữ liệu=>đổ dữ liệu từ mydata vào bảng
            DataTable dt = new DataTable(); //tạo 1 bảng
            // đổ dữ liệu từ mydata vào bảng
            Mydata.Fill(dt);
            dgvtg.DataSource = dt;
            conn.Close();

        }

        private void dgvtg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmatg.Text = dgvtg.CurrentRow.Cells[1].Value.ToString();
            txttentg.Text = dgvtg.CurrentRow.Cells[2].Value.ToString();
            dtpNgaySinh.Text = dgvtg.CurrentRow.Cells[4].Value.ToString();
            txtTrinhDo.Text = dgvtg.CurrentRow.Cells[5].Value.ToString();
            if (dgvtg.CurrentRow.Cells["gioiTinh"].Value.ToString() == "Nam")
            {
                rbnam.Checked = true;
                rbnu.Checked = false;
            }
            else
            {
                rbnam.Checked = false;
                rbnu.Checked = true;
            }
        }

     
    }
}