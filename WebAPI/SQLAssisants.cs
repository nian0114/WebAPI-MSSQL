using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI
{
    public class SQLAssisants
    {
        public static string Query(string ip, string catalog, string table_name, string condition)
        {
            try
            {
                SqlConnection sqlConnection =
                    new SqlConnection(
                        "Data Source=" + ip + ";Initial Catalog=" + catalog + ";Persist Security Info=False;User Id=sa;Password=123456");
                sqlConnection.Open();
                /*
                 * if(condition==""){
                    string sql = "select * from source";
                }else{
                    string sql = "select * from source where"+condition;
                }
                */
                string sql = "select * from " + table_name + (condition == "" ? "" : " where ") + condition;
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                sqlDataAdapter.Fill(dataSet, table_name);
                DataTable dt = dataSet.Tables[table_name];
                string json = JsonConvert.SerializeObject(dt, Formatting.Indented);
                return json;

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        /*
         *private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {

            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

        public static SqlDataReader ExecuteReader(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection("Data Source=192.168.2.176;Initial Catalog=Sources;Persist Security Info=False;User Id=sa;Password=123456");
            try
            {
                PrepareCommand(cmd, conn, cmdType, cmdText, commandParameters);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }

        }
        */
    }
}
