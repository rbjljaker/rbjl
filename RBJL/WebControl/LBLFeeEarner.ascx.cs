using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebControl_LBLFeeEarner : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public Guid initGuidId { get; set; }
    public EnumFeeEarnerAndHandlingColleague type { get; set; }

    public string findMatterUser()
    {
        string result;
        MatterInfo mI = new MatterInfo();
        Guid matterId = initGuidId;
        switch (type)
        {
            case EnumFeeEarnerAndHandlingColleague.HandlingColleague:
                {
                    result = mI.getFeeEarnerAndHandlingColleagueByMatterId(matterId, EnumFeeEarnerAndHandlingColleague.HandlingColleague);
                    break;
                }
            case EnumFeeEarnerAndHandlingColleague.FeeEarner:
            default:
                {
                    result = mI.getFeeEarnerAndHandlingColleagueByMatterId(matterId, EnumFeeEarnerAndHandlingColleague.FeeEarner);
                    break;
                }
        }
        return result;
    }
}
