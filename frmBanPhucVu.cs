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
using DataAccess.fBan;

namespace QLQTS
{
    public partial class frmBanPhucVu : DevExpress.XtraEditors.XtraForm
    {
        bool isUpdate = false;
        public frmBanPhucVu()
        {
            InitializeComponent();
        }
        private void frmBanPhucVu_Load(object sender, EventArgs e)
        {
            LoadBan();
        }
        private void LoadBan()
        {
            BanDAL db = new BanDAL();
            gc.DataSource = db.Select();
        }
        private void LamMoi()
        {
            txtTenBan.Text = String.Empty;
        }
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            isUpdate = false;
            LamMoi();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtTenBan.Text))
                MessageBox.Show("Bạn phải điền đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else
            {
                BanDAL db = new BanDAL();
                if (isUpdate)
                {
                    int ID = int.Parse(gv.GetRowCellValue(gv.FocusedRowHandle, "ID").ToString());
                    db.Update(ID, txtTenBan.Text);
                    isUpdate = false;
                }
                else
                {
                    db.Insert(txtTenBan.Text);
                }
                LamMoi();
                LoadBan();
            }            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = new DialogResult();
            result = MessageBox.Show("Bạn có chắc muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                int ID = int.Parse(gv.GetRowCellValue(gv.FocusedRowHandle, "ID").ToString());
                new BanDAL().Delete(ID);
            }
            LoadBan();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            isUpdate = true;
            string tenBan = gv.GetRowCellValue(gv.FocusedRowHandle, "TenBan").ToString();
            txtTenBan.Text = tenBan;
        }


    }
}