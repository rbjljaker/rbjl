using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RBJLLawFirmDBModel;

public partial class WebControl_DDLReferer : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        EntityDataSource1.DataBind();
        DropDownList1.DataBind();
    }
    protected void EntityDataSource1_QueryCreated(object sender, QueryCreatedEventArgs e)
    {
        IQueryable<Referer> re = e.Query.Cast<Referer>() as IQueryable<Referer>;
        //MaterItem mi = new MaterItem();
        //e.Query = mi.getReferer(re, CheckBox1.Checked);
    }


    public string DDLId
    {
        get
        {
            try { return DropDownList1.SelectedValue; }
            catch { return null; }
        }
        set { DropDownList1.SelectedValue = value; }
    }

    public string DDLText
    {
        get
        {
            try { return DropDownList1.SelectedItem.Text; }
            catch { return null; }
        }
        set { DropDownList1.SelectedItem.Text = value; }
    }
}