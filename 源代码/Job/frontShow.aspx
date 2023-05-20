<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontShow.aspx.cs" Inherits="Job_frontShow" %>
<%@ Register Src="../header.ascx" TagName="header" TagPrefix="uc" %>
<%@ Register Src="../footer.ascx" TagName="footer" TagPrefix="uc" %>
<%
    String path = Request.ApplicationPath;
    String basePath = path + "/";
    ENTITY.Job job = BLL.bllJob.getSomeJob(int.Parse(Request.QueryString["jobId"]));
    job.viewNum = job.viewNum + 1;
    BLL.bllJob.EditJob(job);
%>
<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1 , user-scalable=no">
  <TITLE>查看职位详情</TITLE>
  <link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
  <link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
  <link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
  <link href="<%=basePath %>plugins/animate.css" rel="stylesheet"> 
</head>
<body style="margin-top:70px;"> 
<uc:header ID="header" runat="server" />
<div class="container">
	<ul class="breadcrumb">
  		<li><a href="<%=basePath %>index.aspx">首页</a></li>
  		<li><a href="<%=basePath %>Job/frontList.aspx">职位信息</a></li>
  		<li class="active">详情查看</li>
	</ul>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">职位id:</div>
		<div class="col-md-10 col-xs-6"><%=job.jobId%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">职位类别:</div>
		<div class="col-md-10 col-xs-6"><%=BLL.bllJobType.getSomeJobType(job.jobTypeObj).jobTypeName %></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">职位名称:</div>
		<div class="col-md-10 col-xs-6"><%=job.jobName%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">职位描述:</div>
		<div class="col-md-10 col-xs-6"><%=job.jobDesc%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">工作薪酬:</div>
		<div class="col-md-10 col-xs-6"><%=job.salary%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">招聘人数:</div>
		<div class="col-md-10 col-xs-6"><%=job.zprs%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">学历要求:</div>
		<div class="col-md-10 col-xs-6"><%=job.xlyq%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">有效期限:</div>
		<div class="col-md-10 col-xs-6"><%=job.yxqx%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">工作区域:</div>
		<div class="col-md-10 col-xs-6"><%=job.gzqy%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">工作地址:</div>
		<div class="col-md-10 col-xs-6"><%=job.gzdz%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">浏览次数:</div>
		<div class="col-md-10 col-xs-6"><%=job.viewNum%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">发布企业:</div>
		<div class="col-md-10 col-xs-6"><%=BLL.bllCompany.getSomeCompany(job.companyObj).companyName %></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">发布时间:</div>
		<div class="col-md-10 col-xs-6"><%=job.addTime%></div>
	</div>
	<div class="row bottom15">
		<div class="col-md-2 col-xs-4"></div>
		<div class="col-md-6 col-xs-6">
            <button onclick="jobDelive();" class="btn btn-primary">投递简历</button>&nbsp;&nbsp;
			<button onclick="history.back();" class="btn btn-primary">返回</button>
		</div>
	</div>
</div> 
<uc:footer ID="footer" runat="server" />
<script src="<%=basePath %>plugins/jquery.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap.js"></script>
<script src="<%=basePath %>plugins/wow.min.js"></script>
<script>
    var basePath = "<%=basePath%>";


function jobDelive() {
	$.ajax({
		url : basePath + "Delivery/DeliveryController.aspx?action=userAdd",
		type : "post",
		dataType: "json",
		data: {
			"jobId": <%=job.jobId%>,
		},
		success : function (data, response, status) {
			//var obj = jQuery.parseJSON(data);
			if(data.success){
				alert("投递成功~");
				location.reload();
			}else{
				alert(data.message);
			}
		}
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

