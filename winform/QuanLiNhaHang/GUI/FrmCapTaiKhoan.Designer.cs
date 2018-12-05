namespace QuanLiNhaHang.GUI
{
    partial class FrmCapTaiKhoan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtRePass = new System.Windows.Forms.TextBox();
            this.rbAdmin = new System.Windows.Forms.RadioButton();
            this.rbUser = new System.Windows.Forms.RadioButton();
            this.btDangKi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbLoiUsername = new System.Windows.Forms.Label();
            this.lbLoiPass = new System.Windows.Forms.Label();
            this.lbLoiRePass = new System.Windows.Forms.Label();
            this.lbLoiPhanQuyen = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbNotice = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(157, 46);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(139, 26);
            this.txtUsername.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên đăng nhập";
            // 
            // txtPass
            // 
            this.txtPass.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.Location = new System.Drawing.Point(157, 111);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(139, 26);
            this.txtPass.TabIndex = 6;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // txtRePass
            // 
            this.txtRePass.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRePass.Location = new System.Drawing.Point(157, 168);
            this.txtRePass.Name = "txtRePass";
            this.txtRePass.Size = new System.Drawing.Size(139, 26);
            this.txtRePass.TabIndex = 7;
            this.txtRePass.UseSystemPasswordChar = true;
            // 
            // rbAdmin
            // 
            this.rbAdmin.AutoSize = true;
            this.rbAdmin.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAdmin.Location = new System.Drawing.Point(93, 236);
            this.rbAdmin.Name = "rbAdmin";
            this.rbAdmin.Size = new System.Drawing.Size(82, 23);
            this.rbAdmin.TabIndex = 8;
            this.rbAdmin.TabStop = true;
            this.rbAdmin.Text = "Quản trị";
            this.rbAdmin.UseVisualStyleBackColor = true;
            // 
            // rbUser
            // 
            this.rbUser.AutoSize = true;
            this.rbUser.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbUser.Location = new System.Drawing.Point(190, 236);
            this.rbUser.Name = "rbUser";
            this.rbUser.Size = new System.Drawing.Size(106, 23);
            this.rbUser.TabIndex = 9;
            this.rbUser.TabStop = true;
            this.rbUser.Text = "Người dùng";
            this.rbUser.UseVisualStyleBackColor = true;
            // 
            // btDangKi
            // 
            this.btDangKi.Location = new System.Drawing.Point(145, 306);
            this.btDangKi.Name = "btDangKi";
            this.btDangKi.Size = new System.Drawing.Size(75, 23);
            this.btDangKi.TabIndex = 10;
            this.btDangKi.Text = "Đăng kí";
            this.btDangKi.UseVisualStyleBackColor = true;
            this.btDangKi.Click += new System.EventHandler(this.btDangKi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 19);
            this.label1.TabIndex = 11;
            this.label1.Text = "Xác nhận mật khẩu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(72, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 19);
            this.label3.TabIndex = 12;
            this.label3.Text = "Mật khẩu";
            // 
            // lbLoiUsername
            // 
            this.lbLoiUsername.AutoSize = true;
            this.lbLoiUsername.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoiUsername.ForeColor = System.Drawing.Color.Red;
            this.lbLoiUsername.Location = new System.Drawing.Point(161, 79);
            this.lbLoiUsername.Name = "lbLoiUsername";
            this.lbLoiUsername.Size = new System.Drawing.Size(0, 15);
            this.lbLoiUsername.TabIndex = 13;
            // 
            // lbLoiPass
            // 
            this.lbLoiPass.AutoSize = true;
            this.lbLoiPass.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoiPass.ForeColor = System.Drawing.Color.Red;
            this.lbLoiPass.Location = new System.Drawing.Point(162, 143);
            this.lbLoiPass.Name = "lbLoiPass";
            this.lbLoiPass.Size = new System.Drawing.Size(0, 15);
            this.lbLoiPass.TabIndex = 14;
            // 
            // lbLoiRePass
            // 
            this.lbLoiRePass.AutoSize = true;
            this.lbLoiRePass.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoiRePass.ForeColor = System.Drawing.Color.Red;
            this.lbLoiRePass.Location = new System.Drawing.Point(162, 202);
            this.lbLoiRePass.Name = "lbLoiRePass";
            this.lbLoiRePass.Size = new System.Drawing.Size(0, 15);
            this.lbLoiRePass.TabIndex = 15;
            // 
            // lbLoiPhanQuyen
            // 
            this.lbLoiPhanQuyen.AutoSize = true;
            this.lbLoiPhanQuyen.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoiPhanQuyen.ForeColor = System.Drawing.Color.Red;
            this.lbLoiPhanQuyen.Location = new System.Drawing.Point(141, 271);
            this.lbLoiPhanQuyen.Name = "lbLoiPhanQuyen";
            this.lbLoiPhanQuyen.Size = new System.Drawing.Size(0, 15);
            this.lbLoiPhanQuyen.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(113, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 19);
            this.label8.TabIndex = 17;
            this.label8.Text = "Đăng kí tài khoản";
            // 
            // lbNotice
            // 
            this.lbNotice.AutoSize = true;
            this.lbNotice.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNotice.ForeColor = System.Drawing.Color.Red;
            this.lbNotice.Location = new System.Drawing.Point(105, 347);
            this.lbNotice.Name = "lbNotice";
            this.lbNotice.Size = new System.Drawing.Size(0, 15);
            this.lbNotice.TabIndex = 18;
            // 
            // FrmCapTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 413);
            this.Controls.Add(this.lbNotice);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbLoiPhanQuyen);
            this.Controls.Add(this.lbLoiRePass);
            this.Controls.Add(this.lbLoiPass);
            this.Controls.Add(this.lbLoiUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btDangKi);
            this.Controls.Add(this.rbUser);
            this.Controls.Add(this.rbAdmin);
            this.Controls.Add(this.txtRePass);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUsername);
            this.Name = "FrmCapTaiKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng kí";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtRePass;
        private System.Windows.Forms.RadioButton rbAdmin;
        private System.Windows.Forms.RadioButton rbUser;
        private System.Windows.Forms.Button btDangKi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbLoiUsername;
        private System.Windows.Forms.Label lbLoiPass;
        private System.Windows.Forms.Label lbLoiRePass;
        private System.Windows.Forms.Label lbLoiPhanQuyen;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbNotice;
    }
}