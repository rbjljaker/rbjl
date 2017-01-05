using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageUtilities;
using RBJLLawFirmDBModel;

public partial class Master_Client : CultureEnabledPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "setMenu", "setCurrMenu(3);", true);
        if (!IsPostBack)
        {
            GridViewInsert.DataBind();
            //GridViewCopy.DataBind();
            GridViewCopypop.DataBind();
            ModalPopupExtendercopyfrompop.Hide();
            SessionClass.pop = "0";
        }
        else
        {
            GridviewHelper myGridHelper = new GridviewHelper();
            myGridHelper.GridPaging(GridViewInsert, e);
            //GridviewHelper myGridHelperGridViewCopy = new GridviewHelper();
            //myGridHelperGridViewCopy.GridPaging(GridViewCopy, e);
            GridviewHelper myGridHelperGridViewCopypop = new GridviewHelper();
            myGridHelperGridViewCopypop.GridPaging(GridViewCopypop, e);
            myGridHelperGridViewCopypop.GridPaging(GridViewOutgoingAgent, e);

            if (SessionClass.pop == "1")
            {
                ModalPopupExtendercopyfrompop.Show();

            }

            else if (SessionClass.pop == "2")
            {
                ModalPopupExtendercopyfrompopOutgoingAgent.Show();

            }
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        EntityDataSourceReferer.ContextType = typeof(RBJLLawFirmDBModel.RBJLLawFirmDBEntities);
        EntityDataSourceClientInsert.ContextType = typeof(RBJLLawFirmDBModel.RBJLLawFirmDBEntities);
        EntityDataSourceClientEdit.ContextType = typeof(RBJLLawFirmDBModel.RBJLLawFirmDBEntities);
        EntityDataSourceOutgoingAgent.ContextType = typeof(RBJLLawFirmDBModel.RBJLLawFirmDBEntities);
    }
    protected void DetailsViewClient_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        redirectPageAndDisplayAlert("OK", Request.Url.AbsolutePath);

    }
    private void CheckAutogen()
    {
        MiscellaneousSetting dbConnMiscellaneou = new MiscellaneousSetting();
        var result = dbConnMiscellaneou.getMiscellaneou("ClientNoStartFrom");

        if (result.isAutoGen)
        {
            MaterItem dbConn = new MaterItem();
            var rltClient = dbConn.getClientNoAll();


            Int64 startFrom = Convert.ToInt64(result.numberValue);


            while (rltClient.Contains<string>((startFrom++).ToString()))
            {
            }
            startFrom--;
            TextBox tb = (TextBox)Page.FindControl("ctl00$ContentPlaceHolderMainContent$DetailsViewClientInsert$__clientNum$TextBox1");
            tb.Text = startFrom.ToString();
            tb.ReadOnly = true;
        }
    }

    protected void LinkButtonAdd_Click(object sender, EventArgs e)
    {
        CheckAutogen();
        DetailsViewClientInsert.Visible = true;
        ModalPopupExtenderInsert.Show();
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
    protected void GridViewInsert_SelectedIndexChanged(object sender, EventArgs e)
    {
        DetailsViewClientUpdate.PageIndex = (GridViewInsert.PageIndex * GridViewInsert.PageSize) + GridViewInsert.SelectedIndex;
    }


    //protected void LinkButtonCopyFrom_onclick(object sender, EventArgs e)
    //{
    //    GridViewCopy.Visible = true;
    //    GridViewInsert.Visible = false;
    //    //LinkButtonAdd.Visible = false;
    //    LinkButtonCopyFrom.Visible = false;

    //    DetailsViewClientInsert.Visible = true;

    //    LinkButtonRefresh.Visible = true;

    //}

    private void copyField(string des, string srcValue)
    {
        TextBox tb = (TextBox)Page.FindControl("ctl00$ContentPlaceHolderMainContent$DetailsViewClientInsert$__" + des + "$TextBox1");
        tb.Text = srcValue;
    }



    protected void GridViewInsert_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            //int id = (int)(GridViewCopy.DataKeys[rowIndex]["id"]);
            int id = (int)(GridViewCopypop.DataKeys[rowIndex]["id"]);

            MaterItem dbConn = new MaterItem();
            var rlt = dbConn.getReferer(id);


            copyField(DatabaseConst.CLIENT.clientName, rlt.refererName);
            copyField(DatabaseConst.CLIENT.billingAddressFirst, rlt.billingAddressFirst);
            copyField(DatabaseConst.CLIENT.billingAddressSecond, rlt.billingAddressSecond);
            copyField(DatabaseConst.CLIENT.correspondingAddress1First, rlt.correspondingAddress1First);
            copyField(DatabaseConst.CLIENT.correspondingAddress1Second, rlt.correspondingAddress1Second);
            copyField(DatabaseConst.CLIENT.correspondingAddress2First, rlt.correspondingAddress2First);
            copyField(DatabaseConst.CLIENT.correspondingAddress2Second, rlt.correspondingAddress2Second);
            copyField(DatabaseConst.CLIENT.contactPerson, rlt.contactPerson);
            copyField(DatabaseConst.CLIENT.tel, rlt.tel);
            copyField(DatabaseConst.CLIENT.fax, rlt.fax);
            copyField(DatabaseConst.CLIENT.email, rlt.email);

            CheckAutogen();

            DetailsViewClientInsert.Visible = true;
            ModalPopupExtenderInsert.Show();

            ModalPopupExtendercopyfrompop.Hide();
            SessionClass.pop = "0";
        }
    }

    protected void DetailsViewReferer_DataBound(object sender, EventArgs e)
    {

    }
    protected void LinkButtonRefresh_Click(object sender, EventArgs e)
    {
        redirectCurrentlyPage();
    }
    protected void DetailsViewClientInsert_OnItemCommand(Object sender, DetailsViewCommandEventArgs e)
    {

        // Use the CommandName property to determine which button
        // was clicked. 
        if (e.CommandName == "Insert")
        {
        }
    }
    protected void DetailsViewClientInsert_OnItemInserting(object sender,
     DetailsViewInsertEventArgs e)
    {

        MatterInfo mI = new MatterInfo();
        e.Values[DatabaseConst.createDate] = DateTime.Now;
        e.Values[DatabaseConst.createByUserId] = mI.userGuid;

        e.Values[DatabaseConst.updateDate] = DateTime.Now;
        e.Values[DatabaseConst.updateByUserId] = mI.userGuid;

        TextBox tb = (TextBox)Page.FindControl("ctl00$ContentPlaceHolderMainContent$DetailsViewClientInsert$__clientNum$TextBox1");
        //tb.Text = tb.Text.ToUpper();


        MaterItem dbConn = new MaterItem();
        if (dbConn.cntClientNum(tb.Text) > 0)
        {


            //Response.Write("<script>alert('Client No. already exists!');</script>");
            displayAlert("Client No. already exists!");

            tb.Text = "";


            e.Cancel = true;

            DetailsViewClientInsert.Visible = true;
            ModalPopupExtenderInsert.Show();

        }

    }
    protected void GridViewInsert_OnDataBound(object sender, EventArgs e)
    {
        GridviewHelper myGridHelper = new GridviewHelper();
        myGridHelper.GridPaging(sender, e);
    }

    protected void GridViewCopy_OnDataBound(object sender, EventArgs e)
    {
        GridviewHelper myGridHelper = new GridviewHelper();
        myGridHelper.GridPaging(sender, e);
    }

    protected void DetailsViewClientUpdate_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        MatterInfo mI = new MatterInfo();
        e.NewValues[DatabaseConst.updateDate] = DateTime.Now;
        e.NewValues[DatabaseConst.updateByUserId] = mI.userGuid;
    }
    protected void LinkButtonCopyFrompop_onclick(object sender, EventArgs e)
    {
        ModalPopupExtendercopyfrompop.Show();
        TextBoxReferName.Text = "";
        insertCpoyDataBind();
        SessionClass.pop = "1";
    }

    protected void Button_search_Click(object sender, EventArgs e)
    {
        insertCpoyDataBind();
    }
    protected void EntityDataSourceReferer_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        e.DataSource.Where = SQLHelper.whereStringLike(DatabaseConst.REFERE.refererName, TextBoxReferName.Text);
    }

    private void insertCpoyDataBind()
    {
        EntityDataSourceReferer.DataBind();
        GridViewCopypop.DataBind();
    }
    protected void GridViewInsert_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            Control ctl = e.CommandSource as Control;
            GridViewRow CurrentRow = ctl.NamingContainer as GridViewRow;

            string feeTpye; feeTpye = GridViewInsert.DataKeys[CurrentRow.RowIndex].Value.ToString();
            EntityDataSourceClientEdit.Where = "it.id =" + feeTpye;
            EntityDataSourceClientEdit.DataBind();
            DetailsViewClientUpdate.DataBind();
        }
    }
    protected void EntityDataSourceClientInsert_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        string name = this.TextBoxName.Text;
        if (!String.IsNullOrEmpty(name))
        {
            e.DataSource.Where = SQLHelper.whereStringLikeStart(DatabaseConst.CLIENT.clientName, name);
        }
    }
    protected void ButtonSearchName_Click(object sender, EventArgs e)
    {
        EntityDataSourceClientInsert.DataBind();
        GridViewInsert.DataBind();
    }
    protected void ButtonOutgoingAgentCopyForm_Click(object sender, EventArgs e)
    {
        ModalPopupExtendercopyfrompopOutgoingAgent.Show();
        TextBoxOutgoingAgent.Text = "";
        insertCpoyDataBindOutgoingAgent();
        SessionClass.pop = "2";
    }

    protected void ButtonOutgoingAgentSearch_Click(object sender, EventArgs e)
    {
        insertCpoyDataBindOutgoingAgent();
    }
    protected void LinkButtonRefreshOutgoingAgent_Click(object sender, EventArgs e)
    {
        redirectCurrentlyPage();
    }

    protected void GridViewOutgoingAgent_OnDataBound(object sender, EventArgs e)
    {
        GridviewHelper myGridHelper = new GridviewHelper();
        myGridHelper.GridPaging(sender, e);
    }

    protected void GridViewOutgoingAgent_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            //int id = (int)(GridViewCopy.DataKeys[rowIndex]["id"]);
            int id = (int)(GridViewOutgoingAgent.DataKeys[rowIndex]["id"]);

            MaterItem dbConn = new MaterItem();
            var rlt = dbConn.getOutgoingAgent(id);


            copyField(DatabaseConst.CLIENT.clientName, rlt.agentName);
            copyField(DatabaseConst.CLIENT.billingAddressFirst, rlt.correspondingAddress1First);
            copyField(DatabaseConst.CLIENT.billingAddressSecond, rlt.correspondingAddress1Second);
            copyField(DatabaseConst.CLIENT.correspondingAddress1First, rlt.correspondingAddress1First);
            copyField(DatabaseConst.CLIENT.correspondingAddress1Second, rlt.correspondingAddress1Second);
            copyField(DatabaseConst.CLIENT.correspondingAddress2First, rlt.correspondingAddress2First);
            copyField(DatabaseConst.CLIENT.correspondingAddress2Second, rlt.correspondingAddress2Second);
            copyField(DatabaseConst.CLIENT.contactPerson, rlt.contactPerson);
            copyField(DatabaseConst.CLIENT.tel, rlt.tel);
            copyField(DatabaseConst.CLIENT.fax, rlt.fax);
            copyField(DatabaseConst.CLIENT.email, rlt.email);

            CheckAutogen();

            DetailsViewClientInsert.Visible = true;
            ModalPopupExtenderInsert.Show();

            ModalPopupExtendercopyfrompopOutgoingAgent.Hide();
            SessionClass.pop = "0";
        }
    }

    private void insertCpoyDataBindOutgoingAgent()
    {
        EntityDataSourceOutgoingAgent.DataBind();
        GridViewOutgoingAgent.DataBind();
    }
    protected void EntityDataSourceOutgoingAgent_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        e.DataSource.Where = SQLHelper.whereStringLike(DatabaseConst.OutgoingAgent.agentName, TextBoxOutgoingAgent.Text);
    }
    protected void GridViewInsert_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void GridViewInsert_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        // Display whether the delete operation succeeded.
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