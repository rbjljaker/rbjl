using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebControl_LBLIntroducer : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string userGuid { get; set; }



    public string findName()
    {
        UserInfo uI = new UserInfo();
        string result = uI.getIntroducer(userGuid);
        return result;
    }
}