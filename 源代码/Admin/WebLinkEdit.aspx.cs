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
    public partial class WebLinkEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                /*���뱾��Ϣ���ҳ��ʾ��ͼ��ͼƬ*/
                this.WebLogoImage.ImageUrl = "../FileUpload/NoImage.jpg";
                if (Request["linkId"] != null)
                {
                    LoadData();
                }
            }
        }
        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "linkId")))
            {
                ENTITY.WebLink webLink = BLL.bllWebLink.getSomeWebLink(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "linkId")));
                webName.Value = webLink.webName;
                webLogo.Text = webLink.webLogo;
                if (webLink.webLogo != "") this.WebLogoImage.ImageUrl = "../" + webLink.webLogo;
                webAddress.Value = webLink.webAddress;
            }
        }

        protected void BtnWebLinkSave_Click(object sender, EventArgs e)
        {
            ENTITY.WebLink webLink = new ENTITY.WebLink();
            webLink.webName = webName.Value;
            if (webLogo.Text == "") webLogo.Text = "FileUpload/NoImage.jpg";
            webLink.webLogo = webLogo.Text;
            webLink.webAddress = webAddress.Value;
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "linkId")))
            {
                webLink.linkId = int.Parse(Request["linkId"]);
                if (BLL.bllWebLink.EditWebLink(webLink))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"WebLinkEdit.aspx?linkId=" + Request["linkId"] + "\"} else  {location.href=\"WebLinkList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                if (BLL.bllWebLink.AddWebLink(webLink))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"WebLinkEdit.aspx\"} else  {location.href=\"WebLinkList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebLinkList.aspx");
        }
        protected void Btn_WebLogoUpload_Click(object sender, EventArgs e)
        {
            /*����û��ϴ����ļ�*/
            if (this.WebLogoUpload.PostedFile.ContentLength > 0)
            {
                /*��֤�ϴ����ļ���ʽ��ֻ��Ϊgif��jpeg��ʽ*/
                string mimeType = this.WebLogoUpload.PostedFile.ContentType;
                if (String.Compare(mimeType, "image/gif", true) == 0 || String.Compare(mimeType, "image/pjpeg", true) == 0 || String.Compare(mimeType, "image/jpeg", true) == 0)
                {
                    this.webLogo.Text = "�ϴ��ļ���....";
                    string extFileString = System.IO.Path.GetExtension(this.WebLogoUpload.PostedFile.FileName); /*��ȡ�ļ���չ��*/
                    string saveFileName = DAL.Function.MakeFileName(extFileString); /*������չ�������ļ���*/
                    string imagePath = "FileUpload/" + saveFileName;/*ͼƬ·��*/
                    this.WebLogoUpload.PostedFile.SaveAs(Server.MapPath("../" + imagePath));
                    this.WebLogoImage.ImageUrl = "../" + imagePath;
                    this.webLogo.Text = imagePath;
                }
                else
                {
                    Response.Write("<script>alert('�ϴ��ļ���ʽ����ȷ!');</script>");
                }
            }
        }
    }
}

