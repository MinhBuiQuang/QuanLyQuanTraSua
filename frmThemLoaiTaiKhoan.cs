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

namespace QLQTS
{
    public partial class frmThemLoaiTaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        private bool isUpdate;
        private int ID;
        public frmThemLoaiTaiKhoan()
        {
            InitializeComponent();
            isUpdate = false;
        }

        public frmThemLoaiTaiKhoan(int ID, string tenLoai)
        {
            InitializeComponent();
            isUpdate = true;
            this.ID = ID;
            txtTenLoai.Text = tenLoai;
        }

        private bool KiemTra()
        {
            bool result = true;
            if (String.IsNullOrWhiteSpace(txtTenLoai.Text))
            {
                result = false;
            }
            return result;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (KiemTra())
            {
                LoaiTaiKhoanDAL db = new LoaiTaiKhoanDAL();
                if (isUpdate)
                {
                    db.Update(ID, txtTenLoai.Text);
                    MessageBox.Show("Cập nhật thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
                else
                {
                    db.Insert(txtTenLoai.Text);
                    MessageBox.Show("Thêm mới thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenLoai.Text = String.Empty;
                }
            }
            else
            {
                MessageBox.Show("Bạn phải điền đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}