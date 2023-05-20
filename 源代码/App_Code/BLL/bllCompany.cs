using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*企业业务逻辑层*/
    public class bllCompany{
        /*添加企业*/
        public static bool AddCompany(ENTITY.Company company)
        {
            return DAL.dalCompany.AddCompany(company);
        }

        /*根据companyUserName获取某条企业记录*/
        public static ENTITY.Company getSomeCompany(string companyUserName)
        {
            return DAL.dalCompany.getSomeCompany(companyUserName);
        }

        public static bool ulogin(String userName, String password )
        {
            return DAL.dalCompany.ulogin(userName,password);
        }

        /*更新企业*/
        public static bool EditCompany(ENTITY.Company company)
        {
            return DAL.dalCompany.EditCompany(company);
        }

        /*删除企业*/
        public static bool DelCompany(string p)
        {
            return DAL.dalCompany.DelCompany(p);
        }

        /*查询企业*/
        public static System.Data.DataSet GetCompany(string strWhere)
        {
            return DAL.dalCompany.GetCompany(strWhere);
        }

        /*根据条件分页查询企业*/
        public static System.Data.DataTable GetCompany(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalCompany.GetCompany(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的企业*/
        public static System.Data.DataSet getAllCompany()
        {
            return DAL.dalCompany.getAllCompany();
        }
    }
}
