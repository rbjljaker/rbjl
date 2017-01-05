using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageUtilities;
using RBJLLawFirmDBModel;

public partial class Report_exportMatter : CultureEnabledPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Write();

        int gvCount = GridView1.Rows.Count;
        if (gvCount > 0)
        {
            exportToExcel();
        }
        else
        {
            Label1.Visible = true;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        // '處理'GridView' 的控制項 'GridView' 必須置於有 runat=server 的表單標記之中   
    }

    private void exportToExcel()
    {
        Response.ClearContent();
        Response.Write("<meta http-equiv=Content-Type content=text/html;charset=utf-8>");
        string excelFileName = String.Format("matter_{0:yyyyMMdd}.xls", DateTime.Now);
        Response.AddHeader("content-disposition", "attachment;filename=" + Server.UrlEncode(excelFileName));
        Response.ContentType = "application/excel";
        GridView1.AllowPaging = false;
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        GridView1.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }
    protected void EntityDataSource1_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        var date = Request[QueryStringConst.date];
        var dateTo = Request[QueryStringConst.dateTo];

        MatterInfo mI = new MatterInfo();
        e.DataSource.Where = mI.findCurrMatterAdmin();

        //var allMatterQ = mI.findCurrMatterAdmin();
        //if (date != null && dateTo != null)
        //{
        //    e.DataSource.Where = allMatterQ;
        //}
        //else
        //{
        //    e.DataSource.Where = allMatterQ;
        //}
        //e.DataSource.Where = SQLHelper.whereString(DatabaseConst.ViewFindMatter.status, "44");
    }
    protected void EntityDataSource1_QueryCreated(object sender, QueryCreatedEventArgs e)
    {
        var date = Request[QueryStringConst.date];
        var dateTo = Request[QueryStringConst.dateTo];

        if (date != null && dateTo != null)
        {
            var dt = DateTimeHelper.convertStringToDateTime(date);
            var dtE = DateTimeHelper.convertStringToDateTime(dateTo).AddMinutes(-1);

            IQueryable<View_ExportMatter> vF = e.Query.Cast<View_ExportMatter>() as IQueryable<View_ExportMatter>;
            var result = from q in vF
                         where q.fileOpenDate <= dtE && q.fileOpenDate >= dt
                         select q;
            e.Query = result;
        }
    }
}