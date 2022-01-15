using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QLBS
{
    
    public partial class phieuxuat : Form
    {
        string chuoiketnoi = @"Data Source=21AK22-COM;Initial Catalog=QUANLYBANSACH;Integrated Security=True";
        SqlConnection conn;
        public phieuxuat()
        {
            InitializeComponent();
            Hienthi_DGView();
            nhanvien();
        }
        private void connectSQL()
        {
            conn = new SqlConnection(chuoiketnoi);
            //Mở kết nối =>open()
            conn.Open();

        }
        private void Hienthi_DGView()
        {
            connectSQL();
            String hienthipx = "SELECT tb_hoadon.maHoaDon,tb_nhanvien.tenNhanVien,tb_hoadon.sdtKhachHang,tb_hoadon.ngayXuat FROM tb_hoadon INNER JOIN tb_nhanvien on tb_hoadon.maNhanVien=tb_nhanvien.maNhanVien ";
            //tạo đối tượng data adapter =>có csdl
            SqlDataAdapter Mydatapx = new SqlDataAdapter(hienthipx, conn);
            // mydata có dữ liệu=>đổ dữ liệu từ mydata vào bảng
            DataTable dtpx = new DataTable(); //tạo 1 bảng
            // đổ dữ liệu từ mydata vào bảng
            Mydatapx.Fill(dtpx);
            dgvPX.DataSource = dtpx;
            conn.Close();
            connectSQL();
            
        }

        private void phieuxuat_Load(object sender, EventArgs e)
        {
            Hienthi_DGView();
            
        }
        private void btCheck_Click(object sender, EventArgs e)
        {
            connectSQL();
            string sdtKh = tbSDT.Text;
            string sql_kt = "Select * from tb_khachhang where sdtKhachHang='" + sdtKh + "'";
            SqlCommand cmd = new SqlCommand(sql_kt, conn);
            SqlDataReader Dr;
            Dr = cmd.ExecuteReader();
            Boolean kt = true;
            while (Dr.Read())
            {
                if (sdtKh == Dr[0].ToString())
                {
                    kt = false;
                    //lbThongBao.Text = "Chào khách hàng thân thiết!!!";
                    tbTenKhachHang.Text = Dr[1].ToString();
                    tbDiaChi.Text = Dr[2].ToString();
                    tbThemKhachHang.Visible = false;
                    break;

                }

            }
            conn.Close();
            if (kt)
            {
                lbThongBao.Text = "Khách hàng chưa có thông tin";
                tbThemKhachHang.Visible = true;
                tbTenKhachHang.Clear();
                tbDiaChi.Clear();
            }
        }

        private void tbThemKhachHang_Click(object sender, EventArgs e)
        {
            connectSQL();
            string sdtKh = tbSDT.Text.ToString();
            string tenKh = tbTenKhachHang.Text.ToString();
            string diachiKh = tbDiaChi.Text.ToString();
            string sqlthem = "Insert into tb_khachhang values('" + sdtKh + "',N'" + tenKh + "',N'" + diachiKh + "')";
            SqlCommand cmd = new SqlCommand(sqlthem, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Thêm khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void nhanvien()
        {
            string Sql = "select tenNhanVien from tb_nhanvien";
            SqlConnection conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sql, conn);
            SqlDataReader DR = cmd.ExecuteReader();
            while (DR.Read())
            {
                cbNhanVien.Items.Add(DR[0]);

            }
            conn.Close();
        }

        private void btnThemPX_Click(object sender, EventArgs e)
        {
            connectSQL();
            int manv = maNV;
            string sdt = tbSDT.Text;
            string date = datetimeToday.Text;
            string them = "Insert tb_hoadon values ('" + maNV + "','" + sdt + "','" + date + "')";
            SqlCommand cmd = new SqlCommand(them, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Thêm phiếu xuất thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Hienthi_DGView();
        }
        private int maNV;
        private void cbNhanVien_SelectedValueChanged(object sender, EventArgs e)
        {
            string tls = cbNhanVien.Text.ToString();

            string Sql1 = "select maNhanVien from tb_nhanvien where tenNhanVien=N'" + tls + "'";
            SqlConnection conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            SqlCommand cmd1 = new SqlCommand(Sql1, conn);
            SqlDataReader DR2 = cmd1.ExecuteReader();
            while (DR2.Read())
            {
                maNV = Int32.Parse(DR2[0].ToString());

            }
            conn.Close();
        }
        private void dgvPX_CellClick(object sender, DataGridViewCellEventArgs e)
        {   
            tbMaPX.Text = dgvPX.CurrentRow.Cells[1].Value.ToString();
            cbNhanVien.Text = dgvPX.CurrentRow.Cells[2].Value.ToString();
            tbSDT.Text = dgvPX.CurrentRow.Cells["kh"].Value.ToString();
            datetimeToday.Text = dgvPX.CurrentRow.Cells["dt"].Value.ToString();
        }

        private void btnXoaPX_Click(object sender, EventArgs e)
        {
            connectSQL();
            string mmm = tbMaPX.Text;
            if (mmm == "")
            {
                MessageBox.Show("Chưa chọn phiếu xuất cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string delte_cthd = "Delete from tb_chitiethoadon where maHoaDon='" + mmm + "'";
                string delte_hd = "Delete from tb_hoadon where maHoaDon='" + mmm + "'";
                SqlCommand cmd = new SqlCommand(delte_cthd, conn);
                SqlCommand cmd1= new SqlCommand(delte_hd, conn);
                DialogResult Rsulet = MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Rsulet == DialogResult.OK)
                {
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
                    Hienthi_DGView();
                }
            }
            XoaDL();
        }
        private void XoaDL()
        {
            cbNhanVien.ResetText();
            tbSDT.Clear();
            datetimeToday.ResetText();
            Hienthi_DGView();
            tbMaPX.Text = "";
            tbTenKhachHang.Clear();
            tbDiaChi.Clear();
        }

        private void dgvPX_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i = 0; i < dgvPX.RowCount; i++)
            {
                dgvPX.Rows[i].Cells[0].Value = i + 1;
            }
        }


        private void dgvPX_DoubleClick(object sender, EventArgs e)
        {
            showCTPX();
        }


        private void showCTPX()
        {
            chitietPX ctpx = new chitietPX(Int32.Parse(tbMaPX.Text));
            ctpx.ShowDialog();
        }

        private void btnCTPX_Click(object sender, EventArgs e)
        {
            showCTPX();
        }

    }
}
