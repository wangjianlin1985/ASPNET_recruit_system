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
    public partial class DeliveryEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindJobjobObj();
                BindUserInfouserObj();
                if (Request["deliveryId"] != null)
                {
                    LoadData();
                }
            }
        }
        private void BindJobjobObj()
        {
            jobObj.DataSource = BLL.bllJob.getAllJob();
            jobObj.DataTextField = "jobName";
            jobObj.DataValueField = "jobId";
            jobObj.DataBind();
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
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "deliveryId")))
            {
                ENTITY.Delivery delivery = BLL.bllDelivery.getSomeDelivery(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "deliveryId")));
                jobObj.SelectedValue = delivery.jobObj.ToString();
                userObj.SelectedValue = delivery.userObj;
                deliveryTime.Text = delivery.deliveryTime.ToShortDateString() + " " + delivery.deliveryTime.ToLongTimeString();
                handleTime.Text = delivery.handleTime.ToShortDateString() + " " + delivery.handleTime.ToLongTimeString();
                clzt.Value = delivery.clzt;
                tzxx.Value = delivery.tzxx;
                gzpj.Value = delivery.gzpj;
            }
        }

        protected void BtnDeliverySave_Click(object sender, EventArgs e)
        {
            ENTITY.Delivery delivery = new ENTITY.Delivery();
            delivery.jobObj = int.Parse(jobObj.SelectedValue);
            delivery.userObj = userObj.SelectedValue;
            delivery.deliveryTime = Convert.ToDateTime(deliveryTime.Text);
            delivery.handleTime = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString());
            delivery.clzt = clzt.Value;
            delivery.tzxx = tzxx.Value;
            delivery.gzpj = gzpj.Value;
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "deliveryId")))
            {
                delivery.deliveryId = int.Parse(Request["deliveryId"]);
                if (BLL.bllDelivery.EditDelivery(delivery))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"companyDeliveryEdit.aspx?deliveryId=" + Request["deliveryId"] + "\"} else  {location.href=\"companyDeliveryList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("companyDeliveryList.aspx");
        }
    }
}

