using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageUtilities;

public partial class Matter_PendingListTimeEntry : CultureEnabledPage
{
    TimeEntryInfo tEI = new TimeEntryInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "setMenu", "setCurrMenu(0);", true);
    }


    protected void EntityDataSourceMatterDetails_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        e.DataSource.Where = tEI.findDraftMatter();
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        EntityDataSourceMatterDetails.ContextType = typeof(RBJLLawFirmDBModel.RBJLLawFirmDBEntities);
    }

    protected void GridViewMatterDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            //int rowIndex = Convert.ToInt32(e.CommandArgument);
            //int tarId = Convert.ToInt16(GridViewMatterDetails.DataKeys[rowIndex].Value);

            int tarId = Convert.ToInt32(e.CommandArgument);
            SessionClass.MatterDetailId = tarId.ToString();

            var tempTar = tEI.getMatterDetailsByDetailsId(tarId);
            tempTar.isBill = true;
            SessionClass.timeEntry = tempTar;
            Response.Redirect("New.aspx?timeEntry=moveto");
        }
    }
}