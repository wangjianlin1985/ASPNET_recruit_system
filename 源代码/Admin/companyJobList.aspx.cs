using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace chengxusheji.Admin
{
    public partial class JobList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindjobTypeObj();
                
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
              
                if (Request["addTime"] != null && Request["addTime"].ToString() != "")
                {
                    sqlstr += "  and Convert(varchar,addTime,120) like '" + Request["addTime"].ToString() + "%'";
                    addTime.Text = Request["addTime"].ToString();
                }
                sqlstr += "  and companyObj='" + Session["Customername"].ToString() + "'";
                HWhere.Value = sqlstr;
                BindData("");
            }
        }
        private void BindjobTypeObj()
        {
            ListItem li = new ListItem("������", "0");
            jobTypeObj.Items.Add(li);
            DataSet jobTypeObjDs = BLL.bllJobType.getAllJobType();
            for (int i = 0; i < jobTypeObjDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = jobTypeObjDs.Tables[0].Rows[i];
                li = new ListItem(dr["jobTypeName"].ToString(), dr["jobTypeName"].ToString());
                jobTypeObj.Items.Add(li);
            }
            jobTypeObj.SelectedValue = "0";
        }

        

        protected void BtnJobAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("companyJobEdit.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllJob.DelJob(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "��Ϣ�ɹ�ɾ��..", "companyJobList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "error", "��Ϣɾ��ʧ�ܣ������Ի���ϵ������Ա..");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "error", "ɾ��ʧ��..");
                }
            }
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
            PageMes.Text = string.Format("[ÿҳ<font color=green>{0}</font>�� ��<font color=red>{1}</font>ҳ����<font color=green>{2}</font>ҳ   ��<font color=green>{3}</font>��]", PageSize, NowPage, AllPage, DataCount);
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
        protected void RpJob_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllJob.DelJob((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "��Ϣɾ���ɹ�...", "companyJobList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "��Ϣɾ��ʧ�ܣ������Ի���ϵ������Ա...", "companyJobList.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "ɾ��ʧ��...", "companyJobList.aspx");
                }
            }
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
            Response.Redirect("companyJobList.aspx?jobTypeObj=" + jobTypeObj.SelectedValue.Trim()+ "&&jobName=" + jobName.Text.Trim()+ "&&xlyq=" + xlyq.Text.Trim()+ "&&gzqy=" + gzqy.Text.Trim() + "&&companyObj=" + companyObj.SelectedValue.Trim()+ "&&addTime=" + addTime.Text.Trim());
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet jobDataSet = BLL.bllJob.GetJob(HWhere.Value); 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            sb.Append("<table borderColor='black' border='1' >");
            sb.Append("<thead><tr><th colSpan='11'>ְλ��¼</th></tr>");
            sb.Append("<tr class='title'>");
            sb.Append("<th>ְλid</th>");
            sb.Append("<th>ְλ���</th>");
            sb.Append("<th>ְλ����</th>");
            sb.Append("<th>����н��</th>");
            sb.Append("<th>��Ƹ����</th>");
            sb.Append("<th>ѧ��Ҫ��</th>");
            sb.Append("<th>��Ч����</th>");
            sb.Append("<th>��������</th>");
            sb.Append("<th>�������</th>");
            sb.Append("<th>������ҵ</th>");
            sb.Append("<th>����ʱ��</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");
            for (int i = 0; i < jobDataSet.Tables[0].Rows.Count; i++)
            {
                DataRow dr = jobDataSet.Tables[0].Rows[i];
                sb.Append("<tr class=content>");
                sb.Append("<td>" + dr["jobId"].ToString() + "</td>");
                sb.Append("<td>" + BLL.bllJobType.getSomeJobType(Convert.ToInt32(dr["jobTypeObj"])).jobTypeName + "</td>");
                sb.Append("<td>" + dr["jobName"].ToString() + "</td>");
                sb.Append("<td>" + dr["salary"].ToString() + "</td>");
                sb.Append("<td>" + dr["zprs"].ToString() + "</td>");
                sb.Append("<td>" + dr["xlyq"].ToString() + "</td>");
                sb.Append("<td>" + dr["yxqx"].ToString() + "</td>");
                sb.Append("<td>" + dr["gzqy"].ToString() + "</td>");
                sb.Append("<td>" + dr["viewNum"].ToString() + "</td>");
                sb.Append("<td>" + BLL.bllCompany.getSomeCompany(dr["companyObj"].ToString()).companyName + "</td>");
                sb.Append("<td>" + Convert.ToDateTime(dr["addTime"]).ToShortDateString() + "</td>");
                sb.Append("</tr>");
            } 
           sb.Append("</tbody></table>");
            string content = sb.ToString();
            string css = ".content{color:red;text-align:center;}";
            string filename = "ְλ��¼.xls";
            CommonTool.ExportToExcel(filename, content, css);
        }

        protected string GetBaseUrl()
        {
            return Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf("/Admin"));
        }
    }
}
