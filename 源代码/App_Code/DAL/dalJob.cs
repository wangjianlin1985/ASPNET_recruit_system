using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*职位业务逻辑层实现*/
    public class dalJob
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加职位实现*/
        public static bool AddJob(ENTITY.Job job)
        {
            string sql = "insert into Job(jobTypeObj,jobName,jobDesc,salary,zprs,xlyq,yxqx,gzqy,gzdz,viewNum,companyObj,addTime) values(@jobTypeObj,@jobName,@jobDesc,@salary,@zprs,@xlyq,@yxqx,@gzqy,@gzdz,@viewNum,@companyObj,@addTime)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@jobTypeObj",SqlDbType.Int),
             new SqlParameter("@jobName",SqlDbType.VarChar),
             new SqlParameter("@jobDesc",SqlDbType.VarChar),
             new SqlParameter("@salary",SqlDbType.VarChar),
             new SqlParameter("@zprs",SqlDbType.Int),
             new SqlParameter("@xlyq",SqlDbType.VarChar),
             new SqlParameter("@yxqx",SqlDbType.VarChar),
             new SqlParameter("@gzqy",SqlDbType.VarChar),
             new SqlParameter("@gzdz",SqlDbType.VarChar),
             new SqlParameter("@viewNum",SqlDbType.Int),
             new SqlParameter("@companyObj",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime)
            };
            /*给参数赋值*/
            parm[0].Value = job.jobTypeObj; //职位类别
            parm[1].Value = job.jobName; //职位名称
            parm[2].Value = job.jobDesc; //职位描述
            parm[3].Value = job.salary; //工作薪酬
            parm[4].Value = job.zprs; //招聘人数
            parm[5].Value = job.xlyq; //学历要求
            parm[6].Value = job.yxqx; //有效期限
            parm[7].Value = job.gzqy; //工作区域
            parm[8].Value = job.gzdz; //工作地址
            parm[9].Value = job.viewNum; //浏览次数
            parm[10].Value = job.companyObj; //发布企业
            parm[11].Value = job.addTime; //发布时间

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据jobId获取某条职位记录*/
        public static ENTITY.Job getSomeJob(int jobId)
        {
            /*构建查询sql*/
            string sql = "select * from Job where jobId=" + jobId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Job job = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                job = new ENTITY.Job();
                job.jobId = Convert.ToInt32(DataRead["jobId"]);
                job.jobTypeObj = Convert.ToInt32(DataRead["jobTypeObj"]);
                job.jobName = DataRead["jobName"].ToString();
                job.jobDesc = DataRead["jobDesc"].ToString();
                job.salary = DataRead["salary"].ToString();
                job.zprs = Convert.ToInt32(DataRead["zprs"]);
                job.xlyq = DataRead["xlyq"].ToString();
                job.yxqx = DataRead["yxqx"].ToString();
                job.gzqy = DataRead["gzqy"].ToString();
                job.gzdz = DataRead["gzdz"].ToString();
                job.viewNum = Convert.ToInt32(DataRead["viewNum"]);
                job.companyObj = DataRead["companyObj"].ToString();
                job.addTime = Convert.ToDateTime(DataRead["addTime"].ToString());
            }
            return job;
        }

        /*更新职位实现*/
        public static bool EditJob(ENTITY.Job job)
        {
            string sql = "update Job set jobTypeObj=@jobTypeObj,jobName=@jobName,jobDesc=@jobDesc,salary=@salary,zprs=@zprs,xlyq=@xlyq,yxqx=@yxqx,gzqy=@gzqy,gzdz=@gzdz,viewNum=@viewNum,companyObj=@companyObj,addTime=@addTime where jobId=@jobId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@jobTypeObj",SqlDbType.Int),
             new SqlParameter("@jobName",SqlDbType.VarChar),
             new SqlParameter("@jobDesc",SqlDbType.VarChar),
             new SqlParameter("@salary",SqlDbType.VarChar),
             new SqlParameter("@zprs",SqlDbType.Int),
             new SqlParameter("@xlyq",SqlDbType.VarChar),
             new SqlParameter("@yxqx",SqlDbType.VarChar),
             new SqlParameter("@gzqy",SqlDbType.VarChar),
             new SqlParameter("@gzdz",SqlDbType.VarChar),
             new SqlParameter("@viewNum",SqlDbType.Int),
             new SqlParameter("@companyObj",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime),
             new SqlParameter("@jobId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = job.jobTypeObj;
            parm[1].Value = job.jobName;
            parm[2].Value = job.jobDesc;
            parm[3].Value = job.salary;
            parm[4].Value = job.zprs;
            parm[5].Value = job.xlyq;
            parm[6].Value = job.yxqx;
            parm[7].Value = job.gzqy;
            parm[8].Value = job.gzdz;
            parm[9].Value = job.viewNum;
            parm[10].Value = job.companyObj;
            parm[11].Value = job.addTime;
            parm[12].Value = job.jobId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除职位*/
        public static bool DelJob(string p)
        {
            string sql = "delete from Job where jobId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询职位*/
        public static DataSet GetJob(string strWhere)
        {
            try
            {
                string strSql = "select * from Job" + strWhere + " order by jobId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询职位*/
        public static System.Data.DataTable GetJob(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Job";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "jobId", strShow, strSql, strWhere, " jobId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllJob()
        {
            try
            {
                string strSql = "select * from Job";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
