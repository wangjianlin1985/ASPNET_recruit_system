<%@ Page Language="C#" AutoEventWireup="true" CodeFile="companyDeliveryList.aspx.cs" Inherits="chengxusheji.Admin.DeliveryList" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>����Ͷ���б�</title>
    <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
   <script src="JavaScript/Admin.js" type="text/javascript"></script>
   <script type="text/javascript" src="../js/jsdate.js"></script>
</head>
<body>
   <form id="form1" runat="server">
    <div class="div_All">
    <div class="Body_Title">����Ͷ�ݹ��� ��������Ͷ���б�</div>
     <div class="Body_Search">
        <asp:DropDownList ID="jobObj" runat="server" Visible="false"></asp:DropDownList>  &nbsp;&nbsp;
        ӦƸ��&nbsp;&nbsp;<asp:DropDownList ID="userObj" runat="server"></asp:DropDownList>  &nbsp;&nbsp;
        Ͷ��ʱ��&nbsp;&nbsp; <asp:TextBox ID="deliveryTime"  runat="server" Width="112px" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>&nbsp;&nbsp;
        ����ʱ��&nbsp;&nbsp; <asp:TextBox ID="handleTime"  runat="server" Width="112px" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>&nbsp;&nbsp;
        ����״̬&nbsp;&nbsp;<asp:TextBox ID="clzt" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" Text="��ѯ" onclick="btnSearch_Click" /> 
        &nbsp;&nbsp;&nbsp;<asp:Button ID="btnExport" runat="server" Text="����excel" OnClick="btnExport_Click" />
    <asp:Repeater ID="RpDelivery" runat="server" onitemcommand="RpDelivery_ItemCommand">
        <HeaderTemplate>
            <table cellpadding="2" cellspacing="1" class="Admin_Table">
                <thead>
                    <tr class="Admin_Table_Title">
                        <th>ѡ��</th> 
                        <th>Ͷ��id</th>
                        <th>ӦƸְλ</th>
                        <th>ӦƸ��</th>
                        <th>Ͷ��ʱ��</th>
                        <th>����ʱ��</th>
                        <th>����״̬</th>
                        <th>֪ͨ��Ϣ</th>
                        <th>��������</th>
                        <th>����</th> 
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td align="center"><input type="checkbox" value='<%#Eval("deliveryId") %>' name="CheckMes" id="DelChecked"/></td>
                <td align="center"><%#Eval("deliveryId")%> </td>
                  <td align="center"><%#GetJobjobObj(Eval("jobObj").ToString())%></td>
                  <td align="center"><%#GetUserInfouserObj(Eval("userObj").ToString())%></td>
                  <td align="center"><%# Convert.ToDateTime(Eval("deliveryTime")).ToShortDateString() + " " + Convert.ToDateTime(Eval("deliveryTime")).ToLongTimeString() %></td>
                  <td align="center"><%# Convert.ToDateTime(Eval("handleTime")).ToShortDateString() + " " + Convert.ToDateTime(Eval("handleTime")).ToLongTimeString() %></td>
                <td align="center"><%#Eval("clzt")%> </td>
                <td align="center"><%#Eval("tzxx")%> </td>
                <td align="center"><%#Eval("gzpj")%> </td>
                <td align="center"><a href="companyDeliveryEdit.aspx?deliveryId=<%#Eval("deliveryId") %>"><img src="Images/MillMes_ICO.gif" alt="�޸���Ϣ..." /></a><asp:ImageButton class="DelClass" ID="IBDelClass" runat="server" CommandArgument='<%#Eval("deliveryId")%>' CommandName="Del" ImageUrl="Images/Delete.gif"  ToolTip="ɾ������Ϣ..."/></td>
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
