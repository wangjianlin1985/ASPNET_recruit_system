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
                /*进入本信息添加页显示无图的图片*/
                this.WebLogoImage.ImageUrl = "../FileUpload/NoImage.jpg";
                if (Request["linkId"] != null)
                {
                    LoadData();
                }
            }
        }
        /*如果是需要对记录进行编辑需要在界面初始化显示数据*/
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
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息修改成功，是否继续修改？否则返回信息列表。\")) {location.href=\"WebLinkEdit.aspx?linkId=" + Request["linkId"] + "\"} else  {location.href=\"WebLinkList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息修改失败，请重试或联系管理人员..");
                }
            }
            else
            {
                if (BLL.bllWebLink.AddWebLink(webLink))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息添加成功，是否继续添加？否则返回信息列表。\")) {location.href=\"WebLinkEdit.aspx\"} else  {location.href=\"WebLinkList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息添加失败，请重试或联系管理人员..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebLinkList.aspx");
        }
        protected void Btn_WebLogoUpload_Click(object sender, EventArgs e)
        {
            /*如果用户上传了文件*/
            if (this.WebLogoUpload.PostedFile.ContentLength > 0)
            {
                /*验证上传的文件格式，只能为gif和jpeg格式*/
                string mimeType = this.WebLogoUpload.PostedFile.ContentType;
                if (String.Compare(mimeType, "image/gif", true) == 0 || String.Compare(mimeType, "image/pjpeg", true) == 0 || String.Compare(mimeType, "image/jpeg", true) == 0)
                {
                    this.webLogo.Text = "上传文件中....";
                    string extFileString = System.IO.Path.GetExtension(this.WebLogoUpload.PostedFile.FileName); /*获取文件扩展名*/
                    string saveFileName = DAL.Function.MakeFileName(extFileString); /*根据扩展名生成文件名*/
                    string imagePath = "FileUpload/" + saveFileName;/*图片路径*/
                    this.WebLogoUpload.PostedFile.SaveAs(Server.MapPath("../" + imagePath));
                    this.WebLogoImage.ImageUrl = "../" + imagePath;
                    this.webLogo.Text = imagePath;
                }
                else
                {
                    Response.Write("<script>alert('上传文件格式不正确!');</script>");
                }
            }
        }
    }
}

