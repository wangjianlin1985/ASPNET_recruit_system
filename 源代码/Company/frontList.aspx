<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="Company_frontList" %>
<%@ Register Src="../header.ascx" TagName="header" TagPrefix="uc" %>
<%@ Register Src="../footer.ascx" TagName="footer" TagPrefix="uc" %>
<%
    String path = Request.ApplicationPath;
    String basePath = path + "/"; 
%>
<!DOCTYPE html>
<html>
<head>
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1 , user-scalable=no">
<title>企业查询</title>
<link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
<link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
<link href="<%=basePath %>plugins/animate.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
</head>
<body style="margin-top:70px;">
<div class="container">
<uc:header ID="header" runat="server" />
 <form id="form1" runat="server">
	<div class="col-md-9 wow fadeInLeft">
		<ul class="breadcrumb">
  			<li><a href="../index.aspx">首页</a></li>
  			<li><a href="frontList.aspx">企业信息列表</a></li>
  			<li class="active">查询结果显示</li>
  			<a class="pull-right" href="frontAdd.aspx" style="display:none;">添加企业</a>
		</ul>
		<div class="row">
			<asp:Repeater ID="RpCompany" runat="server">
			<ItemTemplate>
			<div class="col-md-3 bottom15" <%#(((Container.ItemIndex+0)%4==0)?"style='clear:left;'":"") %>>
			  <a href="frontshow.aspx?companyUserName=<%#Eval("companyUserName")%>"><img class="img-responsive" src="../<%#Eval("yyzz")%>" /></a>
			     <div class="showFields">
			     	<div class="field">
	            		企业用户名: <%#Eval("companyUserName")%>
			     	</div>
			     	<div class="field">
	            		信用级别: <%#Eval("qyjb")%>
			     	</div>
			     	<div class="field">
	            		企业名称: <%#Eval("companyName")%>
			     	</div>
			     	<div class="field">
	            		工商注册号: <%#Eval("gszch")%>
			     	</div>
			     	<div class="field">
	            		公司性质: <%#Eval("gsxz")%>
			     	</div>
			     	<div class="field">
	            		公司规模: <%#Eval("gsgm")%>
			     	</div>
			     	<div class="field">
	            		公司行业: <%#Eval("gghy")%>
			     	</div>
			     	<div class="field">
	            		联系人: <%#Eval("lxr")%>
			     	</div>
			     	<div class="field">
	            		联系电话: <%#Eval("lxdh")%>
			     	</div>
			     	<div class="field">
	            		审核状态: <%#Eval("shzt")%>
			     	</div>
			        <a class="btn btn-primary top5" href="frontShow.aspx?companyUserName=<%#Eval("companyUserName")%>">详情</a>
			        <a class="btn btn-primary top5" onclick="companyEdit('<%#Eval("companyUserName")%>');" style="display:none;">修改</a>
			        <a class="btn btn-primary top5" onclick="companyDelete('<%#Eval("companyUserName")%>');" style="display:none;">删除</a>
			     </div>
			</div>
			</ItemTemplate>
			</asp:Repeater>

			<div class="row">
				<div class="col-md-12">
					<nav class="pull-left">
						<ul class="pagination">
 						        <asp:LinkButton ID="LBHome" runat="server" CssClass="pageBtn" 
 						            onclick="LBHome_Click">[首页]</asp:LinkButton>
 						        <asp:LinkButton ID="LBUp" runat="server" CssClass="pageBtn" 
 						            onclick="LBUp_Click">[上一页]</asp:LinkButton>
 						        <asp:LinkButton ID="LBNext" runat="server" CssClass="pageBtn"
 						            onclick="LBNext_Click">[下一页]</asp:LinkButton>
 						        <asp:LinkButton ID="LBEnd" runat="server" CssClass="pageBtn" 
 						            onclick="LBEnd_Click">[尾页]</asp:LinkButton>
 						        <asp:HiddenField ID="HSelectID" runat="server" Value=""/>
 						        <asp:HiddenField ID="HWhere" runat="server" Value=""/>
 						        <asp:HiddenField ID="HNowPage" runat="server" Value="1"/>
 						        <asp:HiddenField ID="HPageSize" runat="server" Value="8"/>
 						        <asp:HiddenField ID="HAllPage" runat="server" Value="0"/>
						</ul>
					</nav>
					<div class="pull-right" style="line-height:75px;" ><asp:Label runat="server" ID="PageMes"></asp:Label></div>
				</div>
			</div>
		</div>
	</div>

	<div class="col-md-3 wow fadeInRight">
		<div class="page-header">
    		<h1>企业查询</h1>
		</div>
			<div class="form-group">
				<label for="qyjb">信用级别:</label>
				<asp:TextBox ID="qyjb" runat="server"  CssClass="form-control" placeholder="请输入信用级别"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="companyName">企业名称:</label>
				<asp:TextBox ID="companyName" runat="server"  CssClass="form-control" placeholder="请输入企业名称"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="gszch">工商注册号:</label>
				<asp:TextBox ID="gszch" runat="server"  CssClass="form-control" placeholder="请输入工商注册号"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="gsxz">公司性质:</label>
				<asp:TextBox ID="gsxz" runat="server"  CssClass="form-control" placeholder="请输入公司性质"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="gsgm">公司规模:</label>
				<asp:TextBox ID="gsgm" runat="server"  CssClass="form-control" placeholder="请输入公司规模"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="gghy">公司行业:</label>
				<asp:TextBox ID="gghy" runat="server"  CssClass="form-control" placeholder="请输入公司行业"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="lxr">联系人:</label>
				<asp:TextBox ID="lxr" runat="server"  CssClass="form-control" placeholder="请输入联系人"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="lxdh">联系电话:</label>
				<asp:TextBox ID="lxdh" runat="server"  CssClass="form-control" placeholder="请输入联系电话"></asp:TextBox>
			</div>
			<div class="form-group" style="display:none;">
				<label for="shzt">审核状态:</label>
				<asp:TextBox ID="shzt" runat="server"  CssClass="form-control" placeholder="请输入审核状态"></asp:TextBox>
			</div>
        <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>
  </form>
