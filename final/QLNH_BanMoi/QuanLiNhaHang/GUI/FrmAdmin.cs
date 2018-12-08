using QuanLiNhaHang.DAL;
using QuanLiNhaHang.ENTITY;
using QuanLiNhaHang.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiNhaHang.GUI
{
    public partial class FrmAdmin : Form
    {
        private int idCategory = 0;

        public FrmAdmin()
        {
            InitializeComponent();

            LoadMenuCate();     // load cb
            HienThiDSMenu();
            HienThiDSMenuCategory();
            HienthiDanhsachBan();
            HienThiDSNhanVien();
        }

        //Menu
        void HienThiDSMenu()
        {
            dgvmenu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            try
            {
                int idCate = Convert.ToInt16(cbMenuCate.SelectedValue.ToString());
                MenuDAL mnDAL = new MenuDAL();
                dgvmenu.DataSource = mnDAL.getListMenuByIdCategory(idCate);
                this.idCategory = idCate;
            }
            catch
            {

            }

        }


        public bool checkNumber(string str)
        {
            try
            {
                int d = Convert.ToInt32(str);
                return true;
            }
            catch
            {
                MessageBox.Show("Bạn đã nhập sai", "Lỗi");
            }
            return false;
        }

        private void LoadMenuCate()
        {
            MenuCategoryDAL mncDAL = new MenuCategoryDAL();
            DataTable datacate = mncDAL.getListCategory();
            cbMenuCate.DataSource = datacate;
            cbMenuCate.DisplayMember = "Name";
            cbMenuCate.ValueMember = "Id";

        }

        private void cbMenuCate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idCate = Convert.ToInt16(cbMenuCate.SelectedValue.ToString());
                MenuDAL mnDAL = new MenuDAL();
                //MessageBox.Show("Bạn chọn danh mục thành công", "Thông báo");
                dgvmenu.DataSource = mnDAL.getListMenuByIdCategory(idCate);

                this.idCategory = idCate;
            }
            catch
            {

            }
        }

        private void dgvmenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numRow;
            numRow = e.RowIndex;
            txtMaMon.Text = dgvmenu.Rows[numRow].Cells[0].Value.ToString();
            txtTenMon.Text = dgvmenu.Rows[numRow].Cells[1].Value.ToString();
            txtGia.Text = dgvmenu.Rows[numRow].Cells[2].Value.ToString();
            string stt = dgvmenu.Rows[numRow].Cells[3].Value.ToString();
            if (stt == "Còn") rbCon.Checked = true;
            else rbHet.Checked = true;
        }



        private void btInsertThucDon_Click(object sender, EventArgs e)
        {
            int idCate = Convert.ToInt16(cbMenuCate.SelectedValue.ToString());
            ENTITY.Menu mn = new ENTITY.Menu();
            MenuDAL mnDAL = new MenuDAL();
            mn.IdCategory = idCate;


            if (txtTenMon.TextLength == 0)
            {
                MessageBox.Show("Chưa nhập tên món", " Lỗi ");
            }
            else
            {
                mn.Name = txtTenMon.Text;

                if (txtGia.TextLength == 0)
                {
                    MessageBox.Show("Chưa nhập giá ", " Lỗi ");
                }
                else
                {
                    mn.Price = Convert.ToInt32(txtGia.Text.ToString());
                    try
                    {
                        if (rbCon.Checked == false && rbHet.Checked == false)
                        {
                            MessageBox.Show("Chưa chọn tình trạng món ăn", " Lỗi ");
                        }
                        else
                        {
                            if (rbCon.Checked == true) mn.Status = "Còn";
                            else if (rbHet.Checked == true) mn.Status = "Hết";
                            mnDAL.insertMenu(mn.Name, mn.Price, mn.Status, idCate);
                            MessageBox.Show("Bạn đã thêm món thành công", "thông báo");
                            // dgvmenu.DataSource = mnDAL.LoadDSMenuByCate(idCate);
                            HienThiDSMenu();
                        }
                    }
                    catch
                    {

                    }
                }

            }
        }

        private void btDeleteThucDon_Click(object sender, EventArgs e)
        {
            int idCate = Convert.ToInt16(cbMenuCate.SelectedValue.ToString());
            MenuDAL mnDAL = new MenuDAL();
            if (txtMaMon.TextLength == 0)
            {
                MessageBox.Show("Chưa có mã món", " Lỗi ");
            }
            else
            {
                try
                {
                    int id = Convert.ToInt16(txtMaMon.Text);
                    if (MessageBox.Show("Bạn có chắc muốn xóa món?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        mnDAL.deleteMenu(id);
                        MessageBox.Show("Bạn đã xóa món thành công", "thông báo");
                        // dgvmenu.DataSource = mnDAL.LoadDSMenuByCate(idCate);
                        HienThiDSMenu();

                    }
                    else
                    {
                        MessageBox.Show(" Có lỗi khi xóa món", "Thông báo");
                    }

                }
                catch
                {
                    MessageBox.Show("Mã món không thỏa mãn", " Lỗi ");
                }

            }
        }

        private void btEditThucDon_Click(object sender, EventArgs e)
        {
            int idCate = Convert.ToInt16(cbMenuCate.SelectedValue.ToString());
            ENTITY.Menu mn = new ENTITY.Menu();
            mn.Id = Convert.ToInt16(txtMaMon.Text);
            MenuDAL mnDAL = new MenuDAL();

            if (txtMaMon.Text != mn.Id.ToString())
            {
                MessageBox.Show("Không được sửa mã món", " Lỗi ");
            }
            else
            {
                if (txtTenMon.TextLength == 0)
                {
                    MessageBox.Show("Chưa nhập tên món", " Lỗi ");
                }

                else
                {
                    mn.Name = txtTenMon.Text;
                    if (txtGia.TextLength == 0)
                    {
                        MessageBox.Show("Chưa nhập giá ", " Lỗi ");
                    }
                    else
                    {
                        mn.Price = Convert.ToInt32(txtGia.Text.ToString());

                        if (rbCon.Checked == false && rbHet.Checked == false)
                        {
                            MessageBox.Show("Chưa chọn tình trạng món ăn", " Lỗi ");
                        }
                        else
                        {
                            if (rbCon.Checked == true) mn.Status = "Còn";
                            else if (rbHet.Checked == true) mn.Status = "Hết";
                            mnDAL.UpdateMenu(mn.Name, mn.Price, mn.Status, mn.Id);
                            MessageBox.Show("Bạn đã sửa món thành công", "thông báo");
                            // dgvmenu.DataSource = mnDAL.LoadDSMenuByCate(idCate);
                            HienThiDSMenu();
                        }
                    }
                }
            }
        }

        private void btSearchThucDon_Click(object sender, EventArgs e)
        {
            string searchtxt = txtSearchMenu.Text;
            MenuDAL mnDAL = new MenuDAL();
            dgvmenu.DataSource = mnDAL.searchMenu(searchtxt);
        }

        //MenuCategory
        private void HienThiDSMenuCategory()
        {
            dgvmenucate.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            MenuCategoryDAL mncDAL = new MenuCategoryDAL();
            dgvmenucate.DataSource = mncDAL.getListCategory();
        }

        private void dgvmenucate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numRow;
            numRow = e.RowIndex;
            txtmadm.Text = dgvmenucate.Rows[numRow].Cells[0].Value.ToString();
            txttendm.Text = dgvmenucate.Rows[numRow].Cells[1].Value.ToString();
        }

        // them danh muc
        private void btnthemdm_Click(object sender, EventArgs e)
        {
            ENTITY.MenuCategory mnc = new ENTITY.MenuCategory();
            MenuCategoryDAL mncDAL = new MenuCategoryDAL();

            //if (txtmadm.TextLength != 0)
            //{
            //    MessageBox.Show("Không cần nhập mã danh mục", " Lỗi ");
            //}
            //else
            //{
            if (txttendm.TextLength == 0)
            {
                MessageBox.Show("Chưa nhập tên danh mục", " lỗi ");
            }
            else
            {
                mnc.Name = txttendm.Text;
                mncDAL.insertMenuCate(mnc.Name);
                MessageBox.Show("Bạn đã thêm danh mục thành công", "Thông báo");
                dgvmenucate.DataSource = mncDAL.getListCategory();

            }
            //  }
        }


        // xoa danh muc
        private void btnXoadm_Click(object sender, EventArgs e)
        {
            MenuCategoryDAL mncDAL = new MenuCategoryDAL();
            if (txtmadm.TextLength == 0)
            {
                MessageBox.Show("Chưa có mã danh mục", " Lỗi ");
            }
            else
            {
                try

                {
                    int Id = Convert.ToInt16(txtmadm.Text);
                    if (MessageBox.Show("Bạn có chắc muốn xóa món?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        mncDAL.deleteMenuCate(Id);
                        MessageBox.Show("Bạn đã xóa danh mục thành công", "Thông báo");
                        dgvmenucate.DataSource = mncDAL.getListCategory();
                    }
                    else
                    {
                        MessageBox.Show(" Có lỗi khi xóa món", "Thông báo");
                    }

                }
                catch
                {
                    MessageBox.Show("Mã danh mục không thỏa mãn", " Lỗi ");
                }

            }
        }


        // sua danh muc
        private void btnSuadm_Click(object sender, EventArgs e)
        {
            ENTITY.MenuCategory mnc = new ENTITY.MenuCategory();
            mnc.Id = Convert.ToInt16(txtmadm.Text);
            MenuCategoryDAL mncDAL = new MenuCategoryDAL();

            if (txtmadm.Text != mnc.Id.ToString())
            {
                MessageBox.Show("Không được sửa mã danh mục", " Lỗi ");
            }
            else
            {
                if (txttendm.TextLength == 0)
                {
                    MessageBox.Show("Chưa nhập tên danh mục", " lỗi ");
                }
                else
                {
                    mnc.Name = txttendm.Text;
                    mncDAL.UpdateMenuCate(mnc.Name, mnc.Id);
                    MessageBox.Show("Bạn đã sửa danh mục thành công", "Thông báo");
                    dgvmenucate.DataSource = mncDAL.getListCategory();
                }


            }

        }


        //  nut tim kiem
        private void btntimkiemdm_Click(object sender, EventArgs e)
        {
            string searchtxt = txtSearchMenu.Text;
            MenuCategoryDAL mncDAL = new MenuCategoryDAL();
            dgvmenu.DataSource = mncDAL.searchMenuCate(searchtxt);
        }

        private void txtSearchMenu_TextChanged(object sender, EventArgs e)
        {
            string searchtxt = txtSearchMenu.Text;
            MenuDAL mncDAL = new MenuDAL();
            dgvmenu.DataSource = mncDAL.searchMenu(searchtxt);
        }

        //***********************************************************
        // an 
        private void tabBan_Click(object sender, EventArgs e)
        {
            HienthiDanhsachBan();
        }
        public void HienthiDanhsachBan()
        {
            dgvtable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            TableDAL tbmenuDAL = new TableDAL();
            dgvtable.DataSource = tbmenuDAL.getListTable(2);
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            int key = 0;
            TableDAL tablemenuDAL = new TableDAL();
            Table tablemenu = new Table();
            if (tbArea.TextLength != 0)
            {
                tablemenu.Area = tbArea.Text;
            }
            else
            {
                key++;
                lbloiArea.Text = "Chưa Nhập Khu Vực";
            }

            List<Table> tablemenu_Area = tablemenuDAL.getTableMenu_Area(tablemenu.Area);
            Table table = tablemenu_Area.Find(x => (x.TableName == tbtablename.Text));
            if (table == null)
            {
                tablemenu.TableName = tbtablename.Text;
            }
            else
            {
                key++;
                lbloitablename.Text = "*Tên bàn bị trùng";
            }
            if (tbstatus.TextLength != 0)
            {
                tablemenu.Status = Convert.ToInt16(tbstatus.Text);
            }
            else
            {
                tablemenu.Status = 0;
            }
            if (key == 0)
            {
                tablemenuDAL.insertTableMenu(tablemenu);
                MessageBox.Show("bạn đã thêm bàn công", "thông báo");
                dgvtable.DataSource = tablemenuDAL.getListTable(2);
            }
        }

        private void dgvtable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //   tbid.Enabled = false;
            int numRow;
            numRow = e.RowIndex;
            tbid.Text = dgvtable.Rows[numRow].Cells[0].Value.ToString();
            tbArea.Text = dgvtable.Rows[numRow].Cells[3].Value.ToString();
            tbtablename.Text = dgvtable.Rows[numRow].Cells[1].Value.ToString();
            tbstatus.Text = dgvtable.Rows[numRow].Cells[2].Value.ToString();
        }
        private void btnsua_Click(object sender, EventArgs e)
        {
            int key = 0;
            TableDAL tablemenuDAL = new TableDAL();
            Table tablemenu = new Table();
            tablemenu.Id = Convert.ToInt16(tbid.Text);
            if (tbArea.TextLength != 0)
            {
                tablemenu.Area = tbArea.Text;
            }
            else
            {
                key++;
                lbloiArea.Text = "Chưa Nhập Khu Vực";
            }
            List<Table> tablemenu_Area = tablemenuDAL.getTableMenu_Area(tablemenu.Area);
            Table table = tablemenu_Area.Find(x => (x.TableName == tbtablename.Text));
            if (table == null || tbtablename.Text == Convert.ToString(dgvtable.CurrentRow.Cells[1].Value))
            {
                tablemenu.TableName = tbtablename.Text;
            }
            else
            {
                key++;
                lbloitablename.Text = "*Tên bàn bị trùng";
            }
            if (tbstatus.TextLength != 0)
            {
                tablemenu.Status = Convert.ToInt16(tbstatus.Text);
            }
            else
            {
                tablemenu.Status = 0;
            }
            if (key == 0)
            {
                tablemenuDAL.editTableMenu(tablemenu.Id, tablemenu);
                MessageBox.Show("sửa bàn thành công", "thông báo");
                dgvtable.DataSource = tablemenuDAL.getListTable(2);
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            TableDAL tbmenuDAL = new TableDAL();
            try
            {
                int id = Convert.ToInt32(tbid.Text);
                tbmenuDAL.deleteTableMenu(id);
                MessageBox.Show("đã xóa bàn", "thông báo");
                dgvtable.DataSource = tbmenuDAL.getListTable(2);
            }
            catch
            {
                MessageBox.Show("ma ban khong thoa man", " loi ");
            }
        }

        // ****************************************************************************

        // Binh

        private void btThongKe_Click(object sender, EventArgs e)
        {
            dvwTotal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            BilDAL billDAL = new BilDAL();
            DataTable data = billDAL.LoadDSByTime(Convert.ToDateTime(dtFrom.Value), Convert.ToDateTime(dtTo.Value));
            dvwTotal.DataSource = data;
            int total = 0;

            foreach (DataRow row in data.Rows)
            {
                total += Convert.ToInt32(row.ItemArray[4].ToString());
            }
            lblTotal.Text = total.ToString();

        }

        private void tabAccount_Click(object sender, EventArgs e)
        {

        }

        //*****************************************************************************

        // nhan vien
        public void HienThiDSNhanVien()
        {
            dgvEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            EmployeeDAL empDAL = new EmployeeDAL();
            dgvEmployee.DataSource = empDAL.getListEmployee();
        }

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numRow;
            numRow = e.RowIndex;
            txtIdEmployee.Text = dgvEmployee.Rows[numRow].Cells[0].Value.ToString();
            txtNamEmployee.Text = dgvEmployee.Rows[numRow].Cells[1].Value.ToString();
            txtAddressEmployee.Text = dgvEmployee.Rows[numRow].Cells[3].Value.ToString();
            txtAgeEmployee.Text = dgvEmployee.Rows[numRow].Cells[2].Value.ToString();
            txtPhoneNumberEmployee.Text = dgvEmployee.Rows[numRow].Cells[4].Value.ToString();
        }


        private void btInsertEmployee_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            //if (txtIdEmployee.TextLength != 0)
            //{
            //    MessageBox.Show("Không cần nhập mã nhân viên", " Lỗi ");
            //}
            //else
            //{
            if (txtNamEmployee.TextLength == 0)
            {
                MessageBox.Show("Chưa nhập tên nhân viên", " Lỗi ");
            }
            else
            {
                emp.Name = txtNamEmployee.Text;

                if (txtAddressEmployee.TextLength == 0)
                {
                    MessageBox.Show("Chưa nhập địa chỉ ", " Lỗi ");
                }
                else
                {
                    emp.Address = txtAddressEmployee.Text;
                    if (!checkNumber(txtAgeEmployee.Text))
                    {
                        MessageBox.Show("Nhập sai  tuổi ", " Lỗi ");

                    }
                    else
                    {
                        emp.Age = Convert.ToInt32(txtAgeEmployee.Text);
                        if (txtPhoneNumberEmployee.TextLength == 0)
                        {
                            MessageBox.Show("Chưa nhập số điện thoại ", " Lỗi ");
                        }
                        else
                        {
                            emp.PhoneNumber = txtPhoneNumberEmployee.Text;
                            EmployeeDAL empDAL = new EmployeeDAL();
                            empDAL.insertEmployee(emp);
                            MessageBox.Show("bạn đãn thêm nhân viên thành công", "thông báo");
                            HienThiDSNhanVien();
                        }
                    }
                }
            }
        }

        private void btEditEmployee_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            if (!checkNumber(txtIdEmployee.Text))
            {
                MessageBox.Show("mã nhân viên bị lỗi", " Lỗi ");
            }
            else
            {
                emp.Id = Convert.ToInt32(txtIdEmployee.Text);
                if (txtNamEmployee.TextLength == 0)
                {
                    MessageBox.Show("Chưa nhập tên nhân viên", " Lỗi ");
                }
                else
                {
                    emp.Name = txtNamEmployee.Text;

                    if (txtAddressEmployee.TextLength == 0)
                    {
                        MessageBox.Show("Chưa nhập địa chỉ ", " Lỗi ");
                    }
                    else
                    {
                        emp.Address = txtAddressEmployee.Text;
                        if (!checkNumber(txtAgeEmployee.Text))
                        {
                            MessageBox.Show("Nhập sai  tuổi ", " Lỗi ");

                        }
                        else
                        {
                            emp.Age = Convert.ToInt32(txtAgeEmployee.Text);
                            if (txtPhoneNumberEmployee.TextLength == 0)
                            {
                                MessageBox.Show("Chưa nhập số điện thoại ", " Lỗi ");
                            }
                            else
                            {
                                emp.PhoneNumber = txtPhoneNumberEmployee.Text;
                                EmployeeDAL empDAL = new EmployeeDAL();
                                empDAL.editEmployee(emp.Id, emp);
                                MessageBox.Show("sửa nhân viên thành công", "thông báo");
                                HienThiDSNhanVien();
                            }
                        }

                    }
                }
            }
        }

        private void btDeleteEmployee_Click(object sender, EventArgs e)
        {
            int Id;
            if (!checkNumber(txtIdEmployee.Text))
            {
                MessageBox.Show("mã nhân viên bị lỗi", " Lỗi ");
            }
            else
            {
                Id = Convert.ToInt32(txtIdEmployee.Text);
                EmployeeDAL empDAL = new EmployeeDAL();
                empDAL.deleteEmployee(Id);
                MessageBox.Show("đã xóa nhân viên", "thông báo");
                HienThiDSNhanVien();
            }
        }

        private void btCapTaiKhoan_Click(object sender, EventArgs e)
        {
            int Id;
            EmployeeDAL empDAL = new EmployeeDAL();

            if (!checkNumber(txtIdEmployee.Text))
            {
                MessageBox.Show("mã nhân viên bị lỗi", " Lỗi ");
            }
            else
            {
                Id = Convert.ToInt32(txtIdEmployee.Text);
                if (empDAL.CheckHaveAccount(Id))
                {
                    FrmCapTaiKhoan frmCapTaiKhoan = new FrmCapTaiKhoan(Id);
                    frmCapTaiKhoan.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Nhân viên đã có tài khoản", " Lỗi ");
                }
            }



        }

        private void txtSearchEmployee_TextChanged(object sender, EventArgs e)
        {
            dgvEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            string nameEmployee = txtSearchEmployee.Text;
            EmployeeDAL empDAL = new EmployeeDAL();
            dgvEmployee.DataSource = empDAL.searchEmployee(nameEmployee);
        }

        private void txttimkiemdm_TextChanged(object sender, EventArgs e)
        {
            string searchtxt = txttimkiemdm.Text;
            MenuCategoryDAL mncDAL = new MenuCategoryDAL();
            dgvmenucate.DataSource = mncDAL.searchMenuCate(searchtxt);
        }

        private void btnxuatfiledm_Click(object sender, EventArgs e)
        {
            file.ExportToExcel(dgvmenucate);
        }

        private void btnXuatfileMenu_Click(object sender, EventArgs e)
        {
            file.ExportToExcel(dgvmenu);
        }

        private void btnXuatfileban_Click(object sender, EventArgs e)
        {
            file.ExportToExcel(dgvtable);
        }

        private void btnxuatfilethongke_Click(object sender, EventArgs e)
        {
            file.ExportToExcel(dvwTotal);
        }

        private void btnxuatfileNV_Click(object sender, EventArgs e)
        {
            file.ExportToExcel(dgvEmployee);
        }
    }
}
