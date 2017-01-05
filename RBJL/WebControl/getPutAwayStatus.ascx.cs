using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebControl_getPutAwayStatus : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string statudId { get; set; }

    public string getStatus()
    {
        return checkCase(statudId);
    }

    public void setLblValue(string item)
    {
        Label1.Text = checkCase(item);
    }


    private string checkCase(string item)
    {
        string result = "";

        switch (Convert.ToInt16(item))
        {
            case (int)EnumStatus.Open:
                {
                    result = "Live";
                    break;
                }
            case (int)EnumStatus.Suspend:
                {
                    result = "Suspend";
                    break;
                }
            case (int)EnumStatus.Finish:
                {
                    result = "Closed";
                    break;
                }
            case (int)EnumStatus.Domount:
                {
                    result = "Domount";
                    break;
                }
        }
        return result;
    }
}