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
    public partial class frmThucDon : DevExpress.XtraEditors.XtraForm
    {
        bool isUpdate = false;
        public frmThucDon()
        {
            InitializeComponent();
        }
        private void LoadLoaiDo()
        {
            LoaiDoDAL db = new LoaiDoDAL();
            gcLoaiDo.DataSource = db.Select();
        }

        private void LoadDo()
        {
            DoDAL db = new DoDAL();
            gcDo.DataSource = db.Select();
        }
        private void btnThemDo_Click(object sender, EventArgs e)
        {
            frmThemDo frm = new frmThemDo();
            frm.ShowDialog();
            LoadDo();
        }

        private void btnThemLoaiDo_Click(object sender, EventArgs e)
        {
            frmThemLoaiDo frm = new frmThemLoaiDo();
            frm.ShowDialog();
            LoadLoaiDo();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = new DialogResult();
            result = MessageBox.Show("Bạn có chắc muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                int ID = int.Parse(gvDo.GetRowCellValue(gvDo.FocusedRowHandle, "ID").ToString());
                new DoDAL().Delete(ID);
            }
            LoadDo();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(gvDo.GetRowCellValue(gvDo.FocusedRowHandle, "ID").ToString());
            string tenDo = gvDo.GetRowCellValue(gvDo.FocusedRowHandle, "TenDo").ToString();
            int ID_LoaiDo = int.Parse(gvDo.GetRowCellValue(gvDo.FocusedRowHandle, "IDLoai").ToString());
            float donGia = float.Parse(gvDo.GetRowCellValue(gvDo.FocusedRowHandle, "DonGia").ToString());
            frmThemDo frm = new frmThemDo(ID, tenDo, ID_LoaiDo, donGia);
            frm.ShowDialog();
            LoadDo(); 
        }

        private void btnEditLoai_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(gvLoaiDo.GetRowCellValue(gvLoaiDo.FocusedRowHandle, "ID").ToString());
            string tenLoai = gvLoaiDo.GetRowCellValue(gvLoaiDo.FocusedRowHandle, "TenLoai").ToString();
            frmThemLoaiDo frm = new frmThemLoaiDo(ID, tenLoai);
            frm.ShowDialog();
            LoadDo();
        }

        private void btnDeleteLoai_Click(object sender, EventArgs e)
        {
            DialogResult result = new DialogResult();
            result = MessageBox.Show("Bạn có chắc muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                int ID = int.Parse(gvLoaiDo.GetRowCellValue(gvLoaiDo.FocusedRowHandle, "ID").ToString());
                new LoaiDoDAL().Delete(ID);
            }
            LoadLoaiDo();
        }

        private void frmThucDon_Load(object sender, EventArgs e)
        {
            LoadLoaiDo();
            LoadDo();
        }
    }
}