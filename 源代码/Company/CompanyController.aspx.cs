using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using com.force.json;

public partial class Company_CompanyController : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["action"];
        if (action == "add") addCompany();
        if (action == "delete") deleteCompany();
        if (action == "update") updateCompany();
        if (action == "getCompany") getCompany();
        if (action == "listAll") listAll();
    }
    //处理添加企业控制层方法
    protected void addCompany()
    {
        int success = 0;
        string message = "";
        ENTITY.Company company = new ENTITY.Company();
        company.companyUserName = Request["company.companyUserName"];
        if (BLL.bllCompany.getSomeCompany(company.companyUserName) != null)
        {
            message = "该企业用户名已经存在！";
            writeResult(success, message);
            return;
        }
        company.password = Request["company.password"];
        company.qyjb = Request["company.qyjb"];
        company.companyName = Request["company.companyName"];
        company.gszch = Request["company.gszch"];
        try {
            company.yyzz = handleImageUpload("yyzzFile");
        } catch {
            message = "图片格式不正确！";
            writeResult(success, message);
            return;
        }
        company.gsxz = Request["company.gsxz"];
        company.gsgm = Request["company.gsgm"];
        company.gghy = Request["company.gghy"];
        company.lxr = Request["company.lxr"];
        company.lxdh = Request["company.lxdh"];
        company.companyDesc = Request["company.companyDesc"];
        company.address = Request["company.address"];
        company.shzt = Request["company.shzt"];
        if (!BLL.bllCompany.AddCompany(company))
        {
            message = "添加企业发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //处理删除企业控制层方法
    protected void deleteCompany()
    {
        int success = 0;
        string message = "";
        string companyUserName = Request["companyUserName"];
        try {
            BLL.bllCompany.DelCompany(companyUserName);
            success = 1;
        } catch {
            message = "企业删除失败";
        }
        writeResult(success, message);
    }

    //处理更新企业控制层方法
    protected void updateCompany()
    {
        int success = 0;
        string message = "";
        ENTITY.Company company = new ENTITY.Company();
        company.companyUserName = Request["Company.companyUserName"];
        company.password = Request["company.password"];
        company.qyjb = Request["company.qyjb"];
        company.companyName = Request["company.companyName"];
        company.gszch = Request["company.gszch"];
        company.yyzz = Request["company.yyzz"];
        string yyzzPath = handleImageUpload("yyzzFile");
        if (yyzzPath != "FileUpload/NoImage.jpg") company.yyzz = yyzzPath;
        company.gsxz = Request["company.gsxz"];
        company.gsgm = Request["company.gsgm"];
        company.gghy = Request["company.gghy"];
        company.lxr = Request["company.lxr"];
        company.lxdh = Request["company.lxdh"];
        company.companyDesc = Request["company.companyDesc"];
        company.address = Request["company.address"];
        company.shzt = Request["company.shzt"];
        if (!BLL.bllCompany.EditCompany(company))
        {
            message = "更新企业发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //获取单个企业对象，返回json格式
    protected void getCompany()
    {
        String companyUserName = Request.QueryString["companyUserName"];
        ENTITY.Company company = BLL.bllCompany.getSomeCompany(companyUserName);
        JSONObject jsonCompany = new JSONObject();
        jsonCompany.Put("companyUserName", company.companyUserName);
        jsonCompany.Put("password", company.password);
        jsonCompany.Put("qyjb", company.qyjb);
        jsonCompany.Put("companyName", company.companyName);
        jsonCompany.Put("gszch", company.gszch);
        jsonCompany.Put("yyzz", company.yyzz);
        jsonCompany.Put("gsxz", company.gsxz);
        jsonCompany.Put("gsgm", company.gsgm);
        jsonCompany.Put("gghy", company.gghy);
        jsonCompany.Put("lxr", company.lxr);
        jsonCompany.Put("lxdh", company.lxdh);
        jsonCompany.Put("companyDesc", company.companyDesc);
        jsonCompany.Put("address", company.address);
        jsonCompany.Put("shzt", company.shzt);
        Response.Write(jsonCompany.ToString());
    }

    protected void listAll()
    {
        DataSet companyDs = BLL.bllCompany.getAllCompany();
        JSONArray companyArray = new JSONArray();
        for (int i = 0; i < companyDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = companyDs.Tables[0].Rows[i];
            JSONObject jsonCompany = new JSONObject();
            jsonCompany.Put("companyUserName", dr["companyUserName"].ToString());
            jsonCompany.Put("companyName", dr["companyName"].ToString());
            companyArray.Put(jsonCompany);
        }
        Response.Write(companyArray.ToString());
    }

    //把处理结果返回给界面层
    protected void writeResult(int success, string message)
    {
        JSONObject resultObj = new JSONObject();
        resultObj.Put("success", success);
        resultObj.Put("message", message);
        Response.Write(resultObj.ToString());
    }

    //处理图片文件上传
    protected string handleImageUpload(string fileKeyName)
    {
        string imagePath = "FileUpload/NoImage.jpg";
        HttpPostedFile photoFile = Request.Files[fileKeyName];
        if (photoFile.ContentLength > 0)
        { 
            //获取文件的扩展名
            string fileExt = Path.GetExtension(photoFile.FileName);
            List<string> ExtList = new List<string>(new string[] { ".jpg", ".gif" });
            if (!ExtList.Contains(fileExt))
            {
                throw new Exception("图片格式不正确！");
            }
            string saveFileName = DAL.Function.MakeFileName(fileExt);
            imagePath = "FileUpload/" + saveFileName;/*图片路径*/
            photoFile.SaveAs(Server.MapPath("../" + imagePath));
        }
        return imagePath;
    }

}
