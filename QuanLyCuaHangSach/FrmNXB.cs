using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Windows;
namespace QuanLyCuaHangSach
{
    public partial class FrmNXB : Form
    {
        public FrmNXB()
        {
            InitializeComponent();
        }

        private void FrmNXB_Load(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            LoadDataToGrivew();
            fillDataToCombo();
            DAO.CloseConnetion();
        }
        private void LoadDataToGrivew()
        {

            try
            {
                DAO.OpenConnection();
                string sql = "select * from NhaXuatBan";
                SqlDataAdapter myAdapter = new SqlDataAdapter(sql, DAO.conn);
                DataTable NhaXuatBan = new DataTable();
                myAdapter.Fill(NhaXuatBan);
                dataGridView1.DataSource = NhaXuatBan;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DAO.CloseConnetion();
            }

        }
        public void fillDataToCombo()
        {
            string sql = "Select * from NhaXuatBan";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cmbNXB.DataSource = table;
            cmbNXB.ValueMember = "MaNXB";
            cmbNXB.DisplayMember = "TenNXB";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cmbNXB.Text = dataGridView1.CurrentRow.Cells["MaNSX"].Value.ToString();
            txtNXB.Text = dataGridView1.CurrentRow.Cells["TenNXB"].Value.ToString();
            txtdiachi.Text = dataGridView1.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtsdt.Text = dataGridView1.CurrentRow.Cells["DienThoai"].Value.ToString();
            cmbNXB.Enabled = false;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            cmbNXB.SelectedIndex = -1;
            txtNXB.Text = "";
            txtdiachi.Text = "";
            txtsdt.Text = "";
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if (cmbNXB.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn mã nhà sản xuất");
                return;
            }
            if (txtNXB.Text == "")
            {
                MessageBox.Show("Bạn không được để trống nhà xuất bản");
                txtNXB.Focus();
                return;
            }

            
            if (txtdiachi.Text == "")
            {
                MessageBox.Show("Bạn không được để trống địa chỉ");
                txtdiachi.Focus();
                return;
            }
            if (txtsdt.Text == "")
            {
                MessageBox.Show("Bạn không được để trống số điện thoại");
                txtsdt.Focus();
                return;
            }
            

            // - Mã nhà xuất bản ko được trùng
            string sql = "select * from NhaXuatBan where MaNXB = '" +
            cmbNXB.SelectedValue.ToString() + "'";
            DAO.OpenConnection();
            if (DAO.checkKeyExit(sql))
            {
                MessageBox.Show("mã nhà xuất bản đã tồn tại");
                cmbNXB.Focus();
                DAO.CloseConnetion();
                return;
            }
            else
            {
                sql = "insert into  MatSach (MaNXB, TenNXB,  " +
                    "DiaChi, DienThoai)" +
                    " values ('" + cmbNXB.SelectedValue.ToString() + "'" +
                    ",N'"+ txtNXB.Text + "," +
                    txtdiachi.Text.Trim() + "," + txtsdt.Text.Trim() + ",)";

                SqlCommand cmd = new SqlCommand(sql, DAO.conn);

                MessageBox.Show(sql);

                cmd.ExecuteNonQuery();
                LoadDataToGrivew();
                fillDataToCombo();
                DAO.CloseConnetion();

            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string Sql = "Update NhaXuatBan set MaNXB, tenNXB,DiaChi, SoDienThoai = N'" + cmbNXB.SelectedValue.ToString() + "', N'" + txtNXB.Text.Trim() + "',N'" + txtdiachi.Text.Trim() + "',N'" + txtsdt.Text.Trim() +
                      "' where MaNXB = '" + cmbNXB.SelectedValue + "'";
           
            DAO.OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = Sql;
            cmd.Connection = DAO.conn;
            cmd.ExecuteNonQuery();
            DAO.CloseConnetion();
            LoadDataToGrivew();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sql = "delete from NhaXuatBan where MaNXB = '" + cmbNXB.SelectedValue + "'";
            SqlCommand cmd = new SqlCommand();
            DAO.OpenConnection();
            cmd.CommandText = sql;
            cmd.Connection = DAO.conn;
            cmd.ExecuteNonQuery();
            DAO.CloseConnetion();
            LoadDataToGrivew();
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            if (cmbNXB.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một nhà xuất bản dể tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbNXB.Focus();
                return;
            }
            txtNXB.Text = cmbNXB.Text;
            LoadDataToGrivew();
            btnluu.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            cmbNXB.SelectedIndex = -1;
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

