using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebControl_BottomButton : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ButtonAction_Click(object sender, EventArgs e)
    {
        IPageInterface pageInterface = Page as IPageInterface;
        if (pageInterface != null)
        {
            pageInterface.DoAction();
        }
    }
    protected void ButtonCancel_Click(object sender, EventArgs e)
    {
        IPageInterface pageInterface = Page as IPageInterface;
        if (pageInterface != null)
        {
            pageInterface.DoCancel();
        }
    }
}