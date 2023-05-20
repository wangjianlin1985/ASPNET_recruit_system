using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*职位业务逻辑层*/
    public class bllJob{
        /*添加职位*/
        public static bool AddJob(ENTITY.Job job)
        {
            return DAL.dalJob.AddJob(job);
        }

        /*根据jobId获取某条职位记录*/
        public static ENTITY.Job getSomeJob(int jobId)
        {
            return DAL.dalJob.getSomeJob(jobId);
        }

        /*更新职位*/
        public static bool EditJob(ENTITY.Job job)
        {
            return DAL.dalJob.EditJob(job);
        }

        /*删除职位*/
        public static bool DelJob(string p)
        {
            return DAL.dalJob.DelJob(p);
        }

        /*查询职位*/
        public static System.Data.DataSet GetJob(string strWhere)
        {
            return DAL.dalJob.GetJob(strWhere);
        }

        /*根据条件分页查询职位*/
        public static System.Data.DataTable GetJob(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalJob.GetJob(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的职位*/
        public static System.Data.DataSet getAllJob()
        {
            return DAL.dalJob.getAllJob();
        }
    }
}
