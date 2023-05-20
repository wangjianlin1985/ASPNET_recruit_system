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
    public partial class LeavewordEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindUserInfouserObj();
                if (Request["leaveWordId"] != null)
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
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "leaveWordId")))
            {
                ENTITY.Leaveword leaveword = BLL.bllLeaveword.getSomeLeaveword(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "leaveWordId")));
                leaveTitle.Value = leaveword.leaveTitle;
                leaveContent.Value = leaveword.leaveContent;
                userObj.SelectedValue = leaveword.userObj;
                leaveTime.Text = leaveword.leaveTime.ToShortDateString() + " " + leaveword.leaveTime.ToLongTimeString();
                replyContent.Value = leaveword.replyContent;
                replyTime.Text = leaveword.replyTime.ToShortDateString() + " " + leaveword.replyTime.ToLongTimeString();
            }
        }

        protected void BtnLeavewordSave_Click(object sender, EventArgs e)
        {
            ENTITY.Leaveword leaveword = new ENTITY.Leaveword();
            leaveword.leaveTitle = leaveTitle.Value;
            leaveword.leaveContent = leaveContent.Value;
            leaveword.userObj = userObj.SelectedValue;
            leaveword.leaveTime = Convert.ToDateTime(leaveTime.Text);
            leaveword.replyContent = replyContent.Value;
            leaveword.replyTime = Convert.ToDateTime(replyTime.Text);
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "leaveWordId")))
            {
                leaveword.leaveWordId = int.Parse(Request["leaveWordId"]);
                if (BLL.bllLeaveword.EditLeaveword(leaveword))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"LeavewordEdit.aspx?leaveWordId=" + Request["leaveWordId"] + "\"} else  {location.href=\"LeavewordList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                if (BLL.bllLeaveword.AddLeaveword(leaveword))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"LeavewordEdit.aspx\"} else  {location.href=\"LeavewordList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("LeavewordList.aspx");
        }
    }
}

