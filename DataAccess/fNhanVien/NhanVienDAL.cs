using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.fNhanVien
{
    public class NhanVienDAL
    {
        // select thông tin của tất cả nhân viên
        public DataTable Select()
        {
            SqlHelper db = new SqlHelper();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[0];
            dt = db.ExecuteDataSet("sp_NhanVien_SelectAll", param).Tables[0];
            return dt;
        }

        // select thông tin nhân viên theo id
        public DataTable Select(string TenDangNhap)
        {
            SqlHelper db = new SqlHelper();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@TenDangNhap", TenDangNhap)
            };
            dt = db.ExecuteDataSet("sp_NhanVien_SelectID", param).Tables[0];
            return dt;
        }
        // insert nhân viên
        public void Insert(string tenDangNhap, string hoTen, DateTime ngaySinh, int gioiTinh, string SDT, string Email, DateTime ngayVaoLam, string matKhau, int loaiTaiKhoan)
        {
            SqlHelper db = new SqlHelper();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@TenDangNhap", tenDangNhap),
                new SqlParameter("@HoTen", hoTen),
                new SqlParameter("@NgaySinh", ngaySinh),
                new SqlParameter("@GioiTinh",gioiTinh),
                new SqlParameter("@SDT", SDT),
                new SqlParameter("@Email", Email),
                new SqlParameter("@NgayVaoLam", ngayVaoLam),
                new SqlParameter("@MatKhau", matKhau),
                new SqlParameter("@LoaiTaiKhoan", loaiTaiKhoan)
            };
            db.ExecuteNonQuery("sp_NhanVien_Insert", param);
        }

        // update nhân viên
        public void Update(string tenDangNhap, string hoTen, DateTime ngaySinh, int gioiTinh, string SDT, string Email, DateTime ngayVaoLam, string matKhau, int loaiTaiKhoan)
        {
            SqlHelper db = new SqlHelper();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@TenDangNhap", tenDangNhap),
                new SqlParameter("@HoTen", hoTen),
                new SqlParameter("@NgaySinh", ngaySinh),
                new SqlParameter("@GioiTinh",gioiTinh),
                new SqlParameter("@SDT", SDT),
                new SqlParameter("@Email", Email),
                new SqlParameter("@NgayVaoLam", ngayVaoLam),
                new SqlParameter("@MatKhau", matKhau),
                new SqlParameter("@LoaiTaiKhoan", loaiTaiKhoan)
            };
            db.ExecuteNonQuery("sp_NhanVien_Update", param);
        }

        // delete nhân viên
        public void Delete(string tenDangNhap)
        {
            SqlHelper db = new SqlHelper();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@TenDangNhap", tenDangNhap)
            };
            db.ExecuteNonQuery("sp_NhanVien_Delete", param);
        }
    }
}
