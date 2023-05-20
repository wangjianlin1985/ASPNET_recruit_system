using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Job_frontList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindjobTypeObj();
            BindcompanyObj();
            string sqlstr = " where 1=1 ";
            if (Request["jobTypeObj"] != null && Request["jobTypeObj"].ToString() != "0")
            {
                    sqlstr += "  and jobTypeObj=" + Request["jobTypeObj"].ToString();
                    jobTypeObj.SelectedValue = Request["jobTypeObj"].ToString();
            }
            if (Request["jobName"] != null && Request["jobName"].ToString() != "")
            {
                sqlstr += "  and jobName like '%" + Request["jobName"].ToString() + "%'";
                jobName.Text = Request["jobName"].ToString();
            }
            if (Request["xlyq"] != null && Request["xlyq"].ToString() != "")
            {
                sqlstr += "  and xlyq like '%" + Request["xlyq"].ToString() + "%'";
                xlyq.Text = Request["xlyq"].ToString();
            }
            if (Request["gzqy"] != null && Request["gzqy"].ToString() != "")
            {
                sqlstr += "  and gzqy like '%" + Request["gzqy"].ToString() + "%'";
                gzqy.Text = Request["gzqy"].ToString();
            }
            if (Request["companyObj"] != null && Request["companyObj"].ToString() != "")
            {
                sqlstr += "  and companyObj='" + Request["companyObj"].ToString() + "'";
                companyObj.SelectedValue = Request["companyObj"].ToString();
            }
            if (Request["addTime"] != null && Request["addTime"].ToString() != "")
            {
                sqlstr += "  and Convert(varchar,addTime,120) like '" + Request["addTime"].ToString() + "%'";
                addTime.Text = Request["addTime"].ToString();
            }
            HWhere.Value = sqlstr;
            BindData("");
       }
    }
    private void BindjobTypeObj()
    {
        ListItem li = new ListItem("不限制", "0");
        jobTypeObj.Items.Add(li);
        DataSet jobTypeObjDs = BLL.bllJobType.getAllJobType();
        for (int i = 0; i < jobTypeObjDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = jobTypeObjDs.Tables[0].Rows[i];
            li = new ListItem(dr["jobTypeName"].ToString(),dr["jobTypeId"].ToString());
            jobTypeObj.Items.Add(li);
        }
        jobTypeObj.SelectedValue = "0";
    }

    private void BindcompanyObj()
    {
        ListItem li = new ListItem("不限制", "");
        companyObj.Items.Add(li);
        DataSet companyObjDs = BLL.bllCompany.getAllCompany();
        for (int i = 0; i < companyObjDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = companyObjDs.Tables[0].Rows[i];
            li = new ListItem(dr["companyName"].ToString(),dr["companyUserName"].ToString());
            companyObj.Items.Add(li);
        }
        companyObj.SelectedValue = "";
    }

    private void BindData(string strClass)
    {
        int DataCount = 0;
        int NowPage = 1;
        int AllPage = 0;
        int PageSize = Convert.ToInt32(HPageSize.Value);
        switch (strClass)
        {
            case "next":
                NowPage = Convert.ToInt32(HNowPage.Value) + 1;
                break;
            case "up":
                NowPage = Convert.ToInt32(HNowPage.Value) - 1;
                break;
            case "end":
                NowPage = Convert.ToInt32(HAllPage.Value);
                break;
            default:
                break;
        }
        DataTable dsLog = BLL.bllJob.GetJob(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
        if (dsLog.Rows.Count == 0 || AllPage == 1)
        {
            LBEnd.Enabled = false;
            LBHome.Enabled = false;
            LBNext.Enabled = false;
            LBUp.Enabled = false;
        }
        else if (NowPage == 1)
        {
            LBHome.Enabled = false;
            LBUp.Enabled = false;
            LBNext.Enabled = true;
            LBEnd.Enabled = true;
        }
        else if (NowPage == AllPage)
        {
            LBHome.Enabled = true;
            LBUp.Enabled = true;
            LBNext.Enabled = false;
            LBEnd.Enabled = false;
        }
        else
        {
            LBEnd.Enabled = true;
            LBHome.Enabled = true;
            LBNext.Enabled = true;
            LBUp.Enabled = true;
        }
        RpJob.DataSource = dsLog;
        RpJob.DataBind();
        PageMes.Text = string.Format("[每页<font color=green>{0}</font>条 第<font color=red>{1}</font>页／共<font color=green>{2}</font>页   共<font color=green>{3}</font>条]", PageSize, NowPage, AllPage, DataCount);
        HNowPage.Value = Convert.ToString(NowPage++);
        HAllPage.Value = AllPage.ToString();
    }

    protected void LBHome_Click(object sender, EventArgs e)
    {
        BindData("");
    }
    protected void LBUp_Click(object sender, EventArgs e)
    {
        BindData("up");
    }
    protected void LBNext_Click(object sender, EventArgs e)
    {
        BindData("next");
    }
    protected void LBEnd_Click(object sender, EventArgs e)
    {
        BindData("end");
    }
        public string GetJobTypejobTypeObj(string jobTypeObj)
        {
            return BLL.bllJobType.getSomeJobType(int.Parse(jobTypeObj)).jobTypeName;
        }

        public string GetCompanycompanyObj(string companyObj)
        {
            return BLL.bllCompany.getSomeCompany(companyObj).companyName;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("frontList.aspx?jobTypeObj=" + jobTypeObj.SelectedValue.Trim()+ "&&jobName=" + jobName.Text.Trim()+ "&&xlyq=" + xlyq.Text.Trim()+ "&&gzqy=" + gzqy.Text.Trim() + "&&companyObj=" + companyObj.SelectedValue.Trim()+ "&&addTime=" + addTime.Text.Trim());
        }

}
