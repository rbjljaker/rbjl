using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using GeneralUtilities;
using Microsoft.Reporting.WebForms;

public partial class Report_PutAwayView : System.Web.UI.Page
{
    ReportInfo rI = new ReportInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindReport();
        }
    }


    private void bindReport()
    {

        var findMatter = getPageData();

        string header = PutAwayReport.setHr();
        DataTable dt = DataTableHelper.CreateDataTable(header);

        var putAwayList = rI.findPutAwayReportPutAwayNum(findMatter);

        int count = 1;
        foreach (var item in putAwayList)
        {
            string[] strList = new string[dt.Columns.Count];
            strList[0] = count.ToString();
            strList[1] = item;
            strList[2] = String.Format("Put Away Box No.:{0}", item);
            string dTableValue = DataTableHelper.joinArrayToString(strList);
            DataTableHelper.CreateDataRow(ref dt, dTableValue);
            count++;
        }

        ReportDataSource re = new ReportDataSource("DataSetPutAwayReportHr", dt);
        ReportViewerPutAwayView.LocalReport.DataSources.Clear();
        ReportViewerPutAwayView.LocalReport.DataSources.Add(re);
        ReportViewerPutAwayView.LocalReport.EnableExternalImages = true;

        ReportViewerPutAwayView.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
        ReportViewerPutAwayView.LocalReport.Refresh();
    }



    void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
    {
        string putAwayNum = (e.Parameters[0].Values[0]);

        var findMatterInfo = getPageData();

        var result = rI.findPutAwayResult(findMatterInfo, putAwayNum);

        //string header = PutAwayReport.setContentHr();
        //DataTable dt = DataTableHelper.CreateDataTable(header);

        //foreach (var item in result)
        //{
        //    string[] strList = new string[dt.Columns.Count];
        //    strList[0] = putAwayNum;
        //    strList[1] = item.mattererNum;
        //    strList[2] = item.client;
        //    strList[3] = item.subjectMatter;
        //    strList[4] = item.files;
        //    strList[5] = putAwayNum;
        //    string dTableValue = DataTableHelper.joinArrayToString(strList);
        //    DataTableHelper.CreateDataRow(ref dt, dTableValue);

        //}

        DataTable dt = ListToDataTableHelper.ConvertToDataTable(result);

        ReportDataSource re = new ReportDataSource("DataSetPutAway", dt);
        e.DataSources.Clear();
        e.DataSources.Add(re);
    }

    private IQueryable<RBJLLawFirmDBModel.View_FindMatter> getPageData()
    {
        var findMatter = rI.findPutAwayReport();

        string getDate = Request[QueryStringConst.date];
        string getDateTo = Request[QueryStringConst.dateTo];
        string getFee = Request[QueryStringConst.feeEarner];
        string getClient = Request[QueryStringConst.client];
        string getId = Request[QueryStringConst.matter];

        string getSubject = Request[QueryStringConst.subject];
        string getJobType = Request[QueryStringConst.jobType];

        if (getDate != null)
        {
            rI.findPutAwayReportByDate(ref findMatter, getDate, getDateTo);
        }
        if (getFee != null)
        {
            rI.findMatterReportByFeeEarner(ref findMatter, getFee);
        }

        if (getClient != null)
        {
            rI.findFeeEarnerReportByClient(ref findMatter, getClient);
        }

        if (getId != null)
        {
            rI.findMatterReportById(ref findMatter, getId);
        }

        if (getSubject != null)
        {
            rI.findMatterReportBySubject(ref findMatter, getSubject);
        }

        if (getJobType != null)
        {
            rI.findMatterReportByJobType(ref findMatter, getJobType);
        }

        return findMatter;
    }
}