using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*����Ͷ��ҵ���߼���ʵ��*/
    public class dalDelivery
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��Ӽ���Ͷ��ʵ��*/
        public static bool AddDelivery(ENTITY.Delivery delivery)
        {
            string sql = "insert into Delivery(jobObj,userObj,deliveryTime,handleTime,clzt,tzxx,gzpj) values(@jobObj,@userObj,@deliveryTime,@handleTime,@clzt,@tzxx,@gzpj)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@jobObj",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@deliveryTime",SqlDbType.DateTime),
             new SqlParameter("@handleTime",SqlDbType.DateTime),
             new SqlParameter("@clzt",SqlDbType.VarChar),
             new SqlParameter("@tzxx",SqlDbType.VarChar),
             new SqlParameter("@gzpj",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = delivery.jobObj; //ӦƸְλ
            parm[1].Value = delivery.userObj; //ӦƸ��
            parm[2].Value = delivery.deliveryTime; //Ͷ��ʱ��
            parm[3].Value = delivery.handleTime; //����ʱ��
            parm[4].Value = delivery.clzt; //����״̬
            parm[5].Value = delivery.tzxx; //֪ͨ��Ϣ
            parm[6].Value = delivery.gzpj; //��������

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����deliveryId��ȡĳ������Ͷ�ݼ�¼*/
        public static ENTITY.Delivery getSomeDelivery(int deliveryId)
        {
            /*������ѯsql*/
            string sql = "select * from Delivery where deliveryId=" + deliveryId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Delivery delivery = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                delivery = new ENTITY.Delivery();
                delivery.deliveryId = Convert.ToInt32(DataRead["deliveryId"]);
                delivery.jobObj = Convert.ToInt32(DataRead["jobObj"]);
                delivery.userObj = DataRead["userObj"].ToString();
                delivery.deliveryTime = Convert.ToDateTime(DataRead["deliveryTime"].ToString());
                delivery.handleTime = Convert.ToDateTime(DataRead["handleTime"].ToString());
                delivery.clzt = DataRead["clzt"].ToString();
                delivery.tzxx = DataRead["tzxx"].ToString();
                delivery.gzpj = DataRead["gzpj"].ToString();
            }
            return delivery;
        }

        /*���¼���Ͷ��ʵ��*/
        public static bool EditDelivery(ENTITY.Delivery delivery)
        {
            string sql = "update Delivery set jobObj=@jobObj,userObj=@userObj,deliveryTime=@deliveryTime,handleTime=@handleTime,clzt=@clzt,tzxx=@tzxx,gzpj=@gzpj where deliveryId=@deliveryId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@jobObj",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@deliveryTime",SqlDbType.DateTime),
             new SqlParameter("@handleTime",SqlDbType.DateTime),
             new SqlParameter("@clzt",SqlDbType.VarChar),
             new SqlParameter("@tzxx",SqlDbType.VarChar),
             new SqlParameter("@gzpj",SqlDbType.VarChar),
             new SqlParameter("@deliveryId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = delivery.jobObj;
            parm[1].Value = delivery.userObj;
            parm[2].Value = delivery.deliveryTime;
            parm[3].Value = delivery.handleTime;
            parm[4].Value = delivery.clzt;
            parm[5].Value = delivery.tzxx;
            parm[6].Value = delivery.gzpj;
            parm[7].Value = delivery.deliveryId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ������Ͷ��*/
        public static bool DelDelivery(string p)
        {
            string sql = "delete from Delivery where deliveryId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ����Ͷ��*/
        public static DataSet GetDelivery(string strWhere)
        {
            try
            {
                string strSql = "select * from Delivery" + strWhere + " order by deliveryId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /*��ѯ����Ͷ��*/
        public static System.Data.DataTable GetDelivery(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Delivery";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "deliveryId", strShow, strSql, strWhere, " deliveryId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /*��ѯ����Ͷ��*/
        public static System.Data.DataTable GetDelivery2(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from DeliveryView";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "deliveryId", strShow, strSql, strWhere, " deliveryId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllDelivery()
        {
            try
            {
                string strSql = "select * from Delivery";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
