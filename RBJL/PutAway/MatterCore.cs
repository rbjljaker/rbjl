using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageUtilities;

public partial class PutAway_MatterCore : CultureEnabledPage
{
    public MatterInfo mI = new MatterInfo();
    EnumFeeEarnerAndHandlingColleague checkRole;
    TimeEntryInfo tE = new TimeEntryInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "setMenu", "setCurrMenu(0);", true);
        checkRole = tE.getTimeEntryUserRole();
        if (checkRole == EnumFeeEarnerAndHandlingColleague.GeneralUser && EnumUserLevel.administrator != mI.userLevel)
        {
            Button editBtn = DetailsViewMatter.FindControl("ButtonEdit") as Button;
            editBtn.Visible = false;
        }


        //if (HiddenFieldStatusid.Value != null)
        //{
        //    DropDownList DropDownListMatterstatus = DetailsViewMatter.FindControl("DropDownListMatterstatus") as DropDownList;
        //    if (DropDownListMatterstatus != null)
        //    {
        //        DropDownListMatterstatus.SelectedValue = HiddenFieldStatusid.Value;
        //    }
        //}
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        EntityDataSourceMatter.ContextType = typeof(RBJLLawFirmDBModel.RBJLLawFirmDBEntities);
    }

    //protected void EntityDataSourceMatter_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    //{
    //    MatterInfo mI = new MatterInfo();
    //    e.DataSource.Where = mI.findCurrMatter();
    //}
    protected void EntityDataSourceMatter_QueryCreated(object sender, QueryCreatedEventArgs e)
    {

    }
    protected void GridViewMatter_RowCreated(object sender, GridViewRowEventArgs e)
    {
    }
    protected void DetailsViewMatter_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        DropDownList DropDownListMatterstatus = DetailsViewMatter.FindControl("DropDownListMatterstatus") as DropDownList;
        if (DropDownListMatterstatus != null)
        {
            string status = DropDownListMatterstatus.SelectedValue;


            //if (checkRole == EnumFeeEarnerAndHandlingColleague.FeeEarner)
            //{
            TimeEntryInfo timeEntryInfo = new TimeEntryInfo();
            timeEntryInfo.editMattercore(Guid.Parse(Request[QueryStringConst.matter]), status);
            //}
        }


        if (String.IsNullOrEmpty(SessionClass.checkIsChangeStatus))
        {
            displayAlert("OK");
        }
        else
        {
            SessionClass.checkIsChangeStatus = null;
            redirectPageAndDisplayAlert("OK", String.Format("../matter/MatterCore.aspx?matter={0}", Request[QueryStringConst.matter]));
        }

    }

    protected void EntityDataSourceMatter_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        e.DataSource.Where = "it.id = GUID'" + Request[QueryStringConst.matter] + "'";
    }
    protected void DetailsViewMatter_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {

        WebControl_uploadLogo wc4 = DetailsViewMatter.FindControl("FUUploadLogo") as WebControl_uploadLogo;

        string logoPath = null;
        bool uploadLogo = wc4.uploadLogo(ref logoPath);
        if (uploadLogo)
        {
            e.NewValues[DatabaseConst.matterConst.logo] = logoPath;
        }

        e.NewValues[DatabaseConst.createDate] = e.OldValues[DatabaseConst.createDate];
        e.NewValues[DatabaseConst.createByUserId] = e.OldValues[DatabaseConst.createByUserId];

        MatterInfo mI = new MatterInfo();

        e.NewValues[DatabaseConst.updateDate] = DateTime.Now;
        e.NewValues[DatabaseConst.updateByUserId] = mI.userGuid;



        DropDownList DropDownListMatterstatus = DetailsViewMatter.FindControl("DropDownListMatterstatus") as DropDownList;
        string status = DropDownListMatterstatus.SelectedValue;


        if (status == "1")
        {
            e.NewValues[DatabaseConst.matterConst.isReopen] = true;
            SessionClass.checkIsChangeStatus = "1";
        }
    }

    protected void DropDownListMatterstatus_OnPreRender(EventArgs e)
    {

    }

    protected void DetailsViewMatter_ItemCommand(object sender, DetailsViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            string ddlVaule = e.CommandArgument.ToString();
            HiddenFieldStatusid.Value = ddlVaule;
        }
    }
}