using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DataAccess.fTaiKhoan;

namespace QLQTS
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            TaiKhoanDAL db = new TaiKhoanDAL();
            bool hopLe = false;
            if( String.IsNullOrWhiteSpace(txtTenDangNhap.Text)  || String.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không được để trống hoặc khoảng trắng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            hopLe = db.KiemTraDangNhap(txtTenDangNhap.Text, txtMatKhau.Text);
            if(hopLe)
            {
                frmMain frm = new frmMain(txtTenDangNhap.Text);
                this.Hide();
                frm.Show();
            } else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtMatKhau.Properties.PasswordChar = '*';
        }
    }
}