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
    ///Company ��ժҪ˵������ҵʵ��
    /// </summary>

    public class Company
    {
        /*��ҵ�û���*/
        private string _companyUserName;
        public string companyUserName
        {
            get { return _companyUserName; }
            set { _companyUserName = value; }
        }

        /*��¼����*/
        private string _password;
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        /*���ü���*/
        private string _qyjb;
        public string qyjb
        {
            get { return _qyjb; }
            set { _qyjb = value; }
        }

        /*��ҵ����*/
        private string _companyName;
        public string companyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }

        /*����ע���*/
        private string _gszch;
        public string gszch
        {
            get { return _gszch; }
            set { _gszch = value; }
        }

        /*Ӫҵִ��*/
        private string _yyzz;
        public string yyzz
        {
            get { return _yyzz; }
            set { _yyzz = value; }
        }

        /*��˾����*/
        private string _gsxz;
        public string gsxz
        {
            get { return _gsxz; }
            set { _gsxz = value; }
        }

        /*��˾��ģ*/
        private string _gsgm;
        public string gsgm
        {
            get { return _gsgm; }
            set { _gsgm = value; }
        }

        /*��˾��ҵ*/
        private string _gghy;
        public string gghy
        {
            get { return _gghy; }
            set { _gghy = value; }
        }

        /*��ϵ��*/
        private string _lxr;
        public string lxr
        {
            get { return _lxr; }
            set { _lxr = value; }
        }

        /*��ϵ�绰*/
        private string _lxdh;
        public string lxdh
        {
            get { return _lxdh; }
            set { _lxdh = value; }
        }

        /*��˾����*/
        private string _companyDesc;
        public string companyDesc
        {
            get { return _companyDesc; }
            set { _companyDesc = value; }
        }

        /*��˾��ַ*/
        private string _address;
        public string address
        {
            get { return _address; }
            set { _address = value; }
        }

        /*���״̬*/
        private string _shzt;
        public string shzt
        {
            get { return _shzt; }
            set { _shzt = value; }
        }

    }
}
