using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*ְλҵ���߼���ʵ��*/
    public class dalJob
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*���ְλʵ��*/
        public static bool AddJob(ENTITY.Job job)
        {
            string sql = "insert into Job(jobTypeObj,jobName,jobDesc,salary,zprs,xlyq,yxqx,gzqy,gzdz,viewNum,companyObj,addTime) values(@jobTypeObj,@jobName,@jobDesc,@salary,@zprs,@xlyq,@yxqx,@gzqy,@gzdz,@viewNum,@companyObj,@addTime)";
            /*����sql����*/
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
            /*��������ֵ*/
            parm[0].Value = job.jobTypeObj; //ְλ���
            parm[1].Value = job.jobName; //ְλ����
            parm[2].Value = job.jobDesc; //ְλ����
            parm[3].Value = job.salary; //����н��
            parm[4].Value = job.zprs; //��Ƹ����
            parm[5].Value = job.xlyq; //ѧ��Ҫ��
            parm[6].Value = job.yxqx; //��Ч����
            parm[7].Value = job.gzqy; //��������
            parm[8].Value = job.gzdz; //������ַ
            parm[9].Value = job.viewNum; //�������
            parm[10].Value = job.companyObj; //������ҵ
            parm[11].Value = job.addTime; //����ʱ��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����jobId��ȡĳ��ְλ��¼*/
        public static ENTITY.Job getSomeJob(int jobId)
        {
            /*������ѯsql*/
            string sql = "select * from Job where jobId=" + jobId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Job job = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*����ְλʵ��*/
        public static bool EditJob(ENTITY.Job job)
        {
            string sql = "update Job set jobTypeObj=@jobTypeObj,jobName=@jobName,jobDesc=@jobDesc,salary=@salary,zprs=@zprs,xlyq=@xlyq,yxqx=@yxqx,gzqy=@gzqy,gzdz=@gzdz,viewNum=@viewNum,companyObj=@companyObj,addTime=@addTime where jobId=@jobId";
            /*����sql������Ϣ*/
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
            /*Ϊ������ֵ*/
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
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ��ְλ*/
        public static bool DelJob(string p)
        {
            string sql = "delete from Job where jobId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯְλ*/
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

        /*��ѯְλ*/
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
