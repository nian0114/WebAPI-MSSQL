﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using WebApiParameters.Models;


namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ValuesController : Controller
    {

   
        // GET api/values
        [HttpGet]
        [ActionName("Get01")]
        public string Get()
        {
            return SQLAssisants.Query("users","");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ActionName("Get01")]
        public string Get(int id)
        {
            return SQLAssisants.Query("users","username='0000001'");
        }


        /*
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
        [ActionName("POST01")]
        public string Post([FromForm] UserObject userObject)
        {
            return SQLAssisants.Delete("users","username=1");
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
