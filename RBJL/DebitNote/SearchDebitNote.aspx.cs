using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageUtilities;

public partial class DebitNote_SearchDebitNote : CultureEnabledPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "setMenu", "setCurrMenu(1);", true);
    }
    protected void GridViewDebitnote_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            SessionClass.Debitnoteid = Convert.ToString(GridViewDebitnote.DataKeys[rowIndex].Value);
            //SessionClass.MatterId = Convert.ToString(GridViewDebitnote.Rows[rowIndex].Cells[2].Text);
            Response.Redirect(String.Format("DetailsDebitnote.aspx?matter={0}", Convert.ToString(GridViewDebitnote.Rows[rowIndex].Cells[2].Text)));
        }

    }
}