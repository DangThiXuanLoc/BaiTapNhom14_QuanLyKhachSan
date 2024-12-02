using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsForm
{

    public partial class MainForm : Form
    {

        DataTable table;
        private ToolTip toolTip = new ToolTip();
        private string userTenTK;
        private bool isManager;
        private string tenTK;
        public MainForm()
        {
            InitializeComponent();
        }
        public MainForm(string tenTK, bool isManager)
        {
            InitializeComponent(); userTenTK = tenTK;
            this.isManager = isManager;
            AdjustUIBasedOnRole();
        }
        private void AdjustUIBasedOnRole()
        {
            toolStripButton2.Enabled = isManager;
            toolStripSplitButton2.Enabled = isManager;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.LoadRoomStatus();
            this.LoadKhachHang();
            this.LoadNhanVien();
        }

        private void LoadKhachHang()
        {

            try
            {
                string connectionString = "server=Admin\\SQLEXPRESS;Database=QuanLyKhachSan;Integrated Security=True;";
                SqlConnection conn = new SqlConnection(connectionString);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                string query = @"SELECT IDKhachHang, HoTenKh  FROM KhachHang ";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader re = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(re);

                cbbTenKH.DisplayMember = "HoTenKh";
                cbbTenKH.ValueMember = "IDKhachHang";
                cbbTenKH.DataSource = dt;

                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadNhanVien()
        {
            if (cbbTenKH.SelectedIndex == -1) return;
            string connectionString = "server=Admin\\SQLEXPRESS;Database=QuanLyKhachSan;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT IDNhanVien,HoTenNV FROM NhanVien";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            conn.Open();
            adapter.Fill(dt);
            conn.Close();
            conn.Dispose();
            cbbTenNV.DataSource = dt;
            cbbTenNV.DisplayMember = "HoTenNV";
            cbbTenNV.ValueMember = "IDNhanVien";
        }
        private void LoadRoomStatus()
        {

            string connectionString = "server=Admin\\SQLEXPRESS;database=QuanLyKhachSan;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT a.SoPhong, a.TinhTrang, a.GiaTien, a.GhiChu, a.ViTri,
                                       c.HoTenKH, d.NgayVao, d.NgayRa
                                FROM Phong a
                                LEFT JOIN CT_HoaDon b ON a.IDPhong = b.IDPhong
                                LEFT JOIN HoaDon d ON b.IDHoaDon = d.IDHoaDon
                                LEFT JOIN KhachHang c ON d.IDKhachHang = c.IDKhachHang;";
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {


                while (reader.Read())
                {

                    string roomNumber = reader["SoPhong"]?.ToString();
                    string status = reader["TinhTrang"]?.ToString();
                    string price = reader["GiaTien"]?.ToString();
                    string notes = reader["GhiChu"]?.ToString();
                    string vt = reader["ViTri"]?.ToString();
                    string customerName = reader["HoTenKH"]?.ToString();
                    string checkInDate = reader["NgayVao"] != DBNull.Value ? Convert.ToDateTime(reader["NgayVao"]).ToString("dd/MM/yyyy") : "N/A";
                    string checkOutDate = reader["NgayRa"] != DBNull.Value ? Convert.ToDateTime(reader["NgayRa"]).ToString("dd/MM/yyyy") : "N/A";

                    Button button = FindControlRecursive(this, "btn" + roomNumber) as Button;
                    button.Tag = roomNumber;
                    button.Click += BtnRoom_Click;
                    string toolTipText = $"Phòng: {roomNumber}\nTrạng thái: {status}\nGiá tiền: {price} đ\nGhi chú: {notes}\nVị trí: {vt}";
                    if (button != null)
                    {
                        switch (status)
                        {
                            case "Trống":
                                button.BackColor = Color.LawnGreen;
                                toolTip.SetToolTip(button, toolTipText);
                                rdTrong.Checked = true;
                                break;
                            case "Đang thuê":
                                button.BackColor = Color.Red;
                                toolTip.SetToolTip(button, toolTipText + $"\nKhách hàng: {customerName}\nNgày vào: {checkInDate}\nNgày ra: {checkOutDate}");
                                rdDangThue.Checked = true;
                                break;
                            case "Đã đặt":
                                button.BackColor = Color.Yellow;
                                toolTip.SetToolTip(button, toolTipText + $"\nKhách hàng: {customerName}\nNgày vào: {checkInDate}\nNgày ra: {checkOutDate}");
                                rdDat.Checked = true;
                                break;
                            case "Chưa dọn dẹp":
                                button.BackColor = Color.Fuchsia;
                                toolTip.SetToolTip(button, toolTipText);
                                rdChuaDonDep.Checked = true;
                                break;
                            case "Đang sữa chữa":
                                button.BackColor = Color.Blue;
                                toolTip.SetToolTip(button, toolTipText);
                                rdDangSuaChua.Checked = true;
                                break;
                            default:
                                break;
                        }
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private string GetStatusFromButton(Button btn)
        {

            if (btn.BackColor == Color.LawnGreen)
            {
                return "Trống";
            }
            else if (btn.BackColor == Color.Red)
            {
                return "Đang thuê";
            }
            else if (btn.BackColor == Color.Yellow)
            {
                return "Đã đặt";
            }
            else if (btn.BackColor == Color.Fuchsia)
            {
                return "Chưa dọn dẹp";
            }
            else if (btn.BackColor == Color.Blue)
            {
                return "Đang sữa chữa";
            }
            return "Unknown";
        }
        // Phương thức tìm button theo tên
        private Control FindControlRecursive(Control parent, string controlName)
        {
            foreach (Control child in parent.Controls)
            {
                if (child.Name == controlName)
                    return child;

                Control result = FindControlRecursive(child, controlName);
                if (result != null)
                    return result;
            }
            return null;
        }
        private void BtnRoom_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string roomNumber = clickedButton.Tag.ToString();
            // Load room details based on the room number
            string status = LoadRoomDetails(roomNumber);
            if (string.IsNullOrEmpty(status))
            {
                MessageBox.Show("Không tìm thấy thông tin trạng thái phòng!");
                return;
            }
            status = GetStatusFromButton(clickedButton); // Hàm lấy trạng thái từ màu sắc hoặc thuộc tính khác của button
            switch (status)
            {
                case "Trống":
                    rdTrong.Checked = true;
                    clickedButton.ContextMenuStrip = cmsTrong;
                    break;
                case "Đang thuê":
                    rdDangThue.Checked = true;
                    clickedButton.ContextMenuStrip = cmsDangThue;
                    break;
                case "Đã đặt":
                    rdDat.Checked = true;
                    clickedButton.ContextMenuStrip = cmsDaDat;
                    break;
                case "Chưa dọn dẹp":
                    rdChuaDonDep.Checked = true;
                    clickedButton.ContextMenuStrip = cmsChuaDonDep;
                    break;
                case "Đang sữa chữa":
                    rdDangSuaChua.Checked = true;
                    clickedButton.ContextMenuStrip = cmsDangSuaChua;
                    break;
                default:
                    MessageBox.Show("Trạng thái không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }
        private string LoadRoomDetails(string roomNumber)
        {
            string connectionString = "server=Admin\\SQLEXPRESS;database=QuanLyKhachSan;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"SELECT c.SoCCCD, c.HoTenKH, c.SoDT, g.HoTenNV, a.SoPhong, e.TenLoai, 
                            a.GiaTien, d.NgayVao, d.NgayRa, d.TongTien, d.PhuThu, d.GiamGia, d.ThueVAT, 
                            d.GhiChu, DATEDIFF(DAY, d.NgayVao, d.NgayRa) AS SoNgay, d.SoNguoi, 
                            ISNULL(a.ViTri, '') AS TangLau  
                     FROM Phong a
                     LEFT JOIN CT_HoaDon b ON a.IDPhong = b.IDPhong
                     LEFT JOIN HoaDon d ON b.IDHoaDon = d.IDHoaDon
                     LEFT JOIN KhachHang c ON d.IDKhachHang = c.IDKhachHang
                     LEFT JOIN LoaiPhong e ON a.Loai = e.IDLoai
                     LEFT JOIN NhanVien g ON d.IDNhanVien = g.IDNhanVien
                     WHERE SoPhong=@SoPhong";
                cmd.Parameters.AddWithValue("@SoPhong", roomNumber);

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (reader["SoPhong"] == DBNull.Value)
                            {
                                ClearCustomerDetails();
                            }
                            else
                            {
                                txtSoCCCD.Text = reader["SoCCCD"]?.ToString() ?? string.Empty;
                                cbbTenKH.Text = reader["HoTenKH"]?.ToString() ?? string.Empty;
                                mtxtSoDT.Text = reader["SoDT"]?.ToString() ?? string.Empty;
                                cbbTenNV.Text = reader["HoTenNV"]?.ToString() ?? string.Empty;
                                txtSoPhong.Text = reader["SoPhong"]?.ToString() ?? string.Empty;
                                txtLoaiPhong.Text = reader["TenLoai"]?.ToString() ?? string.Empty;
                                dtpNgayNhanPhong.Value = reader["NgayVao"] != DBNull.Value ? Convert.ToDateTime(reader["NgayVao"]) : DateTime.Now;
                                dtpNgayTraPhong.Value = reader["NgayRa"] != DBNull.Value ? Convert.ToDateTime(reader["NgayRa"]) : DateTime.Now;
                                txtSoNgay.Text = reader["SoNgay"]?.ToString() ?? string.Empty;
                                txtSoNguoi.Text = reader["SoNguoi"]?.ToString() ?? string.Empty;
                                txtGiaTien.Text = reader["GiaTien"]?.ToString() ?? string.Empty;
                                txtPhuThu.Text = reader["PhuThu"]?.ToString() ?? string.Empty;
                                txtThueVAT.Text = reader["ThueVAT"]?.ToString() ?? string.Empty;
                                txtGiamGia.Text = reader["GiamGia"]?.ToString() ?? string.Empty;
                                txtTongTien.Text = reader["TongTien"]?.ToString() ?? string.Empty;
                            }
                        }
                        else
                        {
                            ClearCustomerDetails();
                        }
                    }
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Lỗi khi tải thông tin phòng: Input string was not in a correct format. " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải thông tin phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return roomNumber;
        }


        private void ClearCustomerDetails()
        {
            txtSoCCCD.Text = string.Empty;
            cbbTenKH.SelectedIndex = -1;
            cbbTenKH.Text = string.Empty;
            mtxtSoDT.Clear(); // Sử dụng Clear để làm trống MaskedTextBox
            cbbTenNV.SelectedIndex = -1;
            cbbTenNV.Text = string.Empty;

            // Reset các thông tin khác
            txtSoNguoi.Text = string.Empty;
            txtPhuThu.Text = string.Empty;
            txtThueVAT.Text = string.Empty;
            txtGiamGia.Text = string.Empty;
            txtTongTien.Text = string.Empty;

            // Reset ngày nhận/trả phòng
            dtpNgayNhanPhong.Value = DateTime.Now;
            dtpNgayTraPhong.Value = DateTime.Now;
        }

        private void cbbTenKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadKhachHang();
        }

        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            KhachHang khForm = new KhachHang();
            khForm.Show(this);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
          this.SaveInvoiceDetails();
        }
        private void CalculateTotalAmount()
        {
            DateTime ngayNhanPhong = dtpNgayNhanPhong.Value; 
            DateTime ngayTraPhong = dtpNgayTraPhong.Value;
            int soNgay = (ngayTraPhong - ngayNhanPhong).Days; 
            soNgay = soNgay == 0 ? 1 : soNgay + 1; 
            txtSoNgay.Text = soNgay.ToString();

            // Lấy Giá Tiền từ bảng Phong
            if (decimal.TryParse(txtGiaTien.Text, out decimal giaTien))
            {
                if (decimal.TryParse(txtPhuThu.Text, out decimal phuThu))
                {
                   
                }
                else
                {
                    phuThu = 0; 
                }
                if (decimal.TryParse(txtThueVAT.Text, out decimal thueVAT))
                {
                    thueVAT /= 100; 
                }
                else
                {
                    thueVAT = 0; 
                }
                if (decimal.TryParse(txtGiamGia.Text, out decimal giamGia))
                {
                    giamGia /= 100; 
                }
                else
                {
                    giamGia = 0; 
                }
                decimal tongTien = (giaTien * soNgay) + (giaTien * thueVAT) + phuThu - (giaTien * giamGia);
                txtTongTien.Text = tongTien.ToString("N2"); 
            }
            else
            {
                txtTongTien.Text = "0";
            }
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalAmount();
        }
        private void txtSoNgay_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalAmount();
        }
        private void txtGiaTien_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalAmount();
        }
        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalAmount();
        }
        private void txtThueVAT_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalAmount();
        }
        private void SaveInvoiceDetails()
        {
            // Gọi hàm tính toán tổng tiền để đảm bảo các giá trị được cập nhật
            CalculateTotalAmount();

            string connectionString = "server=Admin\\SQLEXPRESS;database=QuanLyKhachSan;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Query to get IDKhachHang based on SoCCCD
                    string getKhachHangIdQuery = "SELECT IDKhachHang FROM KhachHang WHERE SoCCCD = @SoCCCD";
                    SqlCommand getKhachHangCmd = new SqlCommand(getKhachHangIdQuery, conn);
                    getKhachHangCmd.Parameters.AddWithValue("@SoCCCD", txtSoCCCD.Text);
                    int idKhachHang = Convert.ToInt32(getKhachHangCmd.ExecuteScalar());

                    // Query to get IDNhanVien based on TenNV
                    string getNhanVienIdQuery = "SELECT IDNhanVien FROM NhanVien WHERE HoTenNV = @HoTenNV";
                    SqlCommand getNhanVienCmd = new SqlCommand(getNhanVienIdQuery, conn);
                    getNhanVienCmd.Parameters.AddWithValue("@HoTenNV", cbbTenNV.Text);
                    int idNhanVien = Convert.ToInt32(getNhanVienCmd.ExecuteScalar());

                    // Insert query for HoaDon with status
                    string insertQuery = @"INSERT INTO HoaDon (IDKhachHang, IDNhanVien, GiaTien, NgayVao, NgayRa, 
                                          PhuThu, GiamGia, ThueVAT, TongTien, GhiChu, SoNguoi, TrangThai) 
                              VALUES (@IDKhachHang, @IDNhanVien, @GiaTien, @NgayVao, @NgayRa, 
                                      @PhuThu, @GiamGia, @ThueVAT, @TongTien, @GhiChu, @SoNguoi, @TrangThai)";

                    SqlCommand cmd = new SqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@IDKhachHang", idKhachHang);
                    cmd.Parameters.AddWithValue("@IDNhanVien", idNhanVien);
                    cmd.Parameters.AddWithValue("@GiaTien", Convert.ToDecimal(txtGiaTien.Text));
                    cmd.Parameters.AddWithValue("@NgayVao", dtpNgayNhanPhong.Value);
                    cmd.Parameters.AddWithValue("@NgayRa", dtpNgayTraPhong.Value);
                    cmd.Parameters.AddWithValue("@PhuThu", Convert.ToDecimal(txtPhuThu.Text));
                    cmd.Parameters.AddWithValue("@GiamGia", Convert.ToDecimal(txtGiamGia.Text));
                    cmd.Parameters.AddWithValue("@ThueVAT", Convert.ToDecimal(txtThueVAT.Text));
                    cmd.Parameters.AddWithValue("@TongTien", Convert.ToDecimal(txtTongTien.Text));
                    cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text);
                    cmd.Parameters.AddWithValue("@SoNguoi", Convert.ToInt32(txtSoNguoi.Text));
                    cmd.Parameters.AddWithValue("@TrangThai", "Chưa thanh toán");

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // Update the room status to "Đang thuê"
                        string updatePhongQuery = "UPDATE Phong SET TinhTrang = 'Đang thuê' WHERE SoPhong = @SoPhong";
                        SqlCommand updatePhongCmd = new SqlCommand(updatePhongQuery, conn);
                        updatePhongCmd.Parameters.AddWithValue("@SoPhong", txtSoPhong.Text);

                        int updateRows = updatePhongCmd.ExecuteNonQuery();
                        if (updateRows > 0)
                        {
                            MessageBox.Show("Thông tin đã được lưu thành công và tình trạng phòng đã được cập nhật!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không thể cập nhật tình trạng phòng. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        LoadRoomStatus();
                    }
                    else
                    {
                        MessageBox.Show("Không thể lưu thông tin. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu thông tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn huỷ thông tin?", "Thông báo", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                // Kiểm tra nếu cbbTenKH có giá trị được chọn
                if (cbbTenKH.SelectedValue != null && int.TryParse(cbbTenKH.SelectedValue.ToString(), out int customerId))
                {

                }
                ClearCustomerDetails();
            }
        }

        private void cbbTenKH_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbbTenKH.SelectedValue != null)
            {
                try
                {
                    // Kiểm tra lại SelectedValue có phải là int không
                    int customerId = (int)cbbTenKH.SelectedValue;
                    // Kết nối và truy vấn cơ sở dữ liệu
                    string connectionString = "server=Admin\\SQLEXPRESS;database=QuanLyKhachSan;Integrated Security=True";
                    string query = "SELECT SoCCCD, SoDT FROM KhachHang WHERE IDKhachHang = @CustomerID";

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand(query, conn))
                        {
                            command.Parameters.AddWithValue("@CustomerID", customerId);
                            conn.Open();

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    // Cập nhật thông tin vào các textbox
                                    txtSoCCCD.Text = reader["SoCCCD"].ToString();
                                    mtxtSoDT.Text = reader["SoDT"].ToString();
                                }
                            }
                        }
                    }
                    this.LoadKhachHang();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void HandleRoomStatusUpdate(object sender, string newStatus)
        {

            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            ContextMenuStrip contextMenu = menuItem?.Owner as ContextMenuStrip;
            Button clickedButton = contextMenu?.SourceControl as Button;

            if (clickedButton == null)
            {
                MessageBox.Show("Không thể xác định phòng được chọn.");
                return;
            }

            string roomNumber = clickedButton.Tag?.ToString();
            UpdateMauButton(clickedButton, newStatus);
            UpdateRoomStatus(roomNumber, newStatus);
            LoadRoomStatus();

        }
        private void UpdateMauButton(Button clickedButton, string newStatus)
        {
            switch (newStatus)
            {
                case "Trống":
                    clickedButton.BackColor = Color.LawnGreen;
                    break;
                case "Đang thuê":
                    clickedButton.BackColor = Color.Red;
                    break;
                case "Đã đặt":
                    clickedButton.BackColor = Color.Yellow;
                    break;
                case "Chưa dọn dẹp":
                    clickedButton.BackColor = Color.Fuchsia;
                    break;
                case "Đang sửa chữa":
                    clickedButton.BackColor = Color.Blue;
                    break;
                default:
                    MessageBox.Show("Trạng thái không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }
        private void UpdateRoomStatus(string roomNumber, string newStatus)
        {
            string connectionString = "server=Admin\\SQLEXPRESS;database=QuanLyKhachSan;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Phong SET TinhTrang = @TinhTrang WHERE SoPhong = @SoPhong";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@TinhTrang", SqlDbType.NVarChar).Value = newStatus;
                    cmd.Parameters.Add("@SoPhong", SqlDbType.NVarChar).Value = roomNumber;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhanVienForm nhanVienForm = new NhanVienForm();
            nhanVienForm.ShowDialog();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripSplitButton2_ButtonClick(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Thoat();
        }
        private void Thoat()
        {
            this.Close();
            TaiKhoanForm TK = new TaiKhoanForm();
            //TK.ResetFields();
            TK.Show();
           
        }

        private void đổiMậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            DoiTaiKhoanForm TK =  new DoiTaiKhoanForm();
            TK.Show();
        }

        private void sửaChữatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            HandleRoomStatusUpdate(sender, "Đang sửa chữa");
        }
        private void trảPòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HandleRoomStatusUpdate(sender, "Chưa dọn dẹp");
        }
        private void nhậnPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HandleRoomStatusUpdate(sender, "Đang thuê");
        }
        private void đãDọnDẹpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HandleRoomStatusUpdate(sender, "Trống");
        }

        private void đãSửaChữaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HandleRoomStatusUpdate(sender, "Trống");
        }
        private void đặtphòngtoolStripMenuItem3_Click(object sender, EventArgs e)
        {
            DatPhongForm datPhongForm = new DatPhongForm();
            datPhongForm.ShowDialog();
        }
        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string roomNumber = GetSelectedRoomNumber(sender); // Lấy số phòng hiện tại
            UpdateInvoiceStatus(roomNumber, "Đã thanh toán");
        }
        private void UpdateInvoiceStatus(string roomNumber, string status)
        {
            string connectionString = "server=Admin\\SQLEXPRESS;database=QuanLyKhachSan;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE HoaDon SET TrangThai = @TrangThai WHERE SoPhong = @SoPhong";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@TrangThai", SqlDbType.NVarChar).Value = status;
                    cmd.Parameters.Add("@SoPhong", SqlDbType.NVarChar).Value = roomNumber;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void someEventHandler(object sender, EventArgs e)
        {
            string roomNumber = GetSelectedRoomNumber(sender);
            MessageBox.Show($"Số phòng đang chọn: {roomNumber}");
        }
        private string GetSelectedRoomNumber(object sender)
        {
            if (sender is Button clickedButton)
            {
                return clickedButton.Tag.ToString();
            }
            return null;
        }

        private void addRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddRoomForm addR=new AddRoomForm();
            addR.ShowDialog();
        }
    }
}



