using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*ְλ���ҵ���߼���ʵ��*/
    public class dalJobType
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*���ְλ���ʵ��*/
        public static bool AddJobType(ENTITY.JobType jobType)
        {
            string sql = "insert into JobType(jobTypeName,jobTypeDesc) values(@jobTypeName,@jobTypeDesc)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@jobTypeName",SqlDbType.VarChar),
             new SqlParameter("@jobTypeDesc",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = jobType.jobTypeName; //ְλ�������
            parm[1].Value = jobType.jobTypeDesc; //ְλ�������

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����jobTypeId��ȡĳ��ְλ����¼*/
        public static ENTITY.JobType getSomeJobType(int jobTypeId)
        {
            /*������ѯsql*/
            string sql = "select * from JobType where jobTypeId=" + jobTypeId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.JobType jobType = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                jobType = new ENTITY.JobType();
                jobType.jobTypeId = Convert.ToInt32(DataRead["jobTypeId"]);
                jobType.jobTypeName = DataRead["jobTypeName"].ToString();
                jobType.jobTypeDesc = DataRead["jobTypeDesc"].ToString();
            }
            return jobType;
        }

        /*����ְλ���ʵ��*/
        public static bool EditJobType(ENTITY.JobType jobType)
        {
            string sql = "update JobType set jobTypeName=@jobTypeName,jobTypeDesc=@jobTypeDesc where jobTypeId=@jobTypeId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@jobTypeName",SqlDbType.VarChar),
             new SqlParameter("@jobTypeDesc",SqlDbType.VarChar),
             new SqlParameter("@jobTypeId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = jobType.jobTypeName;
            parm[1].Value = jobType.jobTypeDesc;
            parm[2].Value = jobType.jobTypeId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ��ְλ���*/
        public static bool DelJobType(string p)
        {
            string sql = "delete from JobType where jobTypeId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯְλ���*/
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

        /*��ѯְλ���*/
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
