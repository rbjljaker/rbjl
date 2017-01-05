using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageUtilities;

public partial class Master_Currency : CultureEnabledPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "setMenu", "setCurrMenu(3);", true);
        if (!IsPostBack) GridViewCurrency.DataBind();
        else
        {
            GridviewHelper myGridHelper = new GridviewHelper();
            myGridHelper.GridPaging(GridViewCurrency, e);
        }
    }
    protected void GridViewCurrency_OnDataBound(object sender, EventArgs e)
    {
        GridviewHelper myGridHelper = new GridviewHelper();
        myGridHelper.GridPaging(sender, e);
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        EntityDataSourceCurrency.ContextType = typeof(RBJLLawFirmDBModel.RBJLLawFirmDBEntities);
    }
    protected void LinkButtonAdd_Click(object sender, EventArgs e)
    {
        DetailsViewCurrency.Visible = true;
        ModalPopupExtender1.Show();
    }
    protected void DetailsViewCurrency_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        redirectPageAndDisplayAlert("OK", Request.Url.AbsolutePath);
    }
    protected void DetailsViewCurrency_OnItemInserting(object sender, DetailsViewInsertEventArgs e)
    {

        //MatterInfo mI = new MatterInfo();
        //e.Values[DatabaseConst.createDate] = DateTime.Now;
        //e.Values[DatabaseConst.createByUserId] = mI.userGuid;

        //e.Values[DatabaseConst.updateDate] = DateTime.Now;
        //e.Values[DatabaseConst.updateByUserId] = mI.userGuid;

    }
    protected void GridViewCurrency_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //MatterInfo mI = new MatterInfo();
        //e.NewValues[DatabaseConst.updateDate] = DateTime.Now;
        //e.NewValues[DatabaseConst.updateByUserId] = mI.userGuid;

    }
    protected void GridViewCurrency_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        //redirectPageAndDisplayAlert("OK", Request.Url.AbsolutePath);
        displayAlert("OK");

    }
    protected void DetailsViewCurrencyEdit_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        redirectPageAndDisplayAlert("OK", Request.Url.AbsolutePath);
    }

    protected void LinkButtonEditPopup_Click(object sender, EventArgs e)
    {
        DetailsViewCurrencyEdit.Visible = true;
        ModalPopupExtenderEdit.Show();
    }
    protected void GridViewCurrency_SelectedIndexChanged(object sender, EventArgs e)
    {
        DetailsViewCurrencyEdit.PageIndex = (GridViewCurrency.PageIndex * GridViewCurrency.PageSize) + GridViewCurrency.SelectedIndex;

    }
    protected void GridViewCurrency_RowDeleted(object sender, GridViewDeletedEventArgs e)
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