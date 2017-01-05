using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebControl_LBLDoworkTitle : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Label1.Text = initString;
    }

    public string initString { get; set; }


    public string getString()
    {
        return initString;
    }
}