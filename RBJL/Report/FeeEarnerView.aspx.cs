using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
using GeneralUtilities;

public partial class Report_FeeEarnerView : System.Web.UI.Page
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
        var findMatter = rI.findMatterReport();

        string getDate = Request[QueryStringConst.date];
        string getDateTo = Request[QueryStringConst.dateTo];

        string getFee = Request[QueryStringConst.feeEarner];
        string getClient = Request[QueryStringConst.client];
        string getId = Request[QueryStringConst.matter];
        string description = Request[QueryStringConst.description];

        string getReferer = Request[QueryStringConst.referer];
        string getJobType = Request[QueryStringConst.jobType];

        string billable = Request[QueryStringConst.billable];


        if (getDate != null)
        {
            rI.findMatterReportByDate(ref findMatter, getDate, getDateTo);
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

        if (getReferer != null)
        {
            rI.findMatterReportByRefererId(ref findMatter, getReferer);
        }
        if (getJobType != null)
        {
            rI.findMatterReportByJobType(ref findMatter, getJobType);
        }


        if (billable != null)
        {
            rI.findFeeEarnerReportByBillableOrNonBillable(ref findMatter, billable);
        }



        string header = FeeEarnerReport.setHr();
        DataTable dt = DataTableHelper.CreateDataTable(header);

        //var bgList = getBgImg();

        int count = 1;

        string img = "";

        foreach (var item in findMatter)
        {
            //foreach (var bg in bgList)
            //{
            img = getImg(item.logo);
            string[] strList = new string[dt.Columns.Count];
            strList[0] = count.ToString();
            strList[1] = item.id.ToString();
            strList[2] = String.Format("{0} {1} - {2}", item.matterNum, item.clientName, item.matterSubject);
            strList[3] = img;
            strList[4] = String.IsNullOrEmpty(img) ? "true" : "false";

            string dTableValue = DataTableHelper.joinArrayToString(strList);
            DataTableHelper.CreateDataRow(ref dt, dTableValue);
            count++;
            //}
        }

        ReportDataSource re = new ReportDataSource("DataSetDebitFeeEarnerHr", dt);
        ReportViewerFeeEarner.LocalReport.DataSources.Clear();
        ReportViewerFeeEarner.LocalReport.DataSources.Add(re);
        ReportViewerFeeEarner.LocalReport.EnableExternalImages = true;

        description = String.IsNullOrEmpty(description) ? "true" : "false";
        ReportViewerFeeEarner.LocalReport.SetParameters(new ReportParameter("setDescriptionHrVisable", description));

        img = String.IsNullOrEmpty(img) ? "false" : "false";
        ReportViewerFeeEarner.LocalReport.SetParameters(new ReportParameter("setImageHr", img));

        ReportViewerFeeEarner.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
        ReportViewerFeeEarner.LocalReport.Refresh();
    }

    void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
    {
        // get empID from the parameters
        string matterId = (e.Parameters[0].Values[0]);

        var findTimeEntry = rI.findTimeEntryByMatterId(matterId);

        string billOrUnbill = Request[QueryStringConst.billOrUnbill];
        if (billOrUnbill != null)
        {
            rI.findTimeEntryByIsBillOrUnbill(ref findTimeEntry, billOrUnbill);

        }

        //string header = FeeEarnerReport.setContentHr();
        //DataTable dt = DataTableHelper.CreateDataTable(header);

        List<ReportFeeEarner> resultList = new List<ReportFeeEarner>();

        double tempTotal = 0;
        foreach (var item in findTimeEntry)
        {
            if (item.timespan.HasValue)
            {
                if (item.hourlyRateH.HasValue)
                {
                    var total = item.timespan.Value * item.hourlyRateH.Value;
                    tempTotal += total;
                }
            }

        }
        string setTotal = String.Format("HK${0}", tempTotal);


        foreach (var item in findTimeEntry)
        {
            var checkIsBillable = true;
            ReportFeeEarner tempList = new ReportFeeEarner();
            tempList.matterIdContent = matterId;
            tempList.item = Convert.ToString(item.itemNum);
            tempList.date = DateTimeHelper.convertDateTimeToString(item.date.Value);
            tempList.description = item.description;
            tempList.feeEarner = rI.getUserNameBySystemId(item.feeEarner.Value);

            tempList.bill = setTotal;

            tempList.isBilled = item.isEnable.HasValue ? item.isEnable.Value : false;
            if (item.timespan.HasValue)
            {
                tempList.timeSpent = Convert.ToString(item.timespan.Value);
                if (item.hourlyRateH.HasValue)
                {
                    var total = item.timespan.Value * item.hourlyRateH.Value;
                    //if (item.isEnable.Value)
                    //{
                    //    tempList.unbill = String.Format("HK${0}", total);
                    //}
                    //else
                    //{
                    //    tempList.bill = String.Format("HK${0}", total);
                    //}



                    tempList.nonBillable = String.Format("HK${0}", total);
                }
            }
            resultList.Add(tempList);

            //string[] strList = new string[dt.Columns.Count];
            //strList[0] = matterId;
            //strList[1] = Convert.ToString(item.itemNum);
            //strList[2] = DateTimeHelper.convertDateTimeToString(item.date.Value);
            //strList[3] = item.description;
            //strList[4] = rI.getUserNameBySystemId(item.feeEarner.Value);
            //strList[5] = Convert.ToString(item.timespan);
            //string dTableValue = DataTableHelper.joinArrayToString(strList);
            //DataTableHelper.CreateDataRow(ref dt, dTableValue);
        }
        var result = ListToDataTableHelper.ConvertToDataTable(resultList);
        ReportDataSource re = new ReportDataSource("DataSetDebitFeeEarnerContent", result);
        e.DataSources.Clear();
        e.DataSources.Add(re);
    }

    private string getImg(string item)
    {

        string tempImage = "";
        if (!String.IsNullOrEmpty(item))
        {
            var findlogo = item.Substring(1, item.Length - 1);
            tempImage = String.Format("{0}{1}{2}", HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority), HttpRuntime.AppDomainAppVirtualPath, findlogo);
        }
        return tempImage;
    }

}