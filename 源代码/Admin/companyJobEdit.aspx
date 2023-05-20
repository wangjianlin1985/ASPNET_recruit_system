<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeFile="companyJobEdit.aspx.cs" Inherits="chengxusheji.Admin.JobEdit" %>
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
            var jobName = document.getElementById("jobName").value;
            if (jobName == "") {
                alert("������ְλ����...");
                document.getElementById("jobName").focus();
                return false;
            }

            var jobDesc = document.getElementById("jobDesc").value;
            if (jobDesc == "") {
                alert("������ְλ����...");
                document.getElementById("jobDesc").focus();
                return false;
            }

            var salary = document.getElementById("salary").value;
            if (salary == "") {
                alert("�����빤��н��...");
                document.getElementById("salary").focus();
                return false;
            }

            var zprs = document.getElementById("zprs").value;
            if(zprs == ""){
                alert("��������Ƹ����...");
                document.getElementById("zprs").focus();
                return false;
            }
            else if (!resc.test(zprs))
            {
                alert("��Ƹ��������������");
                document.getElementById("zprs").focus();
                //input.rate.focus();
                return false;
            }

            var xlyq = document.getElementById("xlyq").value;
            if (xlyq == "") {
                alert("������ѧ��Ҫ��...");
                document.getElementById("xlyq").focus();
                return false;
            }

            var yxqx = document.getElementById("yxqx").value;
            if (yxqx == "") {
                alert("��������Ч����...");
                document.getElementById("yxqx").focus();
                return false;
            }

            var gzqy = document.getElementById("gzqy").value;
            if (gzqy == "") {
                alert("�����빤������...");
                document.getElementById("gzqy").focus();
                return false;
            }

            var gzdz = document.getElementById("gzdz").value;
            if (gzdz == "") {
                alert("�����빤����ַ...");
                document.getElementById("gzdz").focus();
                return false;
            }

            var viewNum = document.getElementById("viewNum").value;
            if(viewNum == ""){
                alert("�������������...");
                document.getElementById("viewNum").focus();
                return false;
            }
            

             

            return true;
       } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_All">
    <div class="Body_Title">ְλ���� �����༭ְλ</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    ְλ���</td>
                    <td width="650px;">
                         <asp:DropDownList ID="jobTypeObj" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ְλ���ƣ�</td>
                    <td width="650px;">
                         <input id="jobName" type="text"   style="width:400px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>������ְλ���ƣ�</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ְλ������</td>
                    <td width="650px;">
                        <textarea id="jobDesc" rows=6 cols=80 runat="server"></textarea><span class="WarnMes">*</span>������ְλ������</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ����н�꣺</td>
                    <td width="650px;">
                         <input id="salary" type="text"   style="width:500px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>�����빤��н�꣡</td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��Ƹ������</td>
                    <td width="650px;">
                         <input id="zprs" type="text"   style="width:74px;" runat="server"
                             maxlength="25"/><span class="WarnMes">*</span>��������Ƹ������</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ѧ��Ҫ��</td>
                    <td width="650px;">
                         <input id="xlyq" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>������ѧ��Ҫ��</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��Ч���ޣ�</td>
                    <td width="650px;">
                         <input id="yxqx" type="text"   style="width:300px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>��������Ч���ޣ�</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��������</td>
                    <td width="650px;">
                         <input id="gzqy" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>�����빤������</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ������ַ��</td>
                    <td width="650px;">
                         <input id="gzdz" type="text"   style="width:800px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>�����빤����ַ��</td>
                </tr>

                <tr style="display:none;">
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ���������</td>
                    <td width="650px;">
                         <input id="viewNum" type="text" value="0"   style="width:74px;" runat="server"
                             maxlength="25"/><span class="WarnMes">*</span>���������������</td>
                </tr>

                <tr style="display:none;">
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    ������ҵ��</td>
                    <td width="650px;">
                         <asp:DropDownList ID="companyObj" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                  <tr style="display:none;">
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  ����ʱ�䣺</td>
                    <td width="650px;">
                          <asp:TextBox ID="addTime"  runat="server" Width="150px"
                              onclick="javascript:SelectDate(this,'yyyy-MM-dd hh:mm:ss');"></asp:TextBox></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnJobSave" runat="server" Text=" ������Ϣ "
                            OnClientClick="return CheckIn()" onclick="BtnJobSave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="ȡ��" onclick="Button1_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>

