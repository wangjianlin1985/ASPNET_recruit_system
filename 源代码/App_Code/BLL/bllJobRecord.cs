using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*兼职记录业务逻辑层*/
    public class bllJobRecord{
        /*添加兼职记录*/
        public static bool AddJobRecord(ENTITY.JobRecord jobRecord)
        {
            return DAL.dalJobRecord.AddJobRecord(jobRecord);
        }

        /*根据recordId获取某条兼职记录记录*/
        public static ENTITY.JobRecord getSomeJobRecord(int recordId)
        {
            return DAL.dalJobRecord.getSomeJobRecord(recordId);
        }

        /*更新兼职记录*/
        public static bool EditJobRecord(ENTITY.JobRecord jobRecord)
        {
            return DAL.dalJobRecord.EditJobRecord(jobRecord);
        }

        /*删除兼职记录*/
        public static bool DelJobRecord(string p)
        {
            return DAL.dalJobRecord.DelJobRecord(p);
        }

        /*查询兼职记录*/
        public static System.Data.DataSet GetJobRecord(string strWhere)
        {
            return DAL.dalJobRecord.GetJobRecord(strWhere);
        }

        /*根据条件分页查询兼职记录*/
        public static System.Data.DataTable GetJobRecord(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalJobRecord.GetJobRecord(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的兼职记录*/
        public static System.Data.DataSet getAllJobRecord()
        {
            return DAL.dalJobRecord.getAllJobRecord();
        }
    }
}
