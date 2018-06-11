using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            try
            {
                SqlConnection sqlConnection =
                    new SqlConnection(
                        "Data Source=192.168.2.176;Initial Catalog=Sources;Persist Security Info=False;User Id=sa;Password=123456");
                sqlConnection.Open();
                string sql = "select * from source";
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                sqlDataAdapter.Fill(dataSet, "fuck");
                DataTable dt = dataSet.Tables["fuck"];
                string json = JsonConvert.SerializeObject(dt, Formatting.Indented);
                return json;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            try
            {
                SqlConnection sqlConnection =
                    new SqlConnection(
                        "Data Source=192.168.2.176;Initial Catalog=Sources;Persist Security Info=False;User Id=sa;Password=123456");
                sqlConnection.Open();
                string sql = "select * from users";
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
                sqlDataAdapter.Fill(dataSet, "users");
                DataTable dt = dataSet.Tables["users"];
                string json = JsonConvert.SerializeObject(dt, Formatting.Indented);
                return json;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        /*

        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
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

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id){
            string sql = "select * from fuck";
            SqlParameter[] sqlparameter ={
             new SqlParameter("@id",SqlDbType.Int)
                                        };
            sqlparameter[0].Direction = ParameterDirection.Input;
            sqlparameter[0].Value = id;
            SqlDataReader dr = ExecuteReader(CommandType.Text, sql, sqlparameter);
            if (dr.Read())
            {
                string userid = dr["sb"].ToString();
                string username = dr["sn1"].ToString();
                string gender = dr["sn2"].ToString();
                dr.Close();
                Object a= new
                {
                    success = true,
                    data = new
                    {
                        data1 = userid,
                        data2 = username,
                        data3 = gender
                    }
                };
                return JsonConvert.SerializeObject(a);

            }
            else
            {
                Object a = new
                {
                    success = false,
                    msg = "没有该用户的信息"
                };
                return JsonConvert.SerializeObject(a);
            }
        }
*/
        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
