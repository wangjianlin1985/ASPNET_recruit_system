using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using com.force.json;

public partial class WebLink_WebLinkController : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["action"];
        if (action == "add") addWebLink();
        if (action == "delete") deleteWebLink();
        if (action == "update") updateWebLink();
        if (action == "getWebLink") getWebLink();
        if (action == "listAll") listAll();
    }
    //处理添加友情链接控制层方法
    protected void addWebLink()
    {
        int success = 0;
        string message = "";
        ENTITY.WebLink webLink = new ENTITY.WebLink();
        webLink.webName = Request["webLink.webName"];
        try {
            webLink.webLogo = handleImageUpload("webLogoFile");
        } catch {
            message = "图片格式不正确！";
            writeResult(success, message);
            return;
        }
        webLink.webAddress = Request["webLink.webAddress"];
        if (!BLL.bllWebLink.AddWebLink(webLink))
        {
            message = "添加友情链接发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //处理删除友情链接控制层方法
    protected void deleteWebLink()
    {
        int success = 0;
        string message = "";
        string linkId = Request["linkId"];
        try {
            BLL.bllWebLink.DelWebLink(linkId);
            success = 1;
        } catch {
            message = "友情链接删除失败";
        }
        writeResult(success, message);
    }

    //处理更新友情链接控制层方法
    protected void updateWebLink()
    {
        int success = 0;
        string message = "";
        ENTITY.WebLink webLink = new ENTITY.WebLink();
        webLink.linkId = int.Parse(Request["WebLink.linkId"]);
        webLink.webName = Request["webLink.webName"];
        webLink.webLogo = Request["webLink.webLogo"];
        string webLogoPath = handleImageUpload("webLogoFile");
        if (webLogoPath != "FileUpload/NoImage.jpg") webLink.webLogo = webLogoPath;
        webLink.webAddress = Request["webLink.webAddress"];
        if (!BLL.bllWebLink.EditWebLink(webLink))
        {
            message = "更新友情链接发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //获取单个友情链接对象，返回json格式
    protected void getWebLink()
    {
        int linkId = int.Parse(Request.QueryString["linkId"]);
        ENTITY.WebLink webLink = BLL.bllWebLink.getSomeWebLink(linkId);
        JSONObject jsonWebLink = new JSONObject();
        jsonWebLink.Put("linkId", webLink.linkId);
        jsonWebLink.Put("webName", webLink.webName);
        jsonWebLink.Put("webLogo", webLink.webLogo);
        jsonWebLink.Put("webAddress", webLink.webAddress);
        Response.Write(jsonWebLink.ToString());
    }

    protected void listAll()
    {
        DataSet webLinkDs = BLL.bllWebLink.getAllWebLink();
        JSONArray webLinkArray = new JSONArray();
        for (int i = 0; i < webLinkDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = webLinkDs.Tables[0].Rows[i];
            JSONObject jsonWebLink = new JSONObject();
            jsonWebLink.Put("linkId", Convert.ToInt32(dr["linkId"]));
            jsonWebLink.Put("webName", dr["webName"].ToString());
            webLinkArray.Put(jsonWebLink);
        }
        Response.Write(webLinkArray.ToString());
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
