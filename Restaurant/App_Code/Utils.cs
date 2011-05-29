using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using  System.Web.UI;

/// <summary>
/// Summary description for Utils
/// </summary>
public class Utils
{
        public static void ShowMessageBox(Page page, string message)
        {
            StringBuilder jsString = new StringBuilder();
            jsString.AppendFormat("alert(\"{0}\");", message);
            ScriptManager.RegisterStartupScript(page, typeof(Page), System.Guid.NewGuid().ToString(), jsString.ToString(), true);
        }
	
}