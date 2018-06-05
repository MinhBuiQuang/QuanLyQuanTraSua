using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.fBan
{
    public class BanDAL
    {
        // select tất cả bàn
        public DataTable Select()
        {
            SqlHelper db = new SqlHelper();
            DataTable dt = new DataTable();
            dt = db.ExecuteDataSet("sp_Ban_SelectAll", new SqlParameter[0]).Tables[0];
            return dt;
        }

        public DataTable SelectBanTrong()
        {
            SqlHelper db = new SqlHelper();
            DataTable dt = new DataTable();
            dt = db.ExecuteDataSet("sp_Ban_SelectBanTrong", new SqlParameter[0]).Tables[0];
            return dt;
        }

        // select bàn theo id
        public DataTable Select(int ID)
        {
            SqlHelper db = new SqlHelper();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID", ID)
            };
            dt = db.ExecuteDataSet("sp_Ban_SelectID", param).Tables[0];
            return dt;
        }
        // insert bàn
        public void Insert(string tenBan)
        {
            SqlHelper db = new SqlHelper();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@TenBan", tenBan)
            };
            db.ExecuteNonQuery("sp_Ban_Insert", param);
        }

        // update bàn
        public void Update(int ID, string tenBan)
        {
            SqlHelper db = new SqlHelper();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID", ID),
                new SqlParameter("@TenBan", String.IsNullOrWhiteSpace(tenBan) ? (object)DBNull.Value : tenBan)
            };
            db.ExecuteNonQuery("sp_Ban_Update", param);
        }

        public void Update(int ID, bool conTrong)
        {
            SqlHelper db = new SqlHelper();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID", ID),
                new SqlParameter("@ConTrong", conTrong)
            };
            db.ExecuteNonQuery("sp_Ban_Update", param);
        }

        // delete bàn
        public void Delete(int ID)
        {
            SqlHelper db = new SqlHelper();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ID", ID)
            };
            db.ExecuteNonQuery("sp_Ban_Delete", param);
        }
    }
}
