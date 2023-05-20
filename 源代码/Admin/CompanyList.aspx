<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CompanyList.aspx.cs" Inherits="chengxusheji.Admin.CompanyList" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>��ҵ�б�</title>
    <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
   <script src="JavaScript/Admin.js" type="text/javascript"></script>
   <script type="text/javascript" src="../js/jsdate.js"></script>
</head>
<body>
   <form id="form1" runat="server">
    <div class="div_All">
    <div class="Body_Title">��ҵ���� ������ҵ�б�</div>
     <div class="Body_Search">
        ���ü���&nbsp;&nbsp;<asp:TextBox ID="qyjb" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        ��ҵ����&nbsp;&nbsp;<asp:TextBox ID="companyName" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        ����ע���&nbsp;&nbsp;<asp:TextBox ID="gszch" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        ��˾����&nbsp;&nbsp;<asp:TextBox ID="gsxz" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        ��˾��ģ&nbsp;&nbsp;<asp:TextBox ID="gsgm" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        ��˾��ҵ&nbsp;&nbsp;<asp:TextBox ID="gghy" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        ��ϵ��&nbsp;&nbsp;<asp:TextBox ID="lxr" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        ��ϵ�绰&nbsp;&nbsp;<asp:TextBox ID="lxdh" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        ���״̬&nbsp;&nbsp;<asp:TextBox ID="shzt" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" Text="��ѯ" onclick="btnSearch_Click" /> 
        &nbsp;&nbsp;&nbsp;<asp:Button ID="btnExport" runat="server" Text="����excel" OnClick="btnExport_Click" />
    <asp:Repeater ID="RpCompany" runat="server" onitemcommand="RpCompany_ItemCommand">
        <HeaderTemplate>
            <table cellpadding="2" cellspacing="1" class="Admin_Table">
                <thead>
                    <tr class="Admin_Table_Title">
                        <th>ѡ��</th> 
                        <th>��ҵ�û���</th>
                        <th>���ü���</th>
                        <th>��ҵ����</th>
                        <th>����ע���</th>
                        <th>Ӫҵִ��</th>
                        <th>��˾����</th>
                        <th>��˾��ģ</th>
                        <th>��˾��ҵ</th>
                        <th>��ϵ��</th>
                        <th>��ϵ�绰</th>
                        <th>���״̬</th>
                        <th>����</th> 
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
                <td align="center"><a href="CompanyEdit.aspx?companyUserName=<%#Eval("companyUserName") %>"><img src="Images/MillMes_ICO.gif" alt="�޸���Ϣ..." /></a><asp:ImageButton class="DelClass" ID="IBDelClass" runat="server" CommandArgument='<%#Eval("companyUserName")%>' CommandName="Del" ImageUrl="Images/Delete.gif"  ToolTip="ɾ������Ϣ..."/></td>
             </tr>
        </ItemTemplate>
        <FooterTemplate></table></FooterTemplate>
    </asp:Repeater>

    <div class="Body_Search">
        <div class="page_Left">
            <input id="BtnAllSelect" type="button" value="ȫѡ" />&nbsp;
            <asp:Button ID="BtnAllDel" runat="server" Text=" ɾ��ѡ�� " onclick="BtnAllDel_Click" />
        </div>
        <div class="page_Right">
        <span class="pageBtn">   <asp:Label runat="server" ID="PageMes"></asp:Label></span>
            <asp:LinkButton ID="LBHome" runat="server" CssClass="pageBtn" 
                onclick="LBHome_Click">[��ҳ]</asp:LinkButton>
            <asp:LinkButton ID="LBUp" runat="server" CssClass="pageBtn" 
                onclick="LBUp_Click">[��һҳ]</asp:LinkButton>
            <asp:LinkButton ID="LBNext" runat="server" CssClass="pageBtn" 
                onclick="LBNext_Click">[��һҳ]</asp:LinkButton>
            <asp:LinkButton ID="LBEnd" runat="server" CssClass="pageBtn" 
                onclick="LBEnd_Click">[βҳ]</asp:LinkButton>
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
