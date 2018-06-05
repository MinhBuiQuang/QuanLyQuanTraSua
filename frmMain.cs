using DataAccess.fBan;
using DataAccess.fDo;
using DataAccess.fHoaDon;
using DevExpress.Utils.Drawing;
using DevExpress.XtraBars.Ribbon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLQTS
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        GalleryItemGroup group1 = new GalleryItemGroup();
        public static string TenTaiKhoan;
        private int IDHoaDon = 0;
        private int IDBan = 0;
        private DataTable DSBan = new DataTable();
        public frmMain(string tenTaiKhoan)
        {
            InitializeComponent();
            TenTaiKhoan = tenTaiKhoan;
            group1.Caption = "Bàn";
            gc.Gallery.Groups.Add(group1);
            gc.Gallery.ItemImageLayout = ImageLayoutMode.ZoomInside;
            gc.Gallery.ImageSize = new Size(120, 90);
            gc.Gallery.ShowItemText = true;
        }
        

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadDanhSachBan();
            LoadLoaiDo();
            LoadBanTrong();
        }

        private void LoadLoaiDo()
        {
            LoaiDoDAL db = new LoaiDoDAL();
            lueLoaiDo.Properties.DataSource = db.Select();
            lueLoaiDo.Properties.ValueMember = "ID";
            lueLoaiDo.Properties.DisplayMember = "TenLoai";
        }

        private void LoadDo()
        {
            DoDAL db = new DoDAL();
            lueDo.Properties.DataSource = db.Select((int)lueLoaiDo.EditValue);
            lueDo.Properties.DisplayMember = "TenDo";
            lueDo.Properties.ValueMember = "ID";
        }
        private void RefreshForm()
        {
            LoadDanhSachBan();
            LoadBanTrong();
            LoadLoaiDo();
            lueDo.Properties.DataSource = null;
        }
        private void LoadDanhSachBan()
        {
            BanDAL db = new BanDAL();
            DSBan = new DataTable();
            DSBan = db.Select();
            group1.Items.Clear();   
            if (DSBan.Rows.Count > 0)
            foreach (DataRow dr in DSBan.Rows)
            {
                GalleryItem item = new GalleryItem();
                item.Value = int.Parse(dr["ID"].ToString());
                item.Caption = dr["TenBan"].ToString();
                item.Image = bool.Parse(dr["ConTrong"].ToString()) ? QLQTS.Properties.Resources.bantrong : QLQTS.Properties.Resources.bandangdung;
                group1.Items.Add(item);
            }
                
        }
        private void LoadBanTrong()
        {
            lueBan.Properties.DataSource = new BanDAL().SelectBanTrong();
            lueBan.Properties.ValueMember = "ID";
            lueBan.Properties.DisplayMember = "TenBan";
        }
        private void LoadHoaDon()
        {
            HoaDonDAL db = new HoaDonDAL();
            DataTable dt = db.SelectChiTiet(IDHoaDon);
            DataTable dt2 = db.Select(IDHoaDon);
            gcChiTietHoaDon.DataSource = dt;
            lueBan.EditValue = dt2.Rows[0]["IDBan"];
            lbTongTien.Text = double.Parse(dt2.Rows[0]["TongTien"].ToString()).ToString("C", CultureInfo.CreateSpecificCulture("vi-VN"));
        }

        private void gc_Gallery_ItemClick(object sender, GalleryItemClickEventArgs e)
        {
            int IDBan = (int)e.Item.Value;
            try
            {
                if (IDHoaDon > 0)
                {
                    DialogResult result = new DialogResult();
                    result = MessageBox.Show("Bạn đang mở một hóa đơn khác, bạn có muốn chuyển?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        if (KiemTraBanTrong(IDBan))
                        {
                            IDHoaDon = 0;
                            lueBan.EditValue = IDBan;
                        }
                        else
                        {
                           IDHoaDon = new HoaDonDAL().GetIDHoaDon(IDBan);
                        }
                    }
                    
                    LoadHoaDon();
                }             
            }
            catch
            {

            }
        }
        

        private void btnQLBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmBanPhucVu frm = new frmBanPhucVu();
            frm.ShowDialog();
        }

        private void btnQLThucDon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmThucDon frm = new frmThucDon();
            frm.ShowDialog();
        }

        private void btnQLNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmNhanVien frm = new frmNhanVien();
            frm.ShowDialog();
        }

        private void btnMyAccount_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }

        private void btnSetting_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void lueLoaiDo_EditValueChanged(object sender, EventArgs e)
        {
            LoadDo();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            HoaDonDAL db = new HoaDonDAL();
            if (!KiemTra())
            {
                MessageBox.Show("Bạn phải điền đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (IDHoaDon == 0)
            {
                if ((String.IsNullOrWhiteSpace(lueBan.Text) && !checkMangVe.Checked))
                {
                    MessageBox.Show("Bạn phải điền đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                IDHoaDon = db.Insert(checkMangVe.Checked ? 0 : (int)lueBan.EditValue, frmMain.TenTaiKhoan);
                IDBan = lueBan.EditValue == null ? 0 : (int)lueBan.EditValue;
            }
            db.InsertChiTiet(IDHoaDon, (int)lueDo.EditValue, (int)txtSoLuong.Value);
            LoadDanhSachBan();
            LoadBanTrong();
            LoadHoaDon();
        }
        private bool KiemTra()
        {
            if (String.IsNullOrWhiteSpace(lueLoaiDo.Text) || String.IsNullOrWhiteSpace(lueDo.Text))
                return false;
            return true;
        }
        private bool KiemTraBanTrong(int IDBan)
        {
            foreach (DataRow dr in DSBan.Rows)
            {
                int ID = int.Parse(dr["ID"].ToString());
                if (ID == IDBan && bool.Parse(dr["ConTrong"].ToString()))
                {
                    return true;
                }
            }
            return false;
        }
        private void checkMangVe_CheckedChanged(object sender, EventArgs e)
        {
            if(checkMangVe.Checked)
            {
                lueBan.Enabled = false;
            }
            else
            {
                lueBan.Enabled = true;
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if(IDHoaDon != 0)
            {
                new HoaDonDAL().ThanhToan(IDHoaDon);
            }
            LoadDanhSachBan();
            MessageBox.Show("Thanh toán thành công");
            this.Refresh();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = new DialogResult();
            result = MessageBox.Show("Bạn có chắc muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                int ID = int.Parse(gvChiTietHoaDon.GetRowCellValue(gvChiTietHoaDon.FocusedRowHandle, "ID").ToString());
                new HoaDonDAL().DeleteChiTiet(ID);
            }
            LoadHoaDon();        
        }

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            if (IDHoaDon != 0 && lueBan.EditValue != null)
            {
                int IDBan = (int)lueBan.EditValue;
                if (KiemTraBanTrong(IDBan))
                {
                    new HoaDonDAL().ChuyenBan((int)lueBan.EditValue, IDHoaDon);
                    IDBan = (int)lueBan.EditValue;
                    LoadDanhSachBan();
                    LoadBanTrong();
                    LoadHoaDon(); 
                }
                else
                {
                    MessageBox.Show("Bàn đã có khách");
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn bàn!");
            }
        }
    }
}
