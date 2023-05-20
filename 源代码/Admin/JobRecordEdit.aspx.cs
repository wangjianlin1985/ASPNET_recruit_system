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
    public partial class JobRecordEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindUserInfouserObj();
                if (Request["recordId"] != null)
                {
                    LoadData();
                }
            }
        }
        private void BindUserInfouserObj()
        {
            userObj.DataSource = BLL.bllUserInfo.getAllUserInfo();
            userObj.DataTextField = "name";
            userObj.DataValueField = "user_name";
            userObj.DataBind();
        }

        /*如果是需要对记录进行编辑需要在界面初始化显示数据*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "recordId")))
            {
                ENTITY.JobRecord jobRecord = BLL.bllJobRecord.getSomeJobRecord(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "recordId")));
                title.Value = jobRecord.title;
                content.Value = jobRecord.content;
                userObj.SelectedValue = jobRecord.userObj;
                recordDate.Text = jobRecord.recordDate.ToShortDateString() + " " + jobRecord.recordDate.ToLongTimeString();
            }
        }

        protected void BtnJobRecordSave_Click(object sender, EventArgs e)
        {
            ENTITY.JobRecord jobRecord = new ENTITY.JobRecord();
            jobRecord.title = title.Value;
            jobRecord.content = content.Value;
            jobRecord.userObj = userObj.SelectedValue;
            jobRecord.recordDate = Convert.ToDateTime(recordDate.Text);
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "recordId")))
            {
                jobRecord.recordId = int.Parse(Request["recordId"]);
                if (BLL.bllJobRecord.EditJobRecord(jobRecord))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息修改成功，是否继续修改？否则返回信息列表。\")) {location.href=\"JobRecordEdit.aspx?recordId=" + Request["recordId"] + "\"} else  {location.href=\"JobRecordList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息修改失败，请重试或联系管理人员..");
                }
            }
            else
            {
                if (BLL.bllJobRecord.AddJobRecord(jobRecord))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息添加成功，是否继续添加？否则返回信息列表。\")) {location.href=\"JobRecordEdit.aspx\"} else  {location.href=\"JobRecordList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息添加失败，请重试或联系管理人员..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("JobRecordList.aspx");
        }
    }
}

