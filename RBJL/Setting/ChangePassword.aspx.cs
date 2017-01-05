using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageUtilities;

public partial class Setting_ChangePassword : CultureEnabledPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "setMenu", "setCurrMenu(5);", true);
    }
    protected void ChangePasswordUser_ContinueButtonClick(object sender, EventArgs e)
    {
        redirectCurrentlyPage();
    }
}