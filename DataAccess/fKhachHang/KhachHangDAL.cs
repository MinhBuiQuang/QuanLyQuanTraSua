using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.fKhachHang
{
    public class KhachHangDAL
    {
        // select thông tin tất cả khách hàng
        public DataTable Select()
        {
            SqlHelper db = new SqlHelper();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[0];
            dt = db.ExecuteDataSet("sp_KhachHang_SelectAll", param[0]).Tables[0];
            return dt;
        }

        // select thông tin khách hàng theo id
        public DataTable Select(int ID)
        {
            SqlHelper db = new SqlHelper();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID", ID)
            };
            dt = db.ExecuteDataSet("sp_KhachHang_SelectID", param).Tables[0];
            return dt;
        }

        // insert khách hàng
        public void Insert(int ID, string hoTen, DateTime ngaySinh, int gioiTinh, int SDT, string Email)
        {
            SqlHelper db = new SqlHelper();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID", ID),
                new SqlParameter("@HoTen", hoTen),
                new SqlParameter("@NgaySinh", ngaySinh),
                new SqlParameter("@GioiTinh", gioiTinh),
                new SqlParameter("@Email", Email)
            };
            db.ExecuteNonQuery("sp_KhachHang_Insert");
        }

        // update khách hàng
        public void Update(int ID, string hoTen, DateTime ngaySinh, int gioiTinh, int SDT, string Email)
        {
            SqlHelper db = new SqlHelper();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID", ID),
                new SqlParameter("@HoTen", hoTen),
                new SqlParameter("@NgaySinh", ngaySinh),
                new SqlParameter("@GioiTinh", gioiTinh),
                new SqlParameter("@Email", Email)
            };
            db.ExecuteNonQuery("sp_KhachHang_Update");
        }

        // delete khách hàng
        public void Delete(int ID)
        {
            SqlHelper db = new SqlHelper();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID", ID)
            };
            db.ExecuteNonQuery("sp_KhachHang_Delete");
        }
    }
}
