<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeFile="frontAdd.aspx.cs" Inherits="Company_frontAdd" %>
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
<title>企业添加</title>
<link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
<link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
<link href="<%=basePath %>plugins/animate.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
</head>
<body style="margin-top:70px;">
<div class="container">
<uc:header ID="header" runat="server" />
	<div class="col-md-12 wow fadeInLeft">
		<ul class="breadcrumb">
  			<li><a href="<%=basePath %>index.aspx">首页</a></li>
  			<li><a href="<%=basePath %>Company/frontList.aspx">企业管理</a></li>
  			<li class="active">添加企业</li>
		</ul>
		<div class="row">
			<div class="col-md-10">
		      	<form class="form-horizontal" name="companyAddForm" id="companyAddForm" enctype="multipart/form-data" method="post"  class="mar_t15">
				  <div class="form-group">
					 <label for="company_companyUserName" class="col-md-2 text-right">企业用户名:</label>
					 <div class="col-md-8"> 
					 	<input type="text" id="company_companyUserName" name="company.companyUserName" class="form-control" placeholder="请输入企业用户名">
					 </div>
				  </div> 
				  <div class="form-group">
				  	 <label for="company_password" class="col-md-2 text-right">登录密码:</label>
				  	 <div class="col-md-8">
					    <input type="text" id="company_password" name="company.password" class="form-control" placeholder="请输入登录密码">
					 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="company_qyjb" class="col-md-2 text-right">信用级别:</label>
				  	 <div class="col-md-8">
					    <input type="text" id="company_qyjb" name="company.qyjb" class="form-control" placeholder="请输入信用级别">
					 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="company_companyName" class="col-md-2 text-right">企业名称:</label>
				  	 <div class="col-md-8">
					    <input type="text" id="company_companyName" name="company.companyName" class="form-control" placeholder="请输入企业名称">
					 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="company_gszch" class="col-md-2 text-right">工商注册号:</label>
				  	 <div class="col-md-8">
					    <input type="text" id="company_gszch" name="company.gszch" class="form-control" placeholder="请输入工商注册号">
					 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="company_yyzz" class="col-md-2 text-right">营业执照:</label>
				  	 <div class="col-md-8">
					    <img  class="img-responsive" id="company_yyzzImg" border="0px"/><br/>
					    <input type="hidden" id="company_yyzz" name="company.yyzz"/>
					    <input id="yyzzFile" name="yyzzFile" type="file" size="50" />
				  	 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="company_gsxz" class="col-md-2 text-right">公司性质:</label>
				  	 <div class="col-md-8">
					    <input type="text" id="company_gsxz" name="company.gsxz" class="form-control" placeholder="请输入公司性质">
					 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="company_gsgm" class="col-md-2 text-right">公司规模:</label>
				  	 <div class="col-md-8">
					    <input type="text" id="company_gsgm" name="company.gsgm" class="form-control" placeholder="请输入公司规模">
					 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="company_gghy" class="col-md-2 text-right">公司行业:</label>
				  	 <div class="col-md-8">
					    <input type="text" id="company_gghy" name="company.gghy" class="form-control" placeholder="请输入公司行业">
					 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="company_lxr" class="col-md-2 text-right">联系人:</label>
				  	 <div class="col-md-8">
					    <input type="text" id="company_lxr" name="company.lxr" class="form-control" placeholder="请输入联系人">
					 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="company_lxdh" class="col-md-2 text-right">联系电话:</label>
				  	 <div class="col-md-8">
					    <input type="text" id="company_lxdh" name="company.lxdh" class="form-control" placeholder="请输入联系电话">
					 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="company_companyDesc" class="col-md-2 text-right">公司介绍:</label>
				  	 <div class="col-md-8">
					    <textarea id="company_companyDesc" name="company.companyDesc" rows="8" class="form-control" placeholder="请输入公司介绍"></textarea>
					 </div>
				  </div>
				  <div class="form-group">
				  	 <label for="company_address" class="col-md-2 text-right">公司地址:</label>
				  	 <div class="col-md-8">
					    <input type="text" id="company_address" name="company.address" class="form-control" placeholder="请输入公司地址">
					 </div>
				  </div>
				  <div class="form-group" style="display:none;">
				  	 <label for="company_shzt" class="col-md-2 text-right">审核状态:</label>
				  	 <div class="col-md-8">
					    <input type="text" id="company_shzt" name="company.shzt" value="待审核" class="form-control" placeholder="请输入审核状态">
					 </div>
				  </div>
		          <div class="form-group">
		             <span class="col-md-2""></span>
		             <span onclick="ajaxCompanyAdd();" class="btn btn-primary bottom5 top5">企业注册</span>
		          </div> 
		          <style>#companyAddForm .form-group {margin:5px;}  </style>  
				</form> 
			</div>
			<div class="col-md-2"></div> 
	    </div>
	</div>
