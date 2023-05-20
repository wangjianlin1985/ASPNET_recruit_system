using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace ENTITY
{
    /// <summary>
    ///Job 的摘要说明：职位实体
    /// </summary>

    public class Job
    {
        /*职位id*/
        private int _jobId;
        public int jobId
        {
            get { return _jobId; }
            set { _jobId = value; }
        }

        /*职位类别*/
        private int _jobTypeObj;
        public int jobTypeObj
        {
            get { return _jobTypeObj; }
            set { _jobTypeObj = value; }
        }

        /*职位名称*/
        private string _jobName;
        public string jobName
        {
            get { return _jobName; }
            set { _jobName = value; }
        }

        /*职位描述*/
        private string _jobDesc;
        public string jobDesc
        {
            get { return _jobDesc; }
            set { _jobDesc = value; }
        }

        /*工作薪酬*/
        private string _salary;
        public string salary
        {
            get { return _salary; }
            set { _salary = value; }
        }

        /*招聘人数*/
        private int _zprs;
        public int zprs
        {
            get { return _zprs; }
            set { _zprs = value; }
        }

        /*学历要求*/
        private string _xlyq;
        public string xlyq
        {
            get { return _xlyq; }
            set { _xlyq = value; }
        }

        /*有效期限*/
        private string _yxqx;
        public string yxqx
        {
            get { return _yxqx; }
            set { _yxqx = value; }
        }

        /*工作区域*/
        private string _gzqy;
        public string gzqy
        {
            get { return _gzqy; }
            set { _gzqy = value; }
        }

        /*工作地址*/
        private string _gzdz;
        public string gzdz
        {
            get { return _gzdz; }
            set { _gzdz = value; }
        }

        /*浏览次数*/
        private int _viewNum;
        public int viewNum
        {
            get { return _viewNum; }
            set { _viewNum = value; }
        }

        /*发布企业*/
        private string _companyObj;
        public string companyObj
        {
            get { return _companyObj; }
            set { _companyObj = value; }
        }

        /*发布时间*/
        private DateTime _addTime;
        public DateTime addTime
        {
            get { return _addTime; }
            set { _addTime = value; }
        }

    }
}
