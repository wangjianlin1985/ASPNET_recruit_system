<%@ Page Language="C#" AutoEventWireup="true" CodeFile="companyDeliveryEdit.aspx.cs" Inherits="chengxusheji.Admin.DeliveryEdit" %>
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
            var deliveryTime = document.getElementById("deliveryTime").value;
            if (deliveryTime == "") {
                alert("������Ͷ��ʱ��...");
                document.getElementById("deliveryTime").focus();
                return false;
            }

            

            var clzt = document.getElementById("clzt").value;
            if (clzt == "") {
                alert("�����봦��״̬...");
                document.getElementById("clzt").focus();
                return false;
            }

            var tzxx = document.getElementById("tzxx").value;
            if (tzxx == "") {
                alert("������֪ͨ��Ϣ...");
                document.getElementById("tzxx").focus();
                return false;
            }

            var gzpj = document.getElementById("gzpj").value;
            if (gzpj == "") {
                alert("�����빤������...");
                document.getElementById("gzpj").focus();
                return false;
            }

            return true;
       } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_All">
    <div class="Body_Title">����Ͷ�ݹ��� �����༭����Ͷ��</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    ӦƸְλ��</td>
                    <td width="650px;">
                         <asp:DropDownList ID="jobObj" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    ӦƸ�ˣ�</td>
                    <td width="650px;">
                         <asp:DropDownList ID="userObj" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                  <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  Ͷ��ʱ�䣺</td>
                    <td width="650px;">
                          <asp:TextBox ID="deliveryTime"  runat="server" Width="150px"
                              onclick="javascript:SelectDate(this,'yyyy-MM-dd hh:mm:ss');"></asp:TextBox></td>
                </tr>

                  <tr style="display:none;">
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  ����ʱ�䣺</td>
                    <td width="650px;">
                          <asp:TextBox ID="handleTime"  runat="server" Width="150px"
                              onclick="javascript:SelectDate(this,'yyyy-MM-dd hh:mm:ss');"></asp:TextBox></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ����״̬��</td>
                    <td width="650px;"> 
                        <select id="clzt" runat="server">
                            <option value="������">������</option>
					        <option value="��֪ͨ����">��֪ͨ����</option>
					        <option value="��֪ͨ�ϰ�">��֪ͨ�ϰ�</option>
					        <option value="���ϰ�">���ϰ�</option>
					        <option value="��������">��������</option>
                        </select>     
                    </td>
                        
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ֪ͨ��Ϣ��</td>
                    <td width="650px;">
                        <textarea id="tzxx" rows=6 cols=80 runat="server"></textarea><span class="WarnMes">*</span>������֪ͨ��Ϣ��</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �������ۣ�</td>
                    <td width="650px;">
                        <textarea id="gzpj" rows=6 cols=80 runat="server"></textarea><span class="WarnMes">*</span>�����빤�����ۣ�</td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnDeliverySave" runat="server" Text=" ������Ϣ "
                            OnClientClick="return CheckIn()" onclick="BtnDeliverySave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="ȡ��" onclick="Button1_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>

