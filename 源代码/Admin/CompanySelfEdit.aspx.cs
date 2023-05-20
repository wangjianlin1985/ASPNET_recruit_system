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
                /*���뱾��Ϣ���ҳ��ʾ��ͼ��ͼƬ*/
                this.YyzzImage.ImageUrl = "../FileUpload/NoImage.jpg";
                 
                LoadData();
                
            }
        }
        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
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
                Common.ShowMessage.myScriptMes(Page, "Suess", "alert('��ҵ��Ϣ�޸ĳɹ���');");
            }
            else
            {
                Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
            }
            
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Response.Redirect("CompanyList.aspx");
        }
        protected void Btn_YyzzUpload_Click(object sender, EventArgs e)
        {
            /*����û��ϴ����ļ�*/
            if (this.YyzzUpload.PostedFile.ContentLength > 0)
            {
                /*��֤�ϴ����ļ���ʽ��ֻ��Ϊgif��jpeg��ʽ*/
                string mimeType = this.YyzzUpload.PostedFile.ContentType;
                if (String.Compare(mimeType, "image/gif", true) == 0 || String.Compare(mimeType, "image/pjpeg", true) == 0 || String.Compare(mimeType, "image/jpeg", true) == 0)
                {
                    this.yyzz.Text = "�ϴ��ļ���....";
                    string extFileString = System.IO.Path.GetExtension(this.YyzzUpload.PostedFile.FileName); /*��ȡ�ļ���չ��*/
                    string saveFileName = DAL.Function.MakeFileName(extFileString); /*������չ�������ļ���*/
                    string imagePath = "FileUpload/" + saveFileName;/*ͼƬ·��*/
                    this.YyzzUpload.PostedFile.SaveAs(Server.MapPath("../" + imagePath));
                    this.YyzzImage.ImageUrl = "../" + imagePath;
                    this.yyzz.Text = imagePath;
                }
                else
                {
                    Response.Write("<script>alert('�ϴ��ļ���ʽ����ȷ!');</script>");
                }
            }
        }
    }
}

