using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*ְλ���ҵ���߼���*/
    public class bllJobType{
        /*���ְλ���*/
        public static bool AddJobType(ENTITY.JobType jobType)
        {
            return DAL.dalJobType.AddJobType(jobType);
        }

        /*����jobTypeId��ȡĳ��ְλ����¼*/
        public static ENTITY.JobType getSomeJobType(int jobTypeId)
        {
            return DAL.dalJobType.getSomeJobType(jobTypeId);
        }

        /*����ְλ���*/
        public static bool EditJobType(ENTITY.JobType jobType)
        {
            return DAL.dalJobType.EditJobType(jobType);
        }

        /*ɾ��ְλ���*/
        public static bool DelJobType(string p)
        {
            return DAL.dalJobType.DelJobType(p);
        }

        /*��ѯְλ���*/
        public static System.Data.DataSet GetJobType(string strWhere)
        {
            return DAL.dalJobType.GetJobType(strWhere);
        }

        /*����������ҳ��ѯְλ���*/
        public static System.Data.DataTable GetJobType(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalJobType.GetJobType(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е�ְλ���*/
        public static System.Data.DataSet getAllJobType()
        {
            return DAL.dalJobType.getAllJobType();
        }
    }
}
