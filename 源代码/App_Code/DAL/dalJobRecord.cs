using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*��ְ��¼ҵ���߼���ʵ��*/
    public class dalJobRecord
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��Ӽ�ְ��¼ʵ��*/
        public static bool AddJobRecord(ENTITY.JobRecord jobRecord)
        {
            string sql = "insert into JobRecord(title,content,userObj,recordDate) values(@title,@content,@userObj,@recordDate)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@recordDate",SqlDbType.DateTime)
            };
            /*��������ֵ*/
            parm[0].Value = jobRecord.title; //����
            parm[1].Value = jobRecord.content; //����
            parm[2].Value = jobRecord.userObj; //��¼��
            parm[3].Value = jobRecord.recordDate; //��¼ʱ��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����recordId��ȡĳ����ְ��¼��¼*/
        public static ENTITY.JobRecord getSomeJobRecord(int recordId)
        {
            /*������ѯsql*/
            string sql = "select * from JobRecord where recordId=" + recordId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.JobRecord jobRecord = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*���¼�ְ��¼ʵ��*/
        public static bool EditJobRecord(ENTITY.JobRecord jobRecord)
        {
            string sql = "update JobRecord set title=@title,content=@content,userObj=@userObj,recordDate=@recordDate where recordId=@recordId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@recordDate",SqlDbType.DateTime),
             new SqlParameter("@recordId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = jobRecord.title;
            parm[1].Value = jobRecord.content;
            parm[2].Value = jobRecord.userObj;
            parm[3].Value = jobRecord.recordDate;
            parm[4].Value = jobRecord.recordId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ����ְ��¼*/
        public static bool DelJobRecord(string p)
        {
            string sql = "delete from JobRecord where recordId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ��ְ��¼*/
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

        /*��ѯ��ְ��¼*/
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
