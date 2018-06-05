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
    public partial class frmThemDo : DevExpress.XtraEditors.XtraForm
    {
        private bool isUpdate;
        private int ID;
        public frmThemDo()
        {
            InitializeComponent();
            isUpdate = false;
        }
        public frmThemDo(int ID, string tenDo, int ID_LoaiDo, float donGia)
        {
            InitializeComponent();
            isUpdate = true;
            this.ID = ID;
            txtTenDo.Text = tenDo;
            txtDonGia.EditValue = donGia;
            lueLoaiDo.EditValue = ID_LoaiDo;
        }
        private void frmThemDo_Load(object sender, EventArgs e)
        {
            LoaiDoDAL db = new LoaiDoDAL();
            lueLoaiDo.Properties.DataSource = db.Select();
            lueLoaiDo.Properties.DisplayMember = "TenLoai";
            lueLoaiDo.Properties.ValueMember = "ID";
        }
        private bool KiemTra()
        {
            bool result = true;
            if (String.IsNullOrWhiteSpace(txtTenDo.Text) || String.IsNullOrWhiteSpace(txtDonGia.Text) || float.Parse(txtDonGia.Text) == 0 || String.IsNullOrWhiteSpace(lueLoaiDo.Text))
            {
                result = false;
            }
            return result;
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            DoDAL db = new DoDAL();            
            if (KiemTra())
            {
                int IDLoaiDo = (int)lueLoaiDo.EditValue;
                if (isUpdate)
                {
                    db.Update(ID, txtTenDo.Text, IDLoaiDo, float.Parse(txtDonGia.Text));
                    MessageBox.Show("Cập nhật thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
                else
                {
                    db.Insert(txtTenDo.Text, IDLoaiDo, float.Parse(txtDonGia.Text));
                    MessageBox.Show("Thêm mới thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenDo.Text = String.Empty;
                    txtDonGia.Text = String.Empty;
                }
            }
            else
                MessageBox.Show("Bạn phải điền đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}