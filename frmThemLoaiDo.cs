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
using DataAccess.fDo;

namespace QLQTS
{
    public partial class frmThemLoaiDo : DevExpress.XtraEditors.XtraForm
    {
        private bool isUpdate;
        private int ID;
        public frmThemLoaiDo()
        {
            InitializeComponent();
            isUpdate = false;
        }

        public frmThemLoaiDo(int ID, string TenLoai)
        {
            InitializeComponent();
            isUpdate = true;
            this.ID = ID;
            txtTenLoaiDo.Text = TenLoai;
        }

        private bool KiemTra()
        {
            bool result = true;
            if (String.IsNullOrWhiteSpace(txtTenLoaiDo.Text))
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
            LoaiDoDAL db = new LoaiDoDAL();
            if (KiemTra())
            {
                if (isUpdate)
                {
                    db.Update(ID, txtTenLoaiDo.Text);
                    MessageBox.Show("Cập nhật thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
                else
                {
                    db.Insert(txtTenLoaiDo.Text);
                    MessageBox.Show("Thêm mới thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenLoaiDo.Text = String.Empty;
                }                
            }
            else
            {
                MessageBox.Show("Bạn phải điền đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }            
        }
    }
}