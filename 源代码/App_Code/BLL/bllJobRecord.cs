using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*��ְ��¼ҵ���߼���*/
    public class bllJobRecord{
        /*��Ӽ�ְ��¼*/
        public static bool AddJobRecord(ENTITY.JobRecord jobRecord)
        {
            return DAL.dalJobRecord.AddJobRecord(jobRecord);
        }

        /*����recordId��ȡĳ����ְ��¼��¼*/
        public static ENTITY.JobRecord getSomeJobRecord(int recordId)
        {
            return DAL.dalJobRecord.getSomeJobRecord(recordId);
        }

        /*���¼�ְ��¼*/
        public static bool EditJobRecord(ENTITY.JobRecord jobRecord)
        {
            return DAL.dalJobRecord.EditJobRecord(jobRecord);
        }

        /*ɾ����ְ��¼*/
        public static bool DelJobRecord(string p)
        {
            return DAL.dalJobRecord.DelJobRecord(p);
        }

        /*��ѯ��ְ��¼*/
        public static System.Data.DataSet GetJobRecord(string strWhere)
        {
            return DAL.dalJobRecord.GetJobRecord(strWhere);
        }

        /*����������ҳ��ѯ��ְ��¼*/
        public static System.Data.DataTable GetJobRecord(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalJobRecord.GetJobRecord(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еļ�ְ��¼*/
        public static System.Data.DataSet getAllJobRecord()
        {
            return DAL.dalJobRecord.getAllJobRecord();
        }
    }
}
