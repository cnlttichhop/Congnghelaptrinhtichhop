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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            AccountDAL accDAL = new AccountDAL();

            Account acc = new Account();
            acc.UserName = txtUser.Text;
            acc.PassWord = accDAL.encodeMD5(txtPassword.Text);

           
            DataTable data = accDAL.GetAccount();


            // lọc từ datatable dong có username = username người dùng nhập
            string filterExpression = string.Format("UserName='{0}'", acc.UserName);
            DataRow[] rows = data.Select(filterExpression);

            if (rows.Length != 0)
            {
                if (rows[0].ItemArray[1].ToString() == acc.PassWord)
                {
                    this.Hide();
                    int PhanQuyen = Convert.ToInt32(rows[0].ItemArray[2].ToString());
                    MainFrame mf = new MainFrame(PhanQuyen, acc.UserName, acc.PassWord);

                    mf.ShowDialog();
                    //  this.Show();
                }
                else
                {

                    MessageBox.Show("mật khẩu của bạn bị sai", "Lỗi đăng nhâp");
                }

            }
            else
            {
                MessageBox.Show("tài khoản không tồn tại", "Lỗi đăng nhâp");
            }
        }
    }
}
