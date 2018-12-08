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
    public partial class MainFrame : Form
    {

        Account acc = new Account();
        public MainFrame(int PhanQuyen, string username, string password)
        {
            InitializeComponent();
            LoadTable(2);

            

            this.acc.UserName = username;
            this.acc.PassWord = password;
            this.acc.Type = PhanQuyen;

           
        }

        public void LoadTable(int tt)
        {
            TableDAL tbDAL = new TableDAL();
            List<Table> lsTable = tbDAL.getListTable(tt);
            while (flpTable.Controls.Count > 0) flpTable.Controls.RemoveAt(0);
            foreach (Table table in lsTable)
            {
                Button bt = new Button() { Width = 105, Height = 105 };
                bt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;   // tu zoom image
                bt.Text = table.TableName;
                bt.TextAlign = System.Drawing.ContentAlignment.BottomCenter;


                if (table.Status == 0)
                {
                    bt.BackgroundImage = Image.FromFile(Application.StartupPath + "\\IMAGE\\table0.png");
                }
                else
                {
                    bt.BackgroundImage = Image.FromFile(Application.StartupPath + "\\IMAGE\\table1.png");
                }

                bt.Tag = table;
                bt.Click += btTable_Click;

                flpTable.Controls.Add(bt);
            }
        }
        private void btTable_Click(object sender, EventArgs e)
        {
            Table tb = (sender as Button).Tag as Table;
            if (tb.Status == 0)
            {
                BilDAL billDAL = new BilDAL();
                string dt = DateTime.Today.ToString().Trim();
                DateTime d = Convert.ToDateTime(dt);


                billDAL.insertBill(tb.Id, d);
                //TableDAL tableDAL = new TableDAL();
                //tb = tableDAL.getTableById(tb.Id);
            }

            this.Hide();
            FrmOrder frOrder = new FrmOrder(tb.Id, this.acc.Type, this.acc.UserName, this.acc.PassWord);

            frOrder.ShowDialog();
        }

        private void cbChonTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tt;
            if (cbChonTrangThai.Text == "All") tt = 2;
            else if (cbChonTrangThai.Text == "Bàn Trống") tt = 0;
            else tt = 1;
            LoadTable(tt);
        }

       
        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.acc.Type == 1)
            {
                FrmAdmin frmAdmin = new FrmAdmin();
                frmAdmin.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập", "Lỗi");
            }
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmDoiMatKhau FrmDoiPass = new FrmDoiMatKhau(acc.UserName, acc.PassWord);
            FrmDoiPass.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogin frmLogin = new FrmLogin(); ;
            frmLogin.ShowDialog();
        }
    }
}
