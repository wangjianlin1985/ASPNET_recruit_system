using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*职位类别业务逻辑层*/
    public class bllJobType{
        /*添加职位类别*/
        public static bool AddJobType(ENTITY.JobType jobType)
        {
            return DAL.dalJobType.AddJobType(jobType);
        }

        /*根据jobTypeId获取某条职位类别记录*/
        public static ENTITY.JobType getSomeJobType(int jobTypeId)
        {
            return DAL.dalJobType.getSomeJobType(jobTypeId);
        }

        /*更新职位类别*/
        public static bool EditJobType(ENTITY.JobType jobType)
        {
            return DAL.dalJobType.EditJobType(jobType);
        }

        /*删除职位类别*/
        public static bool DelJobType(string p)
        {
            return DAL.dalJobType.DelJobType(p);
        }

        /*查询职位类别*/
        public static System.Data.DataSet GetJobType(string strWhere)
        {
            return DAL.dalJobType.GetJobType(strWhere);
        }

        /*根据条件分页查询职位类别*/
        public static System.Data.DataTable GetJobType(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalJobType.GetJobType(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的职位类别*/
        public static System.Data.DataSet getAllJobType()
        {
            return DAL.dalJobType.getAllJobType();
        }
    }
}
