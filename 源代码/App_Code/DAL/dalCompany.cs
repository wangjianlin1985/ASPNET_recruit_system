using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*��ҵҵ���߼���ʵ��*/
    public class dalCompany
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*�����ҵʵ��*/
        public static bool AddCompany(ENTITY.Company company)
        {
            string sql = "insert into Company(companyUserName,password,qyjb,companyName,gszch,yyzz,gsxz,gsgm,gghy,lxr,lxdh,companyDesc,address,shzt) values(@companyUserName,@password,@qyjb,@companyName,@gszch,@yyzz,@gsxz,@gsgm,@gghy,@lxr,@lxdh,@companyDesc,@address,@shzt)";
            /*����sql����*/
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
            /*��������ֵ*/
            parm[0].Value = company.companyUserName; //��ҵ�û���
            parm[1].Value = company.password; //��¼����
            parm[2].Value = company.qyjb; //���ü���
            parm[3].Value = company.companyName; //��ҵ����
            parm[4].Value = company.gszch; //����ע���
            parm[5].Value = company.yyzz; //Ӫҵִ��
            parm[6].Value = company.gsxz; //��˾����
            parm[7].Value = company.gsgm; //��˾��ģ
            parm[8].Value = company.gghy; //��˾��ҵ
            parm[9].Value = company.lxr; //��ϵ��
            parm[10].Value = company.lxdh; //��ϵ�绰
            parm[11].Value = company.companyDesc; //��˾����
            parm[12].Value = company.address; //��˾��ַ
            parm[13].Value = company.shzt; //���״̬

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����companyUserName��ȡĳ����ҵ��¼*/
        public static ENTITY.Company getSomeCompany(string companyUserName)
        {
            /*������ѯsql*/
            string sql = "select * from Company where companyUserName='" + companyUserName + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Company company = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        //��ҵ�û���¼
        public static bool ulogin(String userName,String password)
        {
            string sql = @"select companyUserName from Company where companyUserName =@userName and password =@password and shzt='���ͨ��'";
            SqlParameter[] para = new SqlParameter[] { 
             new SqlParameter("@userName",SqlDbType.VarChar),
             new SqlParameter("@password",SqlDbType.VarChar),
           };
            para[0].Value = userName;
            para[1].Value = password;
            return (DBHelp.ExecuteScalar(sql, para) != null) ? true : false;
        }


        /*������ҵʵ��*/
        public static bool EditCompany(ENTITY.Company company)
        {
            string sql = "update Company set password=@password,qyjb=@qyjb,companyName=@companyName,gszch=@gszch,yyzz=@yyzz,gsxz=@gsxz,gsgm=@gsgm,gghy=@gghy,lxr=@lxr,lxdh=@lxdh,companyDesc=@companyDesc,address=@address,shzt=@shzt where companyUserName=@companyUserName";
            /*����sql������Ϣ*/
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
            /*Ϊ������ֵ*/
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
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ����ҵ*/
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


        /*��ѯ��ҵ*/
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

        /*��ѯ��ҵ*/
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
