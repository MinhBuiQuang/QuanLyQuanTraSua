using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.fHoaDon
{
    public class HoaDonDAL
    {
        public int Insert(int IDBan, string tenTaiKhoan)
        {
            SqlHelper db = new SqlHelper();
            SqlParameter IDBanOut = new SqlParameter("@IDHoaDon", System.Data.SqlDbType.Int);
            IDBanOut.Direction = System.Data.ParameterDirection.Output;
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ThoiGian", DateTime.Now),
                new SqlParameter("@IDBan", IDBan == 0 ? (object)DBNull.Value : IDBan),
                new SqlParameter("@NguoiBan", tenTaiKhoan),
                IDBanOut
            };
            db.ExecuteNonQuery("sp_HoaDon_Insert", param);
            return (int)IDBanOut.Value;
        }
        
        public void InsertChiTiet(int IDHoaDon, int IDDo, int SoLuong)
        {
            SqlHelper db = new SqlHelper();
            SqlParameter[] pa = new SqlParameter[]
            {
                new SqlParameter("@IDHoaDon", IDHoaDon),
                new SqlParameter("@IDDo", IDDo),
                new SqlParameter("@SoLuong", SoLuong)
            };
            db.ExecuteNonQuery("sp_ChiTietHoaDon_Insert", pa);
        }
        public DataTable Select(int IDHoaDon)
        {
            SqlHelper db = new SqlHelper();
            DataTable dt = new DataTable();
            dt = db.ExecuteDataSet("sp_HoaDon_SelectID", new SqlParameter("@IDHoaDon", IDHoaDon)).Tables[0];
            return dt;
        }
        public DataTable SelectChiTiet(int IDHoaDon)
        {
            SqlHelper db = new SqlHelper();
            DataTable dt = new DataTable();
            dt = db.ExecuteDataSet("sp_ChiTietHoaDon_Select", new SqlParameter("@IDHoaDon", IDHoaDon)).Tables[0];
            return dt;
        }
        public void DeleteChiTiet(int ID)
        {
            SqlHelper db = new SqlHelper();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID", ID)
            };
            db.ExecuteNonQuery("sp_ChiTietHoaDon_Delete", param);
        }

        public void ThanhToan(int IDHoaDon)
        {
            SqlHelper db = new SqlHelper();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@IDHoaDon", IDHoaDon)
            };
            db.ExecuteNonQuery("sp_ThanhToan", param);
        }

        public int GetIDHoaDon(int IDBan)
        {
            SqlHelper db = new SqlHelper();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@IDBan", IDBan)
            };
            DataTable dt = db.ExecuteDataSet("sp_Ban_GetHoaDon", param).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return int.Parse(dt.Rows[0]["IDHoaDon"].ToString());
            }
            return 0;
        }

        public void ChuyenBan(int IDBan, int IDHoaDon)
        {
            SqlHelper db = new SqlHelper();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@IDHoaDon", IDHoaDon),
                new SqlParameter("@IDBan", IDBan)
            };
            db.ExecuteNonQuery("sp_ChuyenBan", param);
        }
    }
}
