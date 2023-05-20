using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace chengxusheji.Admin
{
    public partial class CompanyList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                string sqlstr = " where 1=1 ";
                if (Request["qyjb"] != null && Request["qyjb"].ToString() != "")
                {
                    sqlstr += "  and qyjb like '%" + Request["qyjb"].ToString() + "%'";
                    qyjb.Text = Request["qyjb"].ToString();
                }
                if (Request["companyName"] != null && Request["companyName"].ToString() != "")
                {
                    sqlstr += "  and companyName like '%" + Request["companyName"].ToString() + "%'";
                    companyName.Text = Request["companyName"].ToString();
                }
                if (Request["gszch"] != null && Request["gszch"].ToString() != "")
                {
                    sqlstr += "  and gszch like '%" + Request["gszch"].ToString() + "%'";
                    gszch.Text = Request["gszch"].ToString();
                }
                if (Request["gsxz"] != null && Request["gsxz"].ToString() != "")
                {
                    sqlstr += "  and gsxz like '%" + Request["gsxz"].ToString() + "%'";
                    gsxz.Text = Request["gsxz"].ToString();
                }
                if (Request["gsgm"] != null && Request["gsgm"].ToString() != "")
                {
                    sqlstr += "  and gsgm like '%" + Request["gsgm"].ToString() + "%'";
                    gsgm.Text = Request["gsgm"].ToString();
                }
                if (Request["gghy"] != null && Request["gghy"].ToString() != "")
                {
                    sqlstr += "  and gghy like '%" + Request["gghy"].ToString() + "%'";
                    gghy.Text = Request["gghy"].ToString();
                }
                if (Request["lxr"] != null && Request["lxr"].ToString() != "")
                {
                    sqlstr += "  and lxr like '%" + Request["lxr"].ToString() + "%'";
                    lxr.Text = Request["lxr"].ToString();
                }
                if (Request["lxdh"] != null && Request["lxdh"].ToString() != "")
                {
                    sqlstr += "  and lxdh like '%" + Request["lxdh"].ToString() + "%'";
                    lxdh.Text = Request["lxdh"].ToString();
                }
                if (Request["shzt"] != null && Request["shzt"].ToString() != "")
                {
                    sqlstr += "  and shzt like '%" + Request["shzt"].ToString() + "%'";
                    shzt.Text = Request["shzt"].ToString();
                }
                HWhere.Value = sqlstr;
                BindData("");
            }
        }
        protected void BtnCompanyAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("CompanyEdit.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllCompany.DelCompany(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "��Ϣ�ɹ�ɾ��..", "CompanyList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "error", "��Ϣɾ��ʧ�ܣ������Ի���ϵ������Ա..");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "error", "ɾ��ʧ��..");
                }
            }
        }

        private void BindData(string strClass)
        {
            int DataCount = 0;
            int NowPage = 1;
            int AllPage = 0;
            int PageSize = Convert.ToInt32(HPageSize.Value);
            switch (strClass)
            {
                case "next":
                    NowPage = Convert.ToInt32(HNowPage.Value) + 1;
                    break;
                case "up":
                    NowPage = Convert.ToInt32(HNowPage.Value) - 1;
                    break;
                case "end":
                    NowPage = Convert.ToInt32(HAllPage.Value);
                    break;
                default:
                    break;
            }
            DataTable dsLog = BLL.bllCompany.GetCompany(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
            if (dsLog.Rows.Count == 0 || AllPage == 1)
            {
                LBEnd.Enabled = false;
                LBHome.Enabled = false;
                LBNext.Enabled = false;
                LBUp.Enabled = false;
            }
            else if (NowPage == 1)
            {
                LBHome.Enabled = false;
                LBUp.Enabled = false;
                LBNext.Enabled = true;
                LBEnd.Enabled = true;
            }
            else if (NowPage == AllPage)
            {
                LBHome.Enabled = true;
                LBUp.Enabled = true;
                LBNext.Enabled = false;
                LBEnd.Enabled = false;
            }
            else
            {
                LBEnd.Enabled = true;
                LBHome.Enabled = true;
                LBNext.Enabled = true;
                LBUp.Enabled = true;
            }
            RpCompany.DataSource = dsLog;
            RpCompany.DataBind();
            PageMes.Text = string.Format("[ÿҳ<font color=green>{0}</font>�� ��<font color=red>{1}</font>ҳ����<font color=green>{2}</font>ҳ   ��<font color=green>{3}</font>��]", PageSize, NowPage, AllPage, DataCount);
            HNowPage.Value = Convert.ToString(NowPage++);
            HAllPage.Value = AllPage.ToString();
        }

        protected void LBHome_Click(object sender, EventArgs e)
        {
            BindData("");
        }
        protected void LBUp_Click(object sender, EventArgs e)
        {
            BindData("up");
        }
        protected void LBNext_Click(object sender, EventArgs e)
        {
            BindData("next");
        }
        protected void LBEnd_Click(object sender, EventArgs e)
        {
            BindData("end");
        }
        protected void RpCompany_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllCompany.DelCompany((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "��Ϣɾ���ɹ�...", "CompanyList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "��Ϣɾ��ʧ�ܣ������Ի���ϵ������Ա...", "CompanyList.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "ɾ��ʧ��...", "CompanyList.aspx");
                }
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("CompanyList.aspx?qyjb=" + qyjb.Text.Trim() + "&&companyName=" + companyName.Text.Trim()+ "&&gszch=" + gszch.Text.Trim()+ "&&gsxz=" + gsxz.Text.Trim()+ "&&gsgm=" + gsgm.Text.Trim()+ "&&gghy=" + gghy.Text.Trim()+ "&&lxr=" + lxr.Text.Trim()+ "&&lxdh=" + lxdh.Text.Trim()+ "&&shzt=" + shzt.Text.Trim());
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet companyDataSet = BLL.bllCompany.GetCompany(HWhere.Value); 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            sb.Append("<table borderColor='black' border='1' >");
            sb.Append("<thead><tr><th colSpan='11'>��ҵ��¼</th></tr>");
            sb.Append("<tr class='title'>");
            sb.Append("<th>��ҵ�û���</th>");
            sb.Append("<th>���ü���</th>");
            sb.Append("<th>��ҵ����</th>");
            sb.Append("<th>����ע���</th>");
            sb.Append("<th>Ӫҵִ��</th>");
            sb.Append("<th>��˾����</th>");
            sb.Append("<th>��˾��ģ</th>");
            sb.Append("<th>��˾��ҵ</th>");
            sb.Append("<th>��ϵ��</th>");
            sb.Append("<th>��ϵ�绰</th>");
            sb.Append("<th>���״̬</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");
            for (int i = 0; i < companyDataSet.Tables[0].Rows.Count; i++)
            {
                DataRow dr = companyDataSet.Tables[0].Rows[i];
                sb.Append("<tr height='60' class=content>");
                sb.Append("<td>" + dr["companyUserName"].ToString() + "</td>");
                sb.Append("<td>" + dr["qyjb"].ToString() + "</td>");
                sb.Append("<td>" + dr["companyName"].ToString() + "</td>");
                sb.Append("<td>" + dr["gszch"].ToString() + "</td>");
                sb.Append("<td width=80><span align='center'><img width='80' height='60' border='0' src='" + GetBaseUrl() + "/" +  dr["yyzz"].ToString() + "'/></span></td>");
                sb.Append("<td>" + dr["gsxz"].ToString() + "</td>");
                sb.Append("<td>" + dr["gsgm"].ToString() + "</td>");
                sb.Append("<td>" + dr["gghy"].ToString() + "</td>");
                sb.Append("<td>" + dr["lxr"].ToString() + "</td>");
                sb.Append("<td>" + dr["lxdh"].ToString() + "</td>");
                sb.Append("<td>" + dr["shzt"].ToString() + "</td>");
                sb.Append("</tr>");
            } 
           sb.Append("</tbody></table>");
            string content = sb.ToString();
            string css = ".content{color:red;text-align:center;}";
            string filename = "��ҵ��¼.xls";
            CommonTool.ExportToExcel(filename, content, css);
        }

        protected string GetBaseUrl()
        {
            return Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf("/Admin"));
        }
    }
}
