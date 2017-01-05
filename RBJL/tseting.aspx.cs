using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class tseting : System.Web.UI.Page
{
    MatterInfo mI = new MatterInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        //var result = Roles.GetUsersInRole(UserLevelConst.GeneralUser);
        //  FileUpload1.


        //TimeEntryInfo tei = new TimeEntryInfo("admin");
        //var result = tei.getOldTimeEntry();
        //Repeater1.DataSource = result;
        //Repeater1.DataBind();


        //FormsAuthentication.RedirectFromLoginPage("admin", false);
    }


    protected void Page_Init(object sender, EventArgs e)
    {
        //EntityDataSourceClientInsert.ContextType = typeof(RBJLLawFirmDBModel.RBJLLawFirmDBEntities);
    }


    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    EmailHelper eh = new EmailHelper();
    //    eh.sendEmail();
    //}

    //protected void Button2_Click(object sender, DirectEventArgs e)
    //{
    //    this.Window1.Show();
    //}
    protected void Button1_Click(object sender, EventArgs e)
    {
        double?[] doubles = { 1.7, 2.3, 1.9, null, 4.1, 2.9, null };

        var sortedDoubles =
            from d in doubles
            orderby d descending
            select d;

        Console.WriteLine("The doubles from highest to lowest:");
        foreach (var d in sortedDoubles)
        {
            Console.WriteLine(d);
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        //DBEntity dbe = new DBEntity("admin");
        //var findTimeEntrty = dbe.db.View_TimeEntryInfo.OrderBy(q => q.debitNoteId);
        //System.Text.StringBuilder sb = new System.Text.StringBuilder();

        //foreach (var item in findTimeEntrty)
        //{
        //    sb.AppendLine(String.Format("{0} {1} {2} {3} {4} {5}", item.debitNoteId, item.debitNoteType, item.timespan, item.description, item.matterDetailsId, item.matterId));

        //    sb.AppendLine("<br/><br/>");
        //}
        //Response.Write(sb.ToString());
    }
    protected void Button3_Click(object sender, EventArgs e)
    {

    }

    protected void EntityDataSourceMatterDebitNoteDetails_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        //e.DataSource.Where = "it.id = GUID'A4EC2981-39CE-42C5-9111-0081A7BFA75A'";

        //e.DataSource.Where = "it.matterId = GUID'" + Request[QueryStringConst.matter] + "'";

        //e.DataSource.Where = "it.matterNumIdList like '%" + Request[QueryStringConst.matter] + "%'";
    }
    protected void EntityDataSourceMatterDebitNoteDetails_QueryCreated(object sender, QueryCreatedEventArgs e)
    {

    }
    protected void GridViewMatterDebitNoteDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GridViewMatterDebitNoteDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }


    protected void EntityDataSourceClientInsert_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {

    }

    protected void EntityDataSourceMatter_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        //if (EnumUserLevel.administrator == mI.userLevel || EnumUserLevel.account == mI.userLevel)
        //{
        //    e.DataSource.Where = mI.findCurrMatterAdmin();
        //}
        //else
        //{
        //    e.DataSource.Where = mI.findCurrMatter();
        //}
    }
    protected void EntityDataSource1_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        e.DataSource.Where = mI.findCurrMatterAdmin();
    }
}