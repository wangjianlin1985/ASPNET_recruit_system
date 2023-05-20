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
    public partial class DeliveryList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindjobObj();
                BinduserObj();
                string sqlstr = " where 1=1 ";
                if (Request["jobObj"] != null && Request["jobObj"].ToString() != "0")
                {
                    sqlstr += "  and jobObj=" + Request["jobObj"].ToString();
                    jobObj.SelectedValue = Request["jobObj"].ToString();
                }
                if (Request["userObj"] != null && Request["userObj"].ToString() != "")
                {
                    sqlstr += "  and userObj='" + Request["userObj"].ToString() + "'";
                    userObj.SelectedValue = Request["userObj"].ToString();
                }
                if (Request["deliveryTime"] != null && Request["deliveryTime"].ToString() != "")
                {
                    sqlstr += "  and Convert(varchar,deliveryTime,120) like '" + Request["deliveryTime"].ToString() + "%'";
                    deliveryTime.Text = Request["deliveryTime"].ToString();
                }
                if (Request["handleTime"] != null && Request["handleTime"].ToString() != "")
                {
                    sqlstr += "  and Convert(varchar,handleTime,120) like '" + Request["handleTime"].ToString() + "%'";
                    handleTime.Text = Request["handleTime"].ToString();
                }
                if (Request["clzt"] != null && Request["clzt"].ToString() != "")
                {
                    sqlstr += "  and clzt like '%" + Request["clzt"].ToString() + "%'";
                    clzt.Text = Request["clzt"].ToString();
                }

                sqlstr += "  and companyObj='" + Session["Customername"].ToString() + "'";
                HWhere.Value = sqlstr;
                BindData("");
            }
        }
        private void BindjobObj()
        {
            ListItem li = new ListItem("不限制", "0");
            jobObj.Items.Add(li);
            DataSet jobObjDs = BLL.bllJob.getAllJob();
            for (int i = 0; i < jobObjDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = jobObjDs.Tables[0].Rows[i];
                li = new ListItem(dr["jobName"].ToString(), dr["jobName"].ToString());
                jobObj.Items.Add(li);
            }
            jobObj.SelectedValue = "0";
        }

        private void BinduserObj()
        {
            ListItem li = new ListItem("不限制", "");
            userObj.Items.Add(li);
            DataSet userObjDs = BLL.bllUserInfo.getAllUserInfo();
            for (int i = 0; i < userObjDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = userObjDs.Tables[0].Rows[i];
                li = new ListItem(dr["name"].ToString(), dr["name"].ToString());
                userObj.Items.Add(li);
            }
            userObj.SelectedValue = "";
        }

        protected void BtnDeliveryAdd_Click(object sender, EventArgs e)
        {
            //Response.Redirect("DeliveryEdit.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllDelivery.DelDelivery(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "信息成功删除..", "companyDeliveryList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "error", "信息删除失败，请重试或联系管理人员..");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "error", "删除失败..");
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
            DataTable dsLog = BLL.bllDelivery.GetDelivery2(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
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
            RpDelivery.DataSource = dsLog;
            RpDelivery.DataBind();
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
        protected void RpDelivery_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllDelivery.DelDelivery((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除成功...", "companyDeliveryList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除失败，请重试或联系管理人员...", "companyDeliveryList.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "删除失败...", "companyDeliveryList.aspx");
                }
            }
        }
        public string GetJobjobObj(string jobObj)
        {
            return BLL.bllJob.getSomeJob(int.Parse(jobObj)).jobName;
        }

        public string GetUserInfouserObj(string userObj)
        {
            return BLL.bllUserInfo.getSomeUserInfo(userObj).name;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("companyDeliveryList.aspx?jobObj=" + jobObj.SelectedValue.Trim() + "&&userObj=" + userObj.SelectedValue.Trim()+ "&&deliveryTime=" + deliveryTime.Text.Trim()+ "&&handleTime=" + handleTime.Text.Trim()+ "&&clzt=" + clzt.Text.Trim());
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet deliveryDataSet = BLL.bllDelivery.GetDelivery(HWhere.Value); 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            sb.Append("<table borderColor='black' border='1' >");
            sb.Append("<thead><tr><th colSpan='8'>简历投递记录</th></tr>");
            sb.Append("<tr class='title'>");
            sb.Append("<th>投递id</th>");
            sb.Append("<th>应聘职位</th>");
            sb.Append("<th>应聘人</th>");
            sb.Append("<th>投递时间</th>");
            sb.Append("<th>处理时间</th>");
            sb.Append("<th>处理状态</th>");
            sb.Append("<th>通知信息</th>");
            sb.Append("<th>工作评价</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");
            for (int i = 0; i < deliveryDataSet.Tables[0].Rows.Count; i++)
            {
                DataRow dr = deliveryDataSet.Tables[0].Rows[i];
                sb.Append("<tr class=content>");
                sb.Append("<td>" + dr["deliveryId"].ToString() + "</td>");
                sb.Append("<td>" + BLL.bllJob.getSomeJob(Convert.ToInt32(dr["jobObj"])).jobName + "</td>");
                sb.Append("<td>" + BLL.bllUserInfo.getSomeUserInfo(dr["userObj"].ToString()).name + "</td>");
                sb.Append("<td>" + Convert.ToDateTime(dr["deliveryTime"]).ToShortDateString() + "</td>");
                sb.Append("<td>" + Convert.ToDateTime(dr["handleTime"]).ToShortDateString() + "</td>");
                sb.Append("<td>" + dr["clzt"].ToString() + "</td>");
                sb.Append("<td>" + dr["tzxx"].ToString() + "</td>");
                sb.Append("<td>" + dr["gzpj"].ToString() + "</td>");
                sb.Append("</tr>");
            } 
           sb.Append("</tbody></table>");
            string content = sb.ToString();
            string css = ".content{color:red;text-align:center;}";
            string filename = "简历投递记录.xls";
            CommonTool.ExportToExcel(filename, content, css);
        }

        protected string GetBaseUrl()
        {
            return Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf("/Admin"));
        }
    }
}
