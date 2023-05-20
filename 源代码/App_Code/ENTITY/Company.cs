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
    ///Company 的摘要说明：企业实体
    /// </summary>

    public class Company
    {
        /*企业用户名*/
        private string _companyUserName;
        public string companyUserName
        {
            get { return _companyUserName; }
            set { _companyUserName = value; }
        }

        /*登录密码*/
        private string _password;
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        /*信用级别*/
        private string _qyjb;
        public string qyjb
        {
            get { return _qyjb; }
            set { _qyjb = value; }
        }

        /*企业名称*/
        private string _companyName;
        public string companyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }

        /*工商注册号*/
        private string _gszch;
        public string gszch
        {
            get { return _gszch; }
            set { _gszch = value; }
        }

        /*营业执照*/
        private string _yyzz;
        public string yyzz
        {
            get { return _yyzz; }
            set { _yyzz = value; }
        }

        /*公司性质*/
        private string _gsxz;
        public string gsxz
        {
            get { return _gsxz; }
            set { _gsxz = value; }
        }

        /*公司规模*/
        private string _gsgm;
        public string gsgm
        {
            get { return _gsgm; }
            set { _gsgm = value; }
        }

        /*公司行业*/
        private string _gghy;
        public string gghy
        {
            get { return _gghy; }
            set { _gghy = value; }
        }

        /*联系人*/
        private string _lxr;
        public string lxr
        {
            get { return _lxr; }
            set { _lxr = value; }
        }

        /*联系电话*/
        private string _lxdh;
        public string lxdh
        {
            get { return _lxdh; }
            set { _lxdh = value; }
        }

        /*公司介绍*/
        private string _companyDesc;
        public string companyDesc
        {
            get { return _companyDesc; }
            set { _companyDesc = value; }
        }

        /*公司地址*/
        private string _address;
        public string address
        {
            get { return _address; }
            set { _address = value; }
        }

        /*审核状态*/
        private string _shzt;
        public string shzt
        {
            get { return _shzt; }
            set { _shzt = value; }
        }

    }
}
