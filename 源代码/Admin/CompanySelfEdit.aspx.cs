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
    public partial class CompanyEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                /*进入本信息添加页显示无图的图片*/
                this.YyzzImage.ImageUrl = "../FileUpload/NoImage.jpg";
                 
                LoadData();
                
            }
        }
        /*如果是需要对记录进行编辑需要在界面初始化显示数据*/
        private void LoadData()
        {
             
                ENTITY.Company company = BLL.bllCompany.getSomeCompany(Session["Customername"].ToString());
                companyUserName.Value = company.companyUserName;
                password.Value = company.password;
                qyjb.Value = company.qyjb;
                companyName.Value = company.companyName;
                gszch.Value = company.gszch;
                yyzz.Text = company.yyzz;
                if (company.yyzz != "") this.YyzzImage.ImageUrl = "../" + company.yyzz;
                gsxz.Value = company.gsxz;
                gsgm.Value = company.gsgm;
                gghy.Value = company.gghy;
                lxr.Value = company.lxr;
                lxdh.Value = company.lxdh;
                companyDesc.Value = company.companyDesc;
                address.Value = company.address;
                shzt.Value = company.shzt;
           
        }

        protected void BtnCompanySave_Click(object sender, EventArgs e)
        {
            ENTITY.Company company = new ENTITY.Company();
            company.companyUserName = this.companyUserName.Value;
            company.password = password.Value;
            company.qyjb = qyjb.Value;
            company.companyName = companyName.Value;
            company.gszch = gszch.Value;
            if (yyzz.Text == "") yyzz.Text = "FileUpload/NoImage.jpg";
            company.yyzz = yyzz.Text;
            company.gsxz = gsxz.Value;
            company.gsgm = gsgm.Value;
            company.gghy = gghy.Value;
            company.lxr = lxr.Value;
            company.lxdh = lxdh.Value;
            company.companyDesc = companyDesc.Value;
            company.address = address.Value;
            company.shzt = shzt.Value;

            company.companyUserName = Session["Customername"].ToString();
            if (BLL.bllCompany.EditCompany(company))
            {
                Common.ShowMessage.myScriptMes(Page, "Suess", "alert('企业信息修改成功！');");
            }
            else
            {
                Common.ShowMessage.Show(Page, "error", "信息修改失败，请重试或联系管理人员..");
            }
            
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Response.Redirect("CompanyList.aspx");
        }
        protected void Btn_YyzzUpload_Click(object sender, EventArgs e)
        {
            /*如果用户上传了文件*/
            if (this.YyzzUpload.PostedFile.ContentLength > 0)
            {
                /*验证上传的文件格式，只能为gif和jpeg格式*/
                string mimeType = this.YyzzUpload.PostedFile.ContentType;
                if (String.Compare(mimeType, "image/gif", true) == 0 || String.Compare(mimeType, "image/pjpeg", true) == 0 || String.Compare(mimeType, "image/jpeg", true) == 0)
                {
                    this.yyzz.Text = "上传文件中....";
                    string extFileString = System.IO.Path.GetExtension(this.YyzzUpload.PostedFile.FileName); /*获取文件扩展名*/
                    string saveFileName = DAL.Function.MakeFileName(extFileString); /*根据扩展名生成文件名*/
                    string imagePath = "FileUpload/" + saveFileName;/*图片路径*/
                    this.YyzzUpload.PostedFile.SaveAs(Server.MapPath("../" + imagePath));
                    this.YyzzImage.ImageUrl = "../" + imagePath;
                    this.yyzz.Text = imagePath;
                }
                else
                {
                    Response.Write("<script>alert('上传文件格式不正确!');</script>");
                }
            }
        }
    }
}

