<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeFile="CompanySelfEdit.aspx.cs" Inherits="chengxusheji.Admin.CompanyEdit" %>
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
            var companyUserName = document.getElementById("companyUserName").value;
            if (companyUserName == "") {
                alert("��������ҵ�û���...");
                document.getElementById("companyUserName").focus();
                return false;
            }

            var password = document.getElementById("password").value;
            if (password == "") {
                alert("�������¼����...");
                document.getElementById("password").focus();
                return false;
            }

            var qyjb = document.getElementById("qyjb").value;
            if (qyjb == "") {
                alert("���������ü���...");
                document.getElementById("qyjb").focus();
                return false;
            }

            var companyName = document.getElementById("companyName").value;
            if (companyName == "") {
                alert("��������ҵ����...");
                document.getElementById("companyName").focus();
                return false;
            }

            var gszch = document.getElementById("gszch").value;
            if (gszch == "") {
                alert("�����빤��ע���...");
                document.getElementById("gszch").focus();
                return false;
            }

            var gsxz = document.getElementById("gsxz").value;
            if (gsxz == "") {
                alert("�����빫˾����...");
                document.getElementById("gsxz").focus();
                return false;
            }

            var gsgm = document.getElementById("gsgm").value;
            if (gsgm == "") {
                alert("�����빫˾��ģ...");
                document.getElementById("gsgm").focus();
                return false;
            }

            var gghy = document.getElementById("gghy").value;
            if (gghy == "") {
                alert("�����빫˾��ҵ...");
                document.getElementById("gghy").focus();
                return false;
            }

            var lxr = document.getElementById("lxr").value;
            if (lxr == "") {
                alert("��������ϵ��...");
                document.getElementById("lxr").focus();
                return false;
            }

            var lxdh = document.getElementById("lxdh").value;
            if (lxdh == "") {
                alert("��������ϵ�绰...");
                document.getElementById("lxdh").focus();
                return false;
            }

            var companyDesc = document.getElementById("companyDesc").value;
            if (companyDesc == "") {
                alert("�����빫˾����...");
                document.getElementById("companyDesc").focus();
                return false;
            }

            var address = document.getElementById("address").value;
            if (address == "") {
                alert("�����빫˾��ַ...");
                document.getElementById("address").focus();
                return false;
            }

            var shzt = document.getElementById("shzt").value;
            if (shzt == "") {
                alert("���������״̬...");
                document.getElementById("shzt").focus();
                return false;
            }

            return true;
       } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_All">
    <div class="Body_Title">��ҵ���� �����༭��ҵ</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��ҵ�û�����</td>
                    <td width="650px;">
                         <input id="companyUserName" type="text"   style="width:300px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>��������ҵ�û�����</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��¼���룺</td>
                    <td width="650px;">
                         <input id="password" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>�������¼���룡</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ���ü���</td>
                    <td width="650px;">
                         <input id="qyjb" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>���������ü���</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��ҵ���ƣ�</td>
                    <td width="650px;">
                         <input id="companyName" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>��������ҵ���ƣ�</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ����ע��ţ�</td>
                    <td width="650px;">
                         <input id="gszch" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>�����빤��ע��ţ�</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   Ӫҵִ�գ�</td>
                    <td width="650px;">
                       <table cellpadding="0px" cellspacing="0px" width="90%">
                        <tr><td width="400px">
                         ͼƬ·����<asp:TextBox ID="yyzz" runat="server" ReadOnly="True" Width="228px" Enabled="False"></asp:TextBox> &nbsp; &nbsp; &nbsp
                         <br />
                         <br />
                         �ϴ�ͼƬ��<asp:FileUpload ID="YyzzUpload" runat="server" Width="237px" />&nbsp;
                         <asp:Button ID="Btn_YyzzUpload" runat="server" Text="�ϴ�" OnClick="Btn_YyzzUpload_Click" /></td><td>
                         <asp:Image ID="YyzzImage" runat="server" Height="90px" Width="99px" />
                         </td></tr>
                       </table>
                    </td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��˾���ʣ�</td>
                    <td width="650px;">
                         <input id="gsxz" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>�����빫˾���ʣ�</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��˾��ģ��</td>
                    <td width="650px;">
                         <input id="gsgm" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>�����빫˾��ģ��</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��˾��ҵ��</td>
                    <td width="650px;">
                         <input id="gghy" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>�����빫˾��ҵ��</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��ϵ�ˣ�</td>
                    <td width="650px;">
                         <input id="lxr" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>��������ϵ�ˣ�</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��ϵ�绰��</td>
                    <td width="650px;">
                         <input id="lxdh" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>��������ϵ�绰��</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��˾���ܣ�</td>
                    <td width="650px;">
                        <textarea id="companyDesc" rows=6 cols=80 runat="server"></textarea><span class="WarnMes">*</span>�����빫˾���ܣ�</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��˾��ַ��</td>
                    <td width="650px;">
                         <input id="address" type="text"   style="width:800px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>�����빫˾��ַ��</td>
                </tr>

                 <tr style="display:none;">
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ���״̬��</td>
                    <td width="650px;">
                         <input id="shzt" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>���������״̬��</td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnCompanySave" runat="server" Text=" ������Ϣ "
                            OnClientClick="return CheckIn()" onclick="BtnCompanySave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="ȡ��" onclick="Button1_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>

