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
    public partial class JobEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindJobTypejobTypeObj();
                BindCompanycompanyObj();
                if (Request["jobId"] != null)
                {
                    LoadData();
                }
            }
        }
        private void BindJobTypejobTypeObj()
        {
            jobTypeObj.DataSource = BLL.bllJobType.getAllJobType();
            jobTypeObj.DataTextField = "jobTypeName";
            jobTypeObj.DataValueField = "jobTypeId";
            jobTypeObj.DataBind();
        }

        private void BindCompanycompanyObj()
        {
            companyObj.DataSource = BLL.bllCompany.getAllCompany();
            companyObj.DataTextField = "companyName";
            companyObj.DataValueField = "companyUserName";
            companyObj.DataBind();
        }

        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "jobId")))
            {
                ENTITY.Job job = BLL.bllJob.getSomeJob(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "jobId")));
                jobTypeObj.SelectedValue = job.jobTypeObj.ToString();
                jobName.Value = job.jobName;
                jobDesc.Value = job.jobDesc;
                salary.Value = job.salary;
                zprs.Value = job.zprs.ToString();
                xlyq.Value = job.xlyq;
                yxqx.Value = job.yxqx;
                gzqy.Value = job.gzqy;
                gzdz.Value = job.gzdz;
                viewNum.Value = job.viewNum.ToString();
                companyObj.SelectedValue = job.companyObj;
                addTime.Text = job.addTime.ToShortDateString() + " " + job.addTime.ToLongTimeString();
            }
        }

        protected void BtnJobSave_Click(object sender, EventArgs e)
        {
            ENTITY.Job job = new ENTITY.Job();
            job.jobTypeObj = int.Parse(jobTypeObj.SelectedValue);
            job.jobName = jobName.Value;
            job.jobDesc = jobDesc.Value;
            job.salary = salary.Value;
            job.zprs = int.Parse(zprs.Value);
            job.xlyq = xlyq.Value;
            job.yxqx = yxqx.Value;
            job.gzqy = gzqy.Value;
            job.gzdz = gzdz.Value;
            job.viewNum = int.Parse(viewNum.Value);
            job.companyObj = companyObj.SelectedValue;
            
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "jobId")))
            {

                job.jobId = int.Parse(Request["jobId"]);
                job.addTime = Convert.ToDateTime(addTime.Text);
                if (BLL.bllJob.EditJob(job))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"companyJobEdit.aspx?jobId=" + Request["jobId"] + "\"} else  {location.href=\"companyJobList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                job.companyObj = Session["Customername"].ToString();
                job.addTime = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString());
                if (BLL.bllJob.AddJob(job))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"companyJobEdit.aspx\"} else  {location.href=\"companyJobList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("companyJobList.aspx");
        }
    }
}

