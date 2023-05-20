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
                alert("��������վ����...");
                document.getElementById("webName").focus();
                return false;
            }

            var webAddress = document.getElementById("webAddress").value;
            if (webAddress == "") {
                alert("��������վ��ַ...");
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
    <div class="Body_Title">�������ӹ��� �����༭��������</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��վ���ƣ�</td>
                    <td width="650px;">
                         <input id="webName" type="text"   style="width:500px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>��������վ���ƣ�</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��վLogo��</td>
                    <td width="650px;">
                       <table cellpadding="0px" cellspacing="0px" width="90%">
                        <tr><td width="400px">
                         ͼƬ·����<asp:TextBox ID="webLogo" runat="server" ReadOnly="True" Width="228px" Enabled="False"></asp:TextBox> &nbsp; &nbsp; &nbsp
                         <br />
                         <br />
                         �ϴ�ͼƬ��<asp:FileUpload ID="WebLogoUpload" runat="server" Width="237px" />&nbsp;
                         <asp:Button ID="Btn_WebLogoUpload" runat="server" Text="�ϴ�" OnClick="Btn_WebLogoUpload_Click" /></td><td>
                         <asp:Image ID="WebLogoImage" runat="server" Height="90px" Width="99px" />
                         </td></tr>
                       </table>
                    </td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��վ��ַ��</td>
                    <td width="650px;">
                         <input id="webAddress" type="text"   style="width:800px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>��������վ��ַ��</td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnWebLinkSave" runat="server" Text=" ������Ϣ "
                            OnClientClick="return CheckIn()" onclick="BtnWebLinkSave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="ȡ��" onclick="Button1_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>

