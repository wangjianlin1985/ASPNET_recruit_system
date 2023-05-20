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
                alert("请输入职位名称...");
                document.getElementById("jobName").focus();
                return false;
            }

            var jobDesc = document.getElementById("jobDesc").value;
            if (jobDesc == "") {
                alert("请输入职位描述...");
                document.getElementById("jobDesc").focus();
                return false;
            }

            var salary = document.getElementById("salary").value;
            if (salary == "") {
                alert("请输入工作薪酬...");
                document.getElementById("salary").focus();
                return false;
            }

            var zprs = document.getElementById("zprs").value;
            if(zprs == ""){
                alert("请输入招聘人数...");
                document.getElementById("zprs").focus();
                return false;
            }
            else if (!resc.test(zprs))
            {
                alert("招聘人数请输入数字");
                document.getElementById("zprs").focus();
                //input.rate.focus();
                return false;
            }

            var xlyq = document.getElementById("xlyq").value;
            if (xlyq == "") {
                alert("请输入学历要求...");
                document.getElementById("xlyq").focus();
                return false;
            }

            var yxqx = document.getElementById("yxqx").value;
            if (yxqx == "") {
                alert("请输入有效期限...");
                document.getElementById("yxqx").focus();
                return false;
            }

            var gzqy = document.getElementById("gzqy").value;
            if (gzqy == "") {
                alert("请输入工作区域...");
                document.getElementById("gzqy").focus();
                return false;
            }

            var gzdz = document.getElementById("gzdz").value;
            if (gzdz == "") {
                alert("请输入工作地址...");
                document.getElementById("gzdz").focus();
                return false;
            }

            var viewNum = document.getElementById("viewNum").value;
            if(viewNum == ""){
                alert("请输入浏览次数...");
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
    <div class="Body_Title">职位管理 》》编辑职位</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    职位类别：</td>
                    <td width="650px;">
                         <asp:DropDownList ID="jobTypeObj" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   职位名称：</td>
                    <td width="650px;">
                         <input id="jobName" type="text"   style="width:400px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入职位名称！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   职位描述：</td>
                    <td width="650px;">
                        <textarea id="jobDesc" rows=6 cols=80 runat="server"></textarea><span class="WarnMes">*</span>请输入职位描述！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   工作薪酬：</td>
                    <td width="650px;">
                         <input id="salary" type="text"   style="width:500px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入工作薪酬！</td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   招聘人数：</td>
                    <td width="650px;">
                         <input id="zprs" type="text"   style="width:74px;" runat="server"
                             maxlength="25"/><span class="WarnMes">*</span>请输入招聘人数！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   学历要求：</td>
                    <td width="650px;">
                         <input id="xlyq" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入学历要求！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   有效期限：</td>
                    <td width="650px;">
                         <input id="yxqx" type="text"   style="width:300px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入有效期限！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   工作区域：</td>
                    <td width="650px;">
                         <input id="gzqy" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入工作区域！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   工作地址：</td>
                    <td width="650px;">
                         <input id="gzdz" type="text"   style="width:800px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入工作地址！</td>
                </tr>

                <tr style="display:none;">
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   浏览次数：</td>
                    <td width="650px;">
                         <input id="viewNum" type="text" value="0"   style="width:74px;" runat="server"
                             maxlength="25"/><span class="WarnMes">*</span>请输入浏览次数！</td>
                </tr>

                <tr style="display:none;">
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    发布企业：</td>
                    <td width="650px;">
                         <asp:DropDownList ID="companyObj" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                  <tr style="display:none;">
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  发布时间：</td>
                    <td width="650px;">
                          <asp:TextBox ID="addTime"  runat="server" Width="150px"
                              onclick="javascript:SelectDate(this,'yyyy-MM-dd hh:mm:ss');"></asp:TextBox></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnJobSave" runat="server" Text=" 保存信息 "
                            OnClientClick="return CheckIn()" onclick="BtnJobSave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="取消" onclick="Button1_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>

