using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebControl_ShowLogo : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string logoPath { get; set; }

    public string getLogo()
    {
        string result = "";

        if (!String.IsNullOrEmpty(logoPath))
        {
            result = logoPath;
        }

        return result;
    }
}