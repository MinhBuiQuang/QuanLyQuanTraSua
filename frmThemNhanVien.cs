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
using DataAccess.fLoaiTaiKhoan;
using DataAccess.fNhanVien;

namespace QLQTS
{
    public partial class frmThemNhanVien : DevExpress.XtraEditors.XtraForm
    {
        private bool isUpdate;

        public frmThemNhanVien()
        {
            InitializeComponent();
            LoaiTaiKhoanDAL db = new LoaiTaiKhoanDAL();
            lueGioiTinh.Properties.DataSource = db.SelectGioiTinh();
            lueGioiTinh.Properties.DisplayMember = "Value";
            lueGioiTinh.Properties.ValueMember = "ID";
            lueLoaiTaiKhoan.Properties.DataSource = db.Select();
            lueLoaiTaiKhoan.Properties.DisplayMember = "TenLoai";
            lueLoaiTaiKhoan.Properties.ValueMember = "ID";
            isUpdate = false;
        }
        public frmThemNhanVien(string tenTaiKhoan, string hoTen, DateTime ngaySinh, int gioiTinh, string sdt, string email, DateTime ngayVaoLam, string matKhau, int loaiTaiKhoan)
        {
            InitializeComponent();
            LoaiTaiKhoanDAL db = new LoaiTaiKhoanDAL();
            lueGioiTinh.Properties.DataSource = db.SelectGioiTinh();
            lueGioiTinh.Properties.DisplayMember = "Value";
            lueGioiTinh.Properties.ValueMember = "ID";
            lueLoaiTaiKhoan.Properties.DataSource = db.Select();
            lueLoaiTaiKhoan.Properties.DisplayMember = "TenLoai";
            lueLoaiTaiKhoan.Properties.ValueMember = "ID";

            isUpdate = true;
            txtTenTaiKhoan.Text = tenTaiKhoan;
            txtTenTaiKhoan.Enabled = false;
            txtHoTen.Text = hoTen;
            deNgaySinh.DateTime = ngaySinh;
            deNgayVaoLam.DateTime = ngayVaoLam;
            lueGioiTinh.EditValue = gioiTinh;
            lueLoaiTaiKhoan.EditValue = loaiTaiKhoan;
            txtSDT.Text = sdt;
            txtEmail.Text = email;
            txtMatKhau.Text = matKhau;
        }

        private void frmThemNhanVien_Load(object sender, EventArgs e)
        {
            txtMatKhau.PasswordChar = '*';
        }
        private void RefreshText()
        {
            txtTenTaiKhoan.Text = String.Empty;
            txtHoTen.Text = String.Empty;
            txtSDT.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtMatKhau.Text = String.Empty;
        }
        private bool KiemTra()
        {
            bool result = true;
            if (String.IsNullOrWhiteSpace(txtTenTaiKhoan.Text) || String.IsNullOrWhiteSpace(txtHoTen.Text) || String.IsNullOrWhiteSpace(deNgaySinh.Text) || 
                String.IsNullOrWhiteSpace(deNgayVaoLam.Text) || String.IsNullOrWhiteSpace(deNgaySinh.Text) || String.IsNullOrWhiteSpace(deNgayVaoLam.Text) ||
                String.IsNullOrWhiteSpace(lueGioiTinh.Text) || String.IsNullOrWhiteSpace(lueLoaiTaiKhoan.Text) || String.IsNullOrWhiteSpace(txtSDT.Text) ||
                String.IsNullOrWhiteSpace(txtEmail.Text) || String.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                result = false;
            }
            return result;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (KiemTra())
            {
                NhanVienDAL nv = new NhanVienDAL();
                if(isUpdate)
                {
                    nv.Update(txtTenTaiKhoan.Text, txtHoTen.Text, deNgaySinh.DateTime, (int)lueGioiTinh.EditValue, txtSDT.Text, txtEmail.Text, deNgayVaoLam.DateTime, txtMatKhau.Text, (int)lueLoaiTaiKhoan.EditValue);
                    MessageBox.Show("Cập nhật thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
                else
                {
                    nv.Insert(txtTenTaiKhoan.Text, txtHoTen.Text, deNgaySinh.DateTime, (int)lueGioiTinh.EditValue, txtSDT.Text, txtEmail.Text, deNgayVaoLam.DateTime, txtMatKhau.Text, (int)lueLoaiTaiKhoan.EditValue);
                    MessageBox.Show("Thêm mới thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshText();
                }
            }
            else
            {
                MessageBox.Show("Bạn phải điền đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}