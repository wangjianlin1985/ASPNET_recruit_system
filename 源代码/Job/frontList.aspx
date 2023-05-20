<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="Job_frontList" %>
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
<title>职位查询</title>
<link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
<link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
<link href="<%=basePath %>plugins/animate.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
</head>
<body style="margin-top:70px;">
<div class="container">
<uc:header ID="header" runat="server" />
 <form id="form2" runat="server">
	<div class="row"> 
		<div class="col-md-9 wow fadeInDown" data-wow-duration="0.5s">
			<div>
				<!-- Nav tabs -->
				<ul class="nav nav-tabs" role="tablist">
			    	<li><a href="../index.aspx">首页</a></li>
			    	<li role="presentation" class="active"><a href="#jobListPanel" aria-controls="jobListPanel" role="tab" data-toggle="tab">职位列表</a></li>
			    	<li role="presentation" ><a href="frontAdd.aspx" style="display:none;">添加职位</a></li>
				</ul>
			  	<!-- Tab panes -->
			  	<div class="tab-content">
				    <div role="tabpanel" class="tab-pane active" id="jobListPanel">
				    		<div class="row">
				    			<div class="col-md-12 top5">
				    				<div class="table-responsive">
				    				<table class="table table-condensed table-hover">
				    					<tr class="success bold"><td>序号</td><td>职位类别</td><td>职位名称</td><td>工作薪酬</td><td>招聘人数</td><td>学历要求</td><td>有效期限</td><td>工作区域</td><td>浏览次数</td><td>发布企业</td><td>发布时间</td><td>操作</td></tr>
				    					<asp:Repeater ID="RpJob" runat="server">
 										<ItemTemplate>
 										<tr>
 											<td><%#(Container.ItemIndex + 1)%></td>
 											<td><%#GetJobTypejobTypeObj(Eval("jobTypeObj").ToString())%></td>
 											<td><%#Eval("jobName")%></td>
 											<td><%#Eval("salary")%></td>
 											<td><%#Eval("zprs")%></td>
 											<td><%#Eval("xlyq")%></td>
 											<td><%#Eval("yxqx")%></td>
 											<td><%#Eval("gzqy")%></td>
 											<td><%#Eval("viewNum")%></td>
 											<td><%#GetCompanycompanyObj(Eval("companyObj").ToString())%></td>
 											<td><%#Eval("addTime")%></td>
 											<td>
 												<a href="frontshow.aspx?jobId=<%#Eval("jobId")%>"><i class="fa fa-info"></i>&nbsp;查看</a>&nbsp;
 												<a href="#" onclick="jobEdit('<%#Eval("jobId")%>');" style="display:none;"><i class="fa fa-pencil fa-fw"></i>编辑</a>&nbsp;
 												<a href="#" onclick="jobDelete('<%#Eval("jobId")%>');" style="display:none;"><i class="fa fa-trash-o fa-fw"></i>删除</a>
 											</td> 
 										</tr>
 										</ItemTemplate>
 										</asp:Repeater>
				    				</table>
				    				</div>
				    			</div>
				    		</div>

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
			</div>
		</div>
	<div class="col-md-3 wow fadeInRight">
		<div class="page-header">
    		<h1>职位查询</h1>
		</div>
            <div class="form-group">
            	<label for="jobTypeObj_jobId">职位类别：</label>
                <asp:DropDownList ID="jobTypeObj" runat="server"  CssClass="form-control" placeholder="请选择职位类别"></asp:DropDownList>
            </div>
			<div class="form-group">
				<label for="jobName">职位名称:</label>
				<asp:TextBox ID="jobName" runat="server"  CssClass="form-control" placeholder="请输入职位名称"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="xlyq">学历要求:</label>
				<asp:TextBox ID="xlyq" runat="server"  CssClass="form-control" placeholder="请输入学历要求"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="gzqy">工作区域:</label>
				<asp:TextBox ID="gzqy" runat="server"  CssClass="form-control" placeholder="请输入工作区域"></asp:TextBox>
			</div>
            <div class="form-group">
            	<label for="companyObj_jobId">发布企业：</label>
                <asp:DropDownList ID="companyObj" runat="server"  CssClass="form-control" placeholder="请选择发布企业"></asp:DropDownList>
            </div>
			<div class="form-group">
				<label for="addTime">发布时间:</label>
				<asp:TextBox ID="addTime"  runat="server" CssClass="form-control" placeholder="请选择发布时间" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
            <input type=hidden name=currentPage value="" />
            <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>

	</div>
 </form>
