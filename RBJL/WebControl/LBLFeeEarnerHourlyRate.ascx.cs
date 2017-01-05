using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GeneralUtilities;

public partial class WebControl_LBLFeeEarnerHourlyRate : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public Guid initGuidId { get; set; }

    public string findMatterUser()
    {
        //string result;
        //MatterInfo mI = new MatterInfo();
        //Guid matterId = initGuidId;
        //result = mI.getFeeEarnerAndHandlingColleagueByMatterId(matterId, EnumFeeEarnerAndHandlingColleague.FeeEarner);
        //return result;

        RepeaterDataBind();
        return "";
    }


    private void RepeaterDataBind()
    {
        MatterInfo mI = new MatterInfo();
        List<HourlyRateDto> result = mI.getFeeEarnerHourRateByMatterId(initGuidId);
        RepeaterHourlyRate.DataSource = ListToDataTableHelper.ConvertToDataTable(result);
        RepeaterHourlyRate.DataBind();
    }
}