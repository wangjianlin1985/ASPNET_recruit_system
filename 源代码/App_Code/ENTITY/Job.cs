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
    ///Job ��ժҪ˵����ְλʵ��
    /// </summary>

    public class Job
    {
        /*ְλid*/
        private int _jobId;
        public int jobId
        {
            get { return _jobId; }
            set { _jobId = value; }
        }

        /*ְλ���*/
        private int _jobTypeObj;
        public int jobTypeObj
        {
            get { return _jobTypeObj; }
            set { _jobTypeObj = value; }
        }

        /*ְλ����*/
        private string _jobName;
        public string jobName
        {
            get { return _jobName; }
            set { _jobName = value; }
        }

        /*ְλ����*/
        private string _jobDesc;
        public string jobDesc
        {
            get { return _jobDesc; }
            set { _jobDesc = value; }
        }

        /*����н��*/
        private string _salary;
        public string salary
        {
            get { return _salary; }
            set { _salary = value; }
        }

        /*��Ƹ����*/
        private int _zprs;
        public int zprs
        {
            get { return _zprs; }
            set { _zprs = value; }
        }

        /*ѧ��Ҫ��*/
        private string _xlyq;
        public string xlyq
        {
            get { return _xlyq; }
            set { _xlyq = value; }
        }

        /*��Ч����*/
        private string _yxqx;
        public string yxqx
        {
            get { return _yxqx; }
            set { _yxqx = value; }
        }

        /*��������*/
        private string _gzqy;
        public string gzqy
        {
            get { return _gzqy; }
            set { _gzqy = value; }
        }

        /*������ַ*/
        private string _gzdz;
        public string gzdz
        {
            get { return _gzdz; }
            set { _gzdz = value; }
        }

        /*�������*/
        private int _viewNum;
        public int viewNum
        {
            get { return _viewNum; }
            set { _viewNum = value; }
        }

        /*������ҵ*/
        private string _companyObj;
        public string companyObj
        {
            get { return _companyObj; }
            set { _companyObj = value; }
        }

        /*����ʱ��*/
        private DateTime _addTime;
        public DateTime addTime
        {
            get { return _addTime; }
            set { _addTime = value; }
        }

    }
}
