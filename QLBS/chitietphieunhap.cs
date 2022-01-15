using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QLBS
{
    public partial class chitietphieunhap : Form
    {
        string chuoiketnoi = @"Data Source=21AK22-COM;Initial Catalog=QUANLYBANSACH;Integrated Security=True";
        SqlConnection conn;
        private int maSACH;
        private int mapn;
        public chitietphieunhap(int mapn)
        {
            InitializeComponent();
            this.mapn = mapn;
        }
        public string temp;
        private void chitietphieunhap_Load(object sender, EventArgs e)
        {
            lbTiltle.Text = "Chi tiết phiếu nhâp " + mapn;
            Hienthi_DGView();
            cbtenSach();
           
        }

        private void Hienthi_DGView()
        {
           conn = new SqlConnection(chuoiketnoi);
            //Mở kết nối =>open()
           conn.Open();
           String chitietPN = "SELECT tb_sach.tenSach,tb_ctphieunhap.soLuongNhap, tb_ctphieunhap.giaNhap FROM tb_ctphieunhap INNER JOIN tb_sach ON tb_sach.maSach=tb_ctphieunhap.maSach where maPhieuNhap ='"+this.mapn+"'";
           SqlDataAdapter Mydata1 = new SqlDataAdapter(chitietPN, conn);         
           DataTable dt = new DataTable(); //tạo 1 bảng           
           Mydata1.Fill(dt);
           dgvCTPN.DataSource = dt;
            conn.Close();
            tinhTongTien();
            xoaDl();

        }

        private void dgvCTPN_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i = 0; i < dgvCTPN.RowCount; i++)
            {
                dgvCTPN.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void connectSQL()
        {
            conn = new SqlConnection(chuoiketnoi);
            //Mở kết nối =>open()
            conn.Open();

        }


        private void cbtenSach()
        {
            string Sql = "select tenSach from tb_sach";
            SqlConnection conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sql, conn);
            SqlDataReader DR = cmd.ExecuteReader();
            while (DR.Read())
            {
                cbbTenSach.Items.Add(DR[0]);

            }
            conn.Close();
        }
        
        private void cbbTenSach_SelectedValueChanged(object sender, EventArgs e)
        {
            string tls = cbbTenSach.Text.ToString();
            string SqlMS = "select maSach from tb_sach where tenSach=N'" + tls + "'";
            SqlConnection conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            SqlCommand cmd = new SqlCommand(SqlMS, conn);
            SqlDataReader DR = cmd.ExecuteReader();
            while (DR.Read())
            {
                maSACH = Int32.Parse(DR[0].ToString());

            }
            conn.Close();
            tbgianhap();
        }

        private void tbgianhap()
        {

            int gs = 0;
            string Sql_gs = "select giaSach from tb_sach where tenSach=N'" + cbbTenSach.Text + "'";
            SqlConnection conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sql_gs, conn);
            SqlDataReader DR = cmd.ExecuteReader();
            while (DR.Read())
            {
                gs = Int32.Parse(DR[0].ToString());

            }
            int ck = 0;
            string sql_ck = "select tb_nhacungcap.chietKhau from tb_nhacungcap INNER JOIN tb_phieunhap ON tb_nhacungcap.maNhaCungCap=tb_phieunhap.maNhaCungCap and tb_phieunhap.maPhieuNhap='" + mapn + "' ";
            SqlConnection conn1 = new SqlConnection(chuoiketnoi);
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand(sql_ck, conn1);
            SqlDataReader DR1 = cmd1.ExecuteReader();
            while (DR1.Read())
            {
                ck = Int32.Parse(DR1[0].ToString());

            }
            conn1.Close();
            tbGiaNhap.Text = ((gs * (100 - ck)) / 100).ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            connectSQL();
            /*    int ms = maSACH;
                int sl = Int32.Parse( nbupSL.Value.ToString());
                int gn = Int32.Parse(tbGiaNhap.Text);
                string them = "Insert tb_ctphieunhap values ('" + mapn + "','" + ms + "','" + sl + "','" + gn + "')";
                SqlCommand cmd = new SqlCommand(them, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Thêm phiếu nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);*/
            updates(Int32.Parse( nbupSL.Value.ToString()));
            Hienthi_DGView();
           
        }

        private void tinhTongTien()
        {
            int tongtien=0;
            if (dgvCTPN.Rows.Count<2)
            {
                lbTongTien.Text = "0";
            } else
            {
                for (int i=0;i<dgvCTPN.Rows.Count-1;i++)
                {
                    tongtien += Int32.Parse(dgvCTPN.Rows[i].Cells["giaNhap"].Value.ToString()) * Int32.Parse(dgvCTPN.Rows[i].Cells["soLuongNhap"].Value.ToString());
                }
            }
            lbTongTien.Text = tongtien.ToString();
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
                string sql_xoaCTPN = "DELETE FROM tb_ctphieunhap where maSach='" + maSACH + "'";
                SqlCommand cmd = new SqlCommand(sql_xoaCTPN, conn);

                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Hienthi_DGView();
            }
        }

        private void dgvCTPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbbTenSach.Text = dgvCTPN.CurrentRow.Cells["tenSach"].Value.ToString();
            tbGiaNhap.Text = dgvCTPN.CurrentRow.Cells["giaNhap"].Value.ToString();
            nbupSL.Value = Int32.Parse(dgvCTPN.CurrentRow.Cells["soLuongNhap"].Value.ToString());
        }   

        private void updates(int them)
        {
            connectSQL();
            int ms = maSACH;
            int sl = Int32.Parse(nbupSL.Value.ToString());
            int gn = Int32.Parse(tbGiaNhap.Text);
            string tsach = cbbTenSach.Text;
            if (dgvCTPN.Rows.Count<1)
            {
                string themmoi = "Insert tb_ctphieunhap values ('" + mapn + "','" + ms + "','" + sl + "','" + gn + "')";
                SqlCommand cmd = new SqlCommand(themmoi, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                int kt = 0;
                
                for (int i=0;i<dgvCTPN.Rows.Count-1;i++)
                {
                    int sll = Int32.Parse( dgvCTPN.Rows[i].Cells["soLuongNhap"].Value.ToString() )+ them;
                    if (dgvCTPN.Rows[i].Cells["tenSach"].Value.Equals(tsach)) {
                        kt = 1;
                        string updateSach = "Update tb_ctphieunhap set soLuongNhap='" + sll + "' where maSach='"+ ms + "'";
                        SqlCommand cmd1 = new SqlCommand(updateSach, conn);
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                        conn.Close();
                        
                    }
                }

                if (kt==0)
                {
                    string themmoi = "Insert tb_ctphieunhap values ('" + mapn + "','" + ms + "','" + sl + "','" + gn + "')";
                    SqlCommand cmd2 = new SqlCommand(themmoi, conn);
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void xoaDl()
        {
            cbbTenSach.ResetText();
            tbGiaNhap.Clear();
            nbupSL.ResetText();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            connectSQL();
            string updateSach = "Update tb_ctphieunhap set soLuongNhap='" + nbupSL.Value + "' where maSach='" + maSACH + "'";
            SqlCommand cmd1 = new SqlCommand(updateSach, conn);
            DialogResult Rsulet = MessageBox.Show("Bạn có chắc chắn muốn sửa không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (Rsulet == DialogResult.OK)
            {
                cmd1.ExecuteNonQuery();
                Hienthi_DGView();
            }
            

            conn.Close();
        }

        private void btInHoaDon_Click(object sender, EventArgs e)
        {
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
