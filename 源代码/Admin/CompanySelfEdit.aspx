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
                alert("请输入企业用户名...");
                document.getElementById("companyUserName").focus();
                return false;
            }

            var password = document.getElementById("password").value;
            if (password == "") {
                alert("请输入登录密码...");
                document.getElementById("password").focus();
                return false;
            }

            var qyjb = document.getElementById("qyjb").value;
            if (qyjb == "") {
                alert("请输入信用级别...");
                document.getElementById("qyjb").focus();
                return false;
            }

            var companyName = document.getElementById("companyName").value;
            if (companyName == "") {
                alert("请输入企业名称...");
                document.getElementById("companyName").focus();
                return false;
            }

            var gszch = document.getElementById("gszch").value;
            if (gszch == "") {
                alert("请输入工商注册号...");
                document.getElementById("gszch").focus();
                return false;
            }

            var gsxz = document.getElementById("gsxz").value;
            if (gsxz == "") {
                alert("请输入公司性质...");
                document.getElementById("gsxz").focus();
                return false;
            }

            var gsgm = document.getElementById("gsgm").value;
            if (gsgm == "") {
                alert("请输入公司规模...");
                document.getElementById("gsgm").focus();
                return false;
            }

            var gghy = document.getElementById("gghy").value;
            if (gghy == "") {
                alert("请输入公司行业...");
                document.getElementById("gghy").focus();
                return false;
            }

            var lxr = document.getElementById("lxr").value;
            if (lxr == "") {
                alert("请输入联系人...");
                document.getElementById("lxr").focus();
                return false;
            }

            var lxdh = document.getElementById("lxdh").value;
            if (lxdh == "") {
                alert("请输入联系电话...");
                document.getElementById("lxdh").focus();
                return false;
            }

            var companyDesc = document.getElementById("companyDesc").value;
            if (companyDesc == "") {
                alert("请输入公司介绍...");
                document.getElementById("companyDesc").focus();
                return false;
            }

            var address = document.getElementById("address").value;
            if (address == "") {
                alert("请输入公司地址...");
                document.getElementById("address").focus();
                return false;
            }

            var shzt = document.getElementById("shzt").value;
            if (shzt == "") {
                alert("请输入审核状态...");
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
    <div class="Body_Title">企业管理 》》编辑企业</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   企业用户名：</td>
                    <td width="650px;">
                         <input id="companyUserName" type="text"   style="width:300px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入企业用户名！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   登录密码：</td>
                    <td width="650px;">
                         <input id="password" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入登录密码！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   信用级别：</td>
                    <td width="650px;">
                         <input id="qyjb" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入信用级别！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   企业名称：</td>
                    <td width="650px;">
                         <input id="companyName" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入企业名称！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   工商注册号：</td>
                    <td width="650px;">
                         <input id="gszch" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入工商注册号！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   营业执照：</td>
                    <td width="650px;">
                       <table cellpadding="0px" cellspacing="0px" width="90%">
                        <tr><td width="400px">
                         图片路径：<asp:TextBox ID="yyzz" runat="server" ReadOnly="True" Width="228px" Enabled="False"></asp:TextBox> &nbsp; &nbsp; &nbsp
                         <br />
                         <br />
                         上传图片：<asp:FileUpload ID="YyzzUpload" runat="server" Width="237px" />&nbsp;
                         <asp:Button ID="Btn_YyzzUpload" runat="server" Text="上传" OnClick="Btn_YyzzUpload_Click" /></td><td>
                         <asp:Image ID="YyzzImage" runat="server" Height="90px" Width="99px" />
                         </td></tr>
                       </table>
                    </td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   公司性质：</td>
                    <td width="650px;">
                         <input id="gsxz" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入公司性质！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   公司规模：</td>
                    <td width="650px;">
                         <input id="gsgm" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入公司规模！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   公司行业：</td>
                    <td width="650px;">
                         <input id="gghy" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入公司行业！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   联系人：</td>
                    <td width="650px;">
                         <input id="lxr" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入联系人！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   联系电话：</td>
                    <td width="650px;">
                         <input id="lxdh" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入联系电话！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   公司介绍：</td>
                    <td width="650px;">
                        <textarea id="companyDesc" rows=6 cols=80 runat="server"></textarea><span class="WarnMes">*</span>请输入公司介绍！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   公司地址：</td>
                    <td width="650px;">
                         <input id="address" type="text"   style="width:800px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入公司地址！</td>
                </tr>

                 <tr style="display:none;">
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   审核状态：</td>
                    <td width="650px;">
                         <input id="shzt" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入审核状态！</td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnCompanySave" runat="server" Text=" 保存信息 "
                            OnClientClick="return CheckIn()" onclick="BtnCompanySave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="取消" onclick="Button1_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>

