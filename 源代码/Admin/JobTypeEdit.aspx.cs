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
    public partial class JobTypeEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                if (Request["jobTypeId"] != null)
                {
                    LoadData();
                }
            }
        }
        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "jobTypeId")))
            {
                ENTITY.JobType jobType = BLL.bllJobType.getSomeJobType(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "jobTypeId")));
                jobTypeName.Value = jobType.jobTypeName;
                jobTypeDesc.Value = jobType.jobTypeDesc;
            }
        }

        protected void BtnJobTypeSave_Click(object sender, EventArgs e)
        {
            ENTITY.JobType jobType = new ENTITY.JobType();
            jobType.jobTypeName = jobTypeName.Value;
            jobType.jobTypeDesc = jobTypeDesc.Value;
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "jobTypeId")))
            {
                jobType.jobTypeId = int.Parse(Request["jobTypeId"]);
                if (BLL.bllJobType.EditJobType(jobType))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"JobTypeEdit.aspx?jobTypeId=" + Request["jobTypeId"] + "\"} else  {location.href=\"JobTypeList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                if (BLL.bllJobType.AddJobType(jobType))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"JobTypeEdit.aspx\"} else  {location.href=\"JobTypeList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("JobTypeList.aspx");
        }
    }
}

