using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
/*using Excel = Microsof.Interop.Excel;*/
namespace WindowsForm
{
    public partial class NhanVienForm : Form
    {
        private SqlConnection connection;
        public NhanVienForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void NhanVienForm_Load(object sender, EventArgs e)
        {


            string connectionString = "server=Admin\\SQLEXPRESS;Database=QuanLyKhachSan;Integrated Security=True;";
            connection = new SqlConnection(connectionString);
            LoadEmployeeData();


        }
        private void LoadEmployeeData()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string query = "SELECT * FROM NhanVien";
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable(); sda.Fill(dt);
                listView1.Items.Clear(); foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["IDNhanVien"].ToString());
                    item.SubItems.Add(row["HoTenNV"].ToString());
                    item.SubItems.Add(row["SoCCCD"].ToString());
                    item.SubItems.Add(row["DiaChi"].ToString());
                    item.SubItems.Add(row["NgaySinh"].ToString());
                    item.SubItems.Add(row["NgayVaoLam"].ToString());
                    item.SubItems.Add(row["ViTriLV"].ToString());
                    item.SubItems.Add(row["SoDT"].ToString());
                    item.SubItems.Add(row["Luong"].ToString());
                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }




        private void bntSua_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0]; int idNhanVien = int.Parse(item.SubItems[0].Text); try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    string query = "UPDATE NhanVien SET HoTenNV=@HoTenNV, SoCCCD=@SoCCCD, DiaChi=@DiaChi, NgaySinh=@NgaySinh, " + "NgayVaoLam=@NgayVaoLam, ViTriLV=@ViTriLV, SoDT=@SoDT, Luong=@Luong WHERE IDNhanVien=@IDNhanVien";
                    SqlCommand sqlCmd = new SqlCommand(query, connection);
                    sqlCmd.Parameters.AddWithValue("@IDNhanVien", idNhanVien);
                    sqlCmd.Parameters.AddWithValue("@HoTenNV", txtHoTen.Text);
                    sqlCmd.Parameters.AddWithValue("@SoCCCD", txtSoCCCD.Text);
                    sqlCmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                    sqlCmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                    sqlCmd.Parameters.AddWithValue("@NgayVaoLam", dtpNgayVaoLam.Value);
                    sqlCmd.Parameters.AddWithValue("@ViTriLV", cbbViTri.Text);
                    sqlCmd.Parameters.AddWithValue("@SoDT", mtxtSoDT.Text);
                    sqlCmd.Parameters.AddWithValue("@Luong", txtLuong.Text);
                    sqlCmd.ExecuteNonQuery(); MessageBox.Show("Cập nhật thông tin nhân viên thành công!");
                    LoadEmployeeData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
            else { MessageBox.Show("Vui lòng chọn nhân viên cần cập nhật thông tin."); }

        }
        private void bntLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            LoadEmployeeData();
        }
        private void ClearInputFields()
        {
            txtHoTen.Text = ""; txtSoCCCD.Text = "";
            txtDiaChi.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
            dtpNgayVaoLam.Value = DateTime.Now;
            cbbViTri.Text = "";
            mtxtSoDT.Text = "";
            txtLuong.Text = "";
        }

        private void bntLuu_Click(object sender, EventArgs e)

        {
            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtSoCCCD.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                string.IsNullOrWhiteSpace(cbbViTri.Text) ||
                string.IsNullOrWhiteSpace(mtxtSoDT.Text) ||
                string.IsNullOrWhiteSpace(txtLuong.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin các trường bắt buộc.");
                return;
            }

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                // Kiểm tra trùng số CCCD
                string checkQuery = "SELECT COUNT(*) FROM NhanVien WHERE SoCCCD=@SoCCCD";
                SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
                checkCmd.Parameters.AddWithValue("@SoCCCD", txtSoCCCD.Text);
                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Số CCCD đã tồn tại. Vui lòng kiểm tra lại.");
                    return;
                }

                // Nếu không trùng, thêm mới nhân viên
                string query = "INSERT INTO NhanVien (HoTenNV, SoCCCD, DiaChi, NgaySinh, NgayVaoLam, ViTriLV, SoDT, Luong) " +
                               "VALUES (@HoTenNV, @SoCCCD, @DiaChi, @NgaySinh, @NgayVaoLam, @ViTriLV, @SoDT, @Luong)";
                SqlCommand sqlCmd = new SqlCommand(query, connection);
                sqlCmd.Parameters.AddWithValue("@HoTenNV", txtHoTen.Text);
                sqlCmd.Parameters.AddWithValue("@SoCCCD", txtSoCCCD.Text);
                sqlCmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                sqlCmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                sqlCmd.Parameters.AddWithValue("@NgayVaoLam", dtpNgayVaoLam.Value);
                sqlCmd.Parameters.AddWithValue("@ViTriLV", cbbViTri.Text);
                sqlCmd.Parameters.AddWithValue("@SoDT", mtxtSoDT.Text);
                sqlCmd.Parameters.AddWithValue("@Luong", txtLuong.Text);

                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Thêm nhân viên thành công!");
                LoadEmployeeData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

   
    


    private void bntXoa_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0]; int idNhanVien = int.Parse(item.SubItems[0].Text); try
                {
                    if (connection.State == ConnectionState.Closed) { connection.Open(); }
                    string query = "DELETE FROM NhanVien WHERE IDNhanVien=@IDNhanVien";
                    SqlCommand sqlCmd = new SqlCommand(query, connection);
                    sqlCmd.Parameters.AddWithValue("@IDNhanVien", idNhanVien);
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa nhân viên thành công!");
                    LoadEmployeeData();
                }
                catch
                (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa.");
            }
        }





        private void FilterByPosition()
        {
            try
            {
                // Mở kết nối nếu đang đóng
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                // Tạo câu lệnh truy vấn SQL cơ bản
                string query = "SELECT * FROM NhanVien WHERE 1=1";
                if (!string.IsNullOrWhiteSpace(cboLocViTriTri.Text))
                {
                    query += " AND ViTriLV = @ViTriLV";
                }
                if (!string.IsNullOrWhiteSpace(txtHoTen.Text))
                {
                    query += " AND HoTenNV LIKE @HoTenNV";
                }
                if (!string.IsNullOrWhiteSpace(txtID.Text))
                {
                    query += " AND IDNhanVien = @IDNhanVien";
                }

                // Tạo đối tượng SqlCommand và thêm các tham số
                SqlCommand sqlCmd = new SqlCommand(query, connection);
                if (!string.IsNullOrWhiteSpace(cboLocViTriTri.Text))
                {
                    sqlCmd.Parameters.AddWithValue("@ViTriLV", cboLocViTriTri.Text.Trim());
                }


                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                listView1.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["IDNhanVien"].ToString());
                    item.SubItems.Add(row["HoTenNV"].ToString());
                    item.SubItems.Add(row["SoCCCD"].ToString());
                    item.SubItems.Add(row["DiaChi"].ToString());
                    item.SubItems.Add(row["NgaySinh"].ToString());
                    item.SubItems.Add(row["NgayVaoLam"].ToString());
                    item.SubItems.Add(row["ViTriLV"].ToString());
                    item.SubItems.Add(row["SoDT"].ToString());
                    item.SubItems.Add(row["Luong"].ToString());

                    listView1.Items.Add(item);
                }


                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }


        }


        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                txtHoTen.Text = item.SubItems[1].Text;
                txtSoCCCD.Text = item.SubItems[2].Text;
                txtDiaChi.Text = item.SubItems[3].Text;
                dtpNgaySinh.Value = DateTime.Parse(item.SubItems[4].Text);
                dtpNgayVaoLam.Value = DateTime.Parse(item.SubItems[5].Text);
                cbbViTri.Text = item.SubItems[6].Text; mtxtSoDT.Text = item.SubItems[7].Text;
                txtLuong.Text = item.SubItems[8].Text;
            }
        }
        private void DeleteEmployee(int idNhanVien)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                // Xóa các hóa đơn liên quan trước
                string deleteInvoicesQuery = "DELETE FROM HoaDon WHERE IDNhanVien=@IDNhanVien";
                SqlCommand deleteInvoicesCmd = new SqlCommand(deleteInvoicesQuery, connection);
                deleteInvoicesCmd.Parameters.AddWithValue("@IDNhanVien", idNhanVien);
                deleteInvoicesCmd.ExecuteNonQuery();

                // Sau đó xóa nhân viên
                string deleteEmployeeQuery = "DELETE FROM NhanVien WHERE IDNhanVien=@IDNhanVien";
                SqlCommand deleteEmployeeCmd = new SqlCommand(deleteEmployeeQuery, connection);
                deleteEmployeeCmd.Parameters.AddWithValue("@IDNhanVien", idNhanVien);
                deleteEmployeeCmd.ExecuteNonQuery();

                MessageBox.Show("Xóa nhân viên thành công!");
                LoadEmployeeData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

       
        private void bntXoa_Click_1(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                int idNhanVien = int.Parse(item.SubItems[0].Text);
                DeleteEmployee(idNhanVien);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa.");
            }
        }

        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                MessageBox.Show("Vui lòng nhập tên hoặc ID nhân viên cần tìm kiếm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }


                string query = "SELECT * FROM NhanVien WHERE IDNhanVien LIKE @SearchText OR HoTenNV LIKE @SearchText";
                SqlCommand sqlCmd = new SqlCommand(query, connection);
                sqlCmd.Parameters.AddWithValue("@SearchText", "%" + txtTimKiem.Text.Trim() + "%");

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                listView1.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["IDNhanVien"].ToString());
                    item.SubItems.Add(row["HoTenNV"].ToString());
                    item.SubItems.Add(row["SoCCCD"].ToString());
                    item.SubItems.Add(row["DiaChi"].ToString());
                    item.SubItems.Add(row["NgaySinh"].ToString());
                    item.SubItems.Add(row["NgayVaoLam"].ToString());
                    item.SubItems.Add(row["ViTriLV"].ToString());
                    item.SubItems.Add(row["SoDT"].ToString());
                    item.SubItems.Add(row["Luong"].ToString());

                    listView1.Items.Add(item);
                }

                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cboLocViTriTri_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            FilterByPosition();
        }

        private void bntNhapFile_Click(object sender, EventArgs e)
        {


        }





       /* private void ExportListViewToExcel(System.Windows.Forms.ListView listView1, string filePath)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];
            worksheet.Name = "NhanVien";

            // Kiểm tra nếu ListView có dữ liệu
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tiêu đề cột
            for (int i = 0; i < listView1.Columns.Count; i++)
            {
                worksheet.Cells[1, i + 1] = listView1.Columns[i].Text;
            }

            // Dữ liệu
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                for (int j = 0; j < listView1.Items[i].SubItems.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = listView1.Items[i].SubItems[j].Text;
                }
            }

            // Lưu tập tin Excel
            try
            {
                workbook.SaveAs(filePath);
                MessageBox.Show("Dữ liệu đã được xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu tệp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                workbook.Close();
                excelApp.Quit();
            }
        }*/




        private void bntXuatFile_Click(object sender, EventArgs e)
       {
           // ExportListViewToExcel(listView1, "flieNhanVien");//
        }
    }
}






