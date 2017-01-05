using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageUtilities;

public partial class DebitNote_DebitNote : CultureEnabledPage
{
    MatterInfo mI = new MatterInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "setMenu", "setCurrMenu(1);", true);
        if (!IsPostBack) { 
           // GridVieDebitNoteCore.DataBind();
        }
        else
        {
            GridviewHelper myGridHelper = new GridviewHelper();
            myGridHelper.GridPaging(GridVieDebitNoteCore, e);
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        EntityDataSourceDebitNoteCore.ContextType = typeof(RBJLLawFirmDBModel.RBJLLawFirmDBEntities);

    }
    protected void GridVieDebitNoteCore_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            Response.Redirect(String.Format("~/DebitNote/DebitNoteCore.aspx?matter={0}", e.CommandArgument));
        }
    }
    protected void Button_search_Click(object sender, EventArgs e)
    {
        dataBind();
    }
    protected void EntityDataSourceDebitNoteCore_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        string debitNoteNum = TextBoxDebitNoteNum.Text;
        var getMatterNum = TextBoxSearchMatterNum.Text;
        var getMatterId = mI.getMatterIdByMatterNum(getMatterNum);

        var sb = new System.Text.StringBuilder();

        if (!String.IsNullOrEmpty(debitNoteNum) && getMatterId.HasValue)
        {
            sb.Append(SQLHelper.whereString(DatabaseConst.DebitNoteCore.debitNoteNum, debitNoteNum));
            sb.Append(DatabaseConst.and);
            sb.Append(SQLHelper.whereStringLike(DatabaseConst.DebitNoteCore.matterNumIdList, getMatterId.Value.ToString()));

        }

        else if (String.IsNullOrEmpty(debitNoteNum) && getMatterId.HasValue)
        {
            sb.Append(SQLHelper.whereIsNotNull(DatabaseConst.DebitNoteCore.debitNoteNum));
            sb.Append(DatabaseConst.and);
            sb.Append(SQLHelper.whereStringLike(DatabaseConst.DebitNoteCore.matterNumIdList, getMatterId.Value.ToString()));
        }
        else if (!String.IsNullOrEmpty(debitNoteNum) && !getMatterId.HasValue)
        {
            sb.Append(SQLHelper.whereString(DatabaseConst.DebitNoteCore.debitNoteNum, debitNoteNum));
        }

        else
        {
            sb.Append(SQLHelper.whereIsNotNull(DatabaseConst.DebitNoteCore.debitNoteNum));
        }
        e.DataSource.Where = sb.ToString();

    }

    private void dataBind()
    {
        EntityDataSourceDebitNoteCore.DataBind();
        GridVieDebitNoteCore.DataBind();
    }
    protected void GridVieDebitNoteCore_DataBound(object sender, EventArgs e)
    {
        GridviewHelper myGridHelper = new GridviewHelper();
        myGridHelper.GridPaging(sender, e);
    }
    protected void GridVieDebitNoteCore_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}