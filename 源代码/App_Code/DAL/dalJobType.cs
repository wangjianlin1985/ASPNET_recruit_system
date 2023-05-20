using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*职位类别业务逻辑层实现*/
    public class dalJobType
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加职位类别实现*/
        public static bool AddJobType(ENTITY.JobType jobType)
        {
            string sql = "insert into JobType(jobTypeName,jobTypeDesc) values(@jobTypeName,@jobTypeDesc)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@jobTypeName",SqlDbType.VarChar),
             new SqlParameter("@jobTypeDesc",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = jobType.jobTypeName; //职位类别名称
            parm[1].Value = jobType.jobTypeDesc; //职位类别描述

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据jobTypeId获取某条职位类别记录*/
        public static ENTITY.JobType getSomeJobType(int jobTypeId)
        {
            /*构建查询sql*/
            string sql = "select * from JobType where jobTypeId=" + jobTypeId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.JobType jobType = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                jobType = new ENTITY.JobType();
                jobType.jobTypeId = Convert.ToInt32(DataRead["jobTypeId"]);
                jobType.jobTypeName = DataRead["jobTypeName"].ToString();
                jobType.jobTypeDesc = DataRead["jobTypeDesc"].ToString();
            }
            return jobType;
        }

        /*更新职位类别实现*/
        public static bool EditJobType(ENTITY.JobType jobType)
        {
            string sql = "update JobType set jobTypeName=@jobTypeName,jobTypeDesc=@jobTypeDesc where jobTypeId=@jobTypeId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@jobTypeName",SqlDbType.VarChar),
             new SqlParameter("@jobTypeDesc",SqlDbType.VarChar),
             new SqlParameter("@jobTypeId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = jobType.jobTypeName;
            parm[1].Value = jobType.jobTypeDesc;
            parm[2].Value = jobType.jobTypeId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除职位类别*/
        public static bool DelJobType(string p)
        {
            string sql = "delete from JobType where jobTypeId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询职位类别*/
        public static DataSet GetJobType(string strWhere)
        {
            try
            {
                string strSql = "select * from JobType" + strWhere + " order by jobTypeId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询职位类别*/
        public static System.Data.DataTable GetJobType(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from JobType";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "jobTypeId", strShow, strSql, strWhere, " jobTypeId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllJobType()
        {
            try
            {
                string strSql = "select * from JobType";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
