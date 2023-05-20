using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*企业业务逻辑层实现*/
    public class dalCompany
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加企业实现*/
        public static bool AddCompany(ENTITY.Company company)
        {
            string sql = "insert into Company(companyUserName,password,qyjb,companyName,gszch,yyzz,gsxz,gsgm,gghy,lxr,lxdh,companyDesc,address,shzt) values(@companyUserName,@password,@qyjb,@companyName,@gszch,@yyzz,@gsxz,@gsgm,@gghy,@lxr,@lxdh,@companyDesc,@address,@shzt)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@companyUserName",SqlDbType.VarChar),
             new SqlParameter("@password",SqlDbType.VarChar),
             new SqlParameter("@qyjb",SqlDbType.VarChar),
             new SqlParameter("@companyName",SqlDbType.VarChar),
             new SqlParameter("@gszch",SqlDbType.VarChar),
             new SqlParameter("@yyzz",SqlDbType.VarChar),
             new SqlParameter("@gsxz",SqlDbType.VarChar),
             new SqlParameter("@gsgm",SqlDbType.VarChar),
             new SqlParameter("@gghy",SqlDbType.VarChar),
             new SqlParameter("@lxr",SqlDbType.VarChar),
             new SqlParameter("@lxdh",SqlDbType.VarChar),
             new SqlParameter("@companyDesc",SqlDbType.VarChar),
             new SqlParameter("@address",SqlDbType.VarChar),
             new SqlParameter("@shzt",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = company.companyUserName; //企业用户名
            parm[1].Value = company.password; //登录密码
            parm[2].Value = company.qyjb; //信用级别
            parm[3].Value = company.companyName; //企业名称
            parm[4].Value = company.gszch; //工商注册号
            parm[5].Value = company.yyzz; //营业执照
            parm[6].Value = company.gsxz; //公司性质
            parm[7].Value = company.gsgm; //公司规模
            parm[8].Value = company.gghy; //公司行业
            parm[9].Value = company.lxr; //联系人
            parm[10].Value = company.lxdh; //联系电话
            parm[11].Value = company.companyDesc; //公司介绍
            parm[12].Value = company.address; //公司地址
            parm[13].Value = company.shzt; //审核状态

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据companyUserName获取某条企业记录*/
        public static ENTITY.Company getSomeCompany(string companyUserName)
        {
            /*构建查询sql*/
            string sql = "select * from Company where companyUserName='" + companyUserName + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Company company = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                company = new ENTITY.Company();
                company.companyUserName = DataRead["companyUserName"].ToString();
                company.password = DataRead["password"].ToString();
                company.qyjb = DataRead["qyjb"].ToString();
                company.companyName = DataRead["companyName"].ToString();
                company.gszch = DataRead["gszch"].ToString();
                company.yyzz = DataRead["yyzz"].ToString();
                company.gsxz = DataRead["gsxz"].ToString();
                company.gsgm = DataRead["gsgm"].ToString();
                company.gghy = DataRead["gghy"].ToString();
                company.lxr = DataRead["lxr"].ToString();
                company.lxdh = DataRead["lxdh"].ToString();
                company.companyDesc = DataRead["companyDesc"].ToString();
                company.address = DataRead["address"].ToString();
                company.shzt = DataRead["shzt"].ToString();
            }
            return company;
        }

        //企业用户登录
        public static bool ulogin(String userName,String password)
        {
            string sql = @"select companyUserName from Company where companyUserName =@userName and password =@password and shzt='审核通过'";
            SqlParameter[] para = new SqlParameter[] { 
             new SqlParameter("@userName",SqlDbType.VarChar),
             new SqlParameter("@password",SqlDbType.VarChar),
           };
            para[0].Value = userName;
            para[1].Value = password;
            return (DBHelp.ExecuteScalar(sql, para) != null) ? true : false;
        }


        /*更新企业实现*/
        public static bool EditCompany(ENTITY.Company company)
        {
            string sql = "update Company set password=@password,qyjb=@qyjb,companyName=@companyName,gszch=@gszch,yyzz=@yyzz,gsxz=@gsxz,gsgm=@gsgm,gghy=@gghy,lxr=@lxr,lxdh=@lxdh,companyDesc=@companyDesc,address=@address,shzt=@shzt where companyUserName=@companyUserName";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@password",SqlDbType.VarChar),
             new SqlParameter("@qyjb",SqlDbType.VarChar),
             new SqlParameter("@companyName",SqlDbType.VarChar),
             new SqlParameter("@gszch",SqlDbType.VarChar),
             new SqlParameter("@yyzz",SqlDbType.VarChar),
             new SqlParameter("@gsxz",SqlDbType.VarChar),
             new SqlParameter("@gsgm",SqlDbType.VarChar),
             new SqlParameter("@gghy",SqlDbType.VarChar),
             new SqlParameter("@lxr",SqlDbType.VarChar),
             new SqlParameter("@lxdh",SqlDbType.VarChar),
             new SqlParameter("@companyDesc",SqlDbType.VarChar),
             new SqlParameter("@address",SqlDbType.VarChar),
             new SqlParameter("@shzt",SqlDbType.VarChar),
             new SqlParameter("@companyUserName",SqlDbType.VarChar)
            };
            /*为参数赋值*/
            parm[0].Value = company.password;
            parm[1].Value = company.qyjb;
            parm[2].Value = company.companyName;
            parm[3].Value = company.gszch;
            parm[4].Value = company.yyzz;
            parm[5].Value = company.gsxz;
            parm[6].Value = company.gsgm;
            parm[7].Value = company.gghy;
            parm[8].Value = company.lxr;
            parm[9].Value = company.lxdh;
            parm[10].Value = company.companyDesc;
            parm[11].Value = company.address;
            parm[12].Value = company.shzt;
            parm[13].Value = company.companyUserName;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除企业*/
        public static bool DelCompany(string p)
        {
            string sql = "";
            string[] ids = p.Split(',');
            for(int i=0;i<ids.Length;i++)
            {
                if(i != ids.Length-1)
                  sql += "'" + ids[i] + "',";
                else
                  sql += "'" + ids[i] + "'";
            }
            sql = "delete from Company where companyUserName in (" + sql + ")";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询企业*/
        public static DataSet GetCompany(string strWhere)
        {
            try
            {
                string strSql = "select * from Company" + strWhere + " order by companyUserName asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询企业*/
        public static System.Data.DataTable GetCompany(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Company";
                string strShow = "*";
                return DAL.DBHelp.ExecutePagerWhenPrimaryIsString(PageIndex, PageSize, "companyUserName", strShow, strSql, strWhere, " companyUserName asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllCompany()
        {
            try
            {
                string strSql = "select * from Company";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
