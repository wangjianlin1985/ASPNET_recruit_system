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
    ///Delivery ��ժҪ˵��������Ͷ��ʵ��
    /// </summary>

    public class Delivery
    {
        /*Ͷ��id*/
        private int _deliveryId;
        public int deliveryId
        {
            get { return _deliveryId; }
            set { _deliveryId = value; }
        }

        /*ӦƸְλ*/
        private int _jobObj;
        public int jobObj
        {
            get { return _jobObj; }
            set { _jobObj = value; }
        }

        /*ӦƸ��*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*Ͷ��ʱ��*/
        private DateTime _deliveryTime;
        public DateTime deliveryTime
        {
            get { return _deliveryTime; }
            set { _deliveryTime = value; }
        }

        /*����ʱ��*/
        private DateTime _handleTime;
        public DateTime handleTime
        {
            get { return _handleTime; }
            set { _handleTime = value; }
        }

        /*����״̬*/
        private string _clzt;
        public string clzt
        {
            get { return _clzt; }
            set { _clzt = value; }
        }

        /*֪ͨ��Ϣ*/
        private string _tzxx;
        public string tzxx
        {
            get { return _tzxx; }
            set { _tzxx = value; }
        }

        /*��������*/
        private string _gzpj;
        public string gzpj
        {
            get { return _gzpj; }
            set { _gzpj = value; }
        }

    }
}
