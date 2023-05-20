using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*简历投递业务逻辑层实现*/
    public class dalDelivery
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加简历投递实现*/
        public static bool AddDelivery(ENTITY.Delivery delivery)
        {
            string sql = "insert into Delivery(jobObj,userObj,deliveryTime,handleTime,clzt,tzxx,gzpj) values(@jobObj,@userObj,@deliveryTime,@handleTime,@clzt,@tzxx,@gzpj)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@jobObj",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@deliveryTime",SqlDbType.DateTime),
             new SqlParameter("@handleTime",SqlDbType.DateTime),
             new SqlParameter("@clzt",SqlDbType.VarChar),
             new SqlParameter("@tzxx",SqlDbType.VarChar),
             new SqlParameter("@gzpj",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = delivery.jobObj; //应聘职位
            parm[1].Value = delivery.userObj; //应聘人
            parm[2].Value = delivery.deliveryTime; //投递时间
            parm[3].Value = delivery.handleTime; //处理时间
            parm[4].Value = delivery.clzt; //处理状态
            parm[5].Value = delivery.tzxx; //通知信息
            parm[6].Value = delivery.gzpj; //工作评价

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据deliveryId获取某条简历投递记录*/
        public static ENTITY.Delivery getSomeDelivery(int deliveryId)
        {
            /*构建查询sql*/
            string sql = "select * from Delivery where deliveryId=" + deliveryId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Delivery delivery = null;
            /*如果查询存在记录，就包装到对象中返回*/
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

        /*更新简历投递实现*/
        public static bool EditDelivery(ENTITY.Delivery delivery)
        {
            string sql = "update Delivery set jobObj=@jobObj,userObj=@userObj,deliveryTime=@deliveryTime,handleTime=@handleTime,clzt=@clzt,tzxx=@tzxx,gzpj=@gzpj where deliveryId=@deliveryId";
            /*构建sql参数信息*/
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
            /*为参数赋值*/
            parm[0].Value = delivery.jobObj;
            parm[1].Value = delivery.userObj;
            parm[2].Value = delivery.deliveryTime;
            parm[3].Value = delivery.handleTime;
            parm[4].Value = delivery.clzt;
            parm[5].Value = delivery.tzxx;
            parm[6].Value = delivery.gzpj;
            parm[7].Value = delivery.deliveryId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除简历投递*/
        public static bool DelDelivery(string p)
        {
            string sql = "delete from Delivery where deliveryId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询简历投递*/
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


        /*查询简历投递*/
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


        /*查询简历投递*/
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
