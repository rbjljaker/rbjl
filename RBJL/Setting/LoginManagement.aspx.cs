using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageUtilities;

public partial class Setting_LoginManagement : CultureEnabledPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void DropDownList1_DataBound(object sender, EventArgs e)
    {
        DropDownList1.Items.Insert(0, new ListItem("All", ""));
        DropDownList1.SelectedIndex = 0;
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string username = ((Label)GridView1.Rows[e.NewEditIndex].Cells[1].FindControl("Label1")).Text;
        Response.Redirect("UserManagement.aspx?user=" + username);
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridViewRow commandRow = e.Row;

            DataControlFieldCell cell = (DataControlFieldCell)commandRow.Controls[0];
            foreach (Control ctl in cell.Controls)
            {
                LinkButton link = ctl as LinkButton;
                if (link != null)
                {
                    if (link.CommandName == "Delete")
                    {
                        link.OnClientClick = "return confirm('" + "del?" + "')";
                    }
                }
            }
        }
    }
}