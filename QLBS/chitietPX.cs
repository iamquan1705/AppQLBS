using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QLBS
{
    public partial class chitietPX : Form
    {
        string chuoiketnoi = @"Data Source=21AK22-COM;Initial Catalog=QUANLYBANSACH;Integrated Security=True";
        SqlConnection conn;
        private int mapx;
        public chitietPX(int mapx)
        {
            InitializeComponent();
            tongKho();
            this.mapx = mapx;
            hienthiTenSach();
            lbTiltle.Text = "Chi tiết phiếu xuất " + mapx;
            Hienthi_DGView();

        }


        private void Hienthi_DGView()
        {
            conn = new SqlConnection(chuoiketnoi);
            //Mở kết nối =>open()
            conn.Open();
            String chitietPN = "SELECT tb_sach.tenSach,chitiethoadon.soLuongBan, tb_sach.giaSach FROM chitiethoadon INNER JOIN tb_sach ON tb_sach.maSach=chitiethoadon.maSach where maHoaDon ='" + this.mapx + "'";
            SqlDataAdapter Mydata1 = new SqlDataAdapter(chitietPN, conn);
            DataTable dt = new DataTable(); //tạo 1 bảng           
            Mydata1.Fill(dt);
            dgvCTPX.DataSource = dt;
            conn.Close();
            tinhTongTien();
            xoaDl();

        }


        private void xoaDl()
        {
            lbgia.Text = "";
            numCount.ResetText();
            cbbTenSach.ResetText();
            tbMaPX.Clear();
            tbSLSTK.Clear();
        }


        private void connectSQL()
        {
            conn = new SqlConnection(chuoiketnoi);
            //Mở kết nối =>open()
            conn.Open();

        }

        private void hienthiTenSach()
        {
            string Sql = "select tenSach from tb_sach";
            connectSQL();
            SqlCommand cmd = new SqlCommand(Sql, conn);
            SqlDataReader DR = cmd.ExecuteReader();
            while (DR.Read())
            {
                cbbTenSach.Items.Add(DR[0]);

            }
            conn.Close();
        }


        private int maSACH;
        private void cbbTenSach_SelectedValueChanged(object sender, EventArgs e)
        {
            string tls = cbbTenSach.Text.ToString();
            string SqlMS = "select maSach,giaSach from tb_sach where tenSach=N'" + tls + "'";
            SqlConnection conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            SqlCommand cmd = new SqlCommand(SqlMS, conn);
            SqlDataReader DR = cmd.ExecuteReader();
            while (DR.Read())
            {
                maSACH = Int32.Parse(DR[0].ToString());
                lbgia.Text = DR[1].ToString();

            }
            conn.Close();
            tongKho();
        }
         

        private void tinhTongTien()
        {
            int tongtien = 0;
            if (dgvCTPX.Rows.Count < 2)
            {
                lbTongTien.Text = "0";
            }
            else
            {
                for (int i = 0; i < dgvCTPX.Rows.Count - 1; i++)
                {
                    tongtien += Int32.Parse(dgvCTPX.Rows[i].Cells["giaSach"].Value.ToString()) * Int32.Parse(dgvCTPX.Rows[i].Cells["soLuongBan"].Value.ToString());
                }
            }
            lbTongTien.Text = tongtien.ToString();
        }

        private khoManager mgnKho = new khoManager();
        private void tongKho()
        {
            connectSQL();
            string sql_tongnhap = "Select tb_sach.tenSach, SUM(soLuongNhap) from tb_sach  INNER JOIN tb_ctphieunhap on tb_sach.maSach = tb_ctphieunhap.maSach GROUP BY tb_sach.tenSach ";
            SqlCommand cmd1 = new SqlCommand(sql_tongnhap, conn);
            SqlDataReader DR = cmd1.ExecuteReader();

            while (DR.Read())
            {
                mgnKho.addKho(new khosach(DR[0].ToString(), Int32.Parse(DR[1].ToString())));

            }
            conn.Close();
            connectSQL();
            string sql_tongban = "select tb_sach.tenSach , sum(soLuongBan) from tb_sach, chitiethoadon where tb_sach.maSach = chitiethoadon.maSach group by tb_sach.tenSach ";
            SqlCommand cmd2 = new SqlCommand(sql_tongban, conn);
            SqlDataReader DR2 = cmd2.ExecuteReader();

            while (DR2.Read())
            {
                mgnKho.editKho(new khosach(DR2[0].ToString(), 0, Int32.Parse(DR2[1].ToString())));

            }
            conn.Close();

            tbSLSTK.Text = (mgnKho.timkiem(cbbTenSach.Text)).ToString();
            


        }


        private void numCount_ValueChanged(object sender, EventArgs e)
        {
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            if (numCount.Value < Int32.Parse(tbSLSTK.Text))
            {
                updates(Int32.Parse(numCount.Value.ToString()));
            } else
            {
                MessageBox.Show("Số lượng sách trong kho không đủ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            tongKho();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            connectSQL();
            if (cbbTenSach.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn tên sách cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string sql_xoaCTPN = "DELETE FROM chitiethoadon where maSach='" + maSACH + "'";
                SqlCommand cmd = new SqlCommand(sql_xoaCTPN, conn);

                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Hienthi_DGView();
            }
            tongKho();
        }

        private void dgvCTPX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbbTenSach.Text = dgvCTPX.CurrentRow.Cells["tenSach"].Value.ToString();
            lbgia.Text = dgvCTPX.CurrentRow.Cells["giaSach"].Value.ToString();
            numCount.Value = Int32.Parse(dgvCTPX.CurrentRow.Cells["soLuongBan"].Value.ToString());
        }
        private void updates(int them)
        {
            connectSQL();
            int ms = maSACH;
            int sl = Int32.Parse(numCount.Value.ToString());
            int gn = Int32.Parse(lbgia.Text);
            string tsach = cbbTenSach.Text;
            if (dgvCTPX.Rows.Count < 1)
            {
                string themmoi = "Insert chitiethoadon values ('" + mapx + "','" + ms + "','" + sl+"')";
                SqlCommand cmd = new SqlCommand(themmoi, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int kt = 0;

                for (int i = 0; i < dgvCTPX.Rows.Count - 1; i++)
                {
                    int sll = Int32.Parse(dgvCTPX.Rows[i].Cells["soLuongBan"].Value.ToString()) + them;
                    if (dgvCTPX.Rows[i].Cells["tenSach"].Value.Equals(tsach))
                    {
                        kt = 1;
                        string updateSach = "Update chitiethoadon set soLuongBan='" + sll + "' where maSach='" + ms + "'";
                        SqlCommand cmd1 = new SqlCommand(updateSach, conn);
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        conn.Close();

                    }
                }

                if (kt == 0)
                {
                    string themmoi = "Insert chitiethoadon values ('" + mapx + "','" + ms + "','" + sl+"')";
                    SqlCommand cmd2 = new SqlCommand(themmoi, conn);
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            Hienthi_DGView();
            xoaDl();
        }
        private void btInHD_Click(object sender, EventArgs e)
        {
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            connectSQL();
            string updateSach = "Update chitiethoadon set soLuongBan='" + numCount.Value + "' where maSach='" + maSACH + "'";
            SqlCommand cmd1 = new SqlCommand(updateSach, conn);
            DialogResult Rsulet = MessageBox.Show("Bạn có chắc chắn muốn sửa không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (Rsulet == DialogResult.OK)
            {
                cmd1.ExecuteNonQuery();
                Hienthi_DGView();
            }


            conn.Close();
        }

    }
}