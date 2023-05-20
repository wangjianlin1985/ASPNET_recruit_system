<%@ Page Language="C#" AutoEventWireup="true" CodeFile="companyJobList.aspx.cs" Inherits="chengxusheji.Admin.JobList" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>职位列表</title>
    <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
   <script src="JavaScript/Admin.js" type="text/javascript"></script>
   <script type="text/javascript" src="../js/jsdate.js"></script>
</head>
<body>
   <form id="form1" runat="server">
    <div class="div_All">
    <div class="Body_Title">职位管理 》》职位列表</div>
     <div class="Body_Search">
        职位类别&nbsp;&nbsp;<asp:DropDownList ID="jobTypeObj" runat="server"></asp:DropDownList>  &nbsp;&nbsp;
        职位名称&nbsp;&nbsp;<asp:TextBox ID="jobName" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        学历要求&nbsp;&nbsp;<asp:TextBox ID="xlyq" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        工作区域&nbsp;&nbsp;<asp:TextBox ID="gzqy" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
         <asp:DropDownList ID="companyObj" runat="server" Visible="false"></asp:DropDownList>  &nbsp;&nbsp;
        发布时间&nbsp;&nbsp; <asp:TextBox ID="addTime"  runat="server" Width="112px" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>&nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" Text="查询" onclick="btnSearch_Click" /> 
        &nbsp;&nbsp;&nbsp;<asp:Button ID="btnExport" runat="server" Text="导出excel" OnClick="btnExport_Click" />
    <asp:Repeater ID="RpJob" runat="server" onitemcommand="RpJob_ItemCommand">
        <HeaderTemplate>
            <table cellpadding="2" cellspacing="1" class="Admin_Table">
                <thead>
                    <tr class="Admin_Table_Title">
                        <th>选择</th> 
                        <th>职位id</th>
                        <th>职位类别</th>
                        <th>职位名称</th>
                        <th>工作薪酬</th>
                        <th>招聘人数</th>
                        <th>学历要求</th>
                        <th>有效期限</th>
                        <th>工作区域</th>
                        <th>浏览次数</th> 
                        <th>发布时间</th>
                        <th>操作</th> 
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td align="center"><input type="checkbox" value='<%#Eval("jobId") %>' name="CheckMes" id="DelChecked"/></td>
                <td align="center"><%#Eval("jobId")%> </td>
                  <td align="center"><%#GetJobTypejobTypeObj(Eval("jobTypeObj").ToString())%></td>
                <td align="center"><%#Eval("jobName")%> </td>
                <td align="center"><%#Eval("salary")%> </td>
                <td align="center"><%#Eval("zprs")%> </td>
                <td align="center"><%#Eval("xlyq")%> </td>
                <td align="center"><%#Eval("yxqx")%> </td>
                <td align="center"><%#Eval("gzqy")%> </td>
                <td align="center"><%#Eval("viewNum")%> </td> 
                  <td align="center"><%# Convert.ToDateTime(Eval("addTime")).ToShortDateString() + " " + Convert.ToDateTime(Eval("addTime")).ToLongTimeString() %></td>
                <td align="center"><a href="companyJobEdit.aspx?jobId=<%#Eval("jobId") %>"><img src="Images/MillMes_ICO.gif" alt="修改信息..." /></a><asp:ImageButton class="DelClass" ID="IBDelClass" runat="server" CommandArgument='<%#Eval("jobId")%>' CommandName="Del" ImageUrl="Images/Delete.gif"  ToolTip="删除该信息..."/></td>
             </tr>
        </ItemTemplate>
        <FooterTemplate></table></FooterTemplate>
    </asp:Repeater>

    <div class="Body_Search">
        <div class="page_Left">
            <input id="BtnAllSelect" type="button" value="全选" />&nbsp;
            <asp:Button ID="BtnAllDel" runat="server" Text=" 删除选中 " onclick="BtnAllDel_Click" />
        </div>
        <div class="page_Right">
        <span class="pageBtn">   <asp:Label runat="server" ID="PageMes"></asp:Label></span>
            <asp:LinkButton ID="LBHome" runat="server" CssClass="pageBtn" 
                onclick="LBHome_Click">[首页]</asp:LinkButton>
            <asp:LinkButton ID="LBUp" runat="server" CssClass="pageBtn" 
                onclick="LBUp_Click">[上一页]</asp:LinkButton>
            <asp:LinkButton ID="LBNext" runat="server" CssClass="pageBtn" 
                onclick="LBNext_Click">[下一页]</asp:LinkButton>
            <asp:LinkButton ID="LBEnd" runat="server" CssClass="pageBtn" 
                onclick="LBEnd_Click">[尾页]</asp:LinkButton>
        </div>
    </div>
    </div>
    <asp:HiddenField ID="HSelectID" runat="server" Value=""/>
    <asp:HiddenField ID="HWhere" runat="server" Value=""/>
    <asp:HiddenField ID="HNowPage" runat="server" Value="1"/>
    <asp:HiddenField ID="HPageSize" runat="server" Value="5"/>
    <asp:HiddenField ID="HAllPage" runat="server" Value="0"/>
    </form>
</body>
</html>
