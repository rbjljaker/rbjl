using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageUtilities;

using System.Data.SqlClient;
using System.Web.DynamicData;
using System.Data;


public partial class Master_Referer : CultureEnabledPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "setMenu", "setCurrMenu(3);", true);
        if (!IsPostBack)
        {
            GridViewReferer.DataBind();
            //GridViewCopy.DataBind();
            GridViewCopypop.DataBind();
            ModalPopupExtendercopyfrompop.Hide();
            SessionClass.pop = "0";
        }
        else
        {
            GridviewHelper myGridHelper = new GridviewHelper();
            myGridHelper.GridPaging(GridViewReferer, e);
            //GridviewHelper myGridHelperDetails = new GridviewHelper();
            //myGridHelperDetails.GridPaging(GridViewCopy, e);
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
    protected void GridViewReferer_OnDataBound(object sender, EventArgs e)
    {
        GridviewHelper myGridHelper = new GridviewHelper();
        myGridHelper.GridPaging(sender, e);
    }

    protected void GridViewCopy_OnDataBound(object sender, EventArgs e)
    {
        GridviewHelper myGridHelper = new GridviewHelper();
        myGridHelper.GridPaging(sender, e);
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        EntityDataSourceReferer.ContextType = typeof(RBJLLawFirmDBModel.RBJLLawFirmDBEntities);
        EntityDataSourceOutgoingAgent.ContextType = EntityDataSourceRefererEdit.ContextType = EntityDataSourceClientInsert.ContextType = typeof(RBJLLawFirmDBModel.RBJLLawFirmDBEntities);

    }
    protected void LinkButtonAdd_Click(object sender, EventArgs e)
    {
        DetailsViewReferer.Visible = true;
        ModalPopupExtenderInsert.Show();
    }

    protected void btnCancel_OnClick(object sender, EventArgs e)
    {
    }


    protected void DetailsViewReferer_ItemInserted(object sender, EventArgs e)
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

    protected void GridViewReferer_SelectedIndexChanged(object sender, EventArgs e)
    {
        DetailsViewClientUpdate.PageIndex = GridViewReferer.PageIndex * GridViewReferer.PageSize + GridViewReferer.SelectedIndex;

    }


    //protected void LinkButtonCopyFrom_onclick(object sender, EventArgs e)
    //{
    //    GridViewCopy.Visible = true;
    //    GridViewReferer.Visible = false;
    //    //LinkButtonAdd.Visible = false;
    //    LinkButtonCopyFrom.Visible = false;

    //    DetailsViewReferer.Visible = true;

    //    LinkButtonRefresh.Visible = true;

    //}

    private void copyField(string des, string srcValue)
    {
        TextBox tb = (TextBox)Page.FindControl("ctl00$ContentPlaceHolderMainContent$DetailsViewReferer$__" + des + "$TextBox1");
        tb.Text = srcValue;
    }



    protected void GridViewInsert_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            int id = (int)(GridViewCopypop.DataKeys[rowIndex]["id"]);

            MaterItem dbConn = new MaterItem();
            var rlt = dbConn.getClient(id);


            copyField(DatabaseConst.REFERE.refererName, rlt.clientName);
            copyField(DatabaseConst.REFERE.billingAddressFirst, rlt.billingAddressFirst);
            copyField(DatabaseConst.REFERE.billingAddressSecond, rlt.billingAddressSecond);
            copyField(DatabaseConst.REFERE.correspondingAddress1First, rlt.correspondingAddress1First);
            copyField(DatabaseConst.REFERE.correspondingAddress1Second, rlt.correspondingAddress1Second);
            copyField(DatabaseConst.REFERE.correspondingAddress2First, rlt.correspondingAddress2First);
            copyField(DatabaseConst.REFERE.correspondingAddress2Second, rlt.correspondingAddress2Second);
            copyField(DatabaseConst.REFERE.contactPerson, rlt.contactPerson);
            copyField(DatabaseConst.REFERE.tel, rlt.tel);
            copyField(DatabaseConst.REFERE.fax, rlt.fax);
            copyField(DatabaseConst.REFERE.email, rlt.email);

            DetailsViewReferer.Visible = true;
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


    protected void DetailsViewReferer_OnItemInserting(object sender, DetailsViewInsertEventArgs e)
    {

        MatterInfo mI = new MatterInfo();
        e.Values[DatabaseConst.createDate] = DateTime.Now;
        e.Values[DatabaseConst.createByUserId] = mI.userGuid;

        e.Values[DatabaseConst.updateDate] = DateTime.Now;
        e.Values[DatabaseConst.updateByUserId] = mI.userGuid;


        TextBox tb = (TextBox)Page.FindControl("ctl00$ContentPlaceHolderMainContent$DetailsViewReferer$__refererNum$TextBox1");
        //tb.Text = tb.Text.ToUpper();


        MaterItem dbConn = new MaterItem();
        if (dbConn.cntReferNum(tb.Text) > 0)
        {


            //Response.Write("<script>alert('Client No. already exists!');</script>");
            displayAlert("Refer No. already exists!");

            tb.Text = "";


            e.Cancel = true;

            DetailsViewReferer.Visible = true;
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

    protected void Button_search_Click(object sender, EventArgs e)
    {
        insertCpoyDataBind();
    }

    private void insertCpoyDataBind()
    {
        EntityDataSourceClientInsert.DataBind();
        GridViewCopypop.DataBind();
    }
    protected void EntityDataSourceClientInsert_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        e.DataSource.Where = SQLHelper.whereStringLike(DatabaseConst.CLIENT.clientName, TextBoxClientName.Text);
    }
    protected void GridViewReferer_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            Control ctl = e.CommandSource as Control;
            GridViewRow CurrentRow = ctl.NamingContainer as GridViewRow;

            string feeTpye; feeTpye = GridViewReferer.DataKeys[CurrentRow.RowIndex].Value.ToString();
            EntityDataSourceRefererEdit.Where = "it.id =" + feeTpye;
            EntityDataSourceRefererEdit.DataBind();
            DetailsViewClientUpdate.DataBind();
        }
    }

    protected void ButtonSearchName_Click(object sender, EventArgs e)
    {
        EntityDataSourceReferer.DataBind();
        GridViewReferer.DataBind();
    }
    protected void EntityDataSourceReferer_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        string name = this.TextBoxName.Text;
        if (!String.IsNullOrEmpty(name))
        {
            e.DataSource.Where = SQLHelper.whereStringLikeStart(DatabaseConst.REFERE.refererName, name);
        }
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


            copyField(DatabaseConst.REFERE.refererName, rlt.agentName);
            copyField(DatabaseConst.REFERE.billingAddressFirst, rlt.correspondingAddress1First);
            copyField(DatabaseConst.REFERE.billingAddressSecond, rlt.correspondingAddress1Second);
            copyField(DatabaseConst.REFERE.correspondingAddress1First, rlt.correspondingAddress1First);
            copyField(DatabaseConst.REFERE.correspondingAddress1Second, rlt.correspondingAddress1Second);
            copyField(DatabaseConst.REFERE.correspondingAddress2First, rlt.correspondingAddress2First);
            copyField(DatabaseConst.REFERE.correspondingAddress2Second, rlt.correspondingAddress2Second);
            copyField(DatabaseConst.REFERE.contactPerson, rlt.contactPerson);
            copyField(DatabaseConst.REFERE.tel, rlt.tel);
            copyField(DatabaseConst.REFERE.fax, rlt.fax);
            copyField(DatabaseConst.REFERE.email, rlt.email);

            DetailsViewReferer.Visible = true;
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
    protected void GridViewReferer_RowDeleted(object sender, GridViewDeletedEventArgs e)
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