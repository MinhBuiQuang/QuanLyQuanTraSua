using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.fLoaiTaiKhoan
{
    public class LoaiTaiKhoanDAL
    {
        // select thông tin tất cả các tài khoản
        public DataTable Select()
        {
            SqlHelper db = new SqlHelper();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[0];
            dt = db.ExecuteDataSet("sp_LoaiTaiKhoan_SelectAll", param).Tables[0];
            return dt;
        }

        public DataTable SelectGioiTinh()
        {
            SqlHelper db = new SqlHelper();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[0];
            dt = db.ExecuteDataSet("sp_GioiTinh_SelectAll", param).Tables[0];
            return dt;
        }

        public void Insert(string loaiTaiKhoan)
        {
            SqlHelper db = new SqlHelper();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@TenLoai", loaiTaiKhoan)
            };
            db.ExecuteNonQuery("sp_LoaiTaiKhoan_Insert", param);
        }
        
        public void Update(int ID, string loaiTaiKhoan)
        {
            SqlHelper db = new SqlHelper();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID", ID),
                new SqlParameter("@TenLoai", loaiTaiKhoan)
            };
            db.ExecuteNonQuery("sp_LoaiTaiKhoan_Update", param);
        }
        
        public void Delete(int ID)
        {
            SqlHelper db = new SqlHelper();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID", ID)
            };
            db.ExecuteNonQuery("sp_LoaiTaiKhoan_Delete", param);
        }
    }
}
