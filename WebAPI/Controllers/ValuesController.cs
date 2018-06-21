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
    [Route("api/[action]")]
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
        [ActionName("getName")]
        public string Get(int id)
        {
            return SQLAssisants.Query_manual("users","SELECT name FROM users WHERE username='"+id+"'");
        }

        // GET api/values/5
        [HttpGet("{name}")]
        [ActionName("getNo")]
        public string GetNo(string name)
        {
            return SQLAssisants.Query_manual("users", "SELECT username FROM users WHERE name='" + name + "'");
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
        [ActionName("checkUser")]
        public string Post([FromForm] UserObject userObject)
        {
            return SQLAssisants.Query("users", "username='" + userObject.username + "' And password='" + userObject.password + "' And type='" + userObject.type + "'");
        }

        // POST api/values
        [HttpPost]
        [ActionName("getUserClass")]
        public string Post(String username)
        {
            return SQLAssisants.Query_manual("score", "SELECT course_id FROM score WHERE no='" + username +"'");
        }

        // POST api/values
        [HttpPost]
        [ActionName("getSource")]
        public string PostSource([FromForm] SourceObject sourceObject)
        {
            return SQLAssisants.Query_manual("score","SELECT no,score,(SELECT count(DISTINCT score) FROM score AS b WHERE course_id='" + sourceObject.course + "' AND a.score<b.score)+1 AS rank,(SELECT course_name FROM course WHERE course_id='" + sourceObject.course + "') AS course_name FROM score AS a WHERE course_id='" + sourceObject.course + "' AND no='" + sourceObject.username + "'");
        }

        // POST api/values
        [HttpPost]
        [ActionName("getSourceByCourse")]
        public string PostSourceByCourse(string course_id)
        {
            return SQLAssisants.Query_manual("score", "SELECT users.username,users.class_id,users.name,score,(SELECT count(DISTINCT score) FROM score AS b WHERE course_id='" + course_id + "' AND a.score<b.score)+1 AS rank,(SELECT course_name FROM course WHERE course_id='" + course_id + "') AS course_name FROM score AS a INNER JOIN users ON (users.username = no) WHERE course_id='" + course_id + "'");
        }

        // POST api/values
        [HttpPost]
        [ActionName("getSourceByClassID")]
        public string PostSourceByClassID(string class_id)
        {
            return SQLAssisants.Query_manual("score", "SELECT rank() over (order by score desc) rank,name,score,(SELECT course_name from course where course_id='100000') course_name from score INNER JOIN users ON (users.username = no) where course_id='100000' AND class_id='" + class_id + "'");
        }

        // POST api/values
        [HttpPost]
        [ActionName("getSourceAVG")]
        public string PostSourceAVG(string class_id)
        {
            return SQLAssisants.Query_manual("score", "SELECT AVG(score) score,(SELECT course_name from course where course_id='100000') course_name FROM score INNER JOIN users ON (users.username = no) where course_id='100000' AND class_id='" + class_id + "'");
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
