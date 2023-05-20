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
                alert("请输入投递时间...");
                document.getElementById("deliveryTime").focus();
                return false;
            }

            

            var clzt = document.getElementById("clzt").value;
            if (clzt == "") {
                alert("请输入处理状态...");
                document.getElementById("clzt").focus();
                return false;
            }

            var tzxx = document.getElementById("tzxx").value;
            if (tzxx == "") {
                alert("请输入通知信息...");
                document.getElementById("tzxx").focus();
                return false;
            }

            var gzpj = document.getElementById("gzpj").value;
            if (gzpj == "") {
                alert("请输入工作评价...");
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
    <div class="Body_Title">简历投递管理 》》编辑简历投递</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    应聘职位：</td>
                    <td width="650px;">
                         <asp:DropDownList ID="jobObj" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    应聘人：</td>
                    <td width="650px;">
                         <asp:DropDownList ID="userObj" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                  <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  投递时间：</td>
                    <td width="650px;">
                          <asp:TextBox ID="deliveryTime"  runat="server" Width="150px"
                              onclick="javascript:SelectDate(this,'yyyy-MM-dd hh:mm:ss');"></asp:TextBox></td>
                </tr>

                  <tr style="display:none;">
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  处理时间：</td>
                    <td width="650px;">
                          <asp:TextBox ID="handleTime"  runat="server" Width="150px"
                              onclick="javascript:SelectDate(this,'yyyy-MM-dd hh:mm:ss');"></asp:TextBox></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   处理状态：</td>
                    <td width="650px;"> 
                        <select id="clzt" runat="server">
                            <option value="待处理">待处理</option>
					        <option value="已通知面试">已通知面试</option>
					        <option value="已通知上班">已通知上班</option>
					        <option value="已上班">已上班</option>
					        <option value="工作结束">工作结束</option>
                        </select>     
                    </td>
                        
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   通知信息：</td>
                    <td width="650px;">
                        <textarea id="tzxx" rows=6 cols=80 runat="server"></textarea><span class="WarnMes">*</span>请输入通知信息！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   工作评价：</td>
                    <td width="650px;">
                        <textarea id="gzpj" rows=6 cols=80 runat="server"></textarea><span class="WarnMes">*</span>请输入工作评价！</td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnDeliverySave" runat="server" Text=" 保存信息 "
                            OnClientClick="return CheckIn()" onclick="BtnDeliverySave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="取消" onclick="Button1_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>

