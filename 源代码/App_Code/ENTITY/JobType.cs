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
    ///JobType ��ժҪ˵����ְλ���ʵ��
    /// </summary>

    public class JobType
    {
        /*ְλ����id*/
        private int _jobTypeId;
        public int jobTypeId
        {
            get { return _jobTypeId; }
            set { _jobTypeId = value; }
        }

        /*ְλ�������*/
        private string _jobTypeName;
        public string jobTypeName
        {
            get { return _jobTypeName; }
            set { _jobTypeName = value; }
        }

        /*ְλ�������*/
        private string _jobTypeDesc;
        public string jobTypeDesc
        {
            get { return _jobTypeDesc; }
            set { _jobTypeDesc = value; }
        }

    }
}
