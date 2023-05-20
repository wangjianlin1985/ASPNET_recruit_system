<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontModify.aspx.cs" Inherits="JobType_frontModify" %>
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
  <TITLE>修改职位类别信息</TITLE>
  <link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
  <link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
  <link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
  <link href="<%=basePath %>plugins/animate.css" rel="stylesheet"> 
</head>
<body style="margin-top:70px;"> 
<div class="container">
<uc:header ID="header" runat="server" />
	<div class="col-md-9 wow fadeInLeft">
	<ul class="breadcrumb">
  		<li><a href="<%=basePath %>index.aspx">首页</a></li>
  		<li class="active">职位类别信息修改</li>
	</ul>
		<div class="row"> 
      	<form class="form-horizontal" name="jobTypeEditForm" id="jobTypeEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="jobType_jobTypeId_edit" class="col-md-3 text-right">职位类型id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="jobType_jobTypeId_edit" name="jobType.jobTypeId" class="form-control" placeholder="请输入职位类型id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="jobType_jobTypeName_edit" class="col-md-3 text-right">职位类别名称:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="jobType_jobTypeName_edit" name="jobType.jobTypeName" class="form-control" placeholder="请输入职位类别名称">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="jobType_jobTypeDesc_edit" class="col-md-3 text-right">职位类别描述:</label>
		  	 <div class="col-md-9">
			    <textarea id="jobType_jobTypeDesc_edit" name="jobType.jobTypeDesc" rows="8" class="form-control" placeholder="请输入职位类别描述"></textarea>
			 </div>
		  </div>
			  <div class="form-group">
			  	<span class="col-md-3""></span>
			  	<span onclick="ajaxJobTypeModify();" class="btn btn-primary bottom5 top5">修改</span>
			  </div>
		</form> 
	    <style>#jobTypeEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
   </div>
</div>


<uc:footer ID="footer" runat="server" />
<script src="<%=basePath %>plugins/jquery.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap.js"></script>
<script src="<%=basePath %>plugins/wow.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap-datetimepicker.min.js"></script>
<script src="<%=basePath %>plugins/locales/bootstrap-datetimepicker.zh-CN.js"></script>
<script type="text/javascript" src="<%=basePath %>js/jsdate.js"></script>
<script>
var basePath = "<%=basePath%>";
/*弹出修改职位类别界面并初始化数据*/
function jobTypeEdit(jobTypeId) {
	$.ajax({
		url :  basePath + "JobType/JobTypeController.aspx?action=getJobType&jobTypeId=" + jobTypeId,
		type : "get",
		dataType: "json",
		success : function (jobType, response, status) {
			if (jobType) {
				$("#jobType_jobTypeId_edit").val(jobType.jobTypeId);
				$("#jobType_jobTypeName_edit").val(jobType.jobTypeName);
				$("#jobType_jobTypeDesc_edit").val(jobType.jobTypeDesc);
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*ajax方式提交职位类别信息表单给服务器端修改*/
function ajaxJobTypeModify() {
	$.ajax({
		url :  basePath + "JobType/JobTypeController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#jobTypeEditForm")[0]),
		success : function (obj, response, status) {
            if(obj.success){
                alert("信息修改成功！");
                location.reload(true);
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
    jobTypeEdit('<%=Request["jobTypeId"] %>');
 })
 </script> 
</body>
</html>

