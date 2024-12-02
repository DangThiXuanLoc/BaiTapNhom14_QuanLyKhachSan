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

namespace WindowsForm
{
    public partial class AddRoomForm : Form
    {
        public AddRoomForm()
        {
            InitializeComponent();
        }

        private void AddRoomForm_Load(object sender, EventArgs e)
        {
            this.LoadDataRoom();
            rdLau1.Checked = true;
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {

            {
                string connectionString = "server=Admin\\SQLEXPRESS;database=QuanLyKhachSan;Integrated Security=True";

                string idPhong = txtIDPhong.Text;
                string soPhong = txtSoPhong.Text;
                string loai = cbbLoai.Text;
                string tinhTrang = txtTinhTrang.Text;
                string giaTien = txtGiaTien.Text;
                string viTri = rdLau1.Checked ? "Lau 1" : (rdLau2.Checked ? "Lau 2" : "");
                string sucChua = txtSucChua.Text;
                string ghiChu = txtGhiChu.Text;

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        string query = "INSERT INTO Phong (IDPhong, SoPhong, Loai, TinhTrang, GiaTien, ViTri, SucChuaToiDa, GhiChu) " +
                                       "VALUES (@IDPhong, @SoPhong, @Loai, @TinhTrang, @GiaTien, @ViTri, @SucChuaToiDa, @GhiChu)";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@IDPhong", idPhong);
                            cmd.Parameters.AddWithValue("@SoPhong", soPhong);
                            cmd.Parameters.AddWithValue("@Loai", loai);
                            cmd.Parameters.AddWithValue("@TinhTrang", tinhTrang);
                            cmd.Parameters.AddWithValue("@GiaTien", giaTien);
                            cmd.Parameters.AddWithValue("@ViTri", viTri);
                            cmd.Parameters.AddWithValue("@SucChuaToiDa", sucChua);
                            cmd.Parameters.AddWithValue("@GhiChu", ghiChu);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Room added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Failed to add room. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void LoadDataRoom()
        {
            string connectionString = "server=Admin\\SQLEXPRESS;database=QuanLyKhachSan;Integrated Security=True";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"SELECT a.IDPhong, a.SoPhong, b.TenLoai, a.TinhTrang, a.GiaTien, a.ViTri, a.SucChuaToiDa, a.GhiChu 
                                FROM Phong a,LoaiPhong b
                                WHERE a.Loai=b.IDLoai";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader re = cmd.ExecuteReader())
                        {
                            lvListRoom.Items.Clear();

                            while (re.Read())
                            {
                                ListViewItem item = new ListViewItem(re["IDPhong"].ToString());
                                item.SubItems.Add(re["SoPhong"].ToString());
                                item.SubItems.Add(re["TenLoai"].ToString());
                                item.SubItems.Add(re["TinhTrang"].ToString());
                                item.SubItems.Add(re["GiaTien"].ToString());
                                item.SubItems.Add(re["ViTri"].ToString());
                                item.SubItems.Add(re["SucChuaToiDa"].ToString());
                                item.SubItems.Add(re["GhiChu"].ToString());
                                lvListRoom.Items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading data. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lvListRoom_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lvListRoom.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvListRoom.SelectedItems[0];

                txtIDPhong.Text = selectedItem.SubItems[0].Text;
                txtSoPhong.Text = selectedItem.SubItems[1].Text;
                cbbLoai.Text = selectedItem.SubItems[2].Text;
                txtTinhTrang.Text = selectedItem.SubItems[3].Text;
                txtGiaTien.Text = selectedItem.SubItems[4].Text;

                // Set radio buttons based on the floor value
                string floor = selectedItem.SubItems[5].Text;
                if (floor == "Lau 1")
                {
                    rdLau1.Checked = true;
                }
                else if (floor == "Lau 2")
                {
                    rdLau2.Checked = true;
                }

                txtSucChua.Text = selectedItem.SubItems[6].Text;
                txtGhiChu.Text = selectedItem.SubItems[7].Text;

                // Example for ComboBox
                cbbLoai.SelectedItem = selectedItem.SubItems[2].Text;
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
