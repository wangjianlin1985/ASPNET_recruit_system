<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CompanyList.aspx.cs" Inherits="chengxusheji.Admin.CompanyList" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>企业列表</title>
    <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
   <script src="JavaScript/Admin.js" type="text/javascript"></script>
   <script type="text/javascript" src="../js/jsdate.js"></script>
</head>
<body>
   <form id="form1" runat="server">
    <div class="div_All">
    <div class="Body_Title">企业管理 》》企业列表</div>
     <div class="Body_Search">
        信用级别&nbsp;&nbsp;<asp:TextBox ID="qyjb" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        企业名称&nbsp;&nbsp;<asp:TextBox ID="companyName" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        工商注册号&nbsp;&nbsp;<asp:TextBox ID="gszch" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        公司性质&nbsp;&nbsp;<asp:TextBox ID="gsxz" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        公司规模&nbsp;&nbsp;<asp:TextBox ID="gsgm" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        公司行业&nbsp;&nbsp;<asp:TextBox ID="gghy" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        联系人&nbsp;&nbsp;<asp:TextBox ID="lxr" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        联系电话&nbsp;&nbsp;<asp:TextBox ID="lxdh" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        审核状态&nbsp;&nbsp;<asp:TextBox ID="shzt" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" Text="查询" onclick="btnSearch_Click" /> 
        &nbsp;&nbsp;&nbsp;<asp:Button ID="btnExport" runat="server" Text="导出excel" OnClick="btnExport_Click" />
    <asp:Repeater ID="RpCompany" runat="server" onitemcommand="RpCompany_ItemCommand">
        <HeaderTemplate>
            <table cellpadding="2" cellspacing="1" class="Admin_Table">
                <thead>
                    <tr class="Admin_Table_Title">
                        <th>选择</th> 
                        <th>企业用户名</th>
                        <th>信用级别</th>
                        <th>企业名称</th>
                        <th>工商注册号</th>
                        <th>营业执照</th>
                        <th>公司性质</th>
                        <th>公司规模</th>
                        <th>公司行业</th>
                        <th>联系人</th>
                        <th>联系电话</th>
                        <th>审核状态</th>
                        <th>操作</th> 
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td align="center"><input type="checkbox" value='<%#Eval("companyUserName") %>' name="CheckMes" id="DelChecked"/></td>
                <td align="center"><%#Eval("companyUserName")%> </td>
                <td align="center"><%#Eval("qyjb")%> </td>
                <td align="center"><%#Eval("companyName")%> </td>
                <td align="center"><%#Eval("gszch")%> </td>
                <td align="center"><img src="../<%#Eval("yyzz")%>" width=50 height=50 />
                <td align="center"><%#Eval("gsxz")%> </td>
                <td align="center"><%#Eval("gsgm")%> </td>
                <td align="center"><%#Eval("gghy")%> </td>
                <td align="center"><%#Eval("lxr")%> </td>
                <td align="center"><%#Eval("lxdh")%> </td>
                <td align="center"><%#Eval("shzt")%> </td>
                <td align="center"><a href="CompanyEdit.aspx?companyUserName=<%#Eval("companyUserName") %>"><img src="Images/MillMes_ICO.gif" alt="修改信息..." /></a><asp:ImageButton class="DelClass" ID="IBDelClass" runat="server" CommandArgument='<%#Eval("companyUserName")%>' CommandName="Del" ImageUrl="Images/Delete.gif"  ToolTip="删除该信息..."/></td>
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
