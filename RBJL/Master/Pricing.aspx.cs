using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageUtilities;

public partial class Master_Pricing : CultureEnabledPage
{


    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "setMenu", "setCurrMenu(3);", true);
        if (!IsPostBack)
        {
            GridViewPricingType.DataBind();
            GridViewPricingDetails.DataBind();
        }
        else
        {
            GridviewHelper myGridHelper = new GridviewHelper();
            myGridHelper.GridPaging(GridViewPricingType, e);
            GridviewHelper myGridHelperDetails = new GridviewHelper();
            myGridHelperDetails.GridPaging(GridViewPricingDetails, e);

        }
    }

    protected void GridViewPricingType_OnDataBound(object sender, EventArgs e)
    {
        GridviewHelper myGridHelper = new GridviewHelper();
        myGridHelper.GridPaging(sender, e);
    }

    protected void GridViewPricingDetails_OnDataBound(object sender, EventArgs e)
    {
        GridviewHelper myGridHelper = new GridviewHelper();
        myGridHelper.GridPaging(sender, e);
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        EntityDataSourcePricingDetailsEdit.ContextType = EntityDataSourcePricingTypeEdit.ContextType = EntityDataSourcePricingDetails.ContextType = EntityDataSourcePricingType.ContextType = typeof(RBJLLawFirmDBModel.RBJLLawFirmDBEntities);
    }
    protected void LinkButtonAdd_Click(object sender, EventArgs e)
    {
        DetailsViewPricingType.Visible = true;
        ModalPopupExtender1.Show();
    }
    protected void LinkButtonAddDetails_Click(object sender, EventArgs e)
    {
        DetailsViewPricingDetails.Visible = true;
        ModalPopupExtender2.Show();
    }


    protected void DetailsViewPricingDetails_ItemCommand(object sender, DetailsViewCommandEventArgs e)
    {
        if (e.CommandName == "Cancel")
        {
            redirectCurrentlyPage();
        }
    }

    protected void DetailsViewPricingType_ItemCommand(object sender, DetailsViewCommandEventArgs e)
    {
        if (e.CommandName == "Cancel")
        {
            redirectCurrentlyPage();
        }
    }

    protected void DetailsViewPricingType_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        redirectPageAndDisplayAlert("OK", Request.Url.AbsolutePath);
    }
    protected void DetailsViewPricingDetails_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        redirectPageAndDisplayAlert("OK", Request.Url.AbsolutePath);
    }

    protected void DetailsViewPricingType_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {

        MatterInfo mI = new MatterInfo();
        e.Values[DatabaseConst.createDate] = DateTime.Now;
        e.Values[DatabaseConst.createByUserId] = mI.userGuid;

        e.Values[DatabaseConst.updateDate] = DateTime.Now;

    }
    protected void DetailsViewPricingType_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        MatterInfo mI = new MatterInfo();
        e.NewValues[DatabaseConst.updateDate] = DateTime.Now;
        e.NewValues[DatabaseConst.updateByUserId] = mI.userGuid;


    }
    protected void GridViewPricingType_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        MatterInfo mI = new MatterInfo();
        e.NewValues[DatabaseConst.updateDate] = DateTime.Now;
        e.NewValues[DatabaseConst.updateByUserId] = mI.userGuid;

    }


    protected void GridViewPricingType_OnRowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        displayAlert("OK");
    }
    protected void GridViewPricingDetails_OnRowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        displayAlert("OK");
    }
    protected void DetailsViewPricingDetails_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {

    }
    protected void GridViewPricingType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            Control ctl = e.CommandSource as Control;
            GridViewRow CurrentRow = ctl.NamingContainer as GridViewRow;

            string feeTpye; feeTpye = GridViewPricingType.DataKeys[CurrentRow.RowIndex].Value.ToString();
            EntityDataSourcePricingTypeEdit.Where = "it.id =" + feeTpye;
            EntityDataSourcePricingTypeEdit.DataBind();
            DetailsViewDetailsEdit.DataBind();
        }
    }

    protected void LinkButtonEditPopup_Click(object sender, EventArgs e)
    {
        DetailsView1.Visible = true;
        Window3.Show();

    }
    protected void GridViewPricingType_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DetailsView1.PageIndex = (GridViewPricingType.PageIndex * GridViewPricingType.PageSize) + GridViewPricingType.SelectedIndex;

    }
    protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        MatterInfo mI = new MatterInfo();
        e.NewValues[DatabaseConst.updateDate] = DateTime.Now;
        e.NewValues[DatabaseConst.updateByUserId] = mI.userGuid;
    }
    protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        redirectPageAndDisplayAlert("OK", Request.Url.AbsolutePath);
    }

    protected void LinkButtonEditPopupDeta_Click(object sender, EventArgs e)
    {
        DetailsViewDetailsEdit.Visible = true;
        WindowDetailsEdit.Show();

    }

    protected void GridViewPricingDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

        //DetailsViewDetailsEdit.PageIndex = (GridViewPricingDetails.PageIndex * GridViewPricingDetails.PageSize) + GridViewPricingDetails.SelectedIndex;
    }
    protected void DetailsViewDetailsEdit_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        redirectPageAndDisplayAlert("OK", Request.Url.AbsolutePath);
    }
    protected void DetailsViewDetailsEdit_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        MatterInfo mI = new MatterInfo();
        e.NewValues[DatabaseConst.updateDate] = DateTime.Now;
        e.NewValues[DatabaseConst.updateByUserId] = mI.userGuid;
    }
    protected void EntityDataSourcePricingTypeEdit_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
    }
    protected void GridViewPricingDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            Control ctl = e.CommandSource as Control;
            GridViewRow CurrentRow = ctl.NamingContainer as GridViewRow;

            string feeTpye;
            feeTpye = GridViewPricingDetails.DataKeys[CurrentRow.RowIndex].Value.ToString();
            EntityDataSourcePricingDetailsEdit.Where = "it.id =" + feeTpye;
            EntityDataSourcePricingDetailsEdit.DataBind();
            DetailsViewPricingDetails.DataBind();
        }
    }


    protected void GridViewPriceType_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        if (e.Exception == null)
        {
            displayAlert("ok");
        }
        else
        {
            displayAlert("An error occurred while attempting to delete the row.");
            e.ExceptionHandled = true;
        }
    }

    protected void GridViewPriceDetails_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        if (e.Exception == null)
        {
            displayAlert("ok");
        }
        else
        {
            displayAlert("An error occurred while attempting to delete the row.");
            e.ExceptionHandled = true;
        }
    }
}