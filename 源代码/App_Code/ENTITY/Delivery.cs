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
    ///Delivery 的摘要说明：简历投递实体
    /// </summary>

    public class Delivery
    {
        /*投递id*/
        private int _deliveryId;
        public int deliveryId
        {
            get { return _deliveryId; }
            set { _deliveryId = value; }
        }

        /*应聘职位*/
        private int _jobObj;
        public int jobObj
        {
            get { return _jobObj; }
            set { _jobObj = value; }
        }

        /*应聘人*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*投递时间*/
        private DateTime _deliveryTime;
        public DateTime deliveryTime
        {
            get { return _deliveryTime; }
            set { _deliveryTime = value; }
        }

        /*处理时间*/
        private DateTime _handleTime;
        public DateTime handleTime
        {
            get { return _handleTime; }
            set { _handleTime = value; }
        }

        /*处理状态*/
        private string _clzt;
        public string clzt
        {
            get { return _clzt; }
            set { _clzt = value; }
        }

        /*通知信息*/
        private string _tzxx;
        public string tzxx
        {
            get { return _tzxx; }
            set { _tzxx = value; }
        }

        /*工作评价*/
        private string _gzpj;
        public string gzpj
        {
            get { return _gzpj; }
            set { _gzpj = value; }
        }

    }
}
