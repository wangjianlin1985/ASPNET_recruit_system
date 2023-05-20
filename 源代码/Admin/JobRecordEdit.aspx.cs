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

        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
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
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"JobRecordEdit.aspx?recordId=" + Request["recordId"] + "\"} else  {location.href=\"JobRecordList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                if (BLL.bllJobRecord.AddJobRecord(jobRecord))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"JobRecordEdit.aspx\"} else  {location.href=\"JobRecordList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("JobRecordList.aspx");
        }
    }
}

