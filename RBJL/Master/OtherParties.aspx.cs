using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageUtilities;

public partial class Master_OtherParties : CultureEnabledPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "setMenu", "setCurrMenu(3);", true);
        if (!IsPostBack)
        {
            GridViewOtherParties.DataBind();

            GridViewCopypop.DataBind();
            ModalPopupExtendercopyfrompop.Hide();
            SessionClass.pop = "0";
        }
        else
        {
            GridviewHelper myGridHelper = new GridviewHelper();
            myGridHelper.GridPaging(GridViewOtherParties, e);

            GridviewHelper myGridHelperGridViewCopypop = new GridviewHelper();
            myGridHelperGridViewCopypop.GridPaging(GridViewCopypop, e);
            if (SessionClass.pop == "1")
            {
                ModalPopupExtendercopyfrompop.Show();
            }
        }
    }
    protected void GridViewOtherParties_OnDataBound(object sender, EventArgs e)
    {
        GridviewHelper myGridHelper = new GridviewHelper();
        myGridHelper.GridPaging(sender, e);
    }


    protected void Page_Init(object sender, EventArgs e)
    {
        EntityDataSourceClientInsert.ContextType = EntityDataSourceOtherParties.ContextType = typeof(RBJLLawFirmDBModel.RBJLLawFirmDBEntities);
    }
    protected void LinkButtonAdd_Click(object sender, EventArgs e)
    {
        DetailsViewOtherParties.Visible = true;
        ModalPopupExtenderInsert.Show();
    }
    protected void DetailsViewOtherParties_ItemInserted(object sender, EventArgs e)
    {
        redirectPageAndDisplayAlert("OK", Request.Url.AbsolutePath);
    }

    protected void LinkButtonEditPopup_Click(object sender, EventArgs e)
    {
        DetailsViewClientUpdate.Visible = true;
        ModalPopupExtenderEdit.Show();

    }

    protected void DetailsViewClientUpdate_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        redirectPageAndDisplayAlert("OK", Request.Url.AbsolutePath);
    }
    protected void GridViewOtherParties_SelectedIndexChanged(object sender, EventArgs e)
    {
        DetailsViewClientUpdate.PageIndex = GridViewOtherParties.PageIndex * GridViewOtherParties.PageSize + GridViewOtherParties.SelectedIndex;
    }

    protected void DetailsViewOtherParties_OnItemInserting(object sender, DetailsViewInsertEventArgs e)
    {

        MatterInfo mI = new MatterInfo();
        e.Values[DatabaseConst.createDate] = DateTime.Now;
        e.Values[DatabaseConst.createByUserId] = mI.userGuid;

        e.Values[DatabaseConst.updateDate] = DateTime.Now;
        e.Values[DatabaseConst.updateByUserId] = mI.userGuid;


        TextBox tb = (TextBox)Page.FindControl("ctl00$ContentPlaceHolderMainContent$DetailsViewOtherParties$__otherPartiesNum$TextBox1");
        //tb.Text = tb.Text.ToUpper();


        MaterItem dbConn = new MaterItem();
        if (dbConn.cntOtherpartiesNum(tb.Text) > 0)
        {


            //Response.Write("<script>alert('Client No. already exists!');</script>");
            displayAlert("OtherParties No. already exists!");

            tb.Text = "";


            e.Cancel = true;

            DetailsViewOtherParties.Visible = true;
            ModalPopupExtenderInsert.Show();

        }
    }
    protected void DetailsViewClientUpdate_OnItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        MatterInfo mI = new MatterInfo();
        e.NewValues[DatabaseConst.updateDate] = DateTime.Now;
        e.NewValues[DatabaseConst.updateByUserId] = mI.userGuid;


    }



    protected void LinkButtonCopyFrompop_onclick(object sender, EventArgs e)
    {
        ModalPopupExtendercopyfrompop.Show();
        TextBoxClientName.Text = "";
        insertCpoyDataBind();
        SessionClass.pop = "1";
    }


    private void insertCpoyDataBind()
    {
        EntityDataSourceClientInsert.DataBind();
        GridViewCopypop.DataBind();
    }

    protected void Button_search_Click(object sender, EventArgs e)
    {
        insertCpoyDataBind();
    }
    protected void GridViewCopy_OnDataBound(object sender, EventArgs e)
    {
        GridviewHelper myGridHelper = new GridviewHelper();
        myGridHelper.GridPaging(sender, e);
    }
    protected void GridViewInsert_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            int id = (int)(GridViewCopypop.DataKeys[rowIndex]["id"]);

            MaterItem dbConn = new MaterItem();
            var rlt = dbConn.getClient(id);


            copyField(DatabaseConst.OtherParties.otherPartiesName, rlt.clientName);
            copyField(DatabaseConst.OutgoingAgent.billingAddressFirst, rlt.billingAddressFirst);
            copyField(DatabaseConst.OutgoingAgent.billingAddressSecond, rlt.billingAddressSecond);
            copyField(DatabaseConst.OtherParties.correspondingAddress1First, rlt.correspondingAddress1First);
            copyField(DatabaseConst.OtherParties.correspondingAddress1Second, rlt.correspondingAddress1Second);
            copyField(DatabaseConst.OtherParties.correspondingAddress2First, rlt.correspondingAddress2First);
            copyField(DatabaseConst.OtherParties.correspondingAddress2Second, rlt.correspondingAddress2Second);
            copyField(DatabaseConst.OtherParties.contactPerson, rlt.contactPerson);
            copyField(DatabaseConst.OtherParties.tel, rlt.tel);
            copyField(DatabaseConst.OtherParties.fax, rlt.fax);
            copyField(DatabaseConst.OtherParties.email, rlt.email);

            // DetailsViewReferer.Visible = true;
            ModalPopupExtenderInsert.Show();

            ModalPopupExtendercopyfrompop.Hide();
            SessionClass.pop = "0";

        }
    }

    private void copyField(string des, string srcValue)
    {
        TextBox tb = (TextBox)Page.FindControl("ctl00$ContentPlaceHolderMainContent$DetailsViewOtherParties$__" + des + "$TextBox1");
        tb.Text = srcValue;
    }
    protected void LinkButtonRefresh_Click(object sender, EventArgs e)
    {
        redirectCurrentlyPage();
    }
    protected void EntityDataSourceClientInsert_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        e.DataSource.Where = SQLHelper.whereStringLike(DatabaseConst.CLIENT.clientName, TextBoxClientName.Text);
    }
    protected void GridViewOtherParties_RowDeleted(object sender, GridViewDeletedEventArgs e)
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