</div>
<div id="companyEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;企业信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="companyEditForm" id="companyEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="company_companyUserName_edit" class="col-md-3 text-right">企业用户名:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="company_companyUserName_edit" name="company.companyUserName" class="form-control" placeholder="请输入企业用户名" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="company_password_edit" class="col-md-3 text-right">登录密码:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="company_password_edit" name="company.password" class="form-control" placeholder="请输入登录密码">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="company_qyjb_edit" class="col-md-3 text-right">信用级别:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="company_qyjb_edit" name="company.qyjb" class="form-control" placeholder="请输入信用级别">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="company_companyName_edit" class="col-md-3 text-right">企业名称:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="company_companyName_edit" name="company.companyName" class="form-control" placeholder="请输入企业名称">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="company_gszch_edit" class="col-md-3 text-right">工商注册号:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="company_gszch_edit" name="company.gszch" class="form-control" placeholder="请输入工商注册号">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="company_yyzz_edit" class="col-md-3 text-right">营业执照:</label>
		  	 <div class="col-md-9">
			    <img  class="img-responsive" id="company_yyzzImg" border="0px"/><br/>
			    <input type="hidden" id="company_yyzz" name="company.yyzz"/>
			    <input id="yyzzFile" name="yyzzFile" type="file" size="50" />
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="company_gsxz_edit" class="col-md-3 text-right">公司性质:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="company_gsxz_edit" name="company.gsxz" class="form-control" placeholder="请输入公司性质">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="company_gsgm_edit" class="col-md-3 text-right">公司规模:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="company_gsgm_edit" name="company.gsgm" class="form-control" placeholder="请输入公司规模">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="company_gghy_edit" class="col-md-3 text-right">公司行业:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="company_gghy_edit" name="company.gghy" class="form-control" placeholder="请输入公司行业">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="company_lxr_edit" class="col-md-3 text-right">联系人:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="company_lxr_edit" name="company.lxr" class="form-control" placeholder="请输入联系人">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="company_lxdh_edit" class="col-md-3 text-right">联系电话:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="company_lxdh_edit" name="company.lxdh" class="form-control" placeholder="请输入联系电话">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="company_companyDesc_edit" class="col-md-3 text-right">公司介绍:</label>
		  	 <div class="col-md-9">
			    <textarea id="company_companyDesc_edit" name="company.companyDesc" rows="8" class="form-control" placeholder="请输入公司介绍"></textarea>
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="company_address_edit" class="col-md-3 text-right">公司地址:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="company_address_edit" name="company.address" class="form-control" placeholder="请输入公司地址">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="company_shzt_edit" class="col-md-3 text-right">审核状态:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="company_shzt_edit" name="company.shzt" class="form-control" placeholder="请输入审核状态">
			 </div>
		  </div>
		</form> 
	    <style>#companyEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxCompanyModify();">提交</button>
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->
<uc:footer ID="footer" runat="server" />
<script src="<%=basePath %>plugins/jquery.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap.js"></script>
<script src="<%=basePath %>plugins/wow.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap-datetimepicker.min.js"></script>
<script src="<%=basePath %>plugins/locales/bootstrap-datetimepicker.zh-CN.js"></script>
<script type="text/javascript" src="<%=basePath %>js/jsdate.js"></script>
<script>
var basePath = "<%=basePath%>";
/*弹出修改企业界面并初始化数据*/
function companyEdit(companyUserName) {
	$.ajax({
		url :  basePath + "Company/CompanyController.aspx?action=getCompany&companyUserName=" + companyUserName,
		type : "get",
		dataType: "json",
		success : function (company, response, status) {
			if (company) {
				$("#company_companyUserName_edit").val(company.companyUserName);
				$("#company_password_edit").val(company.password);
				$("#company_qyjb_edit").val(company.qyjb);
				$("#company_companyName_edit").val(company.companyName);
				$("#company_gszch_edit").val(company.gszch);
				$("#company_yyzz").val(company.yyzz);
				$("#company_yyzzImg").attr("src", basePath +　company.yyzz);
				$("#company_gsxz_edit").val(company.gsxz);
				$("#company_gsgm_edit").val(company.gsgm);
				$("#company_gghy_edit").val(company.gghy);
				$("#company_lxr_edit").val(company.lxr);
				$("#company_lxdh_edit").val(company.lxdh);
				$("#company_companyDesc_edit").val(company.companyDesc);
				$("#company_address_edit").val(company.address);
				$("#company_shzt_edit").val(company.shzt);
				$('#companyEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除企业信息*/
function companyDelete(companyUserName) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "Company/CompanyController.aspx?action=delete",
			data : {
				companyUserName : companyUserName,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
                    $("#btnSearch").click();
					//location.href= basePath + "Company/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交企业信息表单给服务器端修改*/
function ajaxCompanyModify() {
	$.ajax({
		url :  basePath + "Company/CompanyController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#companyEditForm")[0]),
		success : function (obj, response, status) {
            if(obj.success){
                alert("信息修改成功！");
                $("#btnSearch").click();
            }else{
                alert(obj.message);
            } 
		},
		processData: false,
		contentType: false,
	});
}

$(function(){
	/*小屏幕导航点击关闭菜单*/
    $('.navbar-collapse a').click(function(){
        $('.navbar-collapse').collapse('hide');
    });
    new WOW().init();

})
</script>
</body>
</html>

