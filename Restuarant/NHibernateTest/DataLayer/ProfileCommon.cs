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

namespace Restaurant
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Web;
    using System.Web.Profile;

     public class ProfileCommon : ProfileBase
        {
            [SettingsAllowAnonymous(true)]
            public string Address
            {
                //get
                //{
                //    return (string)HttpContext.Current.Profile.GetPropertyValue("Address");
                //}
                //set
                //{
                //    HttpContext.Current.Profile.SetPropertyValue("Address", value);
                //}




                get { return base["Address"].ToString(); }
                set { base["Address"] = value; }
               
            }

            [SettingsAllowAnonymous(true)]
            public string Phone
            {
                //get
                //{
                //    return (string)HttpContext.Current.Profile.GetPropertyValue("Phone");
                //}
                //set
                //{
                //    HttpContext.Current.Profile.SetPropertyValue("Phone", value);
                //}

                get { return base["Phone"].ToString(); }
                set { base["Phone"] = value; }
            }

         

        }
   


}
