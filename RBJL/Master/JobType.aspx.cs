using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageUtilities;

public partial class Master_JobType : CultureEnabledPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "setMenu", "setCurrMenu(3);", true);
        if (!IsPostBack)
        {
            GridViewJobType.DataBind();

        }
        else
        {
            GridviewHelper myGridHelper = new GridviewHelper();
            myGridHelper.GridPaging(GridViewJobType, e);
        }

    }
    protected void GridViewJobType_OnDataBound(object sender, EventArgs e)
    {
        GridviewHelper myGridHelper = new GridviewHelper();
        myGridHelper.GridPaging(sender, e);



    }
    protected void Page_Init(object sender, EventArgs e)
    {
        EntityDataSourceJobType.ContextType = typeof(RBJLLawFirmDBModel.RBJLLawFirmDBEntities);
    }

    protected void LinkButtonAdd_Click(object sender, EventArgs e)
    {
        DetailsViewCurrency.Visible = true;
        ModalPopupExtenderInsert.Show();
    }



    protected void DetailsViewCurrency_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {


        redirectPageAndDisplayAlert("OK", Request.Url.AbsolutePath);
    }
    protected void GridViewJobType_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //if (!IsPostBack) e.Cancel = true;
        MatterInfo mI = new MatterInfo();
        e.NewValues[DatabaseConst.updateDate] = DateTime.Now;
        e.NewValues[DatabaseConst.updateByUserId] = mI.userGuid;

    }
    protected void GridViewJobType_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        //GridViewJobType.DataBind();
        displayAlert("OK");
    }
    protected void DetailsViewCurrency_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        MatterInfo mI = new MatterInfo();
        e.Values[DatabaseConst.createDate] = DateTime.Now;
        e.Values[DatabaseConst.createByUserId] = mI.userGuid;

        e.Values[DatabaseConst.updateDate] = DateTime.Now;
        e.Values[DatabaseConst.updateByUserId] = mI.userGuid;

        TextBox tb = (TextBox)Page.FindControl("ctl00$ContentPlaceHolderMainContent$DetailsViewCurrency$__num$TextBox1");
        //tb.Text = tb.Text.ToUpper();


        MaterItem dbConn = new MaterItem();
        if (dbConn.cntJobTypesNum(int.Parse(tb.Text)) > 0)
        {


            //Response.Write("<script>alert('Client No. already exists!');</script>");
            displayAlert("JobTypes No. already exists!");

            tb.Text = "";


            e.Cancel = true;

            DetailsViewCurrency.Visible = true;
            ModalPopupExtenderInsert.Show();

        }
    }

    protected void LinkButtonEditPopup_Click(object sender, EventArgs e)
    {
        DetailsViewCurrencyEdit.Visible = true;
        ModalPopupExtenderEdit.Show();
    }

    protected void DetailsViewCurrencyEdit_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        redirectPageAndDisplayAlert("OK", Request.Url.AbsolutePath);
    }
    protected void DetailsViewCurrencyEdit_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        MatterInfo mI = new MatterInfo();
        e.NewValues[DatabaseConst.updateDate] = DateTime.Now;
        e.NewValues[DatabaseConst.updateByUserId] = mI.userGuid;
    }
    protected void GridViewJobType_SelectedIndexChanged(object sender, EventArgs e)
    {
        DetailsViewCurrencyEdit.PageIndex = (GridViewJobType.PageIndex * GridViewJobType.PageSize) + GridViewJobType.SelectedIndex;
    }
    protected void GridViewJobType_RowDeleted(object sender, GridViewDeletedEventArgs e)
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