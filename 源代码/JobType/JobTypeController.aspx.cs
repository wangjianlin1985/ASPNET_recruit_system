using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using com.force.json;

public partial class JobType_JobTypeController : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["action"];
        if (action == "add") addJobType();
        if (action == "delete") deleteJobType();
        if (action == "update") updateJobType();
        if (action == "getJobType") getJobType();
        if (action == "listAll") listAll();
    }
    //处理添加职位类别控制层方法
    protected void addJobType()
    {
        int success = 0;
        string message = "";
        ENTITY.JobType jobType = new ENTITY.JobType();
        jobType.jobTypeName = Request["jobType.jobTypeName"];
        jobType.jobTypeDesc = Request["jobType.jobTypeDesc"];
        if (!BLL.bllJobType.AddJobType(jobType))
        {
            message = "添加职位类别发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //处理删除职位类别控制层方法
    protected void deleteJobType()
    {
        int success = 0;
        string message = "";
        string jobTypeId = Request["jobTypeId"];
        try {
            BLL.bllJobType.DelJobType(jobTypeId);
            success = 1;
        } catch {
            message = "职位类别删除失败";
        }
        writeResult(success, message);
    }

    //处理更新职位类别控制层方法
    protected void updateJobType()
    {
        int success = 0;
        string message = "";
        ENTITY.JobType jobType = new ENTITY.JobType();
        jobType.jobTypeId = int.Parse(Request["JobType.jobTypeId"]);
        jobType.jobTypeName = Request["jobType.jobTypeName"];
        jobType.jobTypeDesc = Request["jobType.jobTypeDesc"];
        if (!BLL.bllJobType.EditJobType(jobType))
        {
            message = "更新职位类别发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //获取单个职位类别对象，返回json格式
    protected void getJobType()
    {
        int jobTypeId = int.Parse(Request.QueryString["jobTypeId"]);
        ENTITY.JobType jobType = BLL.bllJobType.getSomeJobType(jobTypeId);
        JSONObject jsonJobType = new JSONObject();
        jsonJobType.Put("jobTypeId", jobType.jobTypeId);
        jsonJobType.Put("jobTypeName", jobType.jobTypeName);
        jsonJobType.Put("jobTypeDesc", jobType.jobTypeDesc);
        Response.Write(jsonJobType.ToString());
    }

    protected void listAll()
    {
        DataSet jobTypeDs = BLL.bllJobType.getAllJobType();
        JSONArray jobTypeArray = new JSONArray();
        for (int i = 0; i < jobTypeDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = jobTypeDs.Tables[0].Rows[i];
            JSONObject jsonJobType = new JSONObject();
            jsonJobType.Put("jobTypeId", Convert.ToInt32(dr["jobTypeId"]));
            jsonJobType.Put("jobTypeName", dr["jobTypeName"].ToString());
            jobTypeArray.Put(jsonJobType);
        }
        Response.Write(jobTypeArray.ToString());
    }

    //把处理结果返回给界面层
    protected void writeResult(int success, string message)
    {
        JSONObject resultObj = new JSONObject();
        resultObj.Put("success", success);
        resultObj.Put("message", message);
        Response.Write(resultObj.ToString());
    }

}
