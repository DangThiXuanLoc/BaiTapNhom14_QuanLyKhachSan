using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsForm
{
    public partial class KhachHang : Form
    {
        public KhachHang()
        {
            InitializeComponent();
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            AddColumnsToDataGridView();
            this.LoadKhachHangData();
        }
        private void AddColumnsToDataGridView()
        {
            // Tạo cột checkbox để chọn khách hàng trong DataGridView
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "Select";
            checkColumn.HeaderText = "";
            dgvKhachHang.Columns.Add(checkColumn);
        }
        private void LoadKhachHangData()
        {
            dgvKhachHang.Columns.Clear();
            AddColumnsToDataGridView();
            string connectionString = "server=Admin\\SQLEXPRESS;database=QuanLyKhachSan;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM KhachHang";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
           
            conn.Open();
            adapter.Fill(dt);
            conn.Close();
            conn.Dispose();
            dgvKhachHang.DataSource=dt;
            dgvKhachHang.CellClick += dgvKhachHang_CellClick;

        }
        public void DisplayCustomerInfo(DataRowView rowView)
        {
            try
            {
                txtIDKH.Text = rowView["IDKhachHang"] != DBNull.Value ? rowView["IDKhachHang"].ToString() : "";
                txtSoCCCD.Text = rowView["SoCCCD"].ToString();
                txtHoTen.Text = rowView["HoTenKH"].ToString();
                txtDiaChi.Text = rowView["DiaChiKH"].ToString();
                mktbSoDT.Text = rowView["SoDT"].ToString();
                if (DateTime.TryParse(rowView["NgayVao"].ToString(), out DateTime ngayVao))
                {
                    dtpNgayVao.Value = ngayVao;
                }
                else
                {
                    dtpNgayVao.Value = DateTime.Now;  // Gán giá trị mặc định nếu không hợp lệ
                }

                // Xử lý ngày ra
                if (DateTime.TryParse(rowView["NgayRa"].ToString(), out DateTime ngayRa))
                {
                    dtpNgayRa.Value = ngayRa;
                }
                else
                {
                    dtpNgayRa.Value = DateTime.Now;  // Gán giá trị mặc định nếu không hợp lệ
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
                DataRowView rowView = (DataRowView)row.DataBoundItem;
                DisplayCustomerInfo(rowView);
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoCCCD.Text) ||
                string.IsNullOrEmpty(txtHoTen.Text) ||
                string.IsNullOrEmpty(txtDiaChi.Text) ||
                string.IsNullOrEmpty(mktbSoDT.Text))
            {
                MessageBox.Show("Chưa nhập dữ liệu cho các ô, vui lòng nhập lại!", 
                                "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra định dạng số CCCD (12 chữ số)
            string pattern = @"^\d{12}$"; // Định dạng 12 chữ số
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(txtSoCCCD.Text.Trim()))
            {
                MessageBox.Show("Số CCCD không đúng định dạng. Vui lòng nhập lại 12 chữ số.", 
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoCCCD.Focus();
                return;
            }

            string connectionString = "server=Admin\\SQLEXPRESS;database=QuanLyKhachSan;Integrated Security=True";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Kiểm tra số CCCD có trùng không
                    string checkQuery = "SELECT COUNT(*) FROM KhachHang WHERE soCCCD = @soCCCD";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.Add("@soCCCD", SqlDbType.VarChar, 20).Value = txtSoCCCD.Text.Trim();
                        int count = (int)checkCmd.ExecuteScalar(); // Trả về số lượng bản ghi có cùng số CCCD

                        if (count > 0) // Nếu số CCCD đã tồn tại
                        {
                            MessageBox.Show(
                                "Số CCCD này đã tồn tại. Vui lòng nhập số khác.",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                            return; // Dừng không thêm mới
                        }
                    }

                    // Thực hiện thêm mới nếu không trùng
                    string query = @"INSERT INTO KhachHang (HoTenKH,SoCCCD, DiaChiKH , SoDT, NgayVao, NgayRa)
                                    OUTPUT INSERTED.iDKhachHang
                                    VALUES (@hoTenKH, @soCCCD, @diaChiKH,@soDT, @ngayVao, @ngayRa)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Thêm các tham số với kiểu dữ liệu và giá trị tương ứng
                        cmd.Parameters.Add("@soCCCD", SqlDbType.VarChar, 20).Value = txtSoCCCD.Text.Trim();
                        cmd.Parameters.Add("@hoTenKH", SqlDbType.NVarChar, 30).Value = txtHoTen.Text.Trim();
                        cmd.Parameters.Add("@soDT", SqlDbType.VarChar, 12).Value = mktbSoDT.Text.Trim();
                        cmd.Parameters.Add("@diaChiKH", SqlDbType.VarChar, 50).Value = txtDiaChi.Text.Trim();
                        cmd.Parameters.Add("@ngayVao", SqlDbType.DateTime).Value = dtpNgayVao.Value;
                        cmd.Parameters.Add("@ngayRa", SqlDbType.DateTime).Value =
                            dtpNgayRa.Checked ? (object)dtpNgayRa.Value : DBNull.Value;

                        // Thực thi câu lệnh và lấy giá trị ID của khách hàng vừa được thêm
                        object insertedID = cmd.ExecuteScalar();

                        // Hiển thị thông báo thành công hoặc thất bại
                        if (insertedID != null)
                        {
                            MessageBox.Show(
                                $"Successfully added new KhachHang, KhachHang ID = {insertedID}",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                            this.LoadKhachHangData();
                        }
                        else
                        {
                            MessageBox.Show("Adding KhachHang failed. No rows were affected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
                
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMacDinh_Click(object sender, EventArgs e)
        {
            txtIDKH.ResetText();
            txtSoCCCD.ResetText();
            txtHoTen.ResetText();
            txtDiaChi.ResetText();
            mktbSoDT.ResetText();
            dtpNgayVao.Value = DateTime.Now;
            dtpNgayRa.Value = DateTime.Now;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            List<int> selectedIds = new List<int>(); // Danh sách để lưu trữ ID khách hàng được chọn

            // Kiểm tra xem có khách hàng nào được chọn để xóa không
            foreach (DataGridViewRow row in dgvKhachHang.Rows)
            {
                // Kiểm tra nếu checkbox trong cột "Select" được chọn
                if (Convert.ToBoolean(row.Cells["Select"].Value))
                {
                    // Lấy ID khách hàng từ cột "ID"
                    int id = Convert.ToInt32(row.Cells["IDKhachHang"].Value);
                    selectedIds.Add(id); // Thêm ID vào danh sách
                }
            }

            // Kiểm tra nếu không có khách hàng nào được chọn
            if (selectedIds.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một khách hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận xóa
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa các khách hàng đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                DeleteCustomers(selectedIds); // Gọi phương thức xóa khách hàng
            }
        }
        private void DeleteCustomers(List<int> customerIds)
        {
            string connectionString = "server=Admin\\SQLEXPRESS;database=QuanLyKhachSan;Integrated Security=True";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Tạo câu lệnh SQL để xóa nhiều khách hàng
                    string query = "DELETE FROM KhachHang WHERE iDKhachHang IN (@customerIds)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Chuyển danh sách ID thành một chuỗi các ID cách nhau bởi dấu phẩy
                        var idsParam = string.Join(",", customerIds);
                        cmd.Parameters.Add("@customerIds", SqlDbType.VarChar).Value = idsParam;

                        int rowsAffected = cmd.ExecuteNonQuery(); // Thực thi câu lệnh xóa

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Đã xóa thành công " + rowsAffected + " khách hàng.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Reload lại dữ liệu sau khi xóa
                            LoadKhachHangData();
                        }
                        else
                        {
                            MessageBox.Show("Không có khách hàng nào được xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
    }
}
