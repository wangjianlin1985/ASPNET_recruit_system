<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontModify.aspx.cs" Inherits="WebLink_frontModify" %>
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
  <TITLE>修改友情链接信息</TITLE>
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
  		<li class="active">友情链接信息修改</li>
	</ul>
		<div class="row"> 
      	<form class="form-horizontal" name="webLinkEditForm" id="webLinkEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="webLink_linkId_edit" class="col-md-3 text-right">记录id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="webLink_linkId_edit" name="webLink.linkId" class="form-control" placeholder="请输入记录id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="webLink_webName_edit" class="col-md-3 text-right">网站名称:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="webLink_webName_edit" name="webLink.webName" class="form-control" placeholder="请输入网站名称">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="webLink_webLogo_edit" class="col-md-3 text-right">网站Logo:</label>
		  	 <div class="col-md-9">
			    <img  class="img-responsive" id="webLink_webLogoImg" border="0px"/><br/>
			    <input type="hidden" id="webLink_webLogo" name="webLink.webLogo"/>
			    <input id="webLogoFile" name="webLogoFile" type="file" size="50" />
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="webLink_webAddress_edit" class="col-md-3 text-right">网站地址:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="webLink_webAddress_edit" name="webLink.webAddress" class="form-control" placeholder="请输入网站地址">
			 </div>
		  </div>
			  <div class="form-group">
			  	<span class="col-md-3""></span>
			  	<span onclick="ajaxWebLinkModify();" class="btn btn-primary bottom5 top5">修改</span>
			  </div>
		</form> 
	    <style>#webLinkEditForm .form-group {margin-bottom:5px;}  </style>
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
/*弹出修改友情链接界面并初始化数据*/
function webLinkEdit(linkId) {
	$.ajax({
		url :  basePath + "WebLink/WebLinkController.aspx?action=getWebLink&linkId=" + linkId,
		type : "get",
		dataType: "json",
		success : function (webLink, response, status) {
			if (webLink) {
				$("#webLink_linkId_edit").val(webLink.linkId);
				$("#webLink_webName_edit").val(webLink.webName);
				$("#webLink_webLogo").val(webLink.webLogo);
				$("#webLink_webLogoImg").attr("src", basePath +　webLink.webLogo);
				$("#webLink_webAddress_edit").val(webLink.webAddress);
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*ajax方式提交友情链接信息表单给服务器端修改*/
function ajaxWebLinkModify() {
	$.ajax({
		url :  basePath + "WebLink/WebLinkController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#webLinkEditForm")[0]),
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
    webLinkEdit('<%=Request["linkId"] %>');
 })
 </script> 
</body>
</html>