</div>
<uc:footer ID="footer" runat="server" />
<script src="<%=basePath %>plugins/jquery.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap.js"></script>
<script src="<%=basePath %>plugins/wow.min.js"></script>
<script src="<%=basePath %>plugins/bootstrapvalidator/js/bootstrapValidator.min.js"></script>
<script type="text/javascript" src="<%=basePath %>plugins/bootstrap-datetimepicker.min.js" charset="UTF-8"></script>
<script type="text/javascript" src="<%=basePath %>plugins/locales/bootstrap-datetimepicker.zh-CN.js" charset="UTF-8"></script>
<script>
var basePath = "<%=basePath%>";
	//提交添加企业信息
	function ajaxCompanyAdd() { 
		//提交之前先验证表单
		$("#companyAddForm").data('bootstrapValidator').validate();
		if(!$("#companyAddForm").data('bootstrapValidator').isValid()){
			return;
		}
		jQuery.ajax({
			type : "post",
			url : basePath + "Company/CompanyController.aspx?action=add",
			dataType : "json" , 
			data: new FormData($("#companyAddForm")[0]),
			success : function(obj) {
				if(obj.success){ 
					alert("保存成功！");
					$("#companyAddForm").find("input").val("");
					$("#companyAddForm").find("textarea").val("");
				} else {
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
	//验证企业添加表单字段
	$('#companyAddForm').bootstrapValidator({
		feedbackIcons: {
			valid: 'glyphicon glyphicon-ok',
			invalid: 'glyphicon glyphicon-remove',
			validating: 'glyphicon glyphicon-refresh'
		},
		fields: {
			"company.companyUserName": {
				validators: {
					notEmpty: {
						message: "企业用户名不能为空",
					}
				}
			},
			"company.password": {
				validators: {
					notEmpty: {
						message: "登录密码不能为空",
					}
				}
			},
			"company.qyjb": {
				validators: {
					notEmpty: {
						message: "信用级别不能为空",
					}
				}
			},
			"company.companyName": {
				validators: {
					notEmpty: {
						message: "企业名称不能为空",
					}
				}
			},
			"company.gszch": {
				validators: {
					notEmpty: {
						message: "工商注册号不能为空",
					}
				}
			},
			"company.gsxz": {
				validators: {
					notEmpty: {
						message: "公司性质不能为空",
					}
				}
			},
			"company.gsgm": {
				validators: {
					notEmpty: {
						message: "公司规模不能为空",
					}
				}
			},
			"company.gghy": {
				validators: {
					notEmpty: {
						message: "公司行业不能为空",
					}
				}
			},
			"company.lxr": {
				validators: {
					notEmpty: {
						message: "联系人不能为空",
					}
				}
			},
			"company.lxdh": {
				validators: {
					notEmpty: {
						message: "联系电话不能为空",
					}
				}
			},
			"company.address": {
				validators: {
					notEmpty: {
						message: "公司地址不能为空",
					}
				}
			},
		 
		}
	}); 
})
</script>
</body>
</html>
