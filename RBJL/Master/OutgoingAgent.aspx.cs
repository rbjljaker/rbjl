using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageUtilities;

public partial class Master_OutgoingAgent : CultureEnabledPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "setMenu", "setCurrMenu(3);", true);
        if (!IsPostBack)
        {
            GridViewOutgoingAgent.DataBind();
            GridViewCopypop.DataBind();
            ModalPopupExtendercopyfrompop.Hide();
            SessionClass.pop = "0";
        }
        else
        {
            GridviewHelper myGridHelper = new GridviewHelper();
            myGridHelper.GridPaging(GridViewOutgoingAgent, e);

            //GridviewHelper myGridHelperDetails = new GridviewHelper();
            //myGridHelperDetails.GridPaging(GridViewCopy, e);
            GridviewHelper myGridHelperGridViewCopypop = new GridviewHelper();
            myGridHelperGridViewCopypop.GridPaging(GridViewCopypop, e);
            myGridHelperGridViewCopypop.GridPaging(GridViewPopupCopyClient, e);
            if (SessionClass.pop == "1")
            {
                ModalPopupExtendercopyfrompop.Show();
            }
            else if (SessionClass.pop == "2")
            {
                ModalPopupExtendercopyfrompopClient.Show();
            }
        }
    }
    protected void GridViewOutgoingAgent_OnDataBound(object sender, EventArgs e)
    {
        GridviewHelper myGridHelper = new GridviewHelper();
        myGridHelper.GridPaging(sender, e);
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        EntityDataSourcePopupCopyClient.ContextType = EntityDataSourceOutgoingAgentEdit.ContextType = EntityDataSourceReferer.ContextType = EntityDataSourceOutgoingAgent.ContextType = typeof(RBJLLawFirmDBModel.RBJLLawFirmDBEntities);

    }

    protected void DetailsViewOutgoingAgent_ItemInserted(object sender, EventArgs e)
    {
        redirectPageAndDisplayAlert("OK", Request.Url.AbsolutePath);
    }

    protected void LinkButtonAdd_Click(object sender, EventArgs e)
    {
        DetailsViewOutgoingAgent.Visible = true;
        ModalPopupExtenderInsert.Show();

    }

    protected void LinkButtonEditPopup_Click(object sender, EventArgs e)
    {
        DetailsViewClientUpdate.Visible = true;
        ModalPopupExtenderEdit.Show();

    }

    protected void GridViewOutgoingAgent_SelectedIndexChanged(object sender, EventArgs e)
    {
        DetailsViewClientUpdate.PageIndex = GridViewOutgoingAgent.PageIndex * GridViewOutgoingAgent.PageSize + GridViewOutgoingAgent.SelectedIndex;
    }
    protected void DetailsViewOutgoingAgent_OnItemInserting(object sender, DetailsViewInsertEventArgs e)
    {

        MatterInfo mI = new MatterInfo();
        e.Values[DatabaseConst.createDate] = DateTime.Now;
        e.Values[DatabaseConst.createByUserId] = mI.userGuid;

        e.Values[DatabaseConst.updateDate] = DateTime.Now;
        e.Values[DatabaseConst.updateByUserId] = mI.userGuid;


        TextBox tb = (TextBox)Page.FindControl("ctl00$ContentPlaceHolderMainContent$DetailsViewOutgoingAgent$__agentNum$TextBox1");
        //tb.Text = tb.Text.ToUpper();


        MaterItem dbConn = new MaterItem();
        if (dbConn.cntOutgoingNum(tb.Text) > 0)
        {


            //Response.Write("<script>alert('Client No. already exists!');</script>");
            displayAlert("OutgoingAgent No. already exists!");

            tb.Text = "";


            e.Cancel = true;

            DetailsViewOutgoingAgent.Visible = true;
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
        TextBoxReferName.Text = "";
        insertCpoyDataBind();
        SessionClass.pop = "1";
    }

    protected void DetailsViewClientUpdate_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        redirectPageAndDisplayAlert("OK", Request.Url.AbsolutePath);
    }

    private void insertCpoyDataBind()
    {
        EntityDataSourceReferer.DataBind();
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
            var rlt = dbConn.getReferer(id);


            copyField(DatabaseConst.OutgoingAgent.agentName, rlt.refererName);
            //copyField(DatabaseConst.OutgoingAgent.billingAddressFirst, rlt.billingAddressFirst);
            //copyField(DatabaseConst.OutgoingAgent.billingAddressSecond, rlt.billingAddressSecond);
            copyField(DatabaseConst.OutgoingAgent.correspondingAddress1First, rlt.correspondingAddress1First);
            copyField(DatabaseConst.OutgoingAgent.correspondingAddress1Second, rlt.correspondingAddress1Second);
            copyField(DatabaseConst.OutgoingAgent.correspondingAddress2First, rlt.correspondingAddress2First);
            copyField(DatabaseConst.OutgoingAgent.correspondingAddress2Second, rlt.correspondingAddress2Second);
            copyField(DatabaseConst.OutgoingAgent.contactPerson, rlt.contactPerson);
            copyField(DatabaseConst.OutgoingAgent.tel, rlt.tel);
            copyField(DatabaseConst.OutgoingAgent.fax, rlt.fax);
            copyField(DatabaseConst.OutgoingAgent.email, rlt.email);

            // DetailsViewReferer.Visible = true;
            ModalPopupExtenderInsert.Show();

            ModalPopupExtendercopyfrompop.Hide();
            SessionClass.pop = "0";


        }
    }

    private void copyField(string des, string srcValue)
    {
        TextBox tb = (TextBox)Page.FindControl("ctl00$ContentPlaceHolderMainContent$DetailsViewOutgoingAgent$__" + des + "$TextBox1");
        tb.Text = srcValue;
    }
    protected void LinkButtonRefresh_Click(object sender, EventArgs e)
    {
        redirectCurrentlyPage();
    }

    protected void EntityDataSourceReferer_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        e.DataSource.Where = SQLHelper.whereStringLike(DatabaseConst.REFERE.refererName, TextBoxReferName.Text);
    }

    protected void GridViewOutgoingAgent_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            Control ctl = e.CommandSource as Control;
            GridViewRow CurrentRow = ctl.NamingContainer as GridViewRow;

            string feeTpye; feeTpye = GridViewOutgoingAgent.DataKeys[CurrentRow.RowIndex].Value.ToString();
            EntityDataSourceOutgoingAgentEdit.Where = "it.id =" + feeTpye;
            EntityDataSourceOutgoingAgentEdit.DataBind();
            DetailsViewClientUpdate.DataBind();
        }
    }
    protected void EntityDataSourceOutgoingAgent_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        string name = this.TextBoxName.Text;
        if (!String.IsNullOrEmpty(name))
        {
            e.DataSource.Where = SQLHelper.whereStringLikeStart(DatabaseConst.OutgoingAgent.agentName, name);
        }
    }
    protected void ButtonSearchName_Click(object sender, EventArgs e)
    {
        EntityDataSourceOutgoingAgent.DataBind();
        GridViewOutgoingAgent.DataBind();
    }



    protected void LinkButtonRefreshClient_Click(object sender, EventArgs e)
    {
        redirectCurrentlyPage();
    }

    protected void ButtonOutgoingAgentSearch_Click(object sender, EventArgs e)
    {
        insertCpoyDataBind();
    }

    private void insertCpoyDataBindClient()
    {
        EntityDataSourcePopupCopyClient.DataBind();
        GridViewPopupCopyClient.DataBind();
    }
    protected void EntityDataSourcePopupCopyClient_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        string name = this.TextBoxClientName.Text;
        if (!String.IsNullOrEmpty(name))
        {
            e.DataSource.Where = SQLHelper.whereStringLikeStart(DatabaseConst.CLIENT.clientName, name);
        }
    }

    protected void ButtonClientCopyForm_Click(object sender, EventArgs e)
    {
        ModalPopupExtendercopyfrompopClient.Show();
        TextBoxClientName.Text = "";
        insertCpoyDataBindClient();
        SessionClass.pop = "2";
    }
    protected void ButtonClientSearchName_Click(object sender, EventArgs e)
    {
        insertCpoyDataBindClient();
    }


    protected void GridViewClientInsert_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            int id = (int)(GridViewPopupCopyClient.DataKeys[rowIndex]["id"]);

            MaterItem dbConn = new MaterItem();
            var rlt = dbConn.getClient(id);


            copyField(DatabaseConst.OutgoingAgent.agentName, rlt.clientName);
            //copyField(DatabaseConst.OutgoingAgent.billingAddressFirst, rlt.billingAddressFirst);
            //copyField(DatabaseConst.OutgoingAgent.billingAddressSecond, rlt.billingAddressSecond);
            copyField(DatabaseConst.OutgoingAgent.correspondingAddress1First, rlt.correspondingAddress1First);
            copyField(DatabaseConst.OutgoingAgent.correspondingAddress1Second, rlt.correspondingAddress1Second);
            copyField(DatabaseConst.OutgoingAgent.correspondingAddress2First, rlt.correspondingAddress2First);
            copyField(DatabaseConst.OutgoingAgent.correspondingAddress2Second, rlt.correspondingAddress2Second);
            copyField(DatabaseConst.OutgoingAgent.contactPerson, rlt.contactPerson);
            copyField(DatabaseConst.OutgoingAgent.tel, rlt.tel);
            copyField(DatabaseConst.OutgoingAgent.fax, rlt.fax);
            copyField(DatabaseConst.OutgoingAgent.email, rlt.email);

            // DetailsViewReferer.Visible = true;
            ModalPopupExtenderInsert.Show();

            ModalPopupExtendercopyfrompopClient.Hide();
            SessionClass.pop = "0";


        }
    }

    protected void GridViewCopyClient_OnDataBound(object sender, EventArgs e)
    {
        GridviewHelper myGridHelper = new GridviewHelper();
        myGridHelper.GridPaging(sender, e);
    }
    protected void GridViewOutgoingAgent_RowDeleted(object sender, GridViewDeletedEventArgs e)
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