using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.fTaiKhoan
{
    public class TaiKhoanDAL
    {
        // select thông tin tất cả các tài khoản
        public DataTable Select()
        {
            SqlHelper db = new SqlHelper();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[0];
            dt = db.ExecuteDataSet("sp_TaiKhoan_SelectAll", param).Tables[0];
            return dt;
        }
        // select thông tin tài khoản theo tên đăng nhập
        public DataTable Select(string TenDangNhap)
        {
            SqlHelper db = new SqlHelper();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@TenDangNhap", TenDangNhap)
            };
            dt = db.ExecuteDataSet("sp_TaiKhoan_SelectID", param).Tables[0];
            return dt;
        }
        public bool KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            //Hàm hỗ trợ kết nối
            SqlHelper db = new SqlHelper();
            //Biến trạng thái trả về
            bool trangThai = false;
            //Tạo parameter output (phải tạo ngoài vì là output)
            SqlParameter trangThaiOut = new SqlParameter("@TrangThai", System.Data.SqlDbType.Bit);
            trangThaiOut.Direction = System.Data.ParameterDirection.Output; //Set kiểu parameter là out
            //Tạo 1 mảng chứa các parameter để truyền vào
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@TenDangNhap", tenDangNhap), //Đối tượng parameter input @TenDangNhap nvarchar(100)
                new SqlParameter("@MatKhau", matKhau), //Đối tượng parameter input @MatKhau nvarchar(100)
                trangThaiOut //Đối tượng parameter output @TrangThai bit out
            };
            // Chạy câu truy vấn
            db.ExecuteNonQuery("sp_KiemTraDangNhap", param);
            // Lấy ra giá trị output từ câu truy vấn (ở câu truy vấn trả về biến kiểu bit (@TrangThai bit out) nên ép kiểu ở phần mềm là bool
            trangThai = (bool)trangThaiOut.Value;
            return trangThai;
        }

        // insert tài khoản
        public void Insert(string tenDangNhap, string matKhau, string tenHienThi, int loaiTaiKhoan)
        {
            SqlHelper db = new SqlHelper();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@TenDangNhap", tenDangNhap),
                new SqlParameter("@MatKhau", matKhau),
                new SqlParameter("@LoaiTaiKhoan", loaiTaiKhoan)
            };
            db.ExecuteNonQuery("sp_TaiKhoan_Insert", param);
        }

        // update tài khoản
        public void Update(string tenDangNhap, string matKhau, string tenHienThi, int loaiTaiKhoan)
        {
            SqlHelper db = new SqlHelper();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@TenDangNhap", tenDangNhap),
                new SqlParameter("@MatKhau", matKhau),
                new SqlParameter("@LoaiTaiKhoan", loaiTaiKhoan)
            };
            db.ExecuteNonQuery("sp_TaiKhoan_Update");
        }

        // Xóa tài khoản
        public void Delete(string tenDangNhap)
        {
            SqlHelper db = new SqlHelper();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@TenDangNhap", tenDangNhap)
            };
            db.ExecuteNonQuery("sp_TaiKhoan_Delete");
        }
    }
}
