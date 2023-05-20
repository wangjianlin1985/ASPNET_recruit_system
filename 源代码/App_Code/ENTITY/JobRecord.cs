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
    ///JobRecord 的摘要说明：兼职记录实体
    /// </summary>

    public class JobRecord
    {
        /*记录id*/
        private int _recordId;
        public int recordId
        {
            get { return _recordId; }
            set { _recordId = value; }
        }

        /*标题*/
        private string _title;
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        /*内容*/
        private string _content;
        public string content
        {
            get { return _content; }
            set { _content = value; }
        }

        /*记录人*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*记录时间*/
        private DateTime _recordDate;
        public DateTime recordDate
        {
            get { return _recordDate; }
            set { _recordDate = value; }
        }

    }
}