</div> 
<div id="jobEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;职位信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="jobEditForm" id="jobEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="job_jobId_edit" class="col-md-3 text-right">职位id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="job_jobId_edit" name="job.jobId" class="form-control" placeholder="请输入职位id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="job_jobTypeObj_jobTypeId_edit" class="col-md-3 text-right">职位类别:</label>
		  	 <div class="col-md-9">
			    <select id="job_jobTypeObj_jobTypeId_edit" name="job.jobTypeObj.jobTypeId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="job_jobName_edit" class="col-md-3 text-right">职位名称:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="job_jobName_edit" name="job.jobName" class="form-control" placeholder="请输入职位名称">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="job_jobDesc_edit" class="col-md-3 text-right">职位描述:</label>
		  	 <div class="col-md-9">
			    <textarea id="job_jobDesc_edit" name="job.jobDesc" rows="8" class="form-control" placeholder="请输入职位描述"></textarea>
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="job_salary_edit" class="col-md-3 text-right">工作薪酬:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="job_salary_edit" name="job.salary" class="form-control" placeholder="请输入工作薪酬">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="job_zprs_edit" class="col-md-3 text-right">招聘人数:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="job_zprs_edit" name="job.zprs" class="form-control" placeholder="请输入招聘人数">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="job_xlyq_edit" class="col-md-3 text-right">学历要求:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="job_xlyq_edit" name="job.xlyq" class="form-control" placeholder="请输入学历要求">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="job_yxqx_edit" class="col-md-3 text-right">有效期限:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="job_yxqx_edit" name="job.yxqx" class="form-control" placeholder="请输入有效期限">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="job_gzqy_edit" class="col-md-3 text-right">工作区域:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="job_gzqy_edit" name="job.gzqy" class="form-control" placeholder="请输入工作区域">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="job_gzdz_edit" class="col-md-3 text-right">工作地址:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="job_gzdz_edit" name="job.gzdz" class="form-control" placeholder="请输入工作地址">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="job_viewNum_edit" class="col-md-3 text-right">浏览次数:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="job_viewNum_edit" name="job.viewNum" class="form-control" placeholder="请输入浏览次数">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="job_companyObj_companyUserName_edit" class="col-md-3 text-right">发布企业:</label>
		  	 <div class="col-md-9">
			    <select id="job_companyObj_companyUserName_edit" name="job.companyObj.companyUserName" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="job_addTime_edit" class="col-md-3 text-right">发布时间:</label>
		  	 <div class="col-md-9">
                <div class="input-group date job_addTime_edit col-md-12" data-link-field="job_addTime_edit">
                    <input class="form-control" id="job_addTime_edit" name="job.addTime" size="16" type="text" value="" placeholder="请选择发布时间" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		</form> 
	    <style>#jobEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxJobModify();">提交</button>
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
/*弹出修改职位界面并初始化数据*/
function jobEdit(jobId) {
	$.ajax({
		url :  basePath + "Job/JobController.aspx?action=getJob&jobId=" + jobId,
		type : "get",
		dataType: "json",
		success : function (job, response, status) {
			if (job) {
				$("#job_jobId_edit").val(job.jobId);
				$.ajax({
					url: basePath + "JobType/JobTypeController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(jobTypes,response,status) { 
						$("#job_jobTypeObj_jobTypeId_edit").empty();
						var html="";
		        		$(jobTypes).each(function(i,jobType){
		        			html += "<option value='" + jobType.jobTypeId + "'>" + jobType.jobTypeName + "</option>";
		        		});
		        		$("#job_jobTypeObj_jobTypeId_edit").html(html);
		        		$("#job_jobTypeObj_jobTypeId_edit").val(job.jobTypeObjPri);
					}
				});
				$("#job_jobName_edit").val(job.jobName);
				$("#job_jobDesc_edit").val(job.jobDesc);
				$("#job_salary_edit").val(job.salary);
				$("#job_zprs_edit").val(job.zprs);
				$("#job_xlyq_edit").val(job.xlyq);
				$("#job_yxqx_edit").val(job.yxqx);
				$("#job_gzqy_edit").val(job.gzqy);
				$("#job_gzdz_edit").val(job.gzdz);
				$("#job_viewNum_edit").val(job.viewNum);
				$.ajax({
					url: basePath + "Company/CompanyController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(companys,response,status) { 
						$("#job_companyObj_companyUserName_edit").empty();
						var html="";
		        		$(companys).each(function(i,company){
		        			html += "<option value='" + company.companyUserName + "'>" + company.companyName + "</option>";
		        		});
		        		$("#job_companyObj_companyUserName_edit").html(html);
		        		$("#job_companyObj_companyUserName_edit").val(job.companyObjPri);
					}
				});
				$("#job_addTime_edit").val(job.addTime);
				$('#jobEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除职位信息*/
function jobDelete(jobId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "Job/JobController.aspx?action=delete",
			data : {
				jobId : jobId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
					$("#btnSearch").click();
					//location.href= basePath + "Job/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交职位信息表单给服务器端修改*/
function ajaxJobModify() {
	$.ajax({
		url :  basePath + "Job/JobController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#jobEditForm")[0]),
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

    /*发布时间组件*/
    $('.job_addTime_edit').datetimepicker({
    	language:  'zh-CN',  //语言
    	format: 'yyyy-mm-dd hh:ii:ss',
    	weekStart: 1,
    	todayBtn:  1,
    	autoclose: 1,
    	minuteStep: 1,
    	todayHighlight: 1,
    	startView: 2,
    	forceParse: 0
    });
})
</script>
</body>
</html>

