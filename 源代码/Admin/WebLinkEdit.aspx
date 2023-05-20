<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebLinkEdit.aspx.cs" Inherits="chengxusheji.Admin.WebLinkEdit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
   <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
    <script type="text/javascript" src="JavaScript/Admin.js"></script>
    <script type="text/javascript" src="../js/jsdate.js"></script>
    <script type="text/javascript">
        function CheckIn() {
            var re = /^[0-9]+.?[0-9]*$/;
            var resc=/^[1-9]+[0-9]*]*$/ ;
            var webName = document.getElementById("webName").value;
            if (webName == "") {
                alert("请输入网站名称...");
                document.getElementById("webName").focus();
                return false;
            }

            var webAddress = document.getElementById("webAddress").value;
            if (webAddress == "") {
                alert("请输入网站地址...");
                document.getElementById("webAddress").focus();
                return false;
            }

            return true;
       } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_All">
    <div class="Body_Title">友情链接管理 》》编辑友情链接</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   网站名称：</td>
                    <td width="650px;">
                         <input id="webName" type="text"   style="width:500px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入网站名称！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   网站Logo：</td>
                    <td width="650px;">
                       <table cellpadding="0px" cellspacing="0px" width="90%">
                        <tr><td width="400px">
                         图片路径：<asp:TextBox ID="webLogo" runat="server" ReadOnly="True" Width="228px" Enabled="False"></asp:TextBox> &nbsp; &nbsp; &nbsp
                         <br />
                         <br />
                         上传图片：<asp:FileUpload ID="WebLogoUpload" runat="server" Width="237px" />&nbsp;
                         <asp:Button ID="Btn_WebLogoUpload" runat="server" Text="上传" OnClick="Btn_WebLogoUpload_Click" /></td><td>
                         <asp:Image ID="WebLogoImage" runat="server" Height="90px" Width="99px" />
                         </td></tr>
                       </table>
                    </td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   网站地址：</td>
                    <td width="650px;">
                         <input id="webAddress" type="text"   style="width:800px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入网站地址！</td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnWebLinkSave" runat="server" Text=" 保存信息 "
                            OnClientClick="return CheckIn()" onclick="BtnWebLinkSave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="取消" onclick="Button1_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>

