using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*兼职记录业务逻辑层实现*/
    public class dalJobRecord
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加兼职记录实现*/
        public static bool AddJobRecord(ENTITY.JobRecord jobRecord)
        {
            string sql = "insert into JobRecord(title,content,userObj,recordDate) values(@title,@content,@userObj,@recordDate)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@recordDate",SqlDbType.DateTime)
            };
            /*给参数赋值*/
            parm[0].Value = jobRecord.title; //标题
            parm[1].Value = jobRecord.content; //内容
            parm[2].Value = jobRecord.userObj; //记录人
            parm[3].Value = jobRecord.recordDate; //记录时间

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据recordId获取某条兼职记录记录*/
        public static ENTITY.JobRecord getSomeJobRecord(int recordId)
        {
            /*构建查询sql*/
            string sql = "select * from JobRecord where recordId=" + recordId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.JobRecord jobRecord = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                jobRecord = new ENTITY.JobRecord();
                jobRecord.recordId = Convert.ToInt32(DataRead["recordId"]);
                jobRecord.title = DataRead["title"].ToString();
                jobRecord.content = DataRead["content"].ToString();
                jobRecord.userObj = DataRead["userObj"].ToString();
                jobRecord.recordDate = Convert.ToDateTime(DataRead["recordDate"].ToString());
            }
            return jobRecord;
        }

        /*更新兼职记录实现*/
        public static bool EditJobRecord(ENTITY.JobRecord jobRecord)
        {
            string sql = "update JobRecord set title=@title,content=@content,userObj=@userObj,recordDate=@recordDate where recordId=@recordId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@recordDate",SqlDbType.DateTime),
             new SqlParameter("@recordId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = jobRecord.title;
            parm[1].Value = jobRecord.content;
            parm[2].Value = jobRecord.userObj;
            parm[3].Value = jobRecord.recordDate;
            parm[4].Value = jobRecord.recordId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除兼职记录*/
        public static bool DelJobRecord(string p)
        {
            string sql = "delete from JobRecord where recordId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询兼职记录*/
        public static DataSet GetJobRecord(string strWhere)
        {
            try
            {
                string strSql = "select * from JobRecord" + strWhere + " order by recordId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询兼职记录*/
        public static System.Data.DataTable GetJobRecord(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from JobRecord";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "recordId", strShow, strSql, strWhere, " recordId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllJobRecord()
        {
            try
            {
                string strSql = "select * from JobRecord";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
