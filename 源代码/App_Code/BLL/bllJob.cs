using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*ְλҵ���߼���*/
    public class bllJob{
        /*���ְλ*/
        public static bool AddJob(ENTITY.Job job)
        {
            return DAL.dalJob.AddJob(job);
        }

        /*����jobId��ȡĳ��ְλ��¼*/
        public static ENTITY.Job getSomeJob(int jobId)
        {
            return DAL.dalJob.getSomeJob(jobId);
        }

        /*����ְλ*/
        public static bool EditJob(ENTITY.Job job)
        {
            return DAL.dalJob.EditJob(job);
        }

        /*ɾ��ְλ*/
        public static bool DelJob(string p)
        {
            return DAL.dalJob.DelJob(p);
        }

        /*��ѯְλ*/
        public static System.Data.DataSet GetJob(string strWhere)
        {
            return DAL.dalJob.GetJob(strWhere);
        }

        /*����������ҳ��ѯְλ*/
        public static System.Data.DataTable GetJob(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalJob.GetJob(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е�ְλ*/
        public static System.Data.DataSet getAllJob()
        {
            return DAL.dalJob.getAllJob();
        }
    }
}
