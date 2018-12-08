using QuanLiNhaHang.DAL;
using QuanLiNhaHang.ENTITY;
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
    public partial class FrmCapTaiKhoan : Form
    {
        int idEmployee;
        public FrmCapTaiKhoan(int idEmp)
        {
            InitializeComponent();
            this.idEmployee = idEmp;
        }

        private void btDangKi_Click(object sender, EventArgs e)
        {
            int key = 0;
            AccountDAL accDAL = new AccountDAL();
            DataTable dataacc = accDAL.GetAccount();
            Account acc = new Account();
            string filterExpression = string.Format("UserName='{0}'", txtUsername.Text);
            DataRow[] rows = dataacc.Select(filterExpression);
            if (rows.Length == 0)
            {
                acc.UserName = txtUsername.Text;
            }
            else
            {
                key++;
                lbLoiUsername.Text = "*Tên đăng nhập bị trùng";
            }
            if (txtPass.Text.Length >= 8)
            {

            }
            else
            {
                key++;
                lbLoiPass.Text = "*Mật khẩu it nhất 8 kí tự";
            }
            //check pass
            if (txtRePass.Text == txtPass.Text)
            {
                acc.PassWord = accDAL.encodeMD5(txtPass.Text);
                // txtUsername.Text = acc.PassWord;
            }
            else
            {
                key++;
                lbLoiRePass.Text = "*Xác nhận mật khẩu không chính xác";
            }
            // kiem tra Phan quyen
            if (rbAdmin.Checked == true)
            {
                acc.Type = 1;
            }
            else
            {
                if (rbUser.Checked == true)
                {
                    acc.Type = 0;
                }
                else
                {
                    lbLoiPhanQuyen.Text = "Bạn chưa phân quyền tài khoản";
                }
            }
            if (key == 0)
            {
                acc.IdEmployee = this.idEmployee;

                accDAL.insertAccount(acc);
                lbNotice.Text = "Thêm tài khoản thành công";
            }
            else
            {
                lbNotice.Text = "Thêm tài khoản thất bại";
            }
        }
    }
}
