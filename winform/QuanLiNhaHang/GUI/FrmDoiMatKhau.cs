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
    public partial class FrmDoiMatKhau : Form
    {
        Account acc = new Account();
        public FrmDoiMatKhau(string username, string password)
        {
            InitializeComponent();
            acc.UserName = username;
            acc.PassWord = password;
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            AccountDAL accDAL = new AccountDAL();
            string oldpass =accDAL.encodeMD5( txtOldPass.Text);
            string newPass =accDAL.encodeMD5( txtNewPass.Text);

            //   if (MessageBox.Show("Bạn có thật sự muốn đôi mật khẩu ?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                if (acc.PassWord == oldpass && newPass != "")
                {
                    this.Hide();
                   
                    accDAL.doiMatKhau(acc.UserName, oldpass, newPass);

                    acc.PassWord = newPass;
                }
                else
                {
                    MessageBox.Show("Nhập không đúng mật khẩu", "Lỗi ");
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
