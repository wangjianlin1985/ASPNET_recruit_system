using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*��ҵҵ���߼���*/
    public class bllCompany{
        /*�����ҵ*/
        public static bool AddCompany(ENTITY.Company company)
        {
            return DAL.dalCompany.AddCompany(company);
        }

        /*����companyUserName��ȡĳ����ҵ��¼*/
        public static ENTITY.Company getSomeCompany(string companyUserName)
        {
            return DAL.dalCompany.getSomeCompany(companyUserName);
        }

        public static bool ulogin(String userName, String password )
        {
            return DAL.dalCompany.ulogin(userName,password);
        }

        /*������ҵ*/
        public static bool EditCompany(ENTITY.Company company)
        {
            return DAL.dalCompany.EditCompany(company);
        }

        /*ɾ����ҵ*/
        public static bool DelCompany(string p)
        {
            return DAL.dalCompany.DelCompany(p);
        }

        /*��ѯ��ҵ*/
        public static System.Data.DataSet GetCompany(string strWhere)
        {
            return DAL.dalCompany.GetCompany(strWhere);
        }

        /*����������ҳ��ѯ��ҵ*/
        public static System.Data.DataTable GetCompany(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalCompany.GetCompany(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е���ҵ*/
        public static System.Data.DataSet getAllCompany()
        {
            return DAL.dalCompany.getAllCompany();
        }
    }
}
