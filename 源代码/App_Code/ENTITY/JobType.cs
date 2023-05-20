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
    ///JobType 的摘要说明：职位类别实体
    /// </summary>

    public class JobType
    {
        /*职位类型id*/
        private int _jobTypeId;
        public int jobTypeId
        {
            get { return _jobTypeId; }
            set { _jobTypeId = value; }
        }

        /*职位类别名称*/
        private string _jobTypeName;
        public string jobTypeName
        {
            get { return _jobTypeName; }
            set { _jobTypeName = value; }
        }

        /*职位类别描述*/
        private string _jobTypeDesc;
        public string jobTypeDesc
        {
            get { return _jobTypeDesc; }
            set { _jobTypeDesc = value; }
        }

    }
}
