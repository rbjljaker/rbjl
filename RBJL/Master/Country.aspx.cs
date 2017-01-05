using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageUtilities;

public partial class Master_Country : CultureEnabledPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "setMenu", "setCurrMenu(3);", true);
        DetailsViewKeyword.Visible = false;
        if (!IsPostBack) GridViewKeyword.DataBind();
        else
        {
            GridviewHelper myGridHelper = new GridviewHelper();
            myGridHelper.GridPaging(GridViewKeyword, e);
        }
    }

    protected void GridViewKeyword_OnDataBound(object sender, EventArgs e)
    {
        GridviewHelper myGridHelper = new GridviewHelper();
        myGridHelper.GridPaging(sender, e);
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        EntityDataSourceCountry.ContextType = typeof(RBJLLawFirmDBModel.RBJLLawFirmDBEntities);
    }
    protected void LinkButtonAdd_Click(object sender, EventArgs e)
    {
        DetailsViewKeyword.Visible = true;
        ModalPopupExtenderInsert.Show();

    }

    protected void DetailsViewKeyword_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        redirectPageAndDisplayAlert("OK", Request.Url.AbsolutePath);
    }


    protected void LinkButtonUpdate_OnClick(object sender, EventArgs e)
    {

    }


    protected void GridViewKeyword_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        //if (e.CommandName == "Update")
        //{
        //    int rowIndex = Convert.ToInt32(e.CommandArgument);
        //    rowIndex += 2;
        //    string strRowIndex = rowIndex.ToString().PadLeft(2, '0');
        //    string text = GridViewKeyword.Rows[0].Cells[2].Text;
        //    TextBox tb = (TextBox)Page.FindControl("ctl00$ContentPlaceHolderMainContent$GridViewKeyword$ctl" + strRowIndex + "$__name$TextBox1");
        //    tb.Text = tb.Text.ToUpper();




        //}
    }
    //
    protected void DetailsViewKeyword_OnItemCommand(Object sender, DetailsViewCommandEventArgs e)
    {

        // Use the CommandName property to determine which button
        // was clicked. 
        //if (e.CommandName == "Insert")
        //{

        //    TextBox tb = (TextBox)Page.FindControl("ctl00$ContentPlaceHolderMainContent$DetailsViewKeyword$__name$TextBox1");
        //    tb.Text = tb.Text.ToUpper();

        //}
    }


    protected void GridViewKeyword_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //MatterInfo mI = new MatterInfo();
        //e.NewValues[DatabaseConst.updateDate] = DateTime.Now;
        //e.NewValues[DatabaseConst.updateByUserId] = mI.userGuid;


    }
    protected void DetailsViewKeyword_OnItemInserting(object sender, DetailsViewInsertEventArgs e)
    {


        MatterInfo mI = new MatterInfo();
        //e.Values[DatabaseConst.createDate] = DateTime.Now;
        //e.Values[DatabaseConst.createByUserId] = mI.userGuid;


        //e.Values[DatabaseConst.updateDate] = DateTime.Now;
        //e.Values[DatabaseConst.updateByUserId] = mI.userGuid;


    }


    protected void GridViewKeyword_OnRowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        displayAlert("OK");
    }

    protected void LinkButtonEditPopup_Click(object sender, EventArgs e)
    {
        DetailsViewKeywordEdit.Visible = true;
        ModalPopupExtenderEdit.Show();
    }

    protected void DetailsViewKeywordEdit_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        redirectPageAndDisplayAlert("OK", Request.Url.AbsolutePath);
    }
    protected void DetailsViewKeywordEdit_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        //MatterInfo mI = new MatterInfo();
        //e.NewValues[DatabaseConst.updateDate] = DateTime.Now;
        //e.NewValues[DatabaseConst.updateByUserId] = mI.userGuid;
    }
    protected void GridViewKeyword_SelectedIndexChanged(object sender, EventArgs e)
    {
        DetailsViewKeywordEdit.PageIndex = (GridViewKeyword.PageIndex * GridViewKeyword.PageSize) + GridViewKeyword.SelectedIndex;
    }
    protected void GridViewKeyword_RowDeleted(object sender, GridViewDeletedEventArgs e)
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