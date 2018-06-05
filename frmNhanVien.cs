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
using DataAccess.fNhanVien;
using DataAccess.fLoaiTaiKhoan;

namespace QLQTS
{
    public partial class frmNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public object NhanVienDAl { get; private set; }

        public frmNhanVien()
        {
            InitializeComponent();
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadLoaiTaiKhoan();
            LoadNhanVien();
        }
        private void LoadNhanVien()
        {
            NhanVienDAL db = new NhanVienDAL();
            gcNV.DataSource = db.Select();
        }
        private void LoadLoaiTaiKhoan()
        {
            LoaiTaiKhoanDAL db = new LoaiTaiKhoanDAL();
            gcLoaiTK.DataSource = db.Select();
        }
        private void btnThemNV_Click(object sender, EventArgs e)
        {
            frmThemNhanVien frm = new frmThemNhanVien();
            frm.ShowDialog();
            LoadNhanVien();
        }

        private void btnThemLoaiTK_Click(object sender, EventArgs e)
        {
            frmThemLoaiTaiKhoan frm = new frmThemLoaiTaiKhoan();
            frm.ShowDialog();
            LoadLoaiTaiKhoan();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = new DialogResult();
            result = MessageBox.Show("Bạn có chắc muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                string tenDangNhap = gvNV.GetRowCellValue(gvNV.FocusedRowHandle, "TenDangNhap").ToString();
                new NhanVienDAL().Delete(tenDangNhap);
            }
            LoadLoaiTaiKhoan();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string tenDangNhap = gvNV.GetRowCellValue(gvNV.FocusedRowHandle, "TenDangNhap").ToString();
            int loaiTK = int.Parse(gvNV.GetRowCellValue(gvNV.FocusedRowHandle, "LoaiTaiKhoan").ToString());
            int gioiTinh = int.Parse(gvNV.GetRowCellValue(gvNV.FocusedRowHandle, "ID_GioiTinh").ToString());
            string soDienThoai = gvNV.GetRowCellValue(gvNV.FocusedRowHandle, "SDT").ToString();
            string email = gvNV.GetRowCellValue(gvNV.FocusedRowHandle, "Email").ToString();
            string hoTen = gvNV.GetRowCellValue(gvNV.FocusedRowHandle, "HoTen").ToString();
            string matKhau = gvNV.GetRowCellValue(gvNV.FocusedRowHandle, "MatKhau").ToString();
            DateTime ngaySinh = DateTime.Parse(gvNV.GetRowCellValue(gvNV.FocusedRowHandle, "NgaySinh").ToString());
            DateTime ngayVaoLam = DateTime.Parse(gvNV.GetRowCellValue(gvNV.FocusedRowHandle, "NgayVaoLam").ToString());

            frmThemNhanVien frm = new frmThemNhanVien(tenDangNhap, hoTen, ngaySinh, gioiTinh, soDienThoai, email, ngayVaoLam, matKhau, loaiTK);
            frm.ShowDialog();
            LoadNhanVien();
        }

        private void btnEditLoai_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(gvLoaiTK.GetRowCellValue(gvLoaiTK.FocusedRowHandle, "ID").ToString());
            string tenLoai = gvLoaiTK.GetRowCellValue(gvLoaiTK.FocusedRowHandle, "TenLoai").ToString();
            frmThemLoaiTaiKhoan frm = new frmThemLoaiTaiKhoan(ID, tenLoai);
            frm.ShowDialog();
            LoadLoaiTaiKhoan();
        }

        private void btnDeleteLoai_Click(object sender, EventArgs e)
        {
            DialogResult result = new DialogResult();
            result = MessageBox.Show("Bạn có chắc muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                int ID = int.Parse(gvLoaiTK.GetRowCellValue(gvLoaiTK.FocusedRowHandle, "ID").ToString());
                new LoaiTaiKhoanDAL().Delete(ID);
            }
            LoadLoaiTaiKhoan();
        }
    }
}