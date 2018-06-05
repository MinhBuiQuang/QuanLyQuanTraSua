using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SqlHelper
    {
        // làm việc với Database
        private string ConnectionString = ConfigurationManager.AppSettings["CONSTR"];
        public DataSet ExecuteDataSet(string procName, params SqlParameter[] procParams)
        {
            SqlConnection conn = null;
            SqlDataAdapter adapter = null;
            DataSet ds = new DataSet();
            SqlCommand cmd = null;
            string paramName = "";
            try
            {
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand(procName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                if (procParams != null)
                {
                    for (int i = 0; i < procParams.Length; i++)
                    {
                        cmd.Parameters.Add(procParams[i]);
                        paramName += procParams[i].ParameterName + ":" + procParams[i].Value + "|";
                    }
                }
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {
                //log.Error("Command:" + cmd.CommandText + ",Command Parameter:" + paramName);
                //log.Error(ex);

                throw ex;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                }
                if (adapter != null)
                {
                    adapter.Dispose();

                }
                if (conn != null && conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }

            return ds;
        }

        public int ExecuteNonQuery(string procName, params SqlParameter[] procParams)
        {
            SqlCommand cmd = null;
            SqlConnection conn = null;
            int affectedRows = 0;
            string paramName = "";
            try
            {
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = procName;
                cmd.CommandType = CommandType.StoredProcedure;
                if (procParams != null)
                {
                    for (int i = 0; i < procParams.Length; i++)
                    {
                        cmd.Parameters.Add(procParams[i]);
                        paramName += procParams[i].ParameterName + ":" + procParams[i].Value + "|";
                    }
                }
                affectedRows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //log.Error("Command:" + cmd.CommandText + ",Command Parameter:" + paramName);
                //log.Error(ex);

                throw ex;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                }
                if (conn != null && conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return affectedRows;
        }

     

        public int ExcuteCheck(string procName, ref int check, params SqlParameter[] procParams)
        {
            SqlCommand cmd = null;
            SqlConnection conn = null;
            //int affectedRows = 0;
            check = 0;
            string paramName = "";
            try
            {
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = procName;
                cmd.CommandType = CommandType.StoredProcedure;
                if (procParams != null)
                {
                    for (int i = 0; i < procParams.Length; i++)
                    {
                        cmd.Parameters.Add(procParams[i]);
                        paramName += procParams[i].ParameterName + ":" + procParams[i].Value + "|";
                    }
                }
                SqlParameter pCheck = new SqlParameter("@check", SqlDbType.Int);
                pCheck.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pCheck);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                check = (int)pCheck.Value;

                //affectedRows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //log.Error("Command:" + cmd.CommandText + ",Command Parameter:" + paramName);
                //log.Error(ex);

                throw ex;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                }
                if (conn != null && conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return check;
        }

        public double ExcuteCheck(string procName, ref double check, params SqlParameter[] procParams)
        {
            SqlCommand cmd = null;
            SqlConnection conn = null;
            //int affectedRows = 0;
            check = 0;
            string paramName = "";
            try
            {
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = procName;
                cmd.CommandType = CommandType.StoredProcedure;
                if (procParams != null)
                {
                    for (int i = 0; i < procParams.Length; i++)
                    {
                        cmd.Parameters.Add(procParams[i]);
                        paramName += procParams[i].ParameterName + ":" + procParams[i].Value + "|";
                    }
                }
                SqlParameter pCheck = new SqlParameter("@check", SqlDbType.Int);
                pCheck.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pCheck);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                check = (double)pCheck.Value;

                //affectedRows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //log.Error("Command:" + cmd.CommandText + ",Command Parameter:" + paramName);
                //log.Error(ex);

                throw ex;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                }
                if (conn != null && conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return check;
        }

        public bool Convert_Bool(int so)
        {
            if (so == 0) return false;
            return true;
        }


        //kiểm tra dữ liệu
        public bool KiemTraNull_String(string chuoi)
        {
            if (chuoi == null) return true;
            else return false;
        }

        public bool KiemTraNull_Int(int so)
        {
            if (so == 0) return true;
            else return false;
        }

        public bool KiemTraNull_Date(DateTime ngay)
        {
            if (ngay == null) return true;
            else return false;
        }

        public bool KiemTra_SoDienThoai(string SDT)
        {
            if (SDT.Length < 10 || SDT.Length > 15)
                return false;
            return true;
        }
    }
}
