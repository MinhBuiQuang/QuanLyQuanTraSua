using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.fDo
{
    public class DoDAL
    {
        // select tất cả đồ
        public DataTable Select()
        {
            SqlHelper db = new SqlHelper();
            DataTable dt = new DataTable();
            dt = db.ExecuteDataSet("sp_Do_SelectAll", new SqlParameter[0]).Tables[0];
            return dt;
        }

        // select đồ theo id
        public DataTable Select(int ID)
        {
            SqlHelper db = new SqlHelper();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID", ID)
            };
            dt = db.ExecuteDataSet("sp_Do_SelectID", param).Tables[0];
            return dt;
        }

        // insert đồ
        public void Insert(string tenDo, int IDLoai, float donGia)
        {
            SqlHelper db = new SqlHelper();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@TenDo", tenDo),
                new SqlParameter("@DonGia", donGia),
                new SqlParameter("@IDLoai", IDLoai)
            };
            db.ExecuteNonQuery("sp_Do_Insert", param);
        }

        // update đồ
        public void Update(int ID, string tenDo, int IDLoai, float donGia)
        {
            SqlHelper db = new SqlHelper();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID", ID),
                new SqlParameter("@TenDo", tenDo),
                new SqlParameter("@IDLoai", IDLoai),
                new SqlParameter("@DonGia", donGia)
            };
            db.ExecuteNonQuery("sp_Do_Update", param);
        }

        // delete đồ
        public void Delete(int ID)
        {
            SqlHelper db = new SqlHelper();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID", ID)
            };
            db.ExecuteNonQuery("sp_Do_Delete");
        }
    }
}
