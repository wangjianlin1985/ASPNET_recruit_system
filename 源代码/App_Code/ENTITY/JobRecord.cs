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
    ///JobRecord ��ժҪ˵������ְ��¼ʵ��
    /// </summary>

    public class JobRecord
    {
        /*��¼id*/
        private int _recordId;
        public int recordId
        {
            get { return _recordId; }
            set { _recordId = value; }
        }

        /*����*/
        private string _title;
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        /*����*/
        private string _content;
        public string content
        {
            get { return _content; }
            set { _content = value; }
        }

        /*��¼��*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*��¼ʱ��*/
        private DateTime _recordDate;
        public DateTime recordDate
        {
            get { return _recordDate; }
            set { _recordDate = value; }
        }

    }
}
