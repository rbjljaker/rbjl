using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class WebControl_LBLUserName : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    public Guid userGuid { get; set; }


    public string findUserName()
    {
        string result = "";
        MembershipUser curUser = Membership.GetUser(userGuid);
        if (curUser != null)
        {
            UserInfo uI = new UserInfo();

            result = uI.getIntroducer(userGuid.ToString());
        }
        return result;
    }
